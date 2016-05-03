/*
 * project info:
 * inertial measurement unit using dcm sensor fusion algorithm
 * serial output (pitch(y), roll(x), yaw(z))
 *
 *
 * Bruno Silva (brvisi@gmail.com)
 */

#include <Arduino.h>
#include <Wire.h>
#include <EEPROM.h>

#include "GY85.h"
#include "motion.h"

#define SERIALOUTPUT__BAUDRATE 	115200
#define CALIBRATION__MAGNETO	0
#define DATA_INTERVAL 			20 // ms

float G_Dt=0; // gyroscope integration interval
unsigned int timestamp;
unsigned int timestamp_old;
float *ori;

void setup() 
{  
	timestamp=millis();
	Serial.begin(SERIALOUTPUT__BAUDRATE);

/*	GY85 imu;

	if (CALIBRATION__MAGNETO == 1)
	{
		Serial.println("MAGNETOMETER CALIBRATION STARTED");
		imu.magCalibration();
		Serial.println("CALIBRATION FINISHED");
	}
*/
}


void loop()
{

	GY85 imu;

	rotor led(PD5);
	rotor led2(PD6);

	rotor led3(PD3);
	rotor led4(11);

	led.setPWMSpeed(20);
	led2.setPWMSpeed(40);

	led3.setPWMSpeed(30);
	led4.setPWMSpeed(200);

	while(1)
	{


		if ((millis() - timestamp) >= DATA_INTERVAL)
		  {
			timestamp_old = timestamp;
			timestamp = millis();
			if (timestamp > timestamp_old)
			{
				G_Dt = (float)(timestamp - timestamp_old) / 1000.0f;
			}
			else
			{
				G_Dt = 0;
			}

			ori = imu.getOrientation(1, G_Dt); //p r y


			led.setPWMSpeed(1);
			led2.setPWMSpeed(ori[2]);
			led3.setPWMSpeed(ori[2]);
			led4.setPWMSpeed(ori[2]);

			//Serial.println(String(ori[0]) + "," + String(ori[1]) + "," + String(ori[2]) + "," + String(G_Dt) );
		  }

	}
}

/*
 * float Atmega328P = 4 bytes (32bits)
 * char Atmega328P = 1 byte (8bits)
 *
 * program output max = charvector(6) + char + charvector(6) + char + charvector(6) - float + char + float + char + float
 * max outputsizeof = 6 + 1 + 6 + 1 + 6 = 20 bytes = 160 bits
 *
 * target data interval = 5 ms (1/200 sec)
 * 160 bits x 200 = 32000
 * Serial interface baud rate of 38400(bps) should be enough for a 5ms data interval
 *
 * target data interval = 1ms (1/1000 sec)
 * 160 x 1000 = 160000
 * Serial interface baud rate of 230400(bps) should be enough for 1ms data interval
 */
