/*
  SerialLCD Library - Hello World
 
 Demonstrates the use a 16x2 LCD SerialLCD driver from Seeedstudio.
 
 This sketch prints "Hello, Seeeduino!" to the LCD
 and shows the time.
 
 Library originally added 16 Dec. 2010
 by Jimbo.we 
 http://www.seeedstudio.com
 */

// include the library code:
#include <SerialLCD.h>
#include <SoftwareSerial.h> //this is a must

// initialize the library
SerialLCD slcd(11,12);//this is a must, assign soft serial pins

bool backlight=false;
const long unsigned int blink_length = 80;
const long unsigned int blinks = 4; // 2 on, 1 off
long unsigned int current_second = -1;

void setup() {
  // set up
  slcd.begin();

  slcd.backlight();
  // Print a message to the LCD.
  slcd.print("hello, world!");
}

void loop() {
  // set the cursor to column 0, line 1
  // (note: line 1 is the second row, since counting begins with 0):
  slcd.setCursor(0, 1);
  // print the number of seconds since reset:
  long unsigned int t = millis()/1000;
  if ( t != current_second )
  {
    slcd.print(t,DEC);
    current_second = t;
  }

  long unsigned int ms = millis()%1000;

  long unsigned int currentBlink = ms/blink_length;

  if ( currentBlink < blinks )
  {
    bool shouldBeOn = (currentBlink%2)==0;

    if ( shouldBeOn != backlight )
    {
      if ( shouldBeOn )
        slcd.backlight();
      else
        slcd.noBacklight();
      backlight = shouldBeOn;
    }
  }

}


