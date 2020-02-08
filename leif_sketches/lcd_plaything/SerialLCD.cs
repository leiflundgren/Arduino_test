using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace lcd_plaything
{



    /*
      SerialLCD.h - Serial LCD driver Library
      2010 Copyright (c) Seeed Technology Inc.  All right reserved.
 
      Original Author: Jimbo.We
      Contribution: Visweswara R 
  
      Modified 15 March,2012 for Arduino 1.0 IDE
      by Frankie.Chu
  
      This library is free software; you can redistribute it and/or
      modify it under the terms of the GNU Lesser General Public
      License as published by the Free Software Foundation; either
      version 2.1 of the License, or (at your option) any later version.

      This library is distributed in the hope that it will be useful,
      but WITHOUT ANY WARRANTY; without even the implied warranty of
      MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
      Lesser General Public License for more details.

      You should have received a copy of the GNU Lesser General Public
      License along with this library; if not, write to the Free Software
      Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA

      Used as a base for an C# class.
     */


    //Initialization Commands or Responses

    enum slcd
    {

        SLCD_INIT = 0xA3,
        SLCD_INIT_ACK = 0xA5,
        SLCD_INIT_DONE = 0xAA,

        //WorkingMode Commands or Responses
        SLCD_CONTROL_HEADER = 0x9F,
        SLCD_CHAR_HEADER = 0xFE,
        SLCD_CURSOR_HEADER = 0xFF,
        SLCD_CURSOR_ACK = 0x5A,

        SLCD_RETURN_HOME = 0x61,
        SLCD_DISPLAY_OFF = 0x63,
        SLCD_DISPLAY_ON = 0x64,
        SLCD_CLEAR_DISPLAY = 0x65,
        SLCD_CURSOR_OFF = 0x66,
        SLCD_CURSOR_ON = 0x67,
        SLCD_BLINK_OFF = 0x68,
        SLCD_BLINK_ON = 0x69,
        SLCD_SCROLL_LEFT = 0x6C,
        SLCD_SCROLL_RIGHT = 0x72,
        SLCD_NO_AUTO_SCROLL = 0x6A,
        SLCD_AUTO_SCROLL = 0x6D,
        SLCD_LEFT_TO_RIGHT = 0x70,
        SLCD_RIGHT_TO_LEFT = 0x71,
        SLCD_POWER_ON = 0x83,
        SLCD_POWER_OFF = 0x82,
        SLCD_INVALIDCOMMAND = 0x46,
        SLCD_BACKLIGHT_ON = 0x81,
        SLCD_BACKLIGHT_OFF = 0x80,
    }

    class SerialLCD
    {
        private string[] text;
        private int line = 0;
        private int pos = 0;

        private bool active = false;
        private bool m_leftToRight = true;
        private bool m_backlight = false;

        public string Text
        {
            get { return active ? string.Empty : string.Join("\r\n", text); }
        }

        private string Line
        {
            get { return text[line]; }
            set { text[line] = value; }
        }

        public bool LeftToRight
        {
            get { return m_leftToRight; }
            set
            {
                m_leftToRight = value;
                FirePropertyChanged("LeftToRight");
            }
        }

        public bool Backlight
        {
            get { return m_backlight; }
            set
            {
                m_backlight = value;
                FirePropertyChanged("backlight");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void FirePropertyChanged(string prop)
        {
            if ( PropertyChanged != null )
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


        public static int width = 16;
        public static int height = 2;

        public SerialLCD(int pin_in, int pin_out)
        {
            active = false;
            clear();
        }

        public void begin() { }
        public void clear()
        {
            text = new string[] { new string(' ', width), new string(' ', width) };
            home();
        }
        public void home()
        {
            line = 0;
            pos = 0;
        }

        public void noDisplay() { }
        public void display() { }
        public void noBlink() { }
        public void blink() { }
        public void noCursor() { }
        public void cursor() { }

        public void scrollDisplayLeft()
        {
            text = Array.ConvertAll(text, delegate(string line)
                    {
                        if (string.IsNullOrEmpty(line)) return string.Empty;
                        else return line.Substring(1);
                    }
                );
        }
        
        public void scrollDisplayRight()
        {
             text = Array.ConvertAll(text, delegate(string line) 
                     {
                         if (string.IsNullOrEmpty(line)) return string.Empty;
                         string s = " " + line;
                         if ( s.Length > width )
                             s = s.Substring(0, width);
                         return s;
                     }
                );
        }

        public void leftToRight()
        {
            LeftToRight = true;
        }
        public void rightToLeft()
        {
            LeftToRight = false;
        }
        public void autoscroll() { }
        public void noAutoscroll() { }

        public void setCursor(int x, int y)
        {
            pos = x;
            line = y;
        }
        public void noPower() { active = false; }
        public void Power() { active = true; }
        public void noBacklight()
        {
            Backlight = false;
        }
        public void backlight()
        {
            Backlight = true;
        }

        public void print(string s)
        {
            string pre = this.text[line].Substring(0, pos);
            string post = string.Empty;
            if (pos + s.Length < width && this.text[line].Length >= pos+s.Length)
                post = this.text[line].Substring(pos + s.Length).Trim();
            this.text[line] = pre + s + post;
            pos = pre.Length + s.Length;
        }

        public void print(int b)
        {
            print(b.ToString());
        }
        public void print(char[] data)
        {
            print(new string(data));
        }
        public void print(long n, int base_n)
        {
            print(Convert.ToString(n, base_n));
        }
        public void print(float data, int num)
        {
            print( String.Format("{0:0."+ new string('0', num) + "}", data) );
        }
    }

}

 