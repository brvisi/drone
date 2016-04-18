/*
 * driver info:
 * HMC5883L magnetometer (GY-85 module)
 *
 * IIC bus protocol using Arduino <Wire> library
 *
 *
 * Bruno Silva (brvisi@gmail.com)
 */

#include <Arduino.h>
#include <Wire.h>
#include <EEPROM.h>
#include "HMC5883L_mag.h"

HMC5883L::HMC5883L()
{
	HMC5883L_SCALE_FACTOR = (1000 / 1090); // default configuration: field range 1.3Ga
}

void HMC5883L::writeTo(byte address, byte val)
{
	Wire.beginTransmission(HMC5883L_DEVICE);
	Wire.write(address); 
	Wire.write(val); 
	Wire.endTransmission();  
}

void HMC5883L::readFrom(byte address, int num, byte _buff[])
{
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


void HMC5883L::initialize()
{
	Wire.begin();

	writeTo(HMC5883L_ModeRegister, HMC5883L_MeasurementContinuous);
	writeTo(HMC5883L_ConfigurationRegisterA, 0x18);

	if (HMC5883L_DefaultFieldRange==0.88) // Nominal gain configuration (HMC5883L_ConfigurationRegisterB)
	{
		HMC5883L_SCALE_FACTOR = (1000.0f / 1370.0f);
		writeTo(HMC5883L_ConfigurationRegisterB, 0x00);
	}
	else if (HMC5883L_DefaultFieldRange==1.3)
	{
		HMC5883L_SCALE_FACTOR = (1000.0f / 1090.0f);
		writeTo(HMC5883L_ConfigurationRegisterB, 0x20);
	}
	else if (HMC5883L_DefaultFieldRange==1.9)
	{
		HMC5883L_SCALE_FACTOR = (1000.0f / 820.0f);
		writeTo(HMC5883L_ConfigurationRegisterB, 0x40);
	}
	else if (HMC5883L_DefaultFieldRange==2.5)
	{
		HMC5883L_SCALE_FACTOR = (1000.0f / 660.0f);
		writeTo(HMC5883L_ConfigurationRegisterB, 0x60);
	}
	else if (HMC5883L_DefaultFieldRange==4.0)
	{
		HMC5883L_SCALE_FACTOR = (1000.0f / 440.0f);
		writeTo(HMC5883L_ConfigurationRegisterB, 0x80);
	}
	else if (HMC5883L_DefaultFieldRange==4.7)
	{
		HMC5883L_SCALE_FACTOR = (1000.0f / 390.0f);
		writeTo(HMC5883L_ConfigurationRegisterB, 0xA0);
	}
	else if (HMC5883L_DefaultFieldRange==5.6)
	{
		HMC5883L_SCALE_FACTOR = (1000.0f / 330.0f);
		writeTo(HMC5883L_ConfigurationRegisterB, 0xC0);
	}
	else if (HMC5883L_DefaultFieldRange==8.1)
	{
		HMC5883L_SCALE_FACTOR = (1000.0f / 230.0f);
		writeTo(HMC5883L_ConfigurationRegisterB, 0xE0);
	}
}

void HMC5883L::setGain(float fieldRange)
{
	if (fieldRange==0.88) // Nominal gain configuration (HMC5883L_ConfigurationRegisterB)
		{
			HMC5883L_SCALE_FACTOR = ((1 / 1370) * 1000);
			writeTo(HMC5883L_ConfigurationRegisterB, 0x00);
		}
		else if (fieldRange==1.3)
		{
			HMC5883L_SCALE_FACTOR = ((1 / 1090) * 1000);
			writeTo(HMC5883L_ConfigurationRegisterB, 0x20);
		}
		else if (fieldRange==1.9)
		{
			HMC5883L_SCALE_FACTOR = ((1 / 820) * 1000);
			writeTo(HMC5883L_ConfigurationRegisterB, 0x40);
		}
		else if (fieldRange==2.5)
		{
			HMC5883L_SCALE_FACTOR = ((1 / 660) * 1000);
			writeTo(HMC5883L_ConfigurationRegisterB, 0x60);
		}
		else if (fieldRange==4.0)
		{
			HMC5883L_SCALE_FACTOR = ((1 / 440) * 1000);
			writeTo(HMC5883L_ConfigurationRegisterB, 0x80);
		}
		else if (fieldRange==4.7)
		{
			HMC5883L_SCALE_FACTOR = ((1 / 390) * 1000);
			writeTo(HMC5883L_ConfigurationRegisterB, 0xA0);
		}
		else if (fieldRange==5.6)
		{
			HMC5883L_SCALE_FACTOR = ((1 / 330) * 1000);
			writeTo(HMC5883L_ConfigurationRegisterB, 0xC0);
		}
		else if (fieldRange==8.1)
		{
			HMC5883L_SCALE_FACTOR = ((1 / 230) * 1000);
			writeTo(HMC5883L_ConfigurationRegisterB, 0xE0);
		}
		else // out of range - return to defaults
		{
			HMC5883L_SCALE_FACTOR = (1000 / 1090);
			writeTo(HMC5883L_ConfigurationRegisterB, 0x20);
		}
}

void HMC5883L::read()
{
	readFrom(HMC5883L_AxisXDataRegisterMSB, HMC5883L_TO_READ, _buff); //Read HMC5883L_TO_READ bytes from HMC5883L_AxisXDataRegisterMSB onwards and store it in _buff
		
	orientationVector[0] = (((int)_buff[0]) << 8) | _buff[1];
	orientationVector[2] = (((int)_buff[2]) << 8) | _buff[3];  //----->>>  X, Z, Y
	orientationVector[1] = (((int)_buff[4]) << 8) | _buff[5];
}

void HMC5883L::scaleGain()
{
	orientationVector[0] *= HMC5883L_SCALE_FACTOR;
	orientationVector[1] *= HMC5883L_SCALE_FACTOR;
	orientationVector[2] *= HMC5883L_SCALE_FACTOR;
}

void HMC5883L::applyCalibration()
{
	int EEPROM_ADDRESS=0;  // eeprom offset for magnetometer range values
	float valueRange[6]; //MAG_X_MAX, MAG_X_MIN, MAG_Y_MAX, MAG_Y_MIN, MAG_Z_MAX, MAG_Z_MIN

	for(int i=0;i<6;i++)
	{
		EEPROM.get(EEPROM_ADDRESS + (i*(sizeof(float))),valueRange[i]);
	}

	float offsetX = (valueRange[0] + valueRange[1]) / 2.0f;
	float offsetY = (valueRange[2] + valueRange[3]) / 2.0f;
	float offsetZ = (valueRange[4] + valueRange[5]) / 2.0f;

	// #define MAGN_X_SCALE (100.0f / (MAGN_X_MAX - MAGN_X_OFFSET))
	float mag_x_scale = (100.0f / (valueRange[0] - offsetX));
	float mag_y_scale = (100.0f / (valueRange[2] - offsetY));
	float mag_z_scale = (100.0f / (valueRange[4] - offsetZ));

	// magnetom[0] = (magnetom[0] - MAGN_X_OFFSET) * MAGN_X_SCALE;
	orientationVector[0] = (orientationVector[0] - offsetX) * mag_x_scale;
	orientationVector[1] = (orientationVector[1] - offsetY) * mag_y_scale;
	orientationVector[2] = (orientationVector[2] - offsetZ) * mag_z_scale;
}

void HMC5883L::getOrientationVector(float (&data)[3])
{
	read();
	//applyCalibration();
	scaleGain();

	//Serial.println(HMC5883L_SCALE_FACTOR);
	memcpy(data, orientationVector, sizeof(data));
}
