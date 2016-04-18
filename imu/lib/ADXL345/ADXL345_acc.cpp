/*
 * driver info:
 * ADXL345 accelerometer (GY-85 module)
 *
 * IIC bus protocol using Arduino <Wire> library
 *
 *
 * Bruno Silva (brvisi@gmail.com)
 */

#include <Arduino.h>
#include <Wire.h>
#include "ADXL345_acc.h"

ADXL345::ADXL345() 	{}

void ADXL345::writeTo(byte address, byte val)
{
	Wire.beginTransmission(ADXL345_DEVICE);
	Wire.write(address); 
	Wire.write(val); 
	Wire.endTransmission();  
}

void ADXL345::readFrom(byte address, int num, byte _buff[])
{
	Wire.beginTransmission(ADXL345_DEVICE);
	Wire.write(address); 
	Wire.endTransmission(); 
	
	Wire.beginTransmission(ADXL345_DEVICE);
	Wire.requestFrom(ADXL345_DEVICE, num); 
	
	int i = 0;
	while(Wire.available()) 
	{ 
		_buff[i] = Wire.read(); 
		i++;
	}
	/*if(i != num){
		status = ADXL345_ERROR;
		error_code = ADXL345_READ_ERROR;
	}*/
	Wire.endTransmission();  
}

void ADXL345::initialize()
{
	Wire.begin();

	writeTo(ADXL345_POWER_CTL, 0x08);
}

void ADXL345::read()
{
	readFrom(ADXL345_DATAX0, ADXL345_TO_READ, _buff);  //Read ADXL345_TO_READ bytes from ADXL345_DATAX0 onwards and store it in _buff
	
	orientationVector[0] = (((int)_buff[1]) << 8) | _buff[0];
	orientationVector[1] = (((int)_buff[3]) << 8) | _buff[2];
	orientationVector[2] = (((int)_buff[5]) << 8) | _buff[4];

}

void ADXL345::applyCalibration()
{


}

void ADXL345::scale()
{


}

void ADXL345::getOrientationVector(float (&data)[3])
{
	read();
	applyCalibration();
	scale();

	memcpy(data, orientationVector, sizeof(data));
}

