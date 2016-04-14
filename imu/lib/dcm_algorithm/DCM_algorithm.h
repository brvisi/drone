#include "Arduino.h"
#include "ADXL345_acc.h"
#include "HMC5883L_mag.h"
#include "ITG3200_gyro.h"

class Imu
{
public:
	Imu();
	float* getOrientation(int algorithm, float G_dt);

private:
	ADXL345 accelerometer;
	ITG3200 gyroscope;
	HMC5883L magnetometer;

	float dcmMatrix[3][3];
	float orientation[3]; //pitch, roll, yaw

	float accVector[3]; //Store the acceleration in a vector
	float magVector[3];
	float gyrVector[3];

	void dcmAlgorithm(float G_dt, bool driftCorrection, float& pitch, float& roll, float& yaw);

	void initRotationMatrix();
	void matrixUpdate(float acc[3], float gyro[3], float G_Dt, bool drift_correction);
	void normalize();
	void driftCorrection(float mag_heading);
	float magnetoHeading(float magnetometer[3], float accelerometer[3]);
	void eulerAngles();
	void retrieveRotationMatrix(float Rotation_Matrix[3][3]);
};







