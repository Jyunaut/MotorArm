#include <Servo.h>

String serialData;

// Motor Pins
Servo m1, m2, m3;

enum Motor { motor1, motor2, motor3 };

void setup()
{
    m1.attach(9);
    m2.attach(10);
    m3.attach(11);
    m1.write(90);
    Serial.begin(9600);
    Serial.setTimeout(10);
}

void loop()
{ }

int ParseAngleData(String data, Motor motor)
{
    switch (motor)
    {
        case motor1:
            data.remove(data.indexOf("B"));
            data.remove(data.indexOf("A"), 1);
            break;
        case motor2:
            data.remove(0, data.indexOf("B") + 1);
            break;
        default:
            return 90;  // Default to 90 degrees
    }

    return data.toInt();
}

void serialEvent()
{
    serialData = Serial.readString();
    m1.write(ParseAngleData(serialData, motor1));
    m2.write(ParseAngleData(serialData, motor2));
}
