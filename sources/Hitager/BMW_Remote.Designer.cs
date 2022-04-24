
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
            this.label_RSK_Hi = new System.Windows.Forms.Label();
            this.label_RSK_lo = new System.Windows.Forms.Label();
            this.ReadRemote_Button = new System.Windows.Forms.Button();
            this.label_KeyNumber = new System.Windows.Forms.Label();
            this.label_Sync = new System.Windows.Forms.Label();
            this.label_Conf = new System.Windows.Forms.Label();
            this.button_WriteRemote = new System.Windows.Forms.Button();
            this.maskedTextBox_KeyNumber = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_RSK_HI = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_RSK_LO = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_Sync = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_Conf = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label_RSK_Hi
            // 
            this.label_RSK_Hi.AutoSize = true;
            this.label_RSK_Hi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_RSK_Hi.Location = new System.Drawing.Point(24, 47);
            this.label_RSK_Hi.Name = "label_RSK_Hi";
            this.label_RSK_Hi.Size = new System.Drawing.Size(53, 17);
            this.label_RSK_Hi.TabIndex = 21;
            this.label_RSK_Hi.Text = "RSK Hi";
            // 
            // label_RSK_lo
            // 
            this.label_RSK_lo.AutoSize = true;
            this.label_RSK_lo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_RSK_lo.Location = new System.Drawing.Point(24, 76);
            this.label_RSK_lo.Name = "label_RSK_lo";
            this.label_RSK_lo.Size = new System.Drawing.Size(56, 17);
            this.label_RSK_lo.TabIndex = 22;
            this.label_RSK_lo.Text = "RSK Lo";
            // 
            // ReadRemote_Button
            // 
            this.ReadRemote_Button.Location = new System.Drawing.Point(27, 178);
            this.ReadRemote_Button.Name = "ReadRemote_Button";
            this.ReadRemote_Button.Size = new System.Drawing.Size(87, 36);
            this.ReadRemote_Button.TabIndex = 23;
            this.ReadRemote_Button.Text = "Read";
            this.ReadRemote_Button.UseVisualStyleBackColor = true;
            this.ReadRemote_Button.Click += new System.EventHandler(this.Read_Remote_Click);
            // 
            // label_KeyNumber
            // 
            this.label_KeyNumber.AutoSize = true;
            this.label_KeyNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_KeyNumber.Location = new System.Drawing.Point(24, 18);
            this.label_KeyNumber.Name = "label_KeyNumber";
            this.label_KeyNumber.Size = new System.Drawing.Size(86, 17);
            this.label_KeyNumber.TabIndex = 25;
            this.label_KeyNumber.Text = "Key Number";
            // 
            // label_Sync
            // 
            this.label_Sync.AutoSize = true;
            this.label_Sync.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Sync.Location = new System.Drawing.Point(24, 105);
            this.label_Sync.Name = "label_Sync";
            this.label_Sync.Size = new System.Drawing.Size(39, 17);
            this.label_Sync.TabIndex = 27;
            this.label_Sync.Text = "Sync";
            // 
            // label_Conf
            // 
            this.label_Conf.AutoSize = true;
            this.label_Conf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Conf.Location = new System.Drawing.Point(24, 134);
            this.label_Conf.Name = "label_Conf";
            this.label_Conf.Size = new System.Drawing.Size(48, 17);
            this.label_Conf.TabIndex = 29;
            this.label_Conf.Text = "Config";
            // 
            // button_WriteRemote
            // 
            this.button_WriteRemote.Location = new System.Drawing.Point(127, 178);
            this.button_WriteRemote.Name = "button_WriteRemote";
            this.button_WriteRemote.Size = new System.Drawing.Size(87, 36);
            this.button_WriteRemote.TabIndex = 30;
            this.button_WriteRemote.Text = "Write";
            this.button_WriteRemote.UseVisualStyleBackColor = true;
            this.button_WriteRemote.Click += new System.EventHandler(this.button_WriteRemote_Click);
            // 
            // maskedTextBox_KeyNumber
            // 
            this.maskedTextBox_KeyNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBox_KeyNumber.Location = new System.Drawing.Point(168, 15);
            this.maskedTextBox_KeyNumber.Mask = "&& &&";
            this.maskedTextBox_KeyNumber.Name = "maskedTextBox_KeyNumber";
            this.maskedTextBox_KeyNumber.Size = new System.Drawing.Size(46, 23);
            this.maskedTextBox_KeyNumber.TabIndex = 31;
            this.maskedTextBox_KeyNumber.Text = "0000";
            this.maskedTextBox_KeyNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maskedTextBox_KeyNumber.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // maskedTextBox_RSK_HI
            // 
            this.maskedTextBox_RSK_HI.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBox_RSK_HI.Location = new System.Drawing.Point(168, 44);
            this.maskedTextBox_RSK_HI.Mask = "&& &&";
            this.maskedTextBox_RSK_HI.Name = "maskedTextBox_RSK_HI";
            this.maskedTextBox_RSK_HI.Size = new System.Drawing.Size(46, 23);
            this.maskedTextBox_RSK_HI.TabIndex = 32;
            this.maskedTextBox_RSK_HI.Text = "0000";
            this.maskedTextBox_RSK_HI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maskedTextBox_RSK_HI.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // maskedTextBox_RSK_LO
            // 
            this.maskedTextBox_RSK_LO.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBox_RSK_LO.Location = new System.Drawing.Point(133, 73);
            this.maskedTextBox_RSK_LO.Mask = "&& && && &&";
            this.maskedTextBox_RSK_LO.Name = "maskedTextBox_RSK_LO";
            this.maskedTextBox_RSK_LO.Size = new System.Drawing.Size(81, 23);
            this.maskedTextBox_RSK_LO.TabIndex = 33;
            this.maskedTextBox_RSK_LO.Text = "00000000";
            this.maskedTextBox_RSK_LO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maskedTextBox_RSK_LO.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // maskedTextBox_Sync
            // 
            this.maskedTextBox_Sync.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBox_Sync.Location = new System.Drawing.Point(133, 102);
            this.maskedTextBox_Sync.Mask = "&& && && &&";
            this.maskedTextBox_Sync.Name = "maskedTextBox_Sync";
            this.maskedTextBox_Sync.Size = new System.Drawing.Size(81, 23);
            this.maskedTextBox_Sync.TabIndex = 34;
            this.maskedTextBox_Sync.Text = "00000000";
            this.maskedTextBox_Sync.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maskedTextBox_Sync.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // maskedTextBox_Conf
            // 
            this.maskedTextBox_Conf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBox_Conf.Location = new System.Drawing.Point(133, 131);
            this.maskedTextBox_Conf.Mask = "&& && && &&";
            this.maskedTextBox_Conf.Name = "maskedTextBox_Conf";
            this.maskedTextBox_Conf.Size = new System.Drawing.Size(81, 23);
            this.maskedTextBox_Conf.TabIndex = 35;
            this.maskedTextBox_Conf.Text = "00000000";
            this.maskedTextBox_Conf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maskedTextBox_Conf.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // BMW_Remote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 235);
            this.Controls.Add(this.maskedTextBox_Conf);
            this.Controls.Add(this.maskedTextBox_Sync);
            this.Controls.Add(this.maskedTextBox_RSK_LO);
            this.Controls.Add(this.maskedTextBox_RSK_HI);
            this.Controls.Add(this.maskedTextBox_KeyNumber);
            this.Controls.Add(this.button_WriteRemote);
            this.Controls.Add(this.label_Conf);
            this.Controls.Add(this.label_Sync);
            this.Controls.Add(this.label_KeyNumber);
            this.Controls.Add(this.ReadRemote_Button);
            this.Controls.Add(this.label_RSK_lo);
            this.Controls.Add(this.label_RSK_Hi);
            this.Name = "BMW_Remote";
            this.Text = "BMW Remote";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_RSK_Hi;
        private System.Windows.Forms.Label label_RSK_lo;
        private System.Windows.Forms.Button ReadRemote_Button;
        private System.Windows.Forms.Label label_KeyNumber;
        private System.Windows.Forms.Label label_Sync;
        private System.Windows.Forms.Label label_Conf;
        private System.Windows.Forms.Button button_WriteRemote;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_KeyNumber;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_RSK_HI;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_RSK_LO;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Sync;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Conf;
    }
}