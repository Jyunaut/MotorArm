#include <Servo.h>

Servo m1, m2, m3;
int pos = 0;

String serialData;

void setup()
{
    // Set up baud rate and servo connections
    Serial.begin(9600);
    Serial.setTimeout(15);
    m1.attach(9);
    m2.attach(10);
    m3.attach(11);
}

void loop()
{
    
}

void serialEvent()
{
    pos = Serial.readString().toInt();
    m1.write(pos);
}

