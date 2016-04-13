#include "Arduino.h"
#include "DCM_algorithm.h"
#include "Matrix_Vector_Math.h"

const float gravity = 256.0f;

float Kp_ROLLPITCH = 0.02f;
float Ki_ROLLPITCH = 0.00002f;
float Kp_YAW = 1.2f;
float Ki_YAW = 0.00002f;

float accel_Vector[3] = { 0, 0, 0 }; // Store the acceleration in a vector
float gyro_Vector[3] = { 0, 0, 0 }; // Store the gyros turn rate in a vector

float Omega_Vector[3] = { 0, 0, 0 }; // Corrected Gyro_Vector data
float Omega_P[3] = { 0, 0, 0 }; // Omega Proportional correction
float Omega_I[3] = { 0, 0, 0 }; // Omega Integrator
float Omega[3] = { 0, 0, 0 };
float errorRollPitch[3] = { 0, 0, 0 };
float errorYaw[3] = { 0, 0, 0 };

float Update_Matrix[3][3] ={{ 0, 1, 2 },{ 3, 4, 5 },{ 6, 7, 8 }};
float Temporary_Matrix[3][3] ={{ 0, 0, 0 },{ 0, 0, 0 },{ 0, 0, 0 }};
float DCM_Matrix[3][3] = { { 0, 0, 0 },{ 0, 0, 0 },{ 0, 0, 0 } };

float pi = 3.14159265359;
String stringDCMMat;


void DCM_algorithm(float acc[3], float gyro[3], float mag[3], float G_dt, bool drift_correction, float& pitch_deg, float& roll_deg, float& yaw_deg)
{
	Matrix_update(acc, gyro, G_dt, drift_correction);
	Normalize();
	Drift_correction(magneto_heading(mag, acc));
	
	/*
	stringDCMMat = "DCM MAT: ";
	for (int i = 0; i<3; i++)
	{
		for (int j = 0; j<3; j++) {
			stringDCMMat += String(DCM_Matrix[i][j]) + " ";
		}
	}

	Serial.println(stringDCMMat);
	*/

	pitch_deg = -asin(DCM_Matrix[2][0]);
	roll_deg = atan2(DCM_Matrix[2][1], DCM_Matrix[2][2]);
	yaw_deg = atan2(DCM_Matrix[1][0], DCM_Matrix[0][0]);

	pitch_deg *= (180/pi);
	roll_deg *= (180/pi);
	yaw_deg *= (180/pi);
	

}



void init_rotation_matrix(float yaw, float pitch, float roll)
{


	float c1 = cos(roll);
	float s1 = sin(roll);
	float c2 = cos(pitch);
	float s2 = sin(pitch);
	float c3 = cos(yaw);
	float s3 = sin(yaw);

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




void Matrix_update(float acc[3], float gyro[3], float G_Dt, bool drift_correction)
{
	
	gyro_Vector[0] = gyro[0] * (pi/180); //gyro x roll RADIANS
	gyro_Vector[1] = gyro[1] * (pi/180); //gyro y pitch RADIANS
	gyro_Vector[2] = gyro[2] * (pi/180); //gyro z yaw RADIANS
	
	
	accel_Vector[0] = acc[0];
	accel_Vector[1] = acc[1];
	accel_Vector[2] = acc[2];

	Vector_Add(Omega, gyro_Vector, Omega_I);  //adding proportional term
	Vector_Add(Omega_Vector, Omega, Omega_P); //adding Integrator term


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

	Matrix_Multiply(DCM_Matrix, Update_Matrix, Temporary_Matrix); //a*b=c

	for (int x = 0; x < 3; x++) //Matrix Addition (update)
	{
		for (int y = 0; y < 3; y++)
		{
			DCM_Matrix[x][y] += Temporary_Matrix[x][y];
		}
	}

};


void Normalize() 
{

	float error = 0;
	float temporary[3][3] = {{0,0,0},{0,0,0},{0,0,0}};
	float renorm = 0;

	error = -Vector_Dot_Product(DCM_Matrix[0], DCM_Matrix[1]) * .5F; //eq.18/19 //Produto (.) escalar das duas primeiras LINHAS

	Vector_Scale(temporary[0], DCM_Matrix[1], error); //eq.19
	Vector_Scale(temporary[1], DCM_Matrix[0], error); //eq.19


	Vector_Add(temporary[0], temporary[0], DCM_Matrix[0]);//eq.19
	Vector_Add(temporary[1], temporary[1], DCM_Matrix[1]);//eq.19


	Vector_Cross_Product(temporary[2], temporary[0], temporary[1]); // c= a x b //eq.20 Produto vetorial dos vetores com erro em consideração

	renorm = (float).5 * (3 - Vector_Dot_Product(temporary[0], temporary[0])); //eq.21
	Vector_Scale(DCM_Matrix[0], temporary[0], renorm);

	renorm = (float).5 * (3 - Vector_Dot_Product(temporary[1], temporary[1])); //eq.21
	Vector_Scale(DCM_Matrix[1], temporary[1], renorm);

	renorm = (float).5 * (3 - Vector_Dot_Product(temporary[2], temporary[2])); //eq.21
	Vector_Scale(DCM_Matrix[2], temporary[2], renorm);

}


void Drift_correction(float mag_heading)
{
	float mag_heading_x;
	float mag_heading_y;
	float errorCourse;
	//Compensation the Roll, Pitch and Yaw drift. 
	static float Scaled_Omega_P[3];
	static float Scaled_Omega_I[3];
	float Accel_magnitude;
	float Accel_weight;


	//*****Roll and Pitch***************

	// Calculate the magnitude of the accelerometer vector
	Accel_magnitude = sqrt(accel_Vector[0] * accel_Vector[0] + accel_Vector[1] * accel_Vector[1] + accel_Vector[2] * accel_Vector[2]);
	Accel_magnitude = Accel_magnitude / gravity; // Scale to gravity.
												 // Dynamic weighting of accelerometer info (reliability filter)
												 // Weight for accelerometer info (<0.5G = 0.0, 1G = 1.0 , >1.5G = 0.0)
	Accel_weight = constrain(1 - 2 * abs(1 - Accel_magnitude), 0, 1);  //  

	Vector_Cross_Product(errorRollPitch, accel_Vector, DCM_Matrix[2]); //adjust the ground of reference
	Vector_Scale(Omega_P, errorRollPitch, Kp_ROLLPITCH * Accel_weight);

	Vector_Scale(Scaled_Omega_I, errorRollPitch, Ki_ROLLPITCH * Accel_weight);
	Vector_Add(Omega_I, Omega_I, Scaled_Omega_I);

	//*****YAW***************
	// We make the gyro YAW drift correction based on compass magnetic heading


	mag_heading_x = cos(mag_heading);
	mag_heading_y = sin(mag_heading);
	errorCourse = (DCM_Matrix[0][0] * mag_heading_y) - (DCM_Matrix[1][0] * mag_heading_x);  //Calculating YAW error
	Vector_Scale(errorYaw, DCM_Matrix[2], errorCourse); //Applys the yaw correction to the XYZ rotation of the aircraft, depeding the position.

	Vector_Scale(Scaled_Omega_P, errorYaw, Kp_YAW);//.01proportional of YAW.
	Vector_Add(Omega_P, Omega_P, Scaled_Omega_P);//Adding  Proportional.

	Vector_Scale(Scaled_Omega_I, errorYaw, Ki_YAW);//.00001Integrator
	Vector_Add(Omega_I, Omega_I, Scaled_Omega_I);//adding integrator to the Omega_I
}

float magneto_heading(float magnetometer[3], float accelerometer[3])
{
	float temp1[3];
	float temp2[3];
	float xAxis[] = { 1.0f, 0.0f, 0.0f };
	float pitch = -atan2(accelerometer[0], sqrt(accelerometer[1] * accelerometer[1] + accelerometer[2] * accelerometer[2]));

	Vector_Cross_Product(temp1, accelerometer, xAxis);
	Vector_Cross_Product(temp2, xAxis, temp1);

	float roll = atan2(temp2[1], temp2[2]);
	//roll = atan2(acc[1], sqrt(acc[0] * acc[0] + acc[2] * acc[2]));

	// Tilt compensated magnetic field X
	float mag_x = magnetometer[0] * cos(pitch) + magnetometer[1] * sin(roll) * sin(pitch) + magnetometer[2] * cos(roll) * sin(pitch);
	// Tilt compensated magnetic field Y
	float mag_y = magnetometer[1] * cos(roll) - magnetometer[2] * sin(roll);
	return atan2(mag_y, mag_x);

}


void Euler_angles(float pitch, float roll, float yaw)
{
	pitch = -asin(DCM_Matrix[2][0]);
	roll = atan2(DCM_Matrix[2][1], DCM_Matrix[2][2]);
	yaw = atan2(DCM_Matrix[1][0], DCM_Matrix[0][0]);

}
void Retrieve_rotation_matrix(float Rotation_Matrix[3][3])
{

	Rotation_Matrix = DCM_Matrix;

}

