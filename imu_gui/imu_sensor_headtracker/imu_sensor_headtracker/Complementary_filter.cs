using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMU_sensor_headtracker
{
    public class Complementary_filter
    {

        public float[] gyro_rate = { 0, 0, 0 };
        public float[] gyro_angle = { 0, 0, 0 };
        public float[] acc_angle = { 0, 0, 0 };

        public float gyro_DT=0.0f;
        public float[] comp_filter_angles = { 0, 0, 0 };

        public const float G_GAIN = 55f;//0.00875f;
        public const float M_PI = 3.1415926535897f;
        public const float RAD_TO_DEG = 57.29578f; 
        public const float AA = 0.95f;

        float[] temp1 = new float[3];
        float[] temp2 = new float[3];
        float[] xAxis = { 1.0f, 0.0f, 0.0f };

        public void read_gyro(float[] gyroscope, float DT)
        {
            //Convert Gyro raw to degrees per second
            gyro_rate[0] = gyroscope[0] * G_GAIN;
            gyro_rate[1] = -gyroscope[1] * G_GAIN;
            gyro_rate[2] = gyroscope[2] * G_GAIN;

            gyro_DT = DT;

            //Calculate the angles from the gyro
            gyro_angle[0] += gyro_rate[0] * gyro_DT;
            gyro_angle[1] += gyro_rate[1] * gyro_DT;
            gyro_angle[2] += gyro_rate[2] * gyro_DT;

        } 

        public void calculate_angles_acc(float[] accelerometer) // + M_PI
        {
            acc_angle[0] = (float)(Math.Atan2(accelerometer[1], accelerometer[2])) * RAD_TO_DEG + M_PI;
            acc_angle[1] = (float)(Math.Atan2(accelerometer[0], accelerometer[2])) * RAD_TO_DEG + M_PI;
        }

        public void complementary_filter()
        {
            comp_filter_angles[0] = AA * (comp_filter_angles[0] + gyro_rate[0] * gyro_DT) + (1 - AA) * acc_angle[0];
            comp_filter_angles[1] = AA * (comp_filter_angles[1] + gyro_rate[1] * gyro_DT) + (1 - AA) * acc_angle[1];

        }


        public void complementary_filter_yaw(float[] accelerometer, float[] magnetometer)
        {

            float[] acc_norm = { 0, 0, 0 };
            float[] mag_tilt_compensation = { 0, 0, 0 };

            //nomarlizar
            acc_norm[0] = accelerometer[0] / (float)Math.Sqrt(accelerometer[0] * accelerometer[0] + accelerometer[1] * accelerometer[1] + accelerometer[2] * accelerometer[2]);
            acc_norm[1] = accelerometer[1] / (float)Math.Sqrt(accelerometer[0] * accelerometer[0] + accelerometer[1] * accelerometer[1] + accelerometer[2] * accelerometer[2]);

            /////pitch e roll
            // pitch = asin(accXnorm);
            // roll = -asin(accYnorm / cos(pitch));

            //float pitch = (float)-Math.Atan2(accelerometer[0], Math.Sqrt(accelerometer[1] * accelerometer[1] + accelerometer[2] * accelerometer[2]));
            //Matematica.Vector_Cross_Product(ref temp1, accelerometer, xAxis);
            //Matematica.Vector_Cross_Product(ref temp2, xAxis, temp1);
            //float roll = (float)Math.Atan2(temp2[1], temp2[2]);
            
            float pitch = (float)Math.Asin(acc_norm[0]);
            float roll = (float)Math.Asin(acc_norm[1] / Math.Cos(pitch));

            //*mag_raw * cos(pitch) + *(mag_raw + 2) * sin(pitch);
            mag_tilt_compensation[0] = magnetometer[0] * (float)Math.Cos(pitch) + magnetometer[2] * (float)Math.Sin(pitch);

            //*mag_raw * sin(roll) * sin(pitch) + *(mag_raw + 1) * cos(roll) - *(mag_raw + 2) * sin(roll) * cos(pitch);
            mag_tilt_compensation[1] = magnetometer[0] * (float)Math.Sin(roll) * (float)Math.Sin(pitch) + magnetometer[1] * (float)Math.Cos(roll) - magnetometer[2] * (float)Math.Sin(roll) * (float)Math.Cos(pitch);

            //YAW
            float yaw = Matematica.Deg((float)Math.Atan2(-mag_tilt_compensation[1], mag_tilt_compensation[0]));

            comp_filter_angles[2] = AA * (comp_filter_angles[2] + gyro_rate[2] * gyro_DT) + (1 - AA) * yaw;
        }

    }
}
