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
#include "PID.h"

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

	PID rollPID(0.9,0,0.2);
	PID pitchPID(0.9,0,0.2);
	PID yawPID(0,0,0);
	PID zPID(1,0,0);

	float roll, pitch, yaw,zthrust=0;
	float PWM1, PWM2, PWM3, PWM4=0;

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

			pitch = pitchPID.update(-ori[0]);
			roll = rollPID.update(-ori[1]);
			yaw = yawPID.update(-ori[2]);
			zthrust = zPID.update(20); //rover dutyCicle 20%

			PWM1 = zthrust + pitch + yaw;
			PWM2 = zthrust - roll - yaw;
			PWM3 = zthrust - pitch + yaw;
			PWM4 = zthrust + roll - yaw;

			if (PWM1 > 100) { PWM1 = 100; }
			if (PWM1 < 0) { PWM1 = 0; }
			if (PWM2 > 100) { PWM2 = 100; }
			if (PWM2 < 0) { PWM2 = 0; }
			if (PWM3 > 100) { PWM3 = 100; }
			if (PWM3 < 0) { PWM3 = 0; }
			if (PWM4 > 100) { PWM4 = 100; }
			if (PWM4 < 0) { PWM4 = 0; }

			led.setPWMSpeed(PWM1);
			led2.setPWMSpeed(PWM2);
			led3.setPWMSpeed(PWM3);
			led4.setPWMSpeed(PWM4);

			Serial.println("PWM1:" + String(PWM1) + " PWM2:" + String(PWM2) + " PWM3:" + String(PWM3) + " PWM4:" + String(PWM4));
			//Serial.println(String(pitch) + "," + String(roll) + "," + String(yaw));
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
