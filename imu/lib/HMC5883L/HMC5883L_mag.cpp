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
	HMC5883L_SCALE_FACTOR = ((1 / 1090) * 1000); // default configuration: field range 1.3Ga
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
		HMC5883L_SCALE_FACTOR = ((1 / 1370) * 1000);
		writeTo(HMC5883L_ConfigurationRegisterB, 0x00);
	}
	else if (HMC5883L_DefaultFieldRange==1.3)
	{
		HMC5883L_SCALE_FACTOR = ((1 / 1090) * 1000);
		writeTo(HMC5883L_ConfigurationRegisterB, 0x20);
	}
	else if (HMC5883L_DefaultFieldRange==1.9)
	{
		HMC5883L_SCALE_FACTOR = ((1 / 820) * 1000);
		writeTo(HMC5883L_ConfigurationRegisterB, 0x40);
	}
	else if (HMC5883L_DefaultFieldRange==2.5)
	{
		HMC5883L_SCALE_FACTOR = ((1 / 660) * 1000);
		writeTo(HMC5883L_ConfigurationRegisterB, 0x60);
	}
	else if (HMC5883L_DefaultFieldRange==4.0)
	{
		HMC5883L_SCALE_FACTOR = ((1 / 440) * 1000);
		writeTo(HMC5883L_ConfigurationRegisterB, 0x80);
	}
	else if (HMC5883L_DefaultFieldRange==4.7)
	{
		HMC5883L_SCALE_FACTOR = ((1 / 390) * 1000);
		writeTo(HMC5883L_ConfigurationRegisterB, 0xA0);
	}
	else if (HMC5883L_DefaultFieldRange==5.6)
	{
		HMC5883L_SCALE_FACTOR = ((1 / 330) * 1000);
		writeTo(HMC5883L_ConfigurationRegisterB, 0xC0);
	}
	else if (HMC5883L_DefaultFieldRange==8.1)
	{
		HMC5883L_SCALE_FACTOR = ((1 / 230) * 1000);
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
			HMC5883L_SCALE_FACTOR = ((1 / 1090) * 1000);
			writeTo(HMC5883L_ConfigurationRegisterB, 0x20);
		}
}

void HMC5883L::readMag(float rawData[3])
{
	readFrom(HMC5883L_AxisXDataRegisterMSB, HMC5883L_TO_READ, _buff); //Read HMC5883L_TO_READ bytes from HMC5883L_AxisXDataRegisterMSB onwards and store it in _buff
		
	rawData[0] = (((int)_buff[0]) << 8) | _buff[1];
	rawData[2] = (((int)_buff[2]) << 8) | _buff[3];  //----->>>  X, Z, Y
	rawData[1] = (((int)_buff[4]) << 8) | _buff[5];
}

void HMC5883L::scaleMag(float scaledData[3])
{
	scaledData[0] *= HMC5883L_SCALE_FACTOR;
	scaledData[1] *= HMC5883L_SCALE_FACTOR;
	scaledData[2] *= HMC5883L_SCALE_FACTOR;
}

void HMC5883L::calibrateMag(float calibratedData[3])
{
	int EEPROM_ADDRESS=0;  // eeprom offset for magnetometer range values
	float offset[6];

	for(int i=0;i<6;i++)
	{
		EEPROM.get(EEPROM_ADDRESS + (i*(sizeof(float))),offset[i]);
	}

	float offsetX = (offset[0] + offset[1]) / 2;
	float offsetY = (offset[2] + offset[3]) / 2;
	float offsetZ = (offset[4] + offset[5]) / 2;

	calibratedData[0] += offsetX;
	calibratedData[1] += offsetY;
	calibratedData[2] += offsetZ;
}
