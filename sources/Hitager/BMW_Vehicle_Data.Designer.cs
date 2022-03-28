
namespace Hitager
{
    partial class BMW_Vehicle_Data
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
            this.Textbox_VIN = new System.Windows.Forms.TextBox();
            this.label_VIN = new System.Windows.Forms.Label();
            this.Read_VehicleData_Button = new System.Windows.Forms.Button();
            this.textBox_MechCode = new System.Windows.Forms.TextBox();
            this.label_MechCode = new System.Windows.Forms.Label();
            this.textBox_OdoCount = new System.Windows.Forms.TextBox();
            this.label_OdoCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Textbox_VIN
            // 
            this.Textbox_VIN.Location = new System.Drawing.Point(21, 34);
            this.Textbox_VIN.MaxLength = 8;
            this.Textbox_VIN.Name = "Textbox_VIN";
            this.Textbox_VIN.Size = new System.Drawing.Size(127, 20);
            this.Textbox_VIN.TabIndex = 2;
            this.Textbox_VIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_VIN
            // 
            this.label_VIN.AutoSize = true;
            this.label_VIN.Location = new System.Drawing.Point(18, 18);
            this.label_VIN.Name = "label_VIN";
            this.label_VIN.Size = new System.Drawing.Size(25, 13);
            this.label_VIN.TabIndex = 22;
            this.label_VIN.Text = "VIN";
            // 
            // Read_VehicleData_Button
            // 
            this.Read_VehicleData_Button.Location = new System.Drawing.Point(21, 180);
            this.Read_VehicleData_Button.Name = "Read_VehicleData_Button";
            this.Read_VehicleData_Button.Size = new System.Drawing.Size(87, 36);
            this.Read_VehicleData_Button.TabIndex = 24;
            this.Read_VehicleData_Button.Text = "Read";
            this.Read_VehicleData_Button.UseVisualStyleBackColor = true;
            this.Read_VehicleData_Button.Click += new System.EventHandler(this.Read_VehicleData_Button_Click);
            // 
            // textBox_MechCode
            // 
            this.textBox_MechCode.Location = new System.Drawing.Point(21, 83);
            this.textBox_MechCode.MaxLength = 8;
            this.textBox_MechCode.Name = "textBox_MechCode";
            this.textBox_MechCode.Size = new System.Drawing.Size(127, 20);
            this.textBox_MechCode.TabIndex = 25;
            this.textBox_MechCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_MechCode
            // 
            this.label_MechCode.AutoSize = true;
            this.label_MechCode.Location = new System.Drawing.Point(18, 66);
            this.label_MechCode.Name = "label_MechCode";
            this.label_MechCode.Size = new System.Drawing.Size(90, 13);
            this.label_MechCode.TabIndex = 26;
            this.label_MechCode.Text = "Mechanical Code";
            // 
            // textBox_OdoCount
            // 
            this.textBox_OdoCount.Location = new System.Drawing.Point(21, 135);
            this.textBox_OdoCount.MaxLength = 8;
            this.textBox_OdoCount.Name = "textBox_OdoCount";
            this.textBox_OdoCount.Size = new System.Drawing.Size(127, 20);
            this.textBox_OdoCount.TabIndex = 27;
            this.textBox_OdoCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_OdoCount
            // 
            this.label_OdoCount.AutoSize = true;
            this.label_OdoCount.Location = new System.Drawing.Point(18, 117);
            this.label_OdoCount.Name = "label_OdoCount";
            this.label_OdoCount.Size = new System.Drawing.Size(53, 13);
            this.label_OdoCount.TabIndex = 28;
            this.label_OdoCount.Text = "Odometer";
            // 
            // BMW_Vehicle_Data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 227);
            this.Controls.Add(this.label_OdoCount);
            this.Controls.Add(this.textBox_OdoCount);
            this.Controls.Add(this.label_MechCode);
            this.Controls.Add(this.textBox_MechCode);
            this.Controls.Add(this.Read_VehicleData_Button);
            this.Controls.Add(this.label_VIN);
            this.Controls.Add(this.Textbox_VIN);
            this.Name = "BMW_Vehicle_Data";
            this.Text = "BMW Vehicle Data";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Textbox_VIN;
        private System.Windows.Forms.Label label_VIN;
        private System.Windows.Forms.Button Read_VehicleData_Button;
        private System.Windows.Forms.TextBox textBox_MechCode;
        private System.Windows.Forms.Label label_MechCode;
        private System.Windows.Forms.TextBox textBox_OdoCount;
        private System.Windows.Forms.Label label_OdoCount;
    }
}