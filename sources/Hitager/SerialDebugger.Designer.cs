
namespace Hitager
{
    partial class SerialDebugger
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bits1 = new System.Windows.Forms.TextBox();
            this.addInvert1 = new System.Windows.Forms.Button();
            this.send1 = new System.Windows.Forms.Button();
            this.rfOn = new System.Windows.Forms.Button();
            this.rfOff = new System.Windows.Forms.Button();
            this.bits2 = new System.Windows.Forms.TextBox();
            this.bits3 = new System.Windows.Forms.TextBox();
            this.bits4 = new System.Windows.Forms.TextBox();
            this.bits5 = new System.Windows.Forms.TextBox();
            this.bits6 = new System.Windows.Forms.TextBox();
            this.bits7 = new System.Windows.Forms.TextBox();
            this.bits8 = new System.Windows.Forms.TextBox();
            this.addInvert2 = new System.Windows.Forms.Button();
            this.addInvert3 = new System.Windows.Forms.Button();
            this.addInvert4 = new System.Windows.Forms.Button();
            this.addInvert5 = new System.Windows.Forms.Button();
            this.addInvert6 = new System.Windows.Forms.Button();
            this.addInvert7 = new System.Windows.Forms.Button();
            this.addInvert8 = new System.Windows.Forms.Button();
            this.send2 = new System.Windows.Forms.Button();
            this.send3 = new System.Windows.Forms.Button();
            this.send4 = new System.Windows.Forms.Button();
            this.send5 = new System.Windows.Forms.Button();
            this.send6 = new System.Windows.Forms.Button();
            this.send7 = new System.Windows.Forms.Button();
            this.send8 = new System.Windows.Forms.Button();
            this.tbRawData = new System.Windows.Forms.TextBox();
            this.rawSend = new System.Windows.Forms.Button();
            this.debugOffBtn = new System.Windows.Forms.Button();
            this.debugOnBtn = new System.Windows.Forms.Button();
            this.decodeBipBtn = new System.Windows.Forms.Button();
            this.decodeManBtn = new System.Windows.Forms.Button();
            this.pulse1Num = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pulse0Num = new System.Windows.Forms.NumericUpDown();
            this.hysteresisCB = new System.Windows.Forms.CheckBox();
            this.button_GainAutoAdjust = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pulse1Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pulse0Num)).BeginInit();
            this.SuspendLayout();
            // 
            // bits1
            // 
            this.bits1.Location = new System.Drawing.Point(33, 45);
            this.bits1.MaxLength = 64;
            this.bits1.Name = "bits1";
            this.bits1.Size = new System.Drawing.Size(99, 20);
            this.bits1.TabIndex = 0;
            this.bits1.Text = "00111";
            this.bits1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bits1_KeyPress);
            // 
            // addInvert1
            // 
            this.addInvert1.Location = new System.Drawing.Point(146, 45);
            this.addInvert1.Name = "addInvert1";
            this.addInvert1.Size = new System.Drawing.Size(56, 19);
            this.addInvert1.TabIndex = 1;
            this.addInvert1.Text = "Add Inv";
            this.addInvert1.UseVisualStyleBackColor = true;
            this.addInvert1.Click += new System.EventHandler(this.addInvert_Click);
            // 
            // send1
            // 
            this.send1.Location = new System.Drawing.Point(208, 45);
            this.send1.Name = "send1";
            this.send1.Size = new System.Drawing.Size(66, 20);
            this.send1.TabIndex = 2;
            this.send1.Text = "Send";
            this.send1.UseVisualStyleBackColor = true;
            this.send1.Click += new System.EventHandler(this.send1_Click);
            // 
            // rfOn
            // 
            this.rfOn.Location = new System.Drawing.Point(146, 8);
            this.rfOn.Name = "rfOn";
            this.rfOn.Size = new System.Drawing.Size(56, 19);
            this.rfOn.TabIndex = 3;
            this.rfOn.Text = "RF ON";
            this.rfOn.UseVisualStyleBackColor = true;
            this.rfOn.Click += new System.EventHandler(this.rfOn_Click);
            // 
            // rfOff
            // 
            this.rfOff.Location = new System.Drawing.Point(208, 8);
            this.rfOff.Name = "rfOff";
            this.rfOff.Size = new System.Drawing.Size(66, 19);
            this.rfOff.TabIndex = 4;
            this.rfOff.Text = "RF OFF";
            this.rfOff.UseVisualStyleBackColor = true;
            this.rfOff.Click += new System.EventHandler(this.rfOff_Click);
            // 
            // bits2
            // 
            this.bits2.Location = new System.Drawing.Point(33, 71);
            this.bits2.MaxLength = 64;
            this.bits2.Name = "bits2";
            this.bits2.Size = new System.Drawing.Size(99, 20);
            this.bits2.TabIndex = 6;
            this.bits2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bits1_KeyPress);
            // 
            // bits3
            // 
            this.bits3.Location = new System.Drawing.Point(33, 97);
            this.bits3.MaxLength = 64;
            this.bits3.Name = "bits3";
            this.bits3.Size = new System.Drawing.Size(99, 20);
            this.bits3.TabIndex = 7;
            this.bits3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bits1_KeyPress);
            // 
            // bits4
            // 
            this.bits4.Location = new System.Drawing.Point(33, 123);
            this.bits4.MaxLength = 64;
            this.bits4.Name = "bits4";
            this.bits4.Size = new System.Drawing.Size(99, 20);
            this.bits4.TabIndex = 8;
            this.bits4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bits1_KeyPress);
            // 
            // bits5
            // 
            this.bits5.Location = new System.Drawing.Point(33, 149);
            this.bits5.MaxLength = 64;
            this.bits5.Name = "bits5";
            this.bits5.Size = new System.Drawing.Size(99, 20);
            this.bits5.TabIndex = 9;
            this.bits5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bits1_KeyPress);
            // 
            // bits6
            // 
            this.bits6.Location = new System.Drawing.Point(33, 175);
            this.bits6.MaxLength = 64;
            this.bits6.Name = "bits6";
            this.bits6.Size = new System.Drawing.Size(99, 20);
            this.bits6.TabIndex = 10;
            this.bits6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bits1_KeyPress);
            // 
            // bits7
            // 
            this.bits7.Location = new System.Drawing.Point(33, 201);
            this.bits7.MaxLength = 64;
            this.bits7.Name = "bits7";
            this.bits7.Size = new System.Drawing.Size(99, 20);
            this.bits7.TabIndex = 11;
            this.bits7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bits1_KeyPress);
            // 
            // bits8
            // 
            this.bits8.Location = new System.Drawing.Point(33, 227);
            this.bits8.MaxLength = 64;
            this.bits8.Name = "bits8";
            this.bits8.Size = new System.Drawing.Size(99, 20);
            this.bits8.TabIndex = 12;
            this.bits8.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bits1_KeyPress);
            // 
            // addInvert2
            // 
            this.addInvert2.Location = new System.Drawing.Point(146, 71);
            this.addInvert2.Name = "addInvert2";
            this.addInvert2.Size = new System.Drawing.Size(56, 19);
            this.addInvert2.TabIndex = 13;
            this.addInvert2.Text = "Add Inv";
            this.addInvert2.UseVisualStyleBackColor = true;
            this.addInvert2.Click += new System.EventHandler(this.addInvert2_Click);
            // 
            // addInvert3
            // 
            this.addInvert3.Location = new System.Drawing.Point(146, 97);
            this.addInvert3.Name = "addInvert3";
            this.addInvert3.Size = new System.Drawing.Size(56, 19);
            this.addInvert3.TabIndex = 14;
            this.addInvert3.Text = "Add Inv";
            this.addInvert3.UseVisualStyleBackColor = true;
            this.addInvert3.Click += new System.EventHandler(this.addInvert3_Click);
            // 
            // addInvert4
            // 
            this.addInvert4.Location = new System.Drawing.Point(146, 123);
            this.addInvert4.Name = "addInvert4";
            this.addInvert4.Size = new System.Drawing.Size(56, 19);
            this.addInvert4.TabIndex = 15;
            this.addInvert4.Text = "Add Inv";
            this.addInvert4.UseVisualStyleBackColor = true;
            this.addInvert4.Click += new System.EventHandler(this.addInvert4_Click);
            // 
            // addInvert5
            // 
            this.addInvert5.Location = new System.Drawing.Point(146, 149);
            this.addInvert5.Name = "addInvert5";
            this.addInvert5.Size = new System.Drawing.Size(56, 19);
            this.addInvert5.TabIndex = 16;
            this.addInvert5.Text = "Add Inv";
            this.addInvert5.UseVisualStyleBackColor = true;
            this.addInvert5.Click += new System.EventHandler(this.addInvert5_Click);
            // 
            // addInvert6
            // 
            this.addInvert6.Location = new System.Drawing.Point(146, 175);
            this.addInvert6.Name = "addInvert6";
            this.addInvert6.Size = new System.Drawing.Size(56, 19);
            this.addInvert6.TabIndex = 17;
            this.addInvert6.Text = "Add Inv";
            this.addInvert6.UseVisualStyleBackColor = true;
            this.addInvert6.Click += new System.EventHandler(this.addInvert6_Click);
            // 
            // addInvert7
            // 
            this.addInvert7.Location = new System.Drawing.Point(146, 201);
            this.addInvert7.Name = "addInvert7";
            this.addInvert7.Size = new System.Drawing.Size(56, 19);
            this.addInvert7.TabIndex = 18;
            this.addInvert7.Text = "Add Inv";
            this.addInvert7.UseVisualStyleBackColor = true;
            this.addInvert7.Click += new System.EventHandler(this.addInvert7_Click);
            // 
            // addInvert8
            // 
            this.addInvert8.Location = new System.Drawing.Point(146, 227);
            this.addInvert8.Name = "addInvert8";
            this.addInvert8.Size = new System.Drawing.Size(56, 19);
            this.addInvert8.TabIndex = 19;
            this.addInvert8.Text = "Add Inv";
            this.addInvert8.UseVisualStyleBackColor = true;
            this.addInvert8.Click += new System.EventHandler(this.addInvert8_Click);
            // 
            // send2
            // 
            this.send2.Location = new System.Drawing.Point(208, 70);
            this.send2.Name = "send2";
            this.send2.Size = new System.Drawing.Size(66, 20);
            this.send2.TabIndex = 20;
            this.send2.Text = "Send";
            this.send2.UseVisualStyleBackColor = true;
            this.send2.Click += new System.EventHandler(this.send2_Click);
            // 
            // send3
            // 
            this.send3.Location = new System.Drawing.Point(208, 96);
            this.send3.Name = "send3";
            this.send3.Size = new System.Drawing.Size(66, 20);
            this.send3.TabIndex = 21;
            this.send3.Text = "Send";
            this.send3.UseVisualStyleBackColor = true;
            this.send3.Click += new System.EventHandler(this.send3_Click);
            // 
            // send4
            // 
            this.send4.Location = new System.Drawing.Point(208, 122);
            this.send4.Name = "send4";
            this.send4.Size = new System.Drawing.Size(66, 20);
            this.send4.TabIndex = 22;
            this.send4.Text = "Send";
            this.send4.UseVisualStyleBackColor = true;
            this.send4.Click += new System.EventHandler(this.send4_Click);
            // 
            // send5
            // 
            this.send5.Location = new System.Drawing.Point(208, 148);
            this.send5.Name = "send5";
            this.send5.Size = new System.Drawing.Size(66, 20);
            this.send5.TabIndex = 23;
            this.send5.Text = "Send";
            this.send5.UseVisualStyleBackColor = true;
            this.send5.Click += new System.EventHandler(this.send5_Click);
            // 
            // send6
            // 
            this.send6.Location = new System.Drawing.Point(208, 174);
            this.send6.Name = "send6";
            this.send6.Size = new System.Drawing.Size(66, 20);
            this.send6.TabIndex = 24;
            this.send6.Text = "Send";
            this.send6.UseVisualStyleBackColor = true;
            this.send6.Click += new System.EventHandler(this.send6_Click);
            // 
            // send7
            // 
            this.send7.Location = new System.Drawing.Point(208, 200);
            this.send7.Name = "send7";
            this.send7.Size = new System.Drawing.Size(66, 20);
            this.send7.TabIndex = 25;
            this.send7.Text = "Send";
            this.send7.UseVisualStyleBackColor = true;
            this.send7.Click += new System.EventHandler(this.send7_Click);
            // 
            // send8
            // 
            this.send8.Location = new System.Drawing.Point(208, 226);
            this.send8.Name = "send8";
            this.send8.Size = new System.Drawing.Size(66, 20);
            this.send8.TabIndex = 26;
            this.send8.Text = "Send";
            this.send8.UseVisualStyleBackColor = true;
            this.send8.Click += new System.EventHandler(this.send8_Click);
            // 
            // tbRawData
            // 
            this.tbRawData.Location = new System.Drawing.Point(33, 253);
            this.tbRawData.Name = "tbRawData";
            this.tbRawData.Size = new System.Drawing.Size(169, 20);
            this.tbRawData.TabIndex = 27;
            // 
            // rawSend
            // 
            this.rawSend.Location = new System.Drawing.Point(208, 252);
            this.rawSend.Name = "rawSend";
            this.rawSend.Size = new System.Drawing.Size(74, 20);
            this.rawSend.TabIndex = 28;
            this.rawSend.Text = "Send RAW";
            this.rawSend.UseVisualStyleBackColor = true;
            this.rawSend.Click += new System.EventHandler(this.rawSend_Click);
            // 
            // debugOffBtn
            // 
            this.debugOffBtn.Location = new System.Drawing.Point(323, 33);
            this.debugOffBtn.Name = "debugOffBtn";
            this.debugOffBtn.Size = new System.Drawing.Size(80, 19);
            this.debugOffBtn.TabIndex = 30;
            this.debugOffBtn.Text = "Debug OFF";
            this.debugOffBtn.UseVisualStyleBackColor = true;
            this.debugOffBtn.Click += new System.EventHandler(this.debugOffBtn_Click);
            // 
            // debugOnBtn
            // 
            this.debugOnBtn.Location = new System.Drawing.Point(323, 8);
            this.debugOnBtn.Name = "debugOnBtn";
            this.debugOnBtn.Size = new System.Drawing.Size(80, 19);
            this.debugOnBtn.TabIndex = 29;
            this.debugOnBtn.Text = "Debug ON";
            this.debugOnBtn.UseVisualStyleBackColor = true;
            this.debugOnBtn.Click += new System.EventHandler(this.debugOnBtn_Click);
            // 
            // decodeBipBtn
            // 
            this.decodeBipBtn.Location = new System.Drawing.Point(323, 95);
            this.decodeBipBtn.Name = "decodeBipBtn";
            this.decodeBipBtn.Size = new System.Drawing.Size(103, 19);
            this.decodeBipBtn.TabIndex = 32;
            this.decodeBipBtn.Text = "Biphase Mode";
            this.decodeBipBtn.UseVisualStyleBackColor = true;
            this.decodeBipBtn.Click += new System.EventHandler(this.decodeBipBtn_Click);
            // 
            // decodeManBtn
            // 
            this.decodeManBtn.Location = new System.Drawing.Point(323, 70);
            this.decodeManBtn.Name = "decodeManBtn";
            this.decodeManBtn.Size = new System.Drawing.Size(103, 19);
            this.decodeManBtn.TabIndex = 31;
            this.decodeManBtn.Text = "Manchester Mode";
            this.decodeManBtn.UseVisualStyleBackColor = true;
            this.decodeManBtn.Click += new System.EventHandler(this.decodeManBtn_Click);
            // 
            // pulse1Num
            // 
            this.pulse1Num.Location = new System.Drawing.Point(400, 128);
            this.pulse1Num.Name = "pulse1Num";
            this.pulse1Num.Size = new System.Drawing.Size(31, 20);
            this.pulse1Num.TabIndex = 33;
            this.pulse1Num.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.pulse1Num.Visible = false;
            this.pulse1Num.ValueChanged += new System.EventHandler(this.pulse1Num_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(320, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Pulse 1 Width:";
            this.label1.Visible = false;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Pulse 0 Width:";
            this.label2.Visible = false;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // pulse0Num
            // 
            this.pulse0Num.Location = new System.Drawing.Point(400, 153);
            this.pulse0Num.Name = "pulse0Num";
            this.pulse0Num.Size = new System.Drawing.Size(31, 20);
            this.pulse0Num.TabIndex = 35;
            this.pulse0Num.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.pulse0Num.Visible = false;
            this.pulse0Num.ValueChanged += new System.EventHandler(this.pulse0Num_ValueChanged);
            // 
            // hysteresisCB
            // 
            this.hysteresisCB.AutoSize = true;
            this.hysteresisCB.Checked = true;
            this.hysteresisCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hysteresisCB.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hysteresisCB.Location = new System.Drawing.Point(323, 204);
            this.hysteresisCB.Name = "hysteresisCB";
            this.hysteresisCB.Size = new System.Drawing.Size(101, 17);
            this.hysteresisCB.TabIndex = 37;
            this.hysteresisCB.Text = "ABIC Hysteresis";
            this.hysteresisCB.UseVisualStyleBackColor = true;
            this.hysteresisCB.CheckedChanged += new System.EventHandler(this.hysteresisCB_CheckedChanged);
            // 
            // button_GainAutoAdjust
            // 
            this.button_GainAutoAdjust.Location = new System.Drawing.Point(323, 237);
            this.button_GainAutoAdjust.Name = "button_GainAutoAdjust";
            this.button_GainAutoAdjust.Size = new System.Drawing.Size(103, 19);
            this.button_GainAutoAdjust.TabIndex = 38;
            this.button_GainAutoAdjust.Text = "Gain Autoadjust";
            this.button_GainAutoAdjust.UseVisualStyleBackColor = true;
            this.button_GainAutoAdjust.Click += new System.EventHandler(this.button_GainAutoAdjust_Click);
            // 
            // SerialDebugger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_GainAutoAdjust);
            this.Controls.Add(this.hysteresisCB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pulse0Num);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pulse1Num);
            this.Controls.Add(this.decodeBipBtn);
            this.Controls.Add(this.decodeManBtn);
            this.Controls.Add(this.debugOffBtn);
            this.Controls.Add(this.debugOnBtn);
            this.Controls.Add(this.rawSend);
            this.Controls.Add(this.tbRawData);
            this.Controls.Add(this.send8);
            this.Controls.Add(this.send7);
            this.Controls.Add(this.send6);
            this.Controls.Add(this.send5);
            this.Controls.Add(this.send4);
            this.Controls.Add(this.send3);
            this.Controls.Add(this.send2);
            this.Controls.Add(this.addInvert8);
            this.Controls.Add(this.addInvert7);
            this.Controls.Add(this.addInvert6);
            this.Controls.Add(this.addInvert5);
            this.Controls.Add(this.addInvert4);
            this.Controls.Add(this.addInvert3);
            this.Controls.Add(this.addInvert2);
            this.Controls.Add(this.bits8);
            this.Controls.Add(this.bits7);
            this.Controls.Add(this.bits6);
            this.Controls.Add(this.bits5);
            this.Controls.Add(this.bits4);
            this.Controls.Add(this.bits3);
            this.Controls.Add(this.bits2);
            this.Controls.Add(this.rfOff);
            this.Controls.Add(this.rfOn);
            this.Controls.Add(this.send1);
            this.Controls.Add(this.addInvert1);
            this.Controls.Add(this.bits1);
            this.Name = "SerialDebugger";
            this.Size = new System.Drawing.Size(532, 325);
            ((System.ComponentModel.ISupportInitialize)(this.pulse1Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pulse0Num)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox bits1;
        private System.Windows.Forms.Button addInvert1;
        private System.Windows.Forms.Button send1;
        private System.Windows.Forms.Button rfOn;
        private System.Windows.Forms.Button rfOff;
        private System.Windows.Forms.TextBox bits2;
        private System.Windows.Forms.TextBox bits3;
        private System.Windows.Forms.TextBox bits4;
        private System.Windows.Forms.TextBox bits5;
        private System.Windows.Forms.TextBox bits6;
        private System.Windows.Forms.TextBox bits7;
        private System.Windows.Forms.TextBox bits8;
        private System.Windows.Forms.Button addInvert2;
        private System.Windows.Forms.Button addInvert3;
        private System.Windows.Forms.Button addInvert4;
        private System.Windows.Forms.Button addInvert5;
        private System.Windows.Forms.Button addInvert6;
        private System.Windows.Forms.Button addInvert7;
        private System.Windows.Forms.Button addInvert8;
        private System.Windows.Forms.Button send2;
        private System.Windows.Forms.Button send3;
        private System.Windows.Forms.Button send4;
        private System.Windows.Forms.Button send5;
        private System.Windows.Forms.Button send6;
        private System.Windows.Forms.Button send7;
        private System.Windows.Forms.Button send8;
        private System.Windows.Forms.TextBox tbRawData;
        private System.Windows.Forms.Button rawSend;
        private System.Windows.Forms.Button debugOffBtn;
        private System.Windows.Forms.Button debugOnBtn;
        private System.Windows.Forms.Button decodeBipBtn;
        private System.Windows.Forms.Button decodeManBtn;
        private System.Windows.Forms.NumericUpDown pulse1Num;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown pulse0Num;
        private System.Windows.Forms.CheckBox hysteresisCB;
        private System.Windows.Forms.Button button_GainAutoAdjust;
    }
}
