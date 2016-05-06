class dynamicalModel
{
public:

	float motorInversion();

private:

	//general parameters
	float gravity=	9.806; 	//gravity constant [m s^-2]
	float rho=		1.293; 	//air density [kg m^-3]
	float nu=		1.8e-5; //air viscosity at 20c [Pa s]
	float pi=		3.14159265359; //pi

	//quadrotor parameters
	int propellers=	4; 		//number of propellers
	float armLength=29.997; //arm length [m]
	float volume=	0.00281784516; //volume [m3] (((86.36*86.36)/1000)
	float rotorMass=60e-3; 	//quadrotor mass [kg]
	float h=		17e-3; 	//vertical distance between CoG and propellers plan [m]
	float b=		3.13e-5; //thrust factor in hover [N s^2]
	float d=		7.5e-7; //drag factor in hover [N m s^2]
	float wProp=	(rotorMass*gravity)/propellers; //weight of the quadrotor per propeller [N]
	float omegaH=	sqrt(wProp/b); //propeller speed at hover

	//propellers
	int blades=		3; //number of blades per propeller
	float radius=	32.5e-3; //propeller radius [m]
	float A=		pi*(pow(radius,2)); //propeller disk area [m^2]
	float c=		0.0394; //chord [m]
	float theta0=	0.2618; //pitch of incidence [rad]
	float thetaTw=	0.045; 	//twist pitch [rad]
	float sigma=	(blades*c)/(pi*radius); //solidity ratio (rotor fill ratio) [rad^-1]
	float a=		5.7; 	//lift slope
	float C_d=		0.052;	//airfoil drag coefficient
	float A_c=		0.005;	//helicopter center hub area [m^2]

	//longitudinal drag coefficients
	float Cx = 1.32;
	float Cy = 1.32;
	float Cz = 1.32;

	//inertia components [kg m^2]
	float Ixx = 6.228e-3;
	float Iyy = 6.228e-3;
	float Izz = 1.121e-2;

 	//motor parameters
       // TODO complete the motor parameters
    float k_m = 1; //#TODO # torque constant
    float tau = 1; //#TODO # motor time constant
    float eta = 1; //#TODO # motor efficiency
    float Omega_0 = 1; //#TODO # point of linearization of the rotor speeds

    float r = 4; //# Reduction ratio
    float J_t = 6.0100e-5; //# Rotor inertia [kg m^2]

    //matrix for calculating the motor voltages from the control inputs
	float m[4][4]= {
					{(1/(4*b), 0, 1/(2*b), -1/(4*b))},
					{(1/(4*b), -1/(2*b), 0, 1/(4*b))},
					{(1/(4*b), 0, -1/(2*b), -1/(4*b))},
					{(1/(4*b), 1/(2*b), 0 ,  1/(4*b))}
					};



};
