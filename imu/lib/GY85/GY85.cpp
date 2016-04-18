/*
 * driver info:
 * GY-85 module (ADXL345, HMC5883L, ITG3200)
 *
 *
 * Bruno Silva (brvisi@gmail.com)
 */


#include <Arduino.h>
#include <EEPROM.h>
#include "GY85.h"
#include "MatrixMath.h"

float Omega_Vector[3] = { 0, 0, 0 }; // Corrected Gyro_Vector data
float Omega_P[3] = { 0, 0, 0 }; // Omega Proportional correction
float Omega_I[3] = { 0, 0, 0 }; // Omega Integrator
float Omega[3] = { 0, 0, 0 };
float errorRollPitch[3] = { 0, 0, 0 };
float errorYaw[3] = { 0, 0, 0 };

float Update_Matrix[3][3] ={{ 0, 1, 2 },{ 3, 4, 5 },{ 6, 7, 8 }};
float Temporary_Matrix[3][3] ={{ 0, 0, 0 },{ 0, 0, 0 },{ 0, 0, 0 }};

GY85::GY85()
{
	delay(50); // time for sensors to start
	accelerometer.initialize();
	gyroscope.initialize();
	magnetometer.initialize();

	delay(20); // time for sensors to start collecting data
	initRotationMatrix(); // for dcm
}

void GY85::magCalibration()
{
	float magRange[6]; // MAG_MAX_X; MAG_MIN_Y; MAG_MAX_Y; MAG_MIN_Y; MAG_MAX_Z; MAG_MIN_Z
	float rawData[3];
	int calibration_counter=0;
	int EEPROM_ADDRESS=0; // eeprom offset for mag range values

	while(calibration_counter<3000)
	{
		//Serial.println(String(calibration_counter));
		//magnetometer.getOrientationVector(magVector); // -----> need function to read rawData

		//Serial.println("Mag: " + String(mag[0]) + "," + String(mag[1]) + "," + String(mag[2]));
		if (magRange[0]<rawData[0]) { magRange[0] = rawData[0]; }
		if (magRange[1]>rawData[0]) { magRange[1] = rawData[0]; }
		if (magRange[2]<rawData[1]) { magRange[2] = rawData[1]; }
		if (magRange[3]>rawData[1]) { magRange[3] = rawData[1]; }
		if (magRange[4]<rawData[2]) { magRange[4] = rawData[2]; }
		if (magRange[5]>rawData[2]) { magRange[5] = rawData[2]; }

		delay(10);
		calibration_counter++;
	}

	for (int i=0; i<6; i++)
	{
		EEPROM.put(EEPROM_ADDRESS + (i*(sizeof(float))), magRange[i]);
	}

}


float* GY85::getOrientation(int algorithm, float G_dt)
{


	float xAxis[3] = { 1.0f, 0.0f, 0.0f };
	float temp1[3] = { 0, 0, 0};
	float temp2[3] = { 0, 0, 0};

	accelerometer.getOrientationVector(accVector);

	gyroscope.readGyro(gyrVector);
	gyroscope.scaleGyro(gyrVector);

	magnetometer.getOrientationVector(magVector);


	//Serial.println(String(magVector[0]) + "," + String(magVector[1]) + "," + String(magVector[2]));

	// roll
	orientation[0] = atan2(accVector[0], sqrt(accVector[1] * accVector[1] + accVector[2] * accVector[2]));

	//Vector_Cross_Product(temp1, accVector, xAxis);
	//Vector_Cross_Product(temp2, xAxis, temp1);

	// Normally using x-z-plane-component/y-component of compensated gravity vector
	// roll = atan2(temp2[1], sqrt(temp2[0] * temp2[0] + temp2[2] * temp2[2]));
	// Since we compensated for pitch, x-z-plane-component equals z-component:

	// pitch
	//orientation[1] = atan2(temp2[1], temp2[2]);

	orientation[1] = 0; //atan2(accVector[1], sqrt(accVector[0] * accVector[0] + accVector[2] * accVector[2]));
	// Tilt compensated magnetic field X
	float mag_x = magVector[0] * cos(orientation[0]) + magVector[1] * sin(orientation[1]) * sin(orientation[0]) + magVector[2] * cos(orientation[1]) * sin(orientation[0]);
	// Tilt compensated magnetic field Y
	float mag_y = magVector[1] * cos(orientation[1]) - magVector[2] * sin(orientation[1]);

	// yaw
	orientation[2] = atan2(-mag_y, mag_x);

	orientation[0] *= 57.3;
	orientation[1] *= 57.3;
	orientation[2] *= 57.3;
	return orientation;


	//dcmAlgorithm(G_dt, true, orientation); 	// pitch, roll, yaw

	//return orientation;
}

void GY85::dcmAlgorithm(float G_dt, bool useDriftCorrection, float (&orientationDeg)[3])
{
	gyr_dt = G_dt;
	drift_correction = useDriftCorrection;

	accelerometer.getOrientationVector(accVector);

	gyroscope.readGyro(gyrVector);
	gyroscope.scaleGyro(gyrVector);

	magnetometer.getOrientationVector(magVector);

	matrixUpdate();
	normalize();
	
	if (drift_correction)
	{
		driftCorrection();
	}

	// orientation in degrees (pitch, roll, yaw from rotation matrix)
	orientationDeg[0] = -asin(dcmMatrix[2][0]) * (180/pi);
	orientationDeg[1] = atan2(dcmMatrix[2][1], dcmMatrix[2][2]) * (180/pi);
	orientationDeg[2] = atan2(dcmMatrix[1][0], dcmMatrix[0][0]) * (180/pi);
}

void GY85::initRotationMatrix()
{
	float xAxis[3] = { 1.0f, 0.0f, 0.0f };
	float temp1[3] = { 0, 0, 0};
	float temp2[3] = { 0, 0, 0};

	accelerometer.getOrientationVector(accVector);

	gyroscope.readGyro(gyrVector);
	gyroscope.scaleGyro(gyrVector);

	magnetometer.getOrientationVector(magVector);

	// roll
	orientation[0] = atan2(accVector[0], sqrt(accVector[1] * accVector[1] + accVector[2] * accVector[2]));

	Vector_Cross_Product(temp1, accVector, xAxis);
	Vector_Cross_Product(temp2, xAxis, temp1);

	// Normally using x-z-plane-component/y-component of compensated gravity vector
	// roll = atan2(temp2[1], sqrt(temp2[0] * temp2[0] + temp2[2] * temp2[2]));
	// Since we compensated for pitch, x-z-plane-component equals z-component:

	// pitch
	orientation[1] = atan2(temp2[1], temp2[2]);

	// Tilt compensated magnetic field X
	float mag_x = magVector[0] * cos(orientation[0]) + magVector[1] * sin(orientation[1]) * sin(orientation[0]) + magVector[2] * cos(orientation[1]) * sin(orientation[0]);
	// Tilt compensated magnetic field Y
	float mag_y = magVector[1] * cos(orientation[1]) - magVector[2] * sin(orientation[1]);

	// yaw
	orientation[2] = atan2(mag_y, mag_x);

	float c1 = cos(orientation[1]);
	float s1 = sin(orientation[1]);
	float c2 = cos(orientation[0]);
	float s2 = sin(orientation[0]);
	float c3 = cos(orientation[2]);
	float s3 = sin(orientation[2]);

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

void GY85::matrixUpdate()
{
	
	gyrVector[0] *= (pi/180); //gyro x roll radians
	gyrVector[1] *= (pi/180); //gyro y pitch radians
	gyrVector[2] *= (pi/180); //gyro z yaw radians

	Vector_Add(Omega, gyrVector, Omega_I);  // adding proportional term
	Vector_Add(Omega_Vector, Omega, Omega_P); // adding integrator term

	if (!drift_correction)
	{
		Update_Matrix[0][0] = 0;
		Update_Matrix[0][1] = -gyr_dt * gyrVector[2];//-z
		Update_Matrix[0][2] = gyr_dt * gyrVector[1];//y
		Update_Matrix[1][0] = gyr_dt * gyrVector[2];//z
		Update_Matrix[1][1] = 0;
		Update_Matrix[1][2] = -gyr_dt * gyrVector[0];
		Update_Matrix[2][0] = -gyr_dt * gyrVector[1];
		Update_Matrix[2][1] = gyr_dt * gyrVector[0];
		Update_Matrix[2][2] = 0;
	}
	else
	{ // drift correction

		Update_Matrix[0][0] = 0;
		Update_Matrix[0][1] = -gyr_dt * Omega_Vector[2];//-z
		Update_Matrix[0][2] = gyr_dt * Omega_Vector[1];//y
		Update_Matrix[1][0] = gyr_dt * Omega_Vector[2];//z
		Update_Matrix[1][1] = 0;
		Update_Matrix[1][2] = -gyr_dt * Omega_Vector[0];//-x
		Update_Matrix[2][0] = -gyr_dt * Omega_Vector[1];//-y
		Update_Matrix[2][1] = gyr_dt * Omega_Vector[0];//x
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


void GY85::normalize()
{

	float error = 0;
	float temporary[3][3] = {{0,0,0},{0,0,0},{0,0,0}};
	float renorm = 0;

	error = -Vector_Dot_Product(dcmMatrix[0], dcmMatrix[1]) * .5F; //eq.18/19 //Produto (.) escalar das duas primeiras LINHAS

	Vector_Scale(temporary[0], dcmMatrix[1], error); //eq.19
	Vector_Scale(temporary[1], dcmMatrix[0], error); //eq.19

	Vector_Add(temporary[0], temporary[0], dcmMatrix[0]);//eq.19
	Vector_Add(temporary[1], temporary[1], dcmMatrix[1]);//eq.19

	Vector_Cross_Product(temporary[2], temporary[0], temporary[1]); // c= a x b //eq.20 Produto vetorial dos vetores com erro em considera��o

	renorm = (float).5 * (3 - Vector_Dot_Product(temporary[0], temporary[0])); //eq.21
	Vector_Scale(dcmMatrix[0], temporary[0], renorm);

	renorm = (float).5 * (3 - Vector_Dot_Product(temporary[1], temporary[1])); //eq.21
	Vector_Scale(dcmMatrix[1], temporary[1], renorm);

	renorm = (float).5 * (3 - Vector_Dot_Product(temporary[2], temporary[2])); //eq.21
	Vector_Scale(dcmMatrix[2], temporary[2], renorm);

}


void GY85::driftCorrection()
{
	float magHeading;
	magHeading = magnetoHeading(magVector, accVector);

	float magHeadingX;
	float magHeadingY;
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


	magHeadingX = cos(magHeading);
	magHeadingY = sin(magHeading);
	errorCourse = (dcmMatrix[0][0] * magHeadingY) - (dcmMatrix[1][0] * magHeadingX);  //Calculating YAW error
	Vector_Scale(errorYaw, dcmMatrix[2], errorCourse); //Applys the yaw correction to the XYZ rotation of the aircraft, depeding the position.

	Vector_Scale(Scaled_Omega_P, errorYaw, Kp_YAW);//.01proportional of YAW.
	Vector_Add(Omega_P, Omega_P, Scaled_Omega_P);//Adding  Proportional.

	Vector_Scale(Scaled_Omega_I, errorYaw, Ki_YAW);//.00001Integrator
	Vector_Add(Omega_I, Omega_I, Scaled_Omega_I);//adding integrator to the Omega_I
}

float GY85::magnetoHeading(float magnetometer[3], float accelerometer[3])
{
	float temp1[3];
	float temp2[3];
	float xAxis[] = { 1.0f, 0.0f, 0.0f };
	float pitch = atan2(accelerometer[0], sqrt(accelerometer[1] * accelerometer[1] + accelerometer[2] * accelerometer[2]));

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

