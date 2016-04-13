using System;
using System.Globalization;

namespace IMU_sensor_headtracker
{
    class Sensors
    {
        //parâmetros para calibração (acc, mag)
        //public const float accel_x_min = -9.75f;
        //public const float accel_x_max = 9.85f;
        //public const float accel_y_min = -10.30f;
        //public const float accel_y_max = 9.45f;
        //public const float accel_z_min = -9.90f;
        //public const float accel_z_max = 9.85f;

        //public const float mag_x_min = -32.0f;
        //public const float mag_x_max = 26.0f;
        //public const float mag_y_min = -34.0f;
        //public const float mag_y_max = 28.0f;
        //public const float mag_z_min = -17.0f;
        //public const float mag_z_max = 39.0f;

        //parâmetros para calibração (acc, mag) - usando config file
        public static float accel_x_min = Properties.Settings.Default.acc_x_min;
        public static float accel_x_max = Properties.Settings.Default.acc_x_max;
        public static float accel_y_min = Properties.Settings.Default.acc_y_min;
        public static float accel_y_max = Properties.Settings.Default.acc_y_max;
        public static float accel_z_min = Properties.Settings.Default.acc_z_min;
        public static float accel_z_max = Properties.Settings.Default.acc_z_max; 

        public static float gyro_average_offset_x = Properties.Settings.Default.gyro_x_offset;
        public static float gyro_average_offset_y = Properties.Settings.Default.gyro_y_offset;
        public static float gyro_average_offset_z = Properties.Settings.Default.gyro_z_offset;

        public static float mag_x_min = Properties.Settings.Default.mag_x_min;
        public static float mag_x_max = Properties.Settings.Default.mag_x_max;
        public static float mag_y_min = Properties.Settings.Default.mag_y_min;
        public static float mag_y_max = Properties.Settings.Default.mag_y_max;
        public static float mag_z_min = Properties.Settings.Default.mag_z_min;
        public static float mag_z_max = Properties.Settings.Default.mag_z_max;


        public const float gravity = 256f; //9.80665f; //256f // "1G reference" used for DCM filter and accelerometer calibration

        public const float gyro_ganho = 55f;//0.06957f; // Gain for gyroscope
        public static float gyro_ganho_radians(float x) { return (x * Matematica.Rad(gyro_ganho)); } //Aplicar ganho em radianos no gyro;

        public static void read_sensors(string[] raw_data, ref float[] accelerometer, ref float[] magnetometer, ref float[] gyroscope)
        {

            accelerometer[0] = float.Parse(raw_data[1], CultureInfo.InvariantCulture.NumberFormat);
            accelerometer[1] = float.Parse(raw_data[2], CultureInfo.InvariantCulture.NumberFormat);
            accelerometer[2] = float.Parse(raw_data[3], CultureInfo.InvariantCulture.NumberFormat);

            magnetometer[0] = float.Parse(raw_data[4], CultureInfo.InvariantCulture.NumberFormat);
            magnetometer[1] = float.Parse(raw_data[5], CultureInfo.InvariantCulture.NumberFormat);
            magnetometer[2] = float.Parse(raw_data[6], CultureInfo.InvariantCulture.NumberFormat);

            gyroscope[0] = float.Parse(raw_data[7], CultureInfo.InvariantCulture.NumberFormat);
            gyroscope[1] = float.Parse(raw_data[8], CultureInfo.InvariantCulture.NumberFormat);
            gyroscope[2] = float.Parse(raw_data[9], CultureInfo.InvariantCulture.NumberFormat);

            //accelerometer[0] = float.Parse(raw_data[1], CultureInfo.InvariantCulture.NumberFormat);
            //accelerometer[1] = float.Parse(raw_data[2], CultureInfo.InvariantCulture.NumberFormat);
            //accelerometer[2] = float.Parse(raw_data[3], CultureInfo.InvariantCulture.NumberFormat);

            //magnetometer[0] = float.Parse(raw_data[7], CultureInfo.InvariantCulture.NumberFormat);
            //magnetometer[1] = float.Parse(raw_data[8], CultureInfo.InvariantCulture.NumberFormat);
            //magnetometer[2] = float.Parse(raw_data[9], CultureInfo.InvariantCulture.NumberFormat);

            //gyroscope[0] = float.Parse(raw_data[4], CultureInfo.InvariantCulture.NumberFormat);
            //gyroscope[1] = float.Parse(raw_data[5], CultureInfo.InvariantCulture.NumberFormat);
            //gyroscope[2] = float.Parse(raw_data[6], CultureInfo.InvariantCulture.NumberFormat);


        }


        public static ulong read_timestamp(string[] raw_data)
        {
            return ulong.Parse(raw_data[0], CultureInfo.InvariantCulture.NumberFormat);
        }

      
        public static float bussola(float[] magnetometer, float pitch, float roll)
        {

            float cos_roll = (float)Math.Cos(roll);
            float sin_roll = (float)Math.Sin(roll);
            float cos_pitch = (float)Math.Cos(pitch);
            float sin_pitch = (float)Math.Sin(pitch);

            // Tilt compensated magnetic field X
            float mag_x = magnetometer[0] * cos_pitch + magnetometer[1] * sin_roll * sin_pitch + magnetometer[2] * cos_roll * sin_pitch;
            // Tilt compensated magnetic field Y
            float mag_y = magnetometer[1] * cos_roll - magnetometer[2] * sin_roll;
            return (float)Math.Atan2(-mag_y, mag_x); //return (float)Math.Atan2(-mag_y, mag_x);
            //return (float)Math.Atan2(magnetometer[1], magnetometer[0]); //Matematica.Rad((float)Math.Atan2(magnetometer[1], magnetometer[0]));
        }



        public static void sensor_calibration(float[] accelerometer, float[] magnetometer, float[] gyroscope, ref float[] calibrated_acc, ref float[] calibrated_mag, ref float[] calibrated_gyro)
        {
            float accel_x_offset = ((accel_x_min + accel_x_max) / 2.0f);
            float accel_y_offset = ((accel_y_min + accel_y_max) / 2.0f);
            float accel_z_offset = ((accel_z_min + accel_z_max) / 2.0f);
            float accel_x_scale = (gravity / (accel_x_max - accel_x_offset));
            float accel_y_scale = (gravity / (accel_y_max - accel_y_offset));
            float accel_z_scale = (gravity / (accel_z_max - accel_z_offset));

            float mag_x_offset = ((mag_x_min + mag_x_max) / 2.0f);
            float mag_y_offset = ((mag_y_min + mag_y_max) / 2.0f);
            float mag_z_offset = ((mag_z_min + mag_z_max) / 2.0f);
            float mag_x_scale = (100.0f / (mag_x_max - mag_x_offset));
            float mag_y_scale = (100.0f / (mag_y_max - mag_y_offset));
            float mag_z_scale = (100.0f / (mag_z_max - mag_z_offset));

            calibrated_acc[0] = (accelerometer[0] - accel_x_offset) * accel_x_scale;
            calibrated_acc[1] = (accelerometer[1] - accel_y_offset) * accel_y_scale;
            calibrated_acc[2] = (accelerometer[2] - accel_z_offset) * accel_z_scale;
            calibrated_mag[0] = (magnetometer[0] - mag_x_offset) * mag_x_scale;
            calibrated_mag[1] = (magnetometer[1] - mag_y_offset) * mag_y_scale;
            calibrated_mag[2] = (magnetometer[2] - mag_z_offset) * mag_z_scale;

            calibrated_gyro[0] = gyroscope[0] - gyro_average_offset_x;
            calibrated_gyro[1] = gyroscope[1] - gyro_average_offset_y;
            calibrated_gyro[2] = gyroscope[2] - gyro_average_offset_z;

        }


        /// <summary>
        /// Função somente para teste(mostra os valores de orientação do phone)
        /// </summary>
        /// <param name="raw_data"></param>
        /// <param name="orientation"></param>
        public static float[] read_phone_orientation(string[] raw_data)
        {
            float[] orientation = new float[3];
            orientation[0] = float.Parse(raw_data[10], CultureInfo.InvariantCulture.NumberFormat);
            orientation[1] = float.Parse(raw_data[11], CultureInfo.InvariantCulture.NumberFormat);
            orientation[2] = float.Parse(raw_data[12], CultureInfo.InvariantCulture.NumberFormat);
            return orientation;
        }


    }
}
