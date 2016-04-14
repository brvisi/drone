/*
 * driver info:
 * GY-85 module (ADXL345, HMC5883L, ITG3200)
 *
 *
 * Bruno Silva (brvisi@gmail.com)
 */

#ifndef GY85_H
#define GY85_H

#include "ADXL345_acc.h"
#include "HMC5883L_mag.h"
#include "ITG3200_gyro.h"

#define gravity 		256.0f
#define pi 				3.14159265359

#define Kp_ROLLPITCH 	0.02f
#define Ki_ROLLPITCH 	0.00002f
#define Kp_YAW 			1.2f
#define Ki_YAW 			0.00002f

class GY85
{
public:
	GY85();
	float* getOrientation(int algorithm, float G_dt);

	void magCalibration();
	void accCalibration();
	void gyrCalibration();
private:
	ADXL345 accelerometer;
	ITG3200 gyroscope;
	HMC5883L magnetometer;
	float orientation[3]; //pitch, roll, yaw
	float accVector[3];
	float magVector[3];
	float gyrVector[3];
	float gyr_dt;
	float magnetoHeading(float magnetometer[3], float accelerometer[3]);

	// dcm sensor fusion algorithm
	float dcmMatrix[3][3];
	bool drift_correction;
	void dcmAlgorithm(float G_dt, bool driftCorrection, float (&orientationDeg)[3]);
	void initRotationMatrix();
	void matrixUpdate();
	void normalize();
	void driftCorrection();
};

#endif
