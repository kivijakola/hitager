
namespace Hitager
{
    partial class HitagPro
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ide = new System.Windows.Forms.TextBox();
            this.getIde = new System.Windows.Forms.Button();
            this.WriteConfigLSB = new System.Windows.Forms.Button();
            this.setSegment = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SegmentConfig = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.WriteConfig = new System.Windows.Forms.Button();
            this.selectedSegment = new System.Windows.Forms.ComboBox();
            this.Read = new System.Windows.Forms.Button();
            this.Write = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.Read);
            this.panel1.Controls.Add(this.Write);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 439);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(781, 114);
            this.panel1.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ide);
            this.groupBox1.Controls.Add(this.getIde);
            this.groupBox1.Controls.Add(this.WriteConfigLSB);
            this.groupBox1.Controls.Add(this.setSegment);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.SegmentConfig);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.WriteConfig);
            this.groupBox1.Controls.Add(this.selectedSegment);
            this.groupBox1.Location = new System.Drawing.Point(84, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(679, 92);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Segment config";
            // 
            // ide
            // 
            this.ide.Enabled = false;
            this.ide.Location = new System.Drawing.Point(365, 56);
            this.ide.MaxLength = 4;
            this.ide.Name = "ide";
            this.ide.Size = new System.Drawing.Size(88, 20);
            this.ide.TabIndex = 23;
            // 
            // getIde
            // 
            this.getIde.Location = new System.Drawing.Point(365, 24);
            this.getIde.Name = "getIde";
            this.getIde.Size = new System.Drawing.Size(88, 21);
            this.getIde.TabIndex = 21;
            this.getIde.Text = "Read Ide";
            this.getIde.UseVisualStyleBackColor = true;
            this.getIde.Click += new System.EventHandler(this.getIde_Click);
            // 
            // WriteConfigLSB
            // 
            this.WriteConfigLSB.Enabled = false;
            this.WriteConfigLSB.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.WriteConfigLSB.Location = new System.Drawing.Point(280, 60);
            this.WriteConfigLSB.Name = "WriteConfigLSB";
            this.WriteConfigLSB.Size = new System.Drawing.Size(67, 21);
            this.WriteConfigLSB.TabIndex = 20;
            this.WriteConfigLSB.Text = "Write LSB";
            this.WriteConfigLSB.UseVisualStyleBackColor = true;
            this.WriteConfigLSB.Click += new System.EventHandler(this.WriteConfigLSB_Click);
            // 
            // setSegment
            // 
            this.setSegment.Enabled = false;
            this.setSegment.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.setSegment.Location = new System.Drawing.Point(207, 24);
            this.setSegment.Name = "setSegment";
            this.setSegment.Size = new System.Drawing.Size(140, 20);
            this.setSegment.TabIndex = 19;
            this.setSegment.Text = "Select";
            this.setSegment.UseVisualStyleBackColor = true;
            this.setSegment.Click += new System.EventHandler(this.setSegment_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(6, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Configuration:";
            // 
            // SegmentConfig
            // 
            this.SegmentConfig.Location = new System.Drawing.Point(84, 60);
            this.SegmentConfig.MaxLength = 4;
            this.SegmentConfig.Name = "SegmentConfig";
            this.SegmentConfig.Size = new System.Drawing.Size(117, 20);
            this.SegmentConfig.TabIndex = 13;
            this.SegmentConfig.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SegmentConfig_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(26, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Segment:";
            // 
            // WriteConfig
            // 
            this.WriteConfig.Enabled = false;
            this.WriteConfig.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.WriteConfig.Location = new System.Drawing.Point(207, 60);
            this.WriteConfig.Name = "WriteConfig";
            this.WriteConfig.Size = new System.Drawing.Size(67, 21);
            this.WriteConfig.TabIndex = 14;
            this.WriteConfig.Text = "Write MSB";
            this.WriteConfig.UseVisualStyleBackColor = true;
            this.WriteConfig.Click += new System.EventHandler(this.WriteConfig_Click);
            // 
            // selectedSegment
            // 
            this.selectedSegment.FormattingEnabled = true;
            this.selectedSegment.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "C"});
            this.selectedSegment.Location = new System.Drawing.Point(84, 24);
            this.selectedSegment.Name = "selectedSegment";
            this.selectedSegment.Size = new System.Drawing.Size(117, 21);
            this.selectedSegment.TabIndex = 16;
            this.selectedSegment.SelectedIndexChanged += new System.EventHandler(this.selectedSegment_SelectedIndexChanged);
            // 
            // Read
            // 
            this.Read.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Read.Location = new System.Drawing.Point(2, 3);
            this.Read.Name = "Read";
            this.Read.Size = new System.Drawing.Size(75, 44);
            this.Read.TabIndex = 12;
            this.Read.Text = "&Read";
            this.Read.UseVisualStyleBackColor = true;
            this.Read.Click += new System.EventHandler(this.Read_Click);
            // 
            // Write
            // 
            this.Write.Enabled = false;
            this.Write.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Write.Location = new System.Drawing.Point(3, 53);
            this.Write.Name = "Write";
            this.Write.Size = new System.Drawing.Size(75, 44);
            this.Write.TabIndex = 15;
            this.Write.Text = "Write";
            this.Write.UseVisualStyleBackColor = true;
            this.Write.Click += new System.EventHandler(this.Write_Click);
            // 
            // HitagPro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "HitagPro";
            this.Size = new System.Drawing.Size(781, 553);
            this.Load += new System.EventHandler(this.HitagAes_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button WriteConfigLSB;
        private System.Windows.Forms.Button setSegment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SegmentConfig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button WriteConfig;
        private System.Windows.Forms.ComboBox selectedSegment;
        private System.Windows.Forms.Button Read;
        private System.Windows.Forms.Button Write;
        private System.Windows.Forms.Button getIde;
        private System.Windows.Forms.TextBox ide;
    }
}
