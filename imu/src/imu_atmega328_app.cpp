#include <Arduino.h>
#include <Wire.h>

#include <Matrix_Vector_Math.h>
#include <DCM_algorithm.h>
//#include <EEPROM.h>

#define CALIB 0

float G_Dt=0;

unsigned int data_interval = 20; //ms

unsigned int timestamp;
unsigned int timestamp_old;

int calibration_counter=0;
int EEPROM_ADDRESS=0;
float EEPROM_VALUE= 0;

float *ori;



void setup() 
{  
  timestamp=millis();
  
  Serial.begin(115200);
  


  /*
  if (CALIB == 1)
  {  
    Serial.println("CALIBRATION");
    float MAG_RANGE[6]; // MAG_MAX_X; MAG_MIN_Y; MAG_MAX_Y; MAG_MIN_Y; MAG_MAX_Z; MAG_MIN_Z
 
    while(calibration_counter<3000)
    {
      Serial.println(String(calibration_counter));
      magnetometer.readMag(mag);
      //Serial.println("Mag: " + String(mag[0]) + "," + String(mag[1]) + "," + String(mag[2]));
      if (MAG_RANGE[0]<mag[0]) { MAG_RANGE[0] = mag[0]; }
      if (MAG_RANGE[1]>mag[0]) { MAG_RANGE[1] = mag[0]; }
      if (MAG_RANGE[2]<mag[1]) { MAG_RANGE[2] = mag[1]; }
      if (MAG_RANGE[3]>mag[1]) { MAG_RANGE[3] = mag[1]; }
      if (MAG_RANGE[4]<mag[2]) { MAG_RANGE[4] = mag[2]; }
      if (MAG_RANGE[5]>mag[2]) { MAG_RANGE[5] = mag[2]; }    
  
      delay(10);
      calibration_counter++;
    }
    for (int i=0; i<6; i++)
    {
      EEPROM.put(EEPROM_ADDRESS + (i*(sizeof(float))), MAG_RANGE[i]);
    }
  }
  
  EEPROM_ADDRESS=0;  //EEPROM ADDRESS 0 - MAG_OFFSET
  for(int i=0;i<6;i++)
  {
    EEPROM.get(EEPROM_ADDRESS + (i*(sizeof(float))),mag_offset[i]);
  }
   */
}

void loop() {

	Imu gy_85;
	while(1)
	{
		if ((millis() - timestamp) >= data_interval)
		  {
			timestamp_old = timestamp;
			timestamp = millis();
			if (timestamp > timestamp_old) { G_Dt = (float)(timestamp - timestamp_old) / 1000.0f; }
			else { G_Dt = 0; }


			ori = gy_85.getOrientation(1, G_Dt);
			Serial.println(String(ori[0]) + "," + String(ori[1]) + "," + String(ori[2]));
			//Serial.println(String(ori[0]* 57.29) + "," + String(ori[1]* 57.29) + "," + String(ori[2]* 57.29));
			//Serial.println("P: " + String(ori[0]* 57.29) + " R: " + String(ori[1]* 57.29) + " Y: " + String(ori[2]* 57.29));
			delay(50);
		  }
	}





/*

    //DCM_algorithm(acc, gyro, mag, G_Dt, true, pitch_deg, roll_deg, yaw_deg);

  //String stringAcc =  "Acc: " + String(acc[0]) + "," + String(acc[1]) + "," + String(acc[2]);
  //String stringGyro = "Gyro: " + String(gyro[0]) + "," + String(gyro[1]) + "," + String(gyro[2]);
  //String stringMag = "Mag: " + String(mag[0]) + "," + String(mag[1]) + "," + String(mag[2]);
  
  //Serial.println(stringAcc);
  //Serial.println(stringGyro);
  //Serial.println(stringMag);

  //Serial.println(String(pitch* 57.29) + "," + String(roll* 57.29) + "," + String(yaw* 57.29) + "," + String(G_Dt)); //Em graus
  //;Serial.println(String(pitch_deg) + "," + String(roll_deg) + "," + String(yaw_deg) + "," + String(G_Dt)); //Em graus
  //Serial.println("P: " + String(pitch_deg) + " R: " + String(roll_deg) + " Y: " + String(yaw_deg)); //Em graus
  
  //Serial.println(String(millis() - timestamp));
  //delay(1);
  }
*/
}
