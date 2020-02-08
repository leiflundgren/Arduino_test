namespace lcd_plaything
{
    partial class frm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblLcd = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chkSlideshow = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLcd
            // 
            this.lblLcd.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblLcd.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLcd.Location = new System.Drawing.Point(12, 9);
            this.lblLcd.Name = "lblLcd";
            this.lblLcd.Size = new System.Drawing.Size(331, 67);
            this.lblLcd.TabIndex = 0;
            this.lblLcd.Text = "0123456789ABCDEF\r\nHello LCD world!";
            // 
            // timer1
            // 
            this.timer1.Interval = 1800;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chkSlideshow
            // 
            this.chkSlideshow.AutoSize = true;
            this.chkSlideshow.Location = new System.Drawing.Point(350, 13);
            this.chkSlideshow.Name = "chkSlideshow";
            this.chkSlideshow.Size = new System.Drawing.Size(82, 17);
            this.chkSlideshow.TabIndex = 0;
            this.chkSlideshow.Text = "Rotate data";
            this.chkSlideshow.UseVisualStyleBackColor = true;
            this.chkSlideshow.CheckedChanged += new System.EventHandler(this.chkSlideshow_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(350, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frm
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 285);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkSlideshow);
            this.Controls.Add(this.lblLcd);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm";
            this.Text = "LCD test";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_FormClosed);
            this.Load += new System.EventHandler(this.frm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLcd;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox chkSlideshow;
        private System.Windows.Forms.Button button1;
    }
}

