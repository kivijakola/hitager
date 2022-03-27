
namespace Hitager
{
    partial class BMW_Remote
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
            this.Textbox_RSK_Hi = new System.Windows.Forms.TextBox();
            this.Textbox_RSK_Lo = new System.Windows.Forms.TextBox();
            this.label_RSK_Hi = new System.Windows.Forms.Label();
            this.label_RSK_lo = new System.Windows.Forms.Label();
            this.ReadRemote_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Textbox_RSK_Hi
            // 
            this.Textbox_RSK_Hi.Location = new System.Drawing.Point(90, 45);
            this.Textbox_RSK_Hi.MaxLength = 8;
            this.Textbox_RSK_Hi.Name = "Textbox_RSK_Hi";
            this.Textbox_RSK_Hi.Size = new System.Drawing.Size(87, 20);
            this.Textbox_RSK_Hi.TabIndex = 1;
            // 
            // Textbox_RSK_Lo
            // 
            this.Textbox_RSK_Lo.Location = new System.Drawing.Point(90, 81);
            this.Textbox_RSK_Lo.MaxLength = 8;
            this.Textbox_RSK_Lo.Name = "Textbox_RSK_Lo";
            this.Textbox_RSK_Lo.Size = new System.Drawing.Size(87, 20);
            this.Textbox_RSK_Lo.TabIndex = 2;
            // 
            // label_RSK_Hi
            // 
            this.label_RSK_Hi.AutoSize = true;
            this.label_RSK_Hi.Location = new System.Drawing.Point(12, 48);
            this.label_RSK_Hi.Name = "label_RSK_Hi";
            this.label_RSK_Hi.Size = new System.Drawing.Size(42, 13);
            this.label_RSK_Hi.TabIndex = 21;
            this.label_RSK_Hi.Text = "RSK Hi";
            // 
            // label_RSK_lo
            // 
            this.label_RSK_lo.AutoSize = true;
            this.label_RSK_lo.Location = new System.Drawing.Point(12, 84);
            this.label_RSK_lo.Name = "label_RSK_lo";
            this.label_RSK_lo.Size = new System.Drawing.Size(44, 13);
            this.label_RSK_lo.TabIndex = 22;
            this.label_RSK_lo.Text = "RSK Lo";
            // 
            // ReadRemote_Button
            // 
            this.ReadRemote_Button.Location = new System.Drawing.Point(90, 119);
            this.ReadRemote_Button.Name = "ReadRemote_Button";
            this.ReadRemote_Button.Size = new System.Drawing.Size(87, 36);
            this.ReadRemote_Button.TabIndex = 23;
            this.ReadRemote_Button.Text = "Read";
            this.ReadRemote_Button.UseVisualStyleBackColor = true;
            this.ReadRemote_Button.Click += new System.EventHandler(this.Read_Remote_Click);
            // 
            // BMW_Remote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(196, 196);
            this.Controls.Add(this.ReadRemote_Button);
            this.Controls.Add(this.label_RSK_lo);
            this.Controls.Add(this.label_RSK_Hi);
            this.Controls.Add(this.Textbox_RSK_Lo);
            this.Controls.Add(this.Textbox_RSK_Hi);
            this.Name = "BMW_Remote";
            this.Text = "BMW_Remote";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Textbox_RSK_Hi;
        private System.Windows.Forms.TextBox Textbox_RSK_Lo;
        private System.Windows.Forms.Label label_RSK_Hi;
        private System.Windows.Forms.Label label_RSK_lo;
        private System.Windows.Forms.Button ReadRemote_Button;
    }
}