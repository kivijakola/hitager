
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
            this.textBox_RSK_Hi = new System.Windows.Forms.TextBox();
            this.textBox_RSK_Lo = new System.Windows.Forms.TextBox();
            this.label_RSK_Hi = new System.Windows.Forms.Label();
            this.label_RSK_lo = new System.Windows.Forms.Label();
            this.ReadRemote_Button = new System.Windows.Forms.Button();
            this.textBox_KeyNumber = new System.Windows.Forms.TextBox();
            this.label_KeyNumber = new System.Windows.Forms.Label();
            this.textBox_Sync = new System.Windows.Forms.TextBox();
            this.label_Sync = new System.Windows.Forms.Label();
            this.textBox_Conf = new System.Windows.Forms.TextBox();
            this.label_Conf = new System.Windows.Forms.Label();
            this.button_WriteRemote = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_RSK_Hi
            // 
            this.textBox_RSK_Hi.Location = new System.Drawing.Point(157, 38);
            this.textBox_RSK_Hi.MaxLength = 8;
            this.textBox_RSK_Hi.Name = "textBox_RSK_Hi";
            this.textBox_RSK_Hi.Size = new System.Drawing.Size(45, 20);
            this.textBox_RSK_Hi.TabIndex = 1;
            // 
            // textBox_RSK_Lo
            // 
            this.textBox_RSK_Lo.Location = new System.Drawing.Point(115, 64);
            this.textBox_RSK_Lo.MaxLength = 8;
            this.textBox_RSK_Lo.Name = "textBox_RSK_Lo";
            this.textBox_RSK_Lo.Size = new System.Drawing.Size(87, 20);
            this.textBox_RSK_Lo.TabIndex = 2;
            // 
            // label_RSK_Hi
            // 
            this.label_RSK_Hi.AutoSize = true;
            this.label_RSK_Hi.Location = new System.Drawing.Point(24, 41);
            this.label_RSK_Hi.Name = "label_RSK_Hi";
            this.label_RSK_Hi.Size = new System.Drawing.Size(42, 13);
            this.label_RSK_Hi.TabIndex = 21;
            this.label_RSK_Hi.Text = "RSK Hi";
            // 
            // label_RSK_lo
            // 
            this.label_RSK_lo.AutoSize = true;
            this.label_RSK_lo.Location = new System.Drawing.Point(24, 67);
            this.label_RSK_lo.Name = "label_RSK_lo";
            this.label_RSK_lo.Size = new System.Drawing.Size(44, 13);
            this.label_RSK_lo.TabIndex = 22;
            this.label_RSK_lo.Text = "RSK Lo";
            // 
            // ReadRemote_Button
            // 
            this.ReadRemote_Button.Location = new System.Drawing.Point(27, 151);
            this.ReadRemote_Button.Name = "ReadRemote_Button";
            this.ReadRemote_Button.Size = new System.Drawing.Size(87, 36);
            this.ReadRemote_Button.TabIndex = 23;
            this.ReadRemote_Button.Text = "Read";
            this.ReadRemote_Button.UseVisualStyleBackColor = true;
            this.ReadRemote_Button.Click += new System.EventHandler(this.Read_Remote_Click);
            // 
            // textBox_KeyNumber
            // 
            this.textBox_KeyNumber.Location = new System.Drawing.Point(157, 12);
            this.textBox_KeyNumber.MaxLength = 8;
            this.textBox_KeyNumber.Name = "textBox_KeyNumber";
            this.textBox_KeyNumber.Size = new System.Drawing.Size(45, 20);
            this.textBox_KeyNumber.TabIndex = 24;
            // 
            // label_KeyNumber
            // 
            this.label_KeyNumber.AutoSize = true;
            this.label_KeyNumber.Location = new System.Drawing.Point(24, 15);
            this.label_KeyNumber.Name = "label_KeyNumber";
            this.label_KeyNumber.Size = new System.Drawing.Size(65, 13);
            this.label_KeyNumber.TabIndex = 25;
            this.label_KeyNumber.Text = "Key Number";
            // 
            // textBox_Sync
            // 
            this.textBox_Sync.Location = new System.Drawing.Point(115, 90);
            this.textBox_Sync.MaxLength = 8;
            this.textBox_Sync.Name = "textBox_Sync";
            this.textBox_Sync.Size = new System.Drawing.Size(87, 20);
            this.textBox_Sync.TabIndex = 26;
            // 
            // label_Sync
            // 
            this.label_Sync.AutoSize = true;
            this.label_Sync.Location = new System.Drawing.Point(24, 93);
            this.label_Sync.Name = "label_Sync";
            this.label_Sync.Size = new System.Drawing.Size(31, 13);
            this.label_Sync.TabIndex = 27;
            this.label_Sync.Text = "Sync";
            // 
            // textBox_Conf
            // 
            this.textBox_Conf.Location = new System.Drawing.Point(115, 116);
            this.textBox_Conf.MaxLength = 8;
            this.textBox_Conf.Name = "textBox_Conf";
            this.textBox_Conf.Size = new System.Drawing.Size(87, 20);
            this.textBox_Conf.TabIndex = 28;
            // 
            // label_Conf
            // 
            this.label_Conf.AutoSize = true;
            this.label_Conf.Location = new System.Drawing.Point(24, 119);
            this.label_Conf.Name = "label_Conf";
            this.label_Conf.Size = new System.Drawing.Size(37, 13);
            this.label_Conf.TabIndex = 29;
            this.label_Conf.Text = "Config";
            // 
            // button_WriteRemote
            // 
            this.button_WriteRemote.Location = new System.Drawing.Point(120, 151);
            this.button_WriteRemote.Name = "button_WriteRemote";
            this.button_WriteRemote.Size = new System.Drawing.Size(87, 36);
            this.button_WriteRemote.TabIndex = 30;
            this.button_WriteRemote.Text = "Write";
            this.button_WriteRemote.UseVisualStyleBackColor = true;
            this.button_WriteRemote.Click += new System.EventHandler(this.button_WriteRemote_Click);
            // 
            // BMW_Remote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 193);
            this.Controls.Add(this.button_WriteRemote);
            this.Controls.Add(this.label_Conf);
            this.Controls.Add(this.textBox_Conf);
            this.Controls.Add(this.label_Sync);
            this.Controls.Add(this.textBox_Sync);
            this.Controls.Add(this.label_KeyNumber);
            this.Controls.Add(this.textBox_KeyNumber);
            this.Controls.Add(this.ReadRemote_Button);
            this.Controls.Add(this.label_RSK_lo);
            this.Controls.Add(this.label_RSK_Hi);
            this.Controls.Add(this.textBox_RSK_Lo);
            this.Controls.Add(this.textBox_RSK_Hi);
            this.Name = "BMW_Remote";
            this.Text = "BMW Remote";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_RSK_Hi;
        private System.Windows.Forms.TextBox textBox_RSK_Lo;
        private System.Windows.Forms.Label label_RSK_Hi;
        private System.Windows.Forms.Label label_RSK_lo;
        private System.Windows.Forms.Button ReadRemote_Button;
        private System.Windows.Forms.TextBox textBox_KeyNumber;
        private System.Windows.Forms.Label label_KeyNumber;
        private System.Windows.Forms.TextBox textBox_Sync;
        private System.Windows.Forms.Label label_Sync;
        private System.Windows.Forms.TextBox textBox_Conf;
        private System.Windows.Forms.Label label_Conf;
        private System.Windows.Forms.Button button_WriteRemote;
    }
}