using System;
using System.Linq;

namespace IMU_sensor_headtracker
{
    public static class Matematica
    {

        public static float Rad(float x) { return (float)(x * 0.01745329252); } // pi/180

        public static float Deg(float x) { return (float)(x * 57.2957795131); } // 180/pi



        public static float Vector_Dot_Product(float[] v1, float[] v2)
        {
            float result = 0;

            for (int c = 0; c < 3; c++)
            {
                result += v1[c] * v2[c];
            }

            return result;
        }


        public static void Vector_Cross_Product(ref float[] saida, float[] v1, float[] v2)
        {
            saida[0] = (v1[1] * v2[2]) - (v1[2] * v2[1]);
            saida[1] = (v1[2] * v2[0]) - (v1[0] * v2[2]);
            saida[2] = (v1[0] * v2[1]) - (v1[1] * v2[0]);
        }

        // Multiply the vector by a scalar
        public static void Vector_Scale(ref float[] saida, float[] v, float scale)
        {
            for (int c = 0; c < 3; c++)
            {
                saida[c] = v[c] * scale;
            }
        }

        // Adds two vectors
        public static void Vector_Add(ref float[] saida,  float[] v1,  float[] v2)
        {
            for (int c = 0; c < 3; c++)
            {
                saida[c] = v1[c] + v2[c];
            }
        }


        // Multiply two 3x3 matrices: out = a * b
        // saida has to different from a and b (no in-place)!
        public static void Matrix_Multiply(float[][] a, float[][] b, ref float[][] saida)
        {
            for (int x = 0; x < 3; x++)  // rows
            {
                for (int y = 0; y < 3; y++)  // columns
                {
                    saida[x][y] = a[x][0] * b[0][y] + a[x][1] * b[1][y] + a[x][2] * b[2][y];
                }
            }
        }

        // Multiply 3x3 matrix with vector: out = a * b
        // saida has to different from b (no in-place)!
        public static void Matrix_Vector_Multiply(float[][] a, float[] b, ref float[] saida)
        {
            for (int x = 0; x < 3; x++)
            {
                saida[x] = a[x][0] * b[0] + a[x][1] * b[1] + a[x][2] * b[2];
            }
        }

        
        public static float constrain(float x, float a, float b)
        {
            if (x >= a && x <= b)
            {
                return x;
            }
            else
            {
                if (x < a) { return a; }
                else return b;
            }

        }


    }

}
