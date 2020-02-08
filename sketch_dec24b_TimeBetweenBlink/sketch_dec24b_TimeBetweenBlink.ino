#include <Time.h>

int startT;
int digiInPin = 8;
int ledPin = 13;      // select the pin for the LED

int lastStart=0;
int lastStop = 0;
int currentVal;

const int min_light_time=500;
int last_light_at=0;
int is_lit=0;

void setup()
{
  pinMode(digiInPin, INPUT);
  pinMode(ledPin, OUTPUT);  
  
  Serial.begin(9600);
  currentVal = digitalRead(digiInPin);
  startT = millis();
  Serial.println(__FILE__);
  Serial.println(__TIME__);
}

float time_to_avg_kW(int period_ms)
{
  return 3600/period_ms;
}

void loop()
{
  int dval = digitalRead(digiInPin);
  if(dval != currentVal)
  {
    int t = millis();
    currentVal = dval;
   
    if ( dval ) 
    {
      /*
      Serial.print("Start at ");
      Serial.print(t);
      if ( lastStop > 0 )
      {
        int period = t-lastStop;
        Serial.print(" was dark ");
        Serial.print(period);
        Serial.print("ms");
      }
      Serial.println("");
      */
      if ( lastStart > 0 )
      {
        int period = t-lastStart;
        Serial.print("Period: ");
        Serial.print(period);
        Serial.print(" avg ");
        Serial.print( time_to_avg_kW(period) );
        Serial.println("");
      }
      
      lastStart = t;
            
    }    
    else
    {
      digitalWrite(ledPin, HIGH);   
      last_light_at = t;
      is_lit=1;
     /* 
      Serial.print("Stop at ");
      Serial.print(t);
      if ( lastStart > 0 )
      {
        int period = t-lastStop;
        Serial.print(" was light ");
        Serial.print(period);
        Serial.print("ms");
      }
      Serial.println("");
      */
      lastStop = t;
    }    
  }
  
  if ( dval && is_lit && millis()-last_light_at > min_light_time )
  {
    is_lit = 0;
    digitalWrite(ledPin, LOW);
  }

}

