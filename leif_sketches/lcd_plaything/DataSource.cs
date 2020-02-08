using System;
using System.Collections.Generic;
using System.Text;

namespace lcd_plaything
{
    public class DataSource
    {
        private float outTemp = -17.7F;
        private float inTemp = 21.3F;

        private float heatOut = 64.0F;
        private float heatReturn = 40.1F;

        private float power = 5.3F;


        private float diff { 
            get {
                 return 1.0F + 0.2F * (float)Math.Sin(  DateTime.UtcNow.TimeOfDay.TotalMinutes );
            }
        }

        ////private float[] last= new float[] { outTemp, inTemp, heatOut, heatReturn, power };
        //public float OutTemp { get {return -17.7F * diff; } }
        //public float InTemp { get {return 21.3F * diff; } }

        //public float HeatOut { get {return 64.0F * diff; } }
        //public float HeatReturn { get {return 40.1F * diff; } }

        //public float Power { get {return 5.3F * diff; } }

        public Measurement GetData()  {
            float diff = this.diff;
            return new Measurement {
                W = power,
                tempIn = diff * inTemp,
                tempOut = diff * outTemp,
                heatIn = diff * heatReturn,
                heatOut = diff * heatOut,  
            };
        }
    }
}
