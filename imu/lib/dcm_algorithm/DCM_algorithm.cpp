#include "DCM_algorithm.h"
#include "Matrix_Vector_Math.h"

const float gravity = 256.0f;
const float pi = 3.14159265359;

const float Kp_ROLLPITCH = 0.02f;
const float Ki_ROLLPITCH = 0.00002f;
const float Kp_YAW = 1.2f;
const float Ki_YAW = 0.00002f;

float Omega_Vector[3] = { 0, 0, 0 }; // Corrected Gyro_Vector data
float Omega_P[3] = { 0, 0, 0 }; // Omega Proportional correction
float Omega_I[3] = { 0, 0, 0 }; // Omega Integrator
float Omega[3] = { 0, 0, 0 };
float errorRollPitch[3] = { 0, 0, 0 };
float errorYaw[3] = { 0, 0, 0 };

float Update_Matrix[3][3] ={{ 0, 1, 2 },{ 3, 4, 5 },{ 6, 7, 8 }};
float Temporary_Matrix[3][3] ={{ 0, 0, 0 },{ 0, 0, 0 },{ 0, 0, 0 }};

String stringDCMMat;

Imu::Imu()
{
	accelerometer.initialize();
	delay(10);
	gyroscope.initialize();
	delay(10);
	magnetometer.initialize();
	delay(10);

	initRotationMatrix();
}

float* Imu::getOrientation(int algorithm, float G_dt)
{
/*
	float pitch, roll, yaw;
	float xAxis[3] = { 1.0f, 0.0f, 0.0f };
	float temp1[3] = { 0, 0, 0};
	float temp2[3] = { 0, 0, 0};

	accelerometer.readAccel(accVector);

	gyroscope.readGyro(gyrVector);
	gyroscope.scaleGyro(gyrVector);

	magnetometer.readMag(magVector);
	magnetometer.scaleMag(magVector);

	pitch = atan2(accVector[0], sqrt(accVector[1] * accVector[1] + accVector[2] * accVector[2]));

	Vector_Cross_Product(temp1, accVector, xAxis);
	Vector_Cross_Product(temp2, xAxis, temp1);

	roll = atan2(temp2[1], temp2[2]);

	// Tilt compensated magnetic field X
	float mag_x = magVector[0] * cos(pitch) + magVector[1] * sin(roll) * sin(pitch) + magVector[2] * cos(roll) * sin(pitch);
	// Tilt compensated magnetic field Y
	float mag_y = magVector[1] * cos(roll) - magVector[2] * sin(roll);
	yaw = atan2(mag_y, mag_x);

	orientation[0] = pitch;
	orientation[1] = roll;
	orientation[2] = yaw;
	return orientation;
*/
	accelerometer.readAccel(accVector);

	gyroscope.readGyro(gyrVector);
	gyroscope.scaleGyro(gyrVector);

	magnetometer.readMag(magVector);
	magnetometer.scaleMag(magVector);

	float pitch, roll, yaw;


	dcmAlgorithm(G_dt, true, pitch, roll, yaw );

	orientation[0] = pitch;
	orientation[1] = roll;
	orientation[2] = yaw;
	return orientation;

}

void Imu::dcmAlgorithm(float G_dt, bool drift_correction, float& pitch_deg, float& roll_deg, float& yaw_deg)
{
	matrixUpdate(accVector, gyrVector, G_dt, drift_correction);
	normalize();
	driftCorrection(magnetoHeading(magVector, accVector));
	
	/*
	stringDCMMat = "DCM MAT: ";
	for (int i = 0; i<3; i++)
	{
		for (int j = 0; j<3; j++) {
			stringDCMMat += String(dcmMatrix[i][j]) + " ";
		}
	}

	Serial.println(stringDCMMat);
	*/

	pitch_deg = -asin(dcmMatrix[2][0]);
	roll_deg = atan2(dcmMatrix[2][1], dcmMatrix[2][2]);
	yaw_deg = atan2(dcmMatrix[1][0], dcmMatrix[0][0]);

	pitch_deg *= (180/pi);
	roll_deg *= (180/pi);
	yaw_deg *= (180/pi);
}

void Imu::initRotationMatrix()
{
	float pitch, roll, yaw;
	float xAxis[3] = { 1.0f, 0.0f, 0.0f };
	float temp1[3] = { 0, 0, 0};
	float temp2[3] = { 0, 0, 0};

	accelerometer.readAccel(accVector);

	gyroscope.readGyro(gyrVector);
	gyroscope.scaleGyro(gyrVector);

	magnetometer.readMag(magVector);
	magnetometer.scaleMag(magVector);

	pitch = atan2(accVector[0], sqrt(accVector[1] * accVector[1] + accVector[2] * accVector[2]));

	Vector_Cross_Product(temp1, accVector, xAxis);
	Vector_Cross_Product(temp2, xAxis, temp1);

	roll = atan2(temp2[1], temp2[2]);

	// Tilt compensated magnetic field X
	float mag_x = magVector[0] * cos(pitch) + magVector[1] * sin(roll) * sin(pitch) + magVector[2] * cos(roll) * sin(pitch);
	// Tilt compensated magnetic field Y
	float mag_y = magVector[1] * cos(roll) - magVector[2] * sin(roll);
	yaw = atan2(mag_y, mag_x);


	float c1 = cos(roll);
	float s1 = sin(roll);
	float c2 = cos(pitch);
	float s2 = sin(pitch);
	float c3 = cos(yaw);
	float s3 = sin(yaw);

	// Euler angles, right-handed, intrinsic, XYZ convention
	// (which means: rotate around body axes Z, Y', X'') 
	dcmMatrix[0][0] = c2 * c3;
	dcmMatrix[0][1] = c3 * s1 * s2 - c1 * s3;
	dcmMatrix[0][2] = s1 * s3 + c1 * c3 * s2;

	dcmMatrix[1][0] = c2 * s3;
	dcmMatrix[1][1] = c1 * c3 + s1 * s2 * s3;
	dcmMatrix[1][2] = c1 * s2 * s3 - c3 * s1;

	dcmMatrix[2][0] = -s2;
	dcmMatrix[2][1] = c2 * s1;
	dcmMatrix[2][2] = c1 * c2;

}

void Imu::matrixUpdate(float acc[3], float gyro[3], float G_Dt, bool drift_correction)
{
	
	gyrVector[0] = gyro[0] * (pi/180); //gyro x roll RADIANS
	gyrVector[1] = gyro[1] * (pi/180); //gyro y pitch RADIANS
	gyrVector[2] = gyro[2] * (pi/180); //gyro z yaw RADIANS
	
	
	accVector[0] = acc[0];
	accVector[1] = acc[1];
	accVector[2] = acc[2];

	Vector_Add(Omega, gyrVector, Omega_I);  //adding proportional term
	Vector_Add(Omega_Vector, Omega, Omega_P); //adding Integrator term


	if (!drift_correction)
	{
		Update_Matrix[0][0] = 0;
		Update_Matrix[0][1] = -G_Dt * gyrVector[2];//-z
		Update_Matrix[0][2] = G_Dt * gyrVector[1];//y
		Update_Matrix[1][0] = G_Dt * gyrVector[2];//z
		Update_Matrix[1][1] = 0;
		Update_Matrix[1][2] = -G_Dt * gyrVector[0];
		Update_Matrix[2][0] = -G_Dt * gyrVector[1];
		Update_Matrix[2][1] = G_Dt * gyrVector[0];
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

	Matrix_Multiply(dcmMatrix, Update_Matrix, Temporary_Matrix); //a*b=c

	for (int x = 0; x < 3; x++) //Matrix Addition (update)
	{
		for (int y = 0; y < 3; y++)
		{
			dcmMatrix[x][y] += Temporary_Matrix[x][y];
		}
	}

};


void Imu::normalize()
{

	float error = 0;
	float temporary[3][3] = {{0,0,0},{0,0,0},{0,0,0}};
	float renorm = 0;

	error = -Vector_Dot_Product(dcmMatrix[0], dcmMatrix[1]) * .5F; //eq.18/19 //Produto (.) escalar das duas primeiras LINHAS

	Vector_Scale(temporary[0], dcmMatrix[1], error); //eq.19
	Vector_Scale(temporary[1], dcmMatrix[0], error); //eq.19


	Vector_Add(temporary[0], temporary[0], dcmMatrix[0]);//eq.19
	Vector_Add(temporary[1], temporary[1], dcmMatrix[1]);//eq.19


	Vector_Cross_Product(temporary[2], temporary[0], temporary[1]); // c= a x b //eq.20 Produto vetorial dos vetores com erro em consideração

	renorm = (float).5 * (3 - Vector_Dot_Product(temporary[0], temporary[0])); //eq.21
	Vector_Scale(dcmMatrix[0], temporary[0], renorm);

	renorm = (float).5 * (3 - Vector_Dot_Product(temporary[1], temporary[1])); //eq.21
	Vector_Scale(dcmMatrix[1], temporary[1], renorm);

	renorm = (float).5 * (3 - Vector_Dot_Product(temporary[2], temporary[2])); //eq.21
	Vector_Scale(dcmMatrix[2], temporary[2], renorm);

}


void Imu::driftCorrection(float mag_heading)
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
	Accel_magnitude = sqrt(accVector[0] * accVector[0] + accVector[1] * accVector[1] + accVector[2] * accVector[2]);
	Accel_magnitude = Accel_magnitude / gravity; // Scale to gravity.
												 // Dynamic weighting of accelerometer info (reliability filter)
												 // Weight for accelerometer info (<0.5G = 0.0, 1G = 1.0 , >1.5G = 0.0)
	Accel_weight = constrain(1 - 2 * abs(1 - Accel_magnitude), 0, 1);  //  

	Vector_Cross_Product(errorRollPitch, accVector, dcmMatrix[2]); //adjust the ground of reference
	Vector_Scale(Omega_P, errorRollPitch, Kp_ROLLPITCH * Accel_weight);

	Vector_Scale(Scaled_Omega_I, errorRollPitch, Ki_ROLLPITCH * Accel_weight);
	Vector_Add(Omega_I, Omega_I, Scaled_Omega_I);

	//*****YAW***************
	// We make the gyro YAW drift correction based on compass magnetic heading


	mag_heading_x = cos(mag_heading);
	mag_heading_y = sin(mag_heading);
	errorCourse = (dcmMatrix[0][0] * mag_heading_y) - (dcmMatrix[1][0] * mag_heading_x);  //Calculating YAW error
	Vector_Scale(errorYaw, dcmMatrix[2], errorCourse); //Applys the yaw correction to the XYZ rotation of the aircraft, depeding the position.

	Vector_Scale(Scaled_Omega_P, errorYaw, Kp_YAW);//.01proportional of YAW.
	Vector_Add(Omega_P, Omega_P, Scaled_Omega_P);//Adding  Proportional.

	Vector_Scale(Scaled_Omega_I, errorYaw, Ki_YAW);//.00001Integrator
	Vector_Add(Omega_I, Omega_I, Scaled_Omega_I);//adding integrator to the Omega_I
}

float Imu::magnetoHeading(float magnetometer[3], float accelerometer[3])
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

void Imu::eulerAngles()
{
	orientation[0] = -asin(dcmMatrix[2][0]);
	orientation[1] = atan2(dcmMatrix[2][1], dcmMatrix[2][2]);
	orientation[2] = atan2(dcmMatrix[1][0], dcmMatrix[0][0]);
}

void Imu::retrieveRotationMatrix(float Rotation_Matrix[3][3])
{
	Rotation_Matrix = dcmMatrix;
}

