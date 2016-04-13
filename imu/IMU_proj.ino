
#include <ADXL345_acc.h>
#include <ITG3200_gyro.h>
#include <HMC5883L_mag.h>
#include <Matrix_Vector_Math.h>
#include <DCM_algorithm.h>
#include <EEPROM.h>

#define CALIB 0

ADXL345 accelerometer;
ITG3200 gyroscope;
HMC5883L magnetometer;

float acc[3];
float gyro[3];
float mag[3];
float mag_offset[6];

float temp1[3];
float temp2[3];
float xAxis[] = { 1.0f, 0.0f, 0.0f };
float mag_heading;

float pitch, roll, yaw;
float pitch_deg, roll_deg, yaw_deg;

float G_Dt=0;

int data_interval = 5; //ms

unsigned int timestamp;
unsigned int timestamp_old;

int calibration_counter=0;
int EEPROM_ADDRESS=0;
float EEPROM_VALUE= 0;


void setup() 
{  
  timestamp=millis();
  
  Serial.begin(115200);
  accelerometer.initialize();
  gyroscope.initialize();
  magnetometer.initialize();
  delay(30);

  //read acc
  accelerometer.readAccel(acc);
  //read gyro
  gyroscope.readGyro(gyro);
  gyroscope.scaleGyro(gyro);
  //read mag
  magnetometer.readMag(mag);
  magnetometer.scaleMag(mag);
  
  pitch = -atan2(acc[0], sqrt(acc[1] * acc[1] + acc[2] * acc[2]));

  Vector_Cross_Product(temp1, acc, xAxis);
  Vector_Cross_Product(temp2, xAxis, temp1);

  roll = atan2(temp2[1], temp2[2]);
  //roll = atan2(acc[1], sqrt(acc[0] * acc[0] + acc[2] * acc[2]));

  // Tilt compensated magnetic field X
  float mag_x = mag[0] * cos(pitch) + mag[1] * sin(roll) * sin(pitch) + mag[2] * cos(roll) * sin(pitch);
  // Tilt compensated magnetic field Y
  float mag_y = mag[1] * cos(roll) - mag[2] * sin(roll);
  mag_heading = atan2(mag_y, mag_x);

  yaw = mag_heading;

  init_rotation_matrix(yaw, pitch, roll);

  if (CALIB == 1)
  {  
    Serial.println("CALIBRATION");
    float MAG_RANGE[6]; // MAG_MAX_X; MAG_MIN_Y; MAG_MAX_Y; MAG_MIN_Y; MAG_MAX_Z; MAG_MIN_Z
 
    while(calibration_counter<3000)
    {
      Serial.println(String(calibration_counter));
      magnetometer.readMag(mag);
      Serial.println("Mag: " + String(mag[0]) + "," + String(mag[1]) + "," + String(mag[2]));
      if (MAG_RANGE[0]<mag[0]) { MAG_RANGE[0] = mag[0]; }
      if (MAG_RANGE[1]>mag[0]) { MAG_RANGE[1] = mag[0]; }
      if (MAG_RANGE[2]<mag[1]) { MAG_RANGE[2] = mag[1]; }
      if (MAG_RANGE[3]>mag[1]) { MAG_RANGE[3] = mag[1]; }
      if (MAG_RANGE[4]<mag[2]) { MAG_RANGE[4] = mag[2]; }
      if (MAG_RANGE[5]>mag[2]) { MAG_RANGE[5] = mag[2]; }    
  
      delay(10);
      calibration_counter++;
    }
    /*
    String stringMAG_RANGE;
    for (int i=0; i<6; i++)
    {
      stringMAG_RANGE += String(MAG_RANGE[i]) + " ";
    }

    Serial.println(stringMAG_RANGE);
    */
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
  
}

float cosPitch;
float sinPitch;
float cosRoll;
float sinRoll;

void loop() {

  if ((millis() - timestamp) >= data_interval)
  {
    timestamp_old = timestamp;
    timestamp = millis();
    if (timestamp > timestamp_old) { G_Dt = (float)(timestamp - timestamp_old) / 1000.0f; }
    else { G_Dt = 0; }
  
  //read acc
  accelerometer.readAccel(acc);
  //read gyro
  gyroscope.readGyro(gyro);
  gyroscope.scaleGyro(gyro);
  //read mag
  magnetometer.readMag(mag);
  //magnetometer.calibrateMag(mag, mag_offset);
  magnetometer.scaleMag(mag);
 
  //void DCM_algorithm(float acc[3], float gyro[3], float mag[3], float G_dt, bool drift_correction, float pitch, float roll, float yaw)

  pitch = atan2(acc[0], sqrt(acc[1] * acc[1] + acc[2] * acc[2]));

  Vector_Cross_Product(temp1, acc, xAxis);
  Vector_Cross_Product(temp2, xAxis, temp1);

  //roll = atan2(temp2[1], temp2[2]);
  roll = atan2(acc[1], sqrt(acc[0] * acc[0] + acc[2] * acc[2]));


  cosPitch = cos(pitch);   
  sinPitch = sin(pitch) ; 
  cosRoll = cos(roll)  ;
  sinRoll = sin(roll)  ;

  //compMag = [0,0,0] 
  //float mag_x = (mag[0]*cosPitch) + (mag[2]*sinPitch);  
  //float mag_y = (mag[0]*sinRoll*sinPitch) + (mag[1]*cosRoll) - (mag[2]*sinRoll*cosPitch) ; 
  //compMag[Z] = (-rawMag[X]*cosRoll*sinPitch) + (rawMag[Y]*sinRoll) - (rawMag[Z]*cosRoll*cosPitch) 
  
  // Tilt compensated magnetic field X
  float mag_x = mag[0] * cos(pitch) + mag[1] * sin(roll) * sin(pitch) - mag[2] * cos(roll) * sin(pitch);
  // Tilt compensated magnetic field Y
  float mag_y = mag[1] * cos(roll) + mag[2] * sin(roll);
  
  mag_heading = atan2(mag_y, mag_x);
  //yaw = mag_heading;
  yaw =0;
  DCM_algorithm(acc, gyro, mag, G_Dt, true, pitch_deg, roll_deg, yaw_deg);

  //String stringAcc =  "Acc: " + String(acc[0]) + "," + String(acc[1]) + "," + String(acc[2]);
  //String stringGyro = "Gyro: " + String(gyro[0]) + "," + String(gyro[1]) + "," + String(gyro[2]);
  //String stringMag = "Mag: " + String(mag[0]) + "," + String(mag[1]) + "," + String(mag[2]);
  
  //Serial.println(stringAcc);
  //Serial.println(stringGyro);
  //Serial.println(stringMag);

  Serial.println(String(pitch* 57.29) + "," + String(roll* 57.29) + "," + String(yaw* 57.29) + "," + String(G_Dt)); //Em graus
  //Serial.println(String(pitch_deg) + "," + String(roll_deg) + "," + String(yaw_deg) + "," + String(G_Dt)); //Em graus
  //Serial.println("P: " + String(pitch_deg) + " R: " + String(roll_deg) + " Y: " + String(yaw_deg)); //Em graus
  
  //Serial.println(String(millis() - timestamp));
  //delay(1);
  }
}
