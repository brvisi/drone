#include "Arduino.h"
#include "ITG3200_gyro.h"
#include <Wire.h>

ITG3200::ITG3200() 	{

}

void ITG3200::writeTo(byte address, byte val) {
	Wire.beginTransmission(ITG3200_DEVICE);
	Wire.write(address); 
	Wire.write(val); 
	Wire.endTransmission();  
}

void ITG3200::readFrom(byte address, int num, byte _buff[]) {
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

void ITG3200::initialize() {
	Wire.begin();
  
	//writeTo(ITG3200_PWR_MGM, 0x80); // Power up reset defaults
	writeTo(ITG3200_DLPF_FS, 0x18); // DLPF_CFG = 3, FS_SEL = 3
	//writeTo(ITG3200_SMPLRT_DIV, 0x00); //  SMPLRT_DIV = 10 (50Hz)
	//writeTo(ITG3200_PWR_MGM, 0x00); // Set clock to PLL with z gyro reference


}

void ITG3200::readGyro(float raw_data[3]) {
	readFrom(ITG3200_GYRO_XOUT_H, ITG3200_TO_READ, _buff); 
	
	raw_data[0] = (((int)_buff[0]) << 8) | _buff[1];   
	raw_data[1] = (((int)_buff[2]) << 8) | _buff[3];
	raw_data[2] = (((int)_buff[4]) << 8) | _buff[5];

	//raw_data[0] *= -1;
	//raw_data[1] *= -1;
	//raw_data[2] *= -1;

}

void ITG3200::scaleGyro(float scaled_data[3]) {

	scaled_data[0] *= ITG3200_SCALE_FACTOR;
	scaled_data[1] *= ITG3200_SCALE_FACTOR;
	scaled_data[2] *= ITG3200_SCALE_FACTOR;

}

