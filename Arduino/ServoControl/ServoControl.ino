#include <Servo.h>

Servo m1, m2, m3;
enum Motor { motor1, motor2, motor3 };

String serialData;

void setup()
{
    // Set up servo pins
    m1.attach(9);
    m2.attach(10);
    m3.attach(11);

    // Initialize starting angles
    m1.write(90+5);
    m2.write(90);
    m3.write(90);
    
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
            data.remove(data.indexOf("C"));
            break;
        case motor3:
            data.remove(0, data.indexOf("C") + 1);
            break;
        default:
            return 90;
    }
    return data.toInt();
}

void serialEvent()
{
    serialData = Serial.readString();
    m1.write(ParseAngleData(serialData, motor1) + 5);
    m2.write(ParseAngleData(serialData, motor2));
    m3.write(ParseAngleData(serialData, motor3));
}
