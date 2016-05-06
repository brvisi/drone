class PID
{
public:
	PID(float _kp, float _ki, float _kd);
	void setKp(float Kp);
	void setKi(float Ki);
	void setKd(float Kd);
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
