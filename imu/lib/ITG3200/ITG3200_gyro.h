/*
 * driver info:
 * ITG3200 gyroscope (GY-85 module)
 *
 * IIC bus protocol using Arduino <Wire> library
 *
 *
 * Bruno Silva (brvisi@gmail.com)
 */

#ifndef ITG3200_H
#define ITG3200_H

// register map
#define ITG3200_WHO_AM_I 	0x00
#define ITG3200_SMPLRT_DIV 	0x15
#define ITG3200_DLPF_FS		0x16
#define ITG3200_INT_CFG		0x17
#define ITG3200_INT_STATUS	0x1A
#define ITG3200_TEMP_OUT_H	0x1B
#define ITG3200_TEMP_OUT_L	0x1C
#define ITG3200_GYRO_XOUT_H 0x1D
#define ITG3200_GYRO_XOUT_L 0x1E
#define ITG3200_GYRO_YOUT_H 0x1F
#define ITG3200_GYRO_YOUT_L 0x20
#define ITG3200_GYRO_ZOUT_H 0x21
#define ITG3200_GYRO_ZOUT_L 0x22
#define ITG3200_PWR_MGM 	0x3E

// ITG3200 GY-85 device address
#define ITG3200_DEVICE  	0x68
// num of bytes we are going to read each time (two bytes for each axis)
#define ITG3200_TO_READ 	6

#define ITG3200_SCALE_FACTOR  (1 / 14.375) // sensitivity scale factor for 2000º/sec FS_SEL=3 (datasheet)

class ITG3200
{
public:
	ITG3200();
	void initialize();
	void readGyro(float rawData[3]);
	void scaleGyro(float scaledData[3]);
	float gains[3]; //gains
private:
	void writeTo(byte address, byte val);
	void readFrom(byte address, int num, byte buff[]);
	byte _buff[6]; 
};

#endif
