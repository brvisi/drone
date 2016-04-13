#include "Arduino.h"

#define HMC5883L_ConfigurationRegisterA 0x00
#define HMC5883L_ConfigurationRegisterB  0x01
#define HMC5883L_ModeRegister            0x02
#define HMC5883L_AxisXDataRegisterMSB    0x03
#define HMC5883L_AxisXDataRegisterLSB    0x04
#define HMC5883L_AxisZDataRegisterMSB     0x05
#define HMC5883L_AxisZDataRegisterLSB     0x06
#define HMC5883L_AxisYDataRegisterMSB     0x07
#define HMC5883L_AxisYDataRegisterLSB     0x08
#define HMC5883L_StatusRegister           0x09
#define HMC5883L_IdentificationRegisterA  0x10
#define HMC5883L_IdentificationRegisterB  0x11
#define HMC5883L_IdentificationRegisterC  0x12

#define HMC5883L_MeasurementContinuous  0x00
#define HMC5883L_MeasurementSingleShot  0x01
#define HMC5883L_MeasurementIdle  0x03

#define HMC5883L_TO_READ (6)     
#define HMC5883L_DEVICE (0x1E)

#define HMC5883L_SCALE_FACTOR 0.92 //(1 / 1090) //DATASHEET 

class HMC5883L
{
public:

	HMC5883L();
	void initialize();
	void readMag(float raw_data[3]);
	void scaleMag(float scaled_data[3]);
	void calibrateMag(float calibrated_data[3], float offset[6]);
	float gains[3];

private:
	void writeTo(byte address, byte val);
	void readFrom(byte address, int num, byte buff[]);
	byte _buff[6]; 
};