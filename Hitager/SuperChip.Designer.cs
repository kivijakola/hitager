
namespace Hitager
{
    partial class SuperChip
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
            this.buttonSync = new System.Windows.Forms.Button();
            this.buttonRun = new System.Windows.Forms.Button();
            this.buttonHaltChip = new System.Windows.Forms.Button();
            this.buttonRead = new System.Windows.Forms.Button();
            this.comboBoxChipType = new System.Windows.Forms.ComboBox();
            this.buttonSetType = new System.Windows.Forms.Button();
            this.buttonWrite = new System.Windows.Forms.Button();
            this.checkBoxBrute = new System.Windows.Forms.CheckBox();
            this.numericUpDownBlocks = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBlocks)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSync
            // 
            this.buttonSync.Location = new System.Drawing.Point(98, 12);
            this.buttonSync.Name = "buttonSync";
            this.buttonSync.Size = new System.Drawing.Size(116, 21);
            this.buttonSync.TabIndex = 0;
            this.buttonSync.Text = "Enable Mem Access";
            this.buttonSync.UseVisualStyleBackColor = true;
            this.buttonSync.Click += new System.EventHandler(this.buttonSync_Click);
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(17, 90);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(56, 30);
            this.buttonRun.TabIndex = 2;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Visible = false;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // buttonHaltChip
            // 
            this.buttonHaltChip.Location = new System.Drawing.Point(17, 12);
            this.buttonHaltChip.Name = "buttonHaltChip";
            this.buttonHaltChip.Size = new System.Drawing.Size(75, 21);
            this.buttonHaltChip.TabIndex = 4;
            this.buttonHaltChip.Text = "Freeze Chip";
            this.buttonHaltChip.UseVisualStyleBackColor = true;
            this.buttonHaltChip.Click += new System.EventHandler(this.buttonHaltChip_Click);
            // 
            // buttonRead
            // 
            this.buttonRead.Location = new System.Drawing.Point(229, 12);
            this.buttonRead.Name = "buttonRead";
            this.buttonRead.Size = new System.Drawing.Size(83, 21);
            this.buttonRead.TabIndex = 5;
            this.buttonRead.Text = "Read";
            this.buttonRead.UseVisualStyleBackColor = true;
            this.buttonRead.Click += new System.EventHandler(this.buttonRead_Click);
            // 
            // comboBoxChipType
            // 
            this.comboBoxChipType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChipType.FormattingEnabled = true;
            this.comboBoxChipType.Items.AddRange(new object[] {
            "ID11",
            "ID12",
            "ID13",
            "ID7935(ID33,40,42,43,44)",
            "ID7936(ID46)",
            "ID7937",
            "ID7938(ID47)",
            "ID7939(ID49)",
            "ID7946",
            "ID48",
            "ID4C",
            "ID4D (ID60,63)",
            "4D(80)chip(ID70,83,G)",
            "ID4E (ID64)",
            "ID8A (H)",
            "ID8C",
            "ID8E"});
            this.comboBoxChipType.Location = new System.Drawing.Point(437, 12);
            this.comboBoxChipType.Name = "comboBoxChipType";
            this.comboBoxChipType.Size = new System.Drawing.Size(178, 21);
            this.comboBoxChipType.TabIndex = 6;
            this.comboBoxChipType.SelectedIndexChanged += new System.EventHandler(this.comboBoxChipType_SelectedIndexChanged);
            // 
            // buttonSetType
            // 
            this.buttonSetType.Location = new System.Drawing.Point(621, 12);
            this.buttonSetType.Name = "buttonSetType";
            this.buttonSetType.Size = new System.Drawing.Size(58, 21);
            this.buttonSetType.TabIndex = 7;
            this.buttonSetType.Text = "Set Type";
            this.buttonSetType.UseVisualStyleBackColor = true;
            this.buttonSetType.Click += new System.EventHandler(this.buttonSetType_Click);
            // 
            // buttonWrite
            // 
            this.buttonWrite.Location = new System.Drawing.Point(319, 12);
            this.buttonWrite.Name = "buttonWrite";
            this.buttonWrite.Size = new System.Drawing.Size(75, 21);
            this.buttonWrite.TabIndex = 8;
            this.buttonWrite.Text = "Write";
            this.buttonWrite.UseVisualStyleBackColor = true;
            this.buttonWrite.Click += new System.EventHandler(this.buttonWrite_Click);
            // 
            // checkBoxBrute
            // 
            this.checkBoxBrute.AutoSize = true;
            this.checkBoxBrute.Location = new System.Drawing.Point(98, 39);
            this.checkBoxBrute.Name = "checkBoxBrute";
            this.checkBoxBrute.Size = new System.Drawing.Size(102, 17);
            this.checkBoxBrute.TabIndex = 9;
            this.checkBoxBrute.Text = "Use More Force";
            this.checkBoxBrute.UseVisualStyleBackColor = true;
            // 
            // numericUpDownBlocks
            // 
            this.numericUpDownBlocks.Hexadecimal = true;
            this.numericUpDownBlocks.Location = new System.Drawing.Point(277, 36);
            this.numericUpDownBlocks.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.numericUpDownBlocks.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownBlocks.Name = "numericUpDownBlocks";
            this.numericUpDownBlocks.Size = new System.Drawing.Size(35, 20);
            this.numericUpDownBlocks.TabIndex = 10;
            this.numericUpDownBlocks.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Pages:";
            // 
            // SuperChip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownBlocks);
            this.Controls.Add(this.checkBoxBrute);
            this.Controls.Add(this.buttonWrite);
            this.Controls.Add(this.buttonSetType);
            this.Controls.Add(this.comboBoxChipType);
            this.Controls.Add(this.buttonRead);
            this.Controls.Add(this.buttonHaltChip);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.buttonSync);
            this.Name = "SuperChip";
            this.Size = new System.Drawing.Size(747, 111);
            this.Load += new System.EventHandler(this.SuperChip_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBlocks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSync;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Button buttonHaltChip;
        private System.Windows.Forms.Button buttonRead;
        private System.Windows.Forms.ComboBox comboBoxChipType;
        private System.Windows.Forms.Button buttonSetType;
        private System.Windows.Forms.Button buttonWrite;
        private System.Windows.Forms.CheckBox checkBoxBrute;
        private System.Windows.Forms.NumericUpDown numericUpDownBlocks;
        private System.Windows.Forms.Label label1;
    }
}
