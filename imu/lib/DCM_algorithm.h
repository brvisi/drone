#include "Arduino.h"


class IMU
{
public:
	getOrientation(int algorithm, float pitch, float roll, float yaw);



private:


};





void DCM_algorithm(float acc[3], float gyro[3], float mag[3], float G_dt, bool drift_correction, float& pitch, float& roll, float& yaw);



void init_rotation_matrix(float yaw, float pitch, float roll);
void Matrix_update(float acc[3], float gyro[3], float G_Dt, bool drift_correction);
void Normalize();
void Drift_correction(float mag_heading);
float magneto_heading(float magnetometer[3], float accelerometer[3]);

void Euler_angles(float pitch, float roll, float yaw);
void Retrieve_rotation_matrix(float Rotation_Matrix[3][3]);

