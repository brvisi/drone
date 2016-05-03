#include <Arduino.h>

#include "motion.h"

rotor::rotor(int rotorPin)
{

	digitalPin = rotorPin;

	//pin 5 / 6 -> TIMER0 (Arduino nano)
	if ((digitalPin == 5) || (digitalPin == 6))
	{
		TCCR0A |= _BV(COM0A1) | _BV(COM0B1) | _BV(WGM01) | _BV(WGM00);
		TCCR0B |= _BV(CS01)| _BV(CS00);

		DDRD |= _BV(digitalPin);
	}
	if ((digitalPin == 9) || (digitalPin == 10)) //pin 9 / 10 -> TIMER1 (Arduino nano)
	{

		TCCR1A |= _BV(COM1A1) | _BV(COM1B1) | _BV(WGM10);
		TCCR1B |= _BV(WGM12) | _BV(CS11) | _BV(CS10);

		DDRB |= _BV(digitalPin);
	}
	if ((digitalPin == 3)) //pin 3 / 11-> TIMER2 (Arduino nano)
	{
		TCCR2A |= _BV(COM2A1) | _BV(COM2B1) | _BV(WGM21) | _BV(WGM20);
		TCCR2B |= _BV(CS22);


		DDRD |= _BV(digitalPin);
	}

	if ((digitalPin == 11))
	{
		TCCR2A |= _BV(COM2A1) | _BV(COM2B1) | _BV(WGM21) | _BV(WGM20);
		TCCR2B |= _BV(CS22);

		DDRB |= _BV(3); //0b1000; //4bits
		//pinMode(11, OUTPUT);
	}
}

void rotor::setPWMSpeed(int dutyCiclePWM)
{

	if(dutyCiclePWM<0) { dutyCiclePWM *= -1; }

	switch (digitalPin)
	{
	case (5):
		OCR0B = dutyCiclePWM;
		break;
	case (6):
		OCR0A = dutyCiclePWM;
		break;
	case (9):
		OCR1A = dutyCiclePWM;
		break;
	case (10):
		OCR1B = dutyCiclePWM;
		break;
	case (3):
		OCR2B = dutyCiclePWM;
		break;
	case (11):
		OCR2A = dutyCiclePWM;
		break;
	}

}
