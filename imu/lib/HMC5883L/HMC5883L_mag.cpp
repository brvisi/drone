#include "Arduino.h"
#include "HMC5883L_mag.h"
#include "Wire.h"

HMC5883L::HMC5883L() 	{

}


void HMC5883L::writeTo(byte address, byte val) {
	Wire.beginTransmission(HMC5883L_DEVICE);
	Wire.write(address); 
	Wire.write(val); 
	Wire.endTransmission();  
}

void HMC5883L::readFrom(byte address, int num, byte _buff[]) {
	Wire.beginTransmission(HMC5883L_DEVICE);
	Wire.write(address); 
	Wire.endTransmission(); 
	
	Wire.beginTransmission(HMC5883L_DEVICE);
	Wire.requestFrom(HMC5883L_DEVICE, num); 
	
	int i = 0;
	while(Wire.available()) 
	{ 
		_buff[i] = Wire.read(); 
		i++;
	}
	/*if(i != num){
		status = HMC5883L_ERROR;
		error_code = HMC5883L_READ_ERROR;
	}*/
	Wire.endTransmission();  
}


void HMC5883L::initialize() {
	Wire.begin();

	writeTo(HMC5883L_ModeRegister, HMC5883L_MeasurementContinuous);
	writeTo(HMC5883L_ConfigurationRegisterA, 0x18);
	writeTo(HMC5883L_ConfigurationRegisterB, 0x20);

}

void HMC5883L::readMag(float raw_data[3]) { 
	readFrom(HMC5883L_AxisXDataRegisterMSB, HMC5883L_TO_READ, _buff); 
		
	raw_data[0] = (((int)_buff[0]) << 8) | _buff[1];   
	raw_data[2] = (((int)_buff[2]) << 8) | _buff[3];  //------------------------>>>  X, Z, Y
	raw_data[1] = (((int)_buff[4]) << 8) | _buff[5];

	//raw_data[0] *= -1;
	//raw_data[1] *= -1;
	//raw_data[2] *= -1;

}

void HMC5883L::scaleMag(float scaled_data[3]) {

	scaled_data[0] *= HMC5883L_SCALE_FACTOR;
	scaled_data[1] *= HMC5883L_SCALE_FACTOR;
	scaled_data[2] *= HMC5883L_SCALE_FACTOR;

}

void HMC5883L::calibrateMag(float calibrated_data[3], float offset[6])
{
	float offset_x = (offset[0] + offset[1]) / 2;
	float offset_y = (offset[2] + offset[3]) / 2;
	float offset_z = (offset[4] + offset[5]) / 2;

	calibrated_data[0] += offset_x;
	calibrated_data[1] += offset_y;
	calibrated_data[2] += offset_z;
}
