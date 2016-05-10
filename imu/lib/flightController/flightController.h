#include <Arduino.h>

#include "PID.h"
#include "rotor.h"
#include "GY85.h"


class flightController
{
public:
	flightController();
	void stabilize(float G_Dt);
	int PWMtemp[4];
private:
	GY85 imu;
	rotor rotors[4];
	PID pid[4];
	float pitchResponse;
	float rollResponse;
	float yawResponse;
	float zthrustResponse;
};
