/*
 * driver info:
 * HMC5883L magnetometer (GY-85 module)
 *
 * IIC bus protocol using Arduino <Wire> library
 *
 *
 * Bruno Silva (brvisi@gmail.com)
 */

#ifndef HMC5883L_H
#define HMC5883L_H

// register map
#define HMC5883L_ConfigurationRegisterA 	0x00
#define HMC5883L_ConfigurationRegisterB  	0x01
#define HMC5883L_ModeRegister            	0x02
#define HMC5883L_AxisXDataRegisterMSB    	0x03
#define HMC5883L_AxisXDataRegisterLSB    	0x04
#define HMC5883L_AxisZDataRegisterMSB     	0x05
#define HMC5883L_AxisZDataRegisterLSB     	0x06
#define HMC5883L_AxisYDataRegisterMSB     	0x07
#define HMC5883L_AxisYDataRegisterLSB     	0x08
#define HMC5883L_StatusRegister           	0x09
#define HMC5883L_IdentificationRegisterA  	0x10
#define HMC5883L_IdentificationRegisterB  	0x11
#define HMC5883L_IdentificationRegisterC  	0x12

// operation mode (HMC5883L_ConfigurationRegisterA)
#define HMC5883L_MeasurementContinuous  	0x00
#define HMC5883L_MeasurementSingleShot  	0x01
#define HMC5883L_MeasurementIdle  			0x03

// HMC5883L GY-85 device address
#define HMC5883L_DEVICE 					0x1E
// num of bytes we are going to read each time (two bytes for each axis)
#define HMC5883L_TO_READ 					6

// nominal gain (HMC5883L_ConfigurationRegisterB)
#define HMC5883L_DefaultFieldRange 			1.3 // in Ga (accepted values: 0.88, 1.3, 1.9, 2.5, 4.0, 4.7, 5.6, 8.1

class HMC5883L
{
public:
	HMC5883L();
	void initialize();
	void readMag(float rawData[3]);
	void scaleMag(float scaledData[3]);
	void calibrateMag(float calibratedData[3]);
	void setGain(float fieldRange);
private:
	void writeTo(byte address, byte val);
	void readFrom(byte address, int num, byte buff[]);
	float HMC5883L_SCALE_FACTOR;
	byte _buff[6]; 
};

#endif
