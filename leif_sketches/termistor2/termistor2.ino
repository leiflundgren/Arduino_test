#include <math.h>

#define sensorPin 2
#define powerPin 7
int read_cnt=0;
double temp1;

void setup()
{

    Serial.begin(9600); 
    Serial.println(__FILE__);

    pinMode(powerPin, OUTPUT);
    digitalWrite(powerPin, LOW);

    // If you want to set the aref to something other than 5v
    // analogReference(EXTERNAL);
}

void read_a_sample()
{
   digitalWrite(powerPin, HIGH);
    delay(50); // wait for stable

    //getting the voltage reading from the temperature sensor
    int reading = analogRead(sensorPin);  
    digitalWrite(powerPin, LOW);
    ++read_cnt;
 
    Serial.print("Raw reading "); Serial.print(read_cnt); Serial.print(" of pin "); Serial.print(sensorPin); Serial.print(": "); Serial.print(reading); Serial.print("  ");

    // converting that reading to voltage, for 3.3v arduino use 3.3
    double voltage = 5.0 - (reading * 5.0) / 1024.0; 
 
    // print out the voltage
    Serial.print(voltage); Serial.println(" volts");
 
    double R_T = (5500.0/voltage)-1100.0;
    //double temperatureC = 4.6115*exp(-0.04281*R_T); wrong way
    double temperatureC = ( log(R_T/1000.0) - log(4.6115) ) / -0.04281;
 
    if ( read_cnt == 1 )
        temp1 = temperatureC;

    // now print out the temperature
 
    Serial.print("R_T="); Serial.print(R_T); Serial.print(" --> "); Serial.print(temperatureC); Serial.print(" degrees C   "); Serial.print("t1="); Serial.println(temp1);

}

void loop()
{
    read_a_sample(); 
    delay(2000);                                     //waiting a second

}
