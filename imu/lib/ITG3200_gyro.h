#include "Arduino.h"

//data
#define ITG3200_GYRO_XOUT_H 0x1d
#define ITG3200_GYRO_XOUT_L 0x1e
#define ITG3200_GYRO_YOUT_H 0x1f
#define ITG3200_GYRO_YOUT_L 0x20
#define ITG3200_GYRO_ZOUT_H 0x21
#define ITG3200_GYRO_ZOUT_L 0x22


#define ITG3200_SMPLRT_DIV 0x15 
#define ITG3200_PWR_MGM 0x3e  //0x00  // RW	Power Management
#define ITG3200_DLPF_FS 0x16 // FS_SEL 3 e FILTER 0   //[11][000]

#define WHO_AM_I           0x00  // RW   SETUP: I2C address
#define ITG3200_DEVICE  (0x68) 
#define ITG3200_TO_READ (6)      // num of bytes we are going to read each time (two bytes for each axis)

#define ITG3200_SCALE_FACTOR  (1 / 14.375) //Sensitivity through DATASHEET


class ITG3200
{
public:

	ITG3200();
	void initialize();
	void readGyro(float raw_data[3]);
	void scaleGyro(float scaled_data[3]);

	float gains[3]; //gains

private:
	void writeTo(byte address, byte val);
	void readFrom(byte address, int num, byte buff[]);
	byte _buff[6]; 
};