
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
            this.label_RemoteID = new System.Windows.Forms.Label();
            this.label_Sync = new System.Windows.Forms.Label();
            this.label_Conf = new System.Windows.Forms.Label();
            this.button_WriteRemote = new System.Windows.Forms.Button();
            this.maskedTextBox_RemoteID = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_RSK_HI = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_RSK_LO = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_Sync = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_Conf = new System.Windows.Forms.MaskedTextBox();
            this.button_OpenCasDump = new System.Windows.Forms.Button();
            this.comboBox_bankSelect = new System.Windows.Forms.ComboBox();
            this.button_FetchRemoteData = new System.Windows.Forms.Button();
            this.groupBox_CasData = new System.Windows.Forms.GroupBox();
            this.label_CasDumpStatusLabel = new System.Windows.Forms.Label();
            this.groupBox_keyData = new System.Windows.Forms.GroupBox();
            this.label_CasDumpStatus = new System.Windows.Forms.Label();
            this.groupBox_CasData.SuspendLayout();
            this.groupBox_keyData.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_RSK_Hi
            // 
            this.label_RSK_Hi.AutoSize = true;
            this.label_RSK_Hi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_RSK_Hi.Location = new System.Drawing.Point(11, 49);
            this.label_RSK_Hi.Name = "label_RSK_Hi";
            this.label_RSK_Hi.Size = new System.Drawing.Size(53, 17);
            this.label_RSK_Hi.TabIndex = 21;
            this.label_RSK_Hi.Text = "RSK Hi";
            // 
            // label_RSK_lo
            // 
            this.label_RSK_lo.AutoSize = true;
            this.label_RSK_lo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_RSK_lo.Location = new System.Drawing.Point(11, 78);
            this.label_RSK_lo.Name = "label_RSK_lo";
            this.label_RSK_lo.Size = new System.Drawing.Size(56, 17);
            this.label_RSK_lo.TabIndex = 22;
            this.label_RSK_lo.Text = "RSK Lo";
            // 
            // ReadRemote_Button
            // 
            this.ReadRemote_Button.Location = new System.Drawing.Point(10, 162);
            this.ReadRemote_Button.Name = "ReadRemote_Button";
            this.ReadRemote_Button.Size = new System.Drawing.Size(87, 36);
            this.ReadRemote_Button.TabIndex = 23;
            this.ReadRemote_Button.Text = "Read";
            this.ReadRemote_Button.UseVisualStyleBackColor = true;
            this.ReadRemote_Button.Click += new System.EventHandler(this.Read_Remote_Click);
            // 
            // label_RemoteID
            // 
            this.label_RemoteID.AutoSize = true;
            this.label_RemoteID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_RemoteID.Location = new System.Drawing.Point(11, 20);
            this.label_RemoteID.Name = "label_RemoteID";
            this.label_RemoteID.Size = new System.Drawing.Size(86, 17);
            this.label_RemoteID.TabIndex = 25;
            this.label_RemoteID.Text = "Key Number";
            // 
            // label_Sync
            // 
            this.label_Sync.AutoSize = true;
            this.label_Sync.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Sync.Location = new System.Drawing.Point(11, 107);
            this.label_Sync.Name = "label_Sync";
            this.label_Sync.Size = new System.Drawing.Size(39, 17);
            this.label_Sync.TabIndex = 27;
            this.label_Sync.Text = "Sync";
            // 
            // label_Conf
            // 
            this.label_Conf.AutoSize = true;
            this.label_Conf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Conf.Location = new System.Drawing.Point(11, 136);
            this.label_Conf.Name = "label_Conf";
            this.label_Conf.Size = new System.Drawing.Size(48, 17);
            this.label_Conf.TabIndex = 29;
            this.label_Conf.Text = "Config";
            // 
            // button_WriteRemote
            // 
            this.button_WriteRemote.Location = new System.Drawing.Point(124, 162);
            this.button_WriteRemote.Name = "button_WriteRemote";
            this.button_WriteRemote.Size = new System.Drawing.Size(87, 36);
            this.button_WriteRemote.TabIndex = 30;
            this.button_WriteRemote.Text = "Write";
            this.button_WriteRemote.UseVisualStyleBackColor = true;
            this.button_WriteRemote.Click += new System.EventHandler(this.button_WriteRemote_Click);
            // 
            // maskedTextBox_RemoteID
            // 
            this.maskedTextBox_RemoteID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBox_RemoteID.Location = new System.Drawing.Point(165, 17);
            this.maskedTextBox_RemoteID.Mask = "&& &&";
            this.maskedTextBox_RemoteID.Name = "maskedTextBox_RemoteID";
            this.maskedTextBox_RemoteID.Size = new System.Drawing.Size(46, 23);
            this.maskedTextBox_RemoteID.TabIndex = 31;
            this.maskedTextBox_RemoteID.Text = "0000";
            this.maskedTextBox_RemoteID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maskedTextBox_RemoteID.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // maskedTextBox_RSK_HI
            // 
            this.maskedTextBox_RSK_HI.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBox_RSK_HI.Location = new System.Drawing.Point(165, 46);
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
            this.maskedTextBox_RSK_LO.Location = new System.Drawing.Point(130, 75);
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
            this.maskedTextBox_Sync.Location = new System.Drawing.Point(130, 104);
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
            this.maskedTextBox_Conf.Location = new System.Drawing.Point(130, 133);
            this.maskedTextBox_Conf.Mask = "&& && && &&";
            this.maskedTextBox_Conf.Name = "maskedTextBox_Conf";
            this.maskedTextBox_Conf.Size = new System.Drawing.Size(81, 23);
            this.maskedTextBox_Conf.TabIndex = 35;
            this.maskedTextBox_Conf.Text = "00000000";
            this.maskedTextBox_Conf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maskedTextBox_Conf.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // button_OpenCasDump
            // 
            this.button_OpenCasDump.Location = new System.Drawing.Point(10, 19);
            this.button_OpenCasDump.Name = "button_OpenCasDump";
            this.button_OpenCasDump.Size = new System.Drawing.Size(104, 21);
            this.button_OpenCasDump.TabIndex = 36;
            this.button_OpenCasDump.Text = "Open CAS Dump";
            this.button_OpenCasDump.UseVisualStyleBackColor = true;
            this.button_OpenCasDump.Click += new System.EventHandler(this.button_OpenCasDump_Click);
            // 
            // comboBox_bankSelect
            // 
            this.comboBox_bankSelect.FormattingEnabled = true;
            this.comboBox_bankSelect.Location = new System.Drawing.Point(10, 73);
            this.comboBox_bankSelect.Name = "comboBox_bankSelect";
            this.comboBox_bankSelect.Size = new System.Drawing.Size(130, 21);
            this.comboBox_bankSelect.TabIndex = 37;
            // 
            // button_FetchRemoteData
            // 
            this.button_FetchRemoteData.Location = new System.Drawing.Point(146, 73);
            this.button_FetchRemoteData.Name = "button_FetchRemoteData";
            this.button_FetchRemoteData.Size = new System.Drawing.Size(73, 21);
            this.button_FetchRemoteData.TabIndex = 38;
            this.button_FetchRemoteData.Text = "Get Data";
            this.button_FetchRemoteData.UseVisualStyleBackColor = true;
            this.button_FetchRemoteData.Click += new System.EventHandler(this.button_FetchRemoteData_Click);
            // 
            // groupBox_CasData
            // 
            this.groupBox_CasData.Controls.Add(this.label_CasDumpStatus);
            this.groupBox_CasData.Controls.Add(this.label_CasDumpStatusLabel);
            this.groupBox_CasData.Controls.Add(this.comboBox_bankSelect);
            this.groupBox_CasData.Controls.Add(this.button_FetchRemoteData);
            this.groupBox_CasData.Controls.Add(this.button_OpenCasDump);
            this.groupBox_CasData.Location = new System.Drawing.Point(12, 210);
            this.groupBox_CasData.Name = "groupBox_CasData";
            this.groupBox_CasData.Size = new System.Drawing.Size(225, 100);
            this.groupBox_CasData.TabIndex = 39;
            this.groupBox_CasData.TabStop = false;
            this.groupBox_CasData.Text = "CAS Data";
            // 
            // label_CasDumpStatusLabel
            // 
            this.label_CasDumpStatusLabel.AutoSize = true;
            this.label_CasDumpStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CasDumpStatusLabel.Location = new System.Drawing.Point(11, 43);
            this.label_CasDumpStatusLabel.Name = "label_CasDumpStatusLabel";
            this.label_CasDumpStatusLabel.Size = new System.Drawing.Size(93, 17);
            this.label_CasDumpStatusLabel.TabIndex = 39;
            this.label_CasDumpStatusLabel.Text = "Dump Status:";
            // 
            // groupBox_keyData
            // 
            this.groupBox_keyData.Controls.Add(this.label_RemoteID);
            this.groupBox_keyData.Controls.Add(this.label_RSK_Hi);
            this.groupBox_keyData.Controls.Add(this.ReadRemote_Button);
            this.groupBox_keyData.Controls.Add(this.button_WriteRemote);
            this.groupBox_keyData.Controls.Add(this.maskedTextBox_Conf);
            this.groupBox_keyData.Controls.Add(this.label_RSK_lo);
            this.groupBox_keyData.Controls.Add(this.maskedTextBox_Sync);
            this.groupBox_keyData.Controls.Add(this.label_Sync);
            this.groupBox_keyData.Controls.Add(this.maskedTextBox_RSK_LO);
            this.groupBox_keyData.Controls.Add(this.label_Conf);
            this.groupBox_keyData.Controls.Add(this.maskedTextBox_RSK_HI);
            this.groupBox_keyData.Controls.Add(this.maskedTextBox_RemoteID);
            this.groupBox_keyData.Location = new System.Drawing.Point(12, 2);
            this.groupBox_keyData.Name = "groupBox_keyData";
            this.groupBox_keyData.Size = new System.Drawing.Size(225, 204);
            this.groupBox_keyData.TabIndex = 40;
            this.groupBox_keyData.TabStop = false;
            this.groupBox_keyData.Text = "Key Data";
            // 
            // label_CasDumpStatus
            // 
            this.label_CasDumpStatus.AutoSize = true;
            this.label_CasDumpStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CasDumpStatus.Location = new System.Drawing.Point(110, 43);
            this.label_CasDumpStatus.Name = "label_CasDumpStatus";
            this.label_CasDumpStatus.Size = new System.Drawing.Size(112, 17);
            this.label_CasDumpStatus.TabIndex = 40;
            this.label_CasDumpStatus.Text = "No dump loaded";
            this.label_CasDumpStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BMW_Remote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 323);
            this.Controls.Add(this.groupBox_keyData);
            this.Controls.Add(this.groupBox_CasData);
            this.Name = "BMW_Remote";
            this.Text = "BMW Remote";
            this.groupBox_CasData.ResumeLayout(false);
            this.groupBox_CasData.PerformLayout();
            this.groupBox_keyData.ResumeLayout(false);
            this.groupBox_keyData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label_RSK_Hi;
        private System.Windows.Forms.Label label_RSK_lo;
        private System.Windows.Forms.Button ReadRemote_Button;
        private System.Windows.Forms.Label label_RemoteID;
        private System.Windows.Forms.Label label_Sync;
        private System.Windows.Forms.Label label_Conf;
        private System.Windows.Forms.Button button_WriteRemote;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_RemoteID;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_RSK_HI;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_RSK_LO;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Sync;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Conf;
        private System.Windows.Forms.Button button_OpenCasDump;
        private System.Windows.Forms.ComboBox comboBox_bankSelect;
        private System.Windows.Forms.Button button_FetchRemoteData;
        private System.Windows.Forms.GroupBox groupBox_CasData;
        private System.Windows.Forms.Label label_CasDumpStatusLabel;
        private System.Windows.Forms.GroupBox groupBox_keyData;
        private System.Windows.Forms.Label label_CasDumpStatus;
    }
}