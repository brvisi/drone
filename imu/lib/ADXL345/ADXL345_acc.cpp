/*
 * driver info:
 * ADXL345 accelerometer (GY-85 module)
 * IIC bus protocol using Arduino <Wire> library
 *
 * Bruno Silva (brvisi@gmail.com)
 */

#include <Arduino.h>
#include <Wire.h>
#include "ADXL345_acc.h"

/*
 * object constructor:
 * initialize I2C communication
 * write 0x08 in register 0x2d (place the part in measurement mode)
 */
ADXL345::ADXL345()
{
	Wire.begin();

	writeTo(ADXL345_POWER_CTL, 0x08);
}

/*
 * writeTo method:
 * write 'val' in 'address' register (using I2C bus <Wire> lib)
 */
void ADXL345::writeTo(byte address, byte val)
{
	Wire.beginTransmission(ADXL345_DEVICE);
	Wire.write(address); 
	Wire.write(val); 
	Wire.endTransmission();  
}

/*
 * readFrom method:
 * read 'num' bytes from starting 'address' register onwards and stores in '_buff[]'
 * (using I2C bus <Wire> lib)
 */
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

/*
 * read method:
 * store sensor data(x,y,z) in 'orientationVector'
 *
 * values in two's complement form
	 * X value: _buff[1] is MSB & _buff[0] is LSB
	 * Y value: _buff[3] is MSB & _buff[2] is LSB
	 * Z value: _buff[5] is MSB & _buff[4] is LSB
 */
void ADXL345::read()
{
	readFrom(ADXL345_DATAX0, ADXL345_TO_READ, _buff);
	
	orientationVector[0] = (((int)_buff[1]) << 8) | _buff[0];
	orientationVector[1] = (((int)_buff[3]) << 8) | _buff[2];
	orientationVector[2] = (((int)_buff[5]) << 8) | _buff[4];

	orientationVector[0] *= -1;
	orientationVector[1] *= -1;
	orientationVector[2] *= -1;

}

void ADXL345::applyCalibration()
{


}

void ADXL345::scale()
{


}


/*
 * getOrientationVector method:
 * store calibrated and scaled accelerometer data(x,y,z) in '&data' parameter
 */
void ADXL345::getOrientationVector(float (&data)[3])
{
	read();
	applyCalibration();
	scale();

	memcpy(data, orientationVector, sizeof(data));
}

