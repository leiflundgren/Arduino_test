using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace lcd_plaything
{
    public partial class frm : Form
    {
        private SerialLCD lcd;
        private DataSource dataSource = new DataSource();


        public frm()
        {
            InitializeComponent();
        }

        public void UpdateText()
        {
            lblLcd.Text = lcd.Text;
        }

        private void frm_Load(object sender, EventArgs e)
        {
            lcd = new SerialLCD(10, 11);
            lcd.PropertyChanged += new PropertyChangedEventHandler(lcd_PropertyChanged);
        }

        void lcd_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateText();
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;
            lcd.PropertyChanged -= new PropertyChangedEventHandler(lcd_PropertyChanged);
            lcd = null;
        }

        enum DisplayMode
        {
            tempratures = 0,
            heatingTemps = 1,
            power = 2,
        }
        private DisplayMode content = DisplayMode.power;
        private DisplayMode NextContext() {
            return (content = (DisplayMode) (((int)content + 1) % (1+(int)DisplayMode.power)));
        }

        DateTime staticUntil = DateTime.MinValue;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DateTime.UtcNow < staticUntil)
                return;
            NextDisplay();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NextDisplay();
            staticUntil = DateTime.UtcNow + TimeSpan.FromSeconds(5);
        }

        private void NextDisplay()
        {
            Measurement data = dataSource.GetData();

            lcd.clear();
            DisplayMode mode = NextContext();
            switch ( mode )
            {
                case DisplayMode.heatingTemps:
                    lcd.setCursor(0, 0);
                    lcd.print("HeatOut  ");
                    lcd.print(data.heatOut, 1);
                    lcd.setCursor(0, 1);
                    lcd.print("HeatBack ");
                    lcd.print(data.heatIn, 1);
                    break;

                case DisplayMode.tempratures:
                    lcd.setCursor(0, 0);
                    lcd.print("TempOut ");
                    lcd.print(data.tempOut, 1);
                    lcd.setCursor(0, 1);
                    lcd.print("TempIn  ");
                    lcd.print(data.tempIn, 1);
                    break;

                case DisplayMode.power:
                    lcd.setCursor(0, 0);
                    lcd.print("Power consumption:");
                    lcd.setCursor(0, 1);
                    lcd.print(data.W, 1);
                    lcd.print(" kW");
                    break;
            }
            UpdateText();
        }

        private void chkSlideshow_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = chkSlideshow.Checked;
        }

    }
}
