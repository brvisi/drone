#include "flightController.h"

flightController::flightController()
{
	rotors[0].setPin(PD3);
	rotors[1].setPin(PD5);
	rotors[2].setPin(PD6);
	rotors[3].setPin(11);

	//initialize PID for roll, pitch, yaw, zthrust
	pid[0].setConstants(0.9,0,0.2); //roll
	pid[1].setConstants(0.9,0,0.2); //pitch
	pid[2].setConstants(0,0,0);		//yaw
	pid[3].setConstants(1,0,0);		//z thrust
}

void flightController::stabilize(float G_Dt)
{
	float *ori;
	ori = imu.getOrientation(1, G_Dt); //p r y

	pitchResponse = pid[0].update(-ori[0]); //pitch
	rollResponse = pid[1].update(-ori[1]); //roll
	yawResponse = pid[2].update(-ori[2]); //yaw
	zthrustResponse = pid[3].update(20); //rover dutyCicle 20%

	PWMtemp[0] = zthrustResponse + pitchResponse + yawResponse;
	PWMtemp[1] = zthrustResponse - rollResponse - yawResponse;
	PWMtemp[2] = zthrustResponse - pitchResponse + yawResponse;
	PWMtemp[3] = zthrustResponse + rollResponse - yawResponse;

	if (PWMtemp[0] > 100) { PWMtemp[0] = 100; }
	if (PWMtemp[0] < 0) { PWMtemp[0] = 0; }

	if (PWMtemp[1] > 100) { PWMtemp[1] = 100; }
	if (PWMtemp[1] < 0) { PWMtemp[1] = 0; }

	if (PWMtemp[2] > 100) { PWMtemp[2] = 100; }
	if (PWMtemp[2] < 0) { PWMtemp[2] = 0; }

	if (PWMtemp[3] > 100) { PWMtemp[3] = 100; }
	if (PWMtemp[3] < 0) { PWMtemp[3] = 0; }

	rotors[0].setPWMSpeed(PWMtemp[0]);
	rotors[1].setPWMSpeed(PWMtemp[1]);
	rotors[2].setPWMSpeed(PWMtemp[2]);
	rotors[3].setPWMSpeed(PWMtemp[3]);
}
