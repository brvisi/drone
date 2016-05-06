#include <Arduino.h>

#include "PID.h"

PID::PID(float _kp, float _ki, float _kd)
{
	currentTime = millis();
	previousTime = currentTime;

	kp=_kp;
	ki=_ki;
	kd=_kd;

	previousError = 0;

	Cp=0;
	Ci=0;
	Cd=0;
}

float PID::update(float error)
{
	currentTime = millis();
	dt = currentTime - previousTime;
	de = error - previousError;

	Cp = error;
	Ci += error * dt;

	Cd = 0;
	if (dt>0) { Cd = de/dt; }

	previousTime = currentTime;
	previousError = error;

	//   terms_sum = self.Cp * self.Kp  + (self.Ki * self.Ci) + (self.Kd * self.Cd)
	return (kp*Cp + (ki*Ci) + (kd*Cd));
}
