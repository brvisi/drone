/*
 * driver info:
 * ITG3200 gyroscope (GY-85 module)
 *
 * IIC bus protocol using Arduino <Wire> library
 *
 *
 * Bruno Silva (brvisi@gmail.com)
 */

#include "Arduino.h"
#include "ITG3200_gyro.h"
#include <Wire.h>

ITG3200::ITG3200()
{
	Wire.begin();

	writeTo(ITG3200_DLPF_FS, 0x18); // DLPF_CFG = 3, FS_SEL = 3
}

void ITG3200::writeTo(byte address, byte val)
{
	Wire.beginTransmission(ITG3200_DEVICE);
	Wire.write(address); 
	Wire.write(val); 
	Wire.endTransmission();  
}

void ITG3200::readFrom(byte address, int num, byte _buff[])
{
	Wire.beginTransmission(ITG3200_DEVICE);
	Wire.write(address); 
	Wire.endTransmission(); 
	
	Wire.beginTransmission(ITG3200_DEVICE);
	Wire.requestFrom(ITG3200_DEVICE, num); 
	
	int i = 0;
	while(Wire.available()) 
	{ 
		_buff[i] = Wire.read(); 
		i++;
	}
	/*if(i != num){
		status = ITG3200_ERROR;
		error_code = ITG3200_READ_ERROR;
	}*/
	Wire.endTransmission();  
}

void ITG3200::read()
{
	readFrom(ITG3200_GYRO_XOUT_H, ITG3200_TO_READ, _buff); 
	
	orientationVector[0] = (((int)_buff[0]) << 8) | _buff[1];
	orientationVector[1] = (((int)_buff[2]) << 8) | _buff[3];
	orientationVector[2] = (((int)_buff[4]) << 8) | _buff[5];
}

void ITG3200::scale()
{
	orientationVector[0] *= ITG3200_SCALE_FACTOR;
	orientationVector[1] *= ITG3200_SCALE_FACTOR;
	orientationVector[2] *= ITG3200_SCALE_FACTOR;
}

void ITG3200::applyCalibration()
{

}

/*
 * getOrientationVector method:
 * store calibrated and scaled accelerometer data(x,y,z) in '&data' parameter
 */
void ITG3200::getOrientationVector(float (&data)[3])
{
	read();
	applyCalibration();
	scale();

	memcpy(data, orientationVector, sizeof(data));
}

