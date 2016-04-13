#include "Arduino.h"
#include "ADXL345_acc.h"
#include "Wire.h"

ADXL345::ADXL345() 	{
	/*gains[0] = 0.00376390;
	gains[1] = 0.00376009;
	gains[2] = 0.00349265;*/
}

void ADXL345::writeTo(byte address, byte val) {
	Wire.beginTransmission(ADXL345_DEVICE);
	Wire.write(address); 
	Wire.write(val); 
	Wire.endTransmission();  
}

void ADXL345::readFrom(byte address, int num, byte _buff[]) {
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

void ADXL345::initialize() {
	Wire.begin();

	writeTo(ADXL345_POWER_CTL, 0x08); 
}

void ADXL345::readAccel(float raw_data[3]) {
	readFrom(ADXL345_DATAX0, ADXL345_TO_READ, _buff); 
	
	raw_data[0] = (((int)_buff[1]) << 8) | _buff[0];   
	raw_data[1] = (((int)_buff[3]) << 8) | _buff[2];
	raw_data[2] = (((int)_buff[5]) << 8) | _buff[4];

	//raw_data[0] *= -1;
	//raw_data[1] *= -1;
	//raw_data[2] *= -1;
}


