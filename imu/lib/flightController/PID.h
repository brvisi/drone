#ifndef PID_H
#define PID_H

class PID
{
public:
	PID();
	PID(float _kp, float _ki, float _kd);
	void setConstants(float _kp, float _ki, float _kd);
	void setKp(float _Kp);
	void setKi(float _Ki);
	void setKd(float _Kd);
	float update(float error);
private:
	float kp;
	float ki;
	float kd;
	unsigned int currentTime;
	unsigned int previousTime;
	float previousError;
	float Cp;
	float Ci;
	float Cd;
	float dt;
	float de;
};

#endif
