using System;


namespace IMU_sensor_headtracker
{
    public class DCM
    {
        const float gravity = 256.0f;

        //DCM parameters
        private float Kp_ROLLPITCH = 0.02f;
        private float Ki_ROLLPITCH = 0.00002f;
        private float Kp_YAW = 1.2f;
        private float Ki_YAW = 0.00002f;

        private float[] Omega_Vector = { 0, 0, 0 }; // Corrected Gyro_Vector data
        private float[] Omega_P = { 0, 0, 0 }; // Omega Proportional correction
        private float[] Omega_I = { 0, 0, 0 }; // Omega Integrator
        private float[] Omega = { 0, 0, 0 };
        private float[] errorRollPitch = { 0, 0, 0 };
        private float[] errorYaw =  { 0, 0, 0 };

        private float[] accel_Vector = { 0, 0, 0 }; // Store the acceleration in a vector
        private float[] gyro_Vector = { 0, 0, 0 }; // Store the gyros turn rate in a vector

        //public const float gyro_ganho = 55 ;//0.06957f; // Gain for gyroscope
        //public float gyro_ganho_radians(float x) { return (x * Matematica.Rad(gyro_ganho)); }

        private float[][] Update_Matrix =
        {
            new float[] { 0, 1, 2 },
            new float[] { 3, 4, 5 },
            new float[] { 6, 7, 8 }
        };
        private float[][] Temporary_Matrix =
        {
            new float[] { 0, 0, 0 },
            new float[] { 0, 0, 0 },
            new float[] { 0, 0, 0 }
        };

        private float[][] DCM_Matrix =
        {
            new float[] { 0, 0, 0 },
            new float[] { 0, 1, 0 },
            new float[] { 0, 0, 1 }
        };

        public void init_rotation_matrix(float yaw, float pitch, float roll)
        {
            float c1 = (float)Math.Cos(roll);
            float s1 = (float)Math.Sin(roll);
            float c2 = (float)Math.Cos(pitch);
            float s2 = (float)Math.Sin(pitch);
            float c3 = (float)Math.Cos(yaw);
            float s3 = (float)Math.Sin(yaw);

            // Euler angles, right-handed, intrinsic, XYZ convention
            // (which means: rotate around body axes Z, Y', X'') 
            DCM_Matrix[0][0] = c2 * c3;
            DCM_Matrix[0][1] = c3 * s1 * s2 - c1 * s3;
            DCM_Matrix[0][2] = s1 * s3 + c1 * c3 * s2;

            DCM_Matrix[1][0] = c2 * s3;
            DCM_Matrix[1][1] = c1 * c3 + s1 * s2 * s3;
            DCM_Matrix[1][2] = c1 * s2 * s3 - c3 * s1;

            DCM_Matrix[2][0] = -s2;
            DCM_Matrix[2][1] = c2 * s1;
            DCM_Matrix[2][2] = c1 * c2;
        }

        public void Matrix_update(float[] accelerometer, float[] gyroscope, float G_Dt, bool drift_correction)
        {

            gyro_Vector[0] = Sensors.gyro_ganho_radians(gyroscope[0]); //gyro x roll
            gyro_Vector[1] = Sensors.gyro_ganho_radians(gyroscope[1]); //gyro y pitch
            gyro_Vector[2] = Sensors.gyro_ganho_radians(gyroscope[2]); //gyro z yaw

            accel_Vector = accelerometer;

            Matematica.Vector_Add(ref Omega, gyro_Vector, Omega_I);  //adding proportional term
            Matematica.Vector_Add(ref Omega_Vector, Omega, Omega_P); //adding Integrator term


            if (!drift_correction)
            {
                Update_Matrix[0][0] = 0;
                Update_Matrix[0][1] = -G_Dt * gyro_Vector[2];//-z
                Update_Matrix[0][2] = G_Dt * gyro_Vector[1];//y
                Update_Matrix[1][0] = G_Dt * gyro_Vector[2];//z
                Update_Matrix[1][1] = 0;
                Update_Matrix[1][2] = -G_Dt * gyro_Vector[0];
                Update_Matrix[2][0] = -G_Dt * gyro_Vector[1];
                Update_Matrix[2][1] = G_Dt * gyro_Vector[0];
                Update_Matrix[2][2] = 0;
            }
            else
            { // Correção de drift

                Update_Matrix[0][0] = 0;
                Update_Matrix[0][1] = -G_Dt * Omega_Vector[2];//-z
                Update_Matrix[0][2] = G_Dt * Omega_Vector[1];//y
                Update_Matrix[1][0] = G_Dt * Omega_Vector[2];//z
                Update_Matrix[1][1] = 0;
                Update_Matrix[1][2] = -G_Dt * Omega_Vector[0];//-x
                Update_Matrix[2][0] = -G_Dt * Omega_Vector[1];//-y
                Update_Matrix[2][1] = G_Dt * Omega_Vector[0];//x
                Update_Matrix[2][2] = 0;
            }

            Matematica.Matrix_Multiply(DCM_Matrix, Update_Matrix, ref Temporary_Matrix); //a*b=c

            for (int x = 0; x < 3; x++) //Matrix Addition (update)
            {
                for (int y = 0; y < 3; y++)
                {
                    DCM_Matrix[x][y] += Temporary_Matrix[x][y];
                }
            }
        }

        public void Normalize()
        {
            float error = 0;
            float[][] temporary =
            {
                new float[] {0,0,0},
                new float[] {0,0,0},
                new float[] {0,0,0}
            };
            float renorm = 0;


            error = -Matematica.Vector_Dot_Product(DCM_Matrix[0], DCM_Matrix[1]) * .5F; //eq.18/19 //Produto (.) escalar das duas primeiras LINHAS

            Matematica.Vector_Scale(ref temporary[0], DCM_Matrix[1], error); //eq.19
            Matematica.Vector_Scale(ref temporary[1], DCM_Matrix[0], error); //eq.19


            Matematica.Vector_Add(ref temporary[0], temporary[0], DCM_Matrix[0]);//eq.19
            Matematica.Vector_Add(ref temporary[1], temporary[1], DCM_Matrix[1]);//eq.19


            Matematica.Vector_Cross_Product(ref temporary[2], temporary[0], temporary[1]); // c= a x b //eq.20 Produto vetorial dos vetores com erro em consideração

            renorm = (float).5 * (3 - Matematica.Vector_Dot_Product(temporary[0], temporary[0])); //eq.21
            Matematica.Vector_Scale(ref DCM_Matrix[0], temporary[0], renorm);

            renorm = (float).5 * (3 - Matematica.Vector_Dot_Product(temporary[1], temporary[1])); //eq.21
            Matematica.Vector_Scale(ref DCM_Matrix[1], temporary[1], renorm);

            renorm = (float).5 * (3 - Matematica.Vector_Dot_Product(temporary[2], temporary[2])); //eq.21
            Matematica.Vector_Scale(ref DCM_Matrix[2], temporary[2], renorm);
        }


        public void Drift_correction(float mag_heading)
        {
            float mag_heading_x;
            float mag_heading_y;
            float errorCourse;
            //Compensation the Roll, Pitch and Yaw drift. 
            float[] Scaled_Omega_P = new float[3];
            float[] Scaled_Omega_I = new float[3];
            float Accel_magnitude;
            float Accel_weight;


            //*****Roll and Pitch***************

            // Calculate the magnitude of the accelerometer vector
            Accel_magnitude = (float)Math.Sqrt(accel_Vector[0] * accel_Vector[0] + accel_Vector[1] * accel_Vector[1] + accel_Vector[2] * accel_Vector[2]);
            Accel_magnitude = Accel_magnitude / gravity; // Scale to gravity.
                                                         // Dynamic weighting of accelerometer info (reliability filter)
                                                         // Weight for accelerometer info (<0.5G = 0.0, 1G = 1.0 , >1.5G = 0.0)
            Accel_weight = Matematica.constrain(1 - 2 * Math.Abs(1 - Accel_magnitude), 0, 1);  //  

            Matematica.Vector_Cross_Product(ref errorRollPitch, accel_Vector, DCM_Matrix[2]); //adjust the ground of reference
            Matematica.Vector_Scale(ref Omega_P, errorRollPitch, Kp_ROLLPITCH * Accel_weight);

            Matematica.Vector_Scale(ref Scaled_Omega_I, errorRollPitch, Ki_ROLLPITCH * Accel_weight);
            Matematica.Vector_Add(ref Omega_I, Omega_I, Scaled_Omega_I);

            //*****YAW***************
            // We make the gyro YAW drift correction based on compass magnetic heading


            mag_heading_x = (float)Math.Cos(mag_heading);
            mag_heading_y = (float)Math.Sin(mag_heading);
            errorCourse = (DCM_Matrix[0][0] * mag_heading_y) - (DCM_Matrix[1][0] * mag_heading_x);  //Calculating YAW error
            Matematica.Vector_Scale(ref errorYaw, DCM_Matrix[2], errorCourse); //Applys the yaw correction to the XYZ rotation of the aircraft, depeding the position.

            Matematica.Vector_Scale(ref Scaled_Omega_P, errorYaw, Kp_YAW);//.01proportional of YAW.
            Matematica.Vector_Add(ref Omega_P, Omega_P, Scaled_Omega_P);//Adding  Proportional.

            Matematica.Vector_Scale(ref Scaled_Omega_I, errorYaw, Ki_YAW);//.00001Integrator
            Matematica.Vector_Add(ref Omega_I, Omega_I, Scaled_Omega_I);//adding integrator to the Omega_I
        }





        public void Euler_angles(ref float pitch, ref float roll, ref float yaw)
        {
            pitch = (float)-Math.Asin(DCM_Matrix[2][0]);
            roll = (float)Math.Atan2(DCM_Matrix[2][1], DCM_Matrix[2][2]);
            yaw = (float)Math.Atan2(DCM_Matrix[1][0], DCM_Matrix[0][0]);
        }

        public void Retrieve_rotation_matrix(ref float[][] Rotation_Matrix)
        {
            Rotation_Matrix = DCM_Matrix;
        }

    }
}
