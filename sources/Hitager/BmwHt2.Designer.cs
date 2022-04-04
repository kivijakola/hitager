
namespace Hitager
{
    partial class BmwHt2
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
            this.label2 = new System.Windows.Forms.Label();
            this.blocksToHandle = new System.Windows.Forms.NumericUpDown();
            this.write = new System.Windows.Forms.Button();
            this.read = new System.Windows.Forms.Button();
            this.blocksStartNum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Button_Remote = new System.Windows.Forms.Button();
            this.Button_Vehicle_Data = new System.Windows.Forms.Button();
            this.BmwKeyMemory_Groupbox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.blocksToHandle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blocksStartNum)).BeginInit();
            this.BmwKeyMemory_Groupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Blocks";
            // 
            // blocksToHandle
            // 
            this.blocksToHandle.Location = new System.Drawing.Point(197, 72);
            this.blocksToHandle.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.blocksToHandle.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.blocksToHandle.Name = "blocksToHandle";
            this.blocksToHandle.Size = new System.Drawing.Size(91, 20);
            this.blocksToHandle.TabIndex = 10;
            this.blocksToHandle.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // write
            // 
            this.write.Enabled = false;
            this.write.Location = new System.Drawing.Point(6, 59);
            this.write.Name = "write";
            this.write.Size = new System.Drawing.Size(109, 35);
            this.write.TabIndex = 7;
            this.write.Text = "Write";
            this.write.UseVisualStyleBackColor = true;
            this.write.Click += new System.EventHandler(this.write_Click);
            // 
            // read
            // 
            this.read.Location = new System.Drawing.Point(6, 19);
            this.read.Name = "read";
            this.read.Size = new System.Drawing.Size(109, 34);
            this.read.TabIndex = 6;
            this.read.Text = "Read";
            this.read.UseVisualStyleBackColor = true;
            this.read.Click += new System.EventHandler(this.read_Click);
            // 
            // blocksStartNum
            // 
            this.blocksStartNum.Cursor = System.Windows.Forms.Cursors.Default;
            this.blocksStartNum.Location = new System.Drawing.Point(197, 46);
            this.blocksStartNum.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.blocksStartNum.Name = "blocksStartNum";
            this.blocksStartNum.Size = new System.Drawing.Size(91, 20);
            this.blocksStartNum.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "From:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(168, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "To:";
            // 
            // Button_Remote
            // 
            this.Button_Remote.Location = new System.Drawing.Point(570, 8);
            this.Button_Remote.Name = "Button_Remote";
            this.Button_Remote.Size = new System.Drawing.Size(109, 34);
            this.Button_Remote.TabIndex = 16;
            this.Button_Remote.Text = "Remote";
            this.Button_Remote.UseVisualStyleBackColor = true;
            this.Button_Remote.Click += new System.EventHandler(this.Remote_Functions_Click);
            // 
            // Button_Vehicle_Data
            // 
            this.Button_Vehicle_Data.Location = new System.Drawing.Point(570, 55);
            this.Button_Vehicle_Data.Name = "Button_Vehicle_Data";
            this.Button_Vehicle_Data.Size = new System.Drawing.Size(109, 34);
            this.Button_Vehicle_Data.TabIndex = 17;
            this.Button_Vehicle_Data.Text = "Vehicle Data";
            this.Button_Vehicle_Data.UseVisualStyleBackColor = true;
            this.Button_Vehicle_Data.Click += new System.EventHandler(this.BMW_Vehicle_Data_Click);
            // 
            // BmwKeyMemory_Groupbox
            // 
            this.BmwKeyMemory_Groupbox.Controls.Add(this.read);
            this.BmwKeyMemory_Groupbox.Controls.Add(this.write);
            this.BmwKeyMemory_Groupbox.Controls.Add(this.label2);
            this.BmwKeyMemory_Groupbox.Controls.Add(this.label3);
            this.BmwKeyMemory_Groupbox.Controls.Add(this.blocksToHandle);
            this.BmwKeyMemory_Groupbox.Controls.Add(this.label1);
            this.BmwKeyMemory_Groupbox.Controls.Add(this.blocksStartNum);
            this.BmwKeyMemory_Groupbox.Location = new System.Drawing.Point(3, 0);
            this.BmwKeyMemory_Groupbox.Name = "BmwKeyMemory_Groupbox";
            this.BmwKeyMemory_Groupbox.Size = new System.Drawing.Size(300, 101);
            this.BmwKeyMemory_Groupbox.TabIndex = 18;
            this.BmwKeyMemory_Groupbox.TabStop = false;
            this.BmwKeyMemory_Groupbox.Text = "Key Memory";
            // 
            // BmwHt2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BmwKeyMemory_Groupbox);
            this.Controls.Add(this.Button_Vehicle_Data);
            this.Controls.Add(this.Button_Remote);
            this.Name = "BmwHt2";
            this.Size = new System.Drawing.Size(914, 150);
            ((System.ComponentModel.ISupportInitialize)(this.blocksToHandle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blocksStartNum)).EndInit();
            this.BmwKeyMemory_Groupbox.ResumeLayout(false);
            this.BmwKeyMemory_Groupbox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown blocksToHandle;
        private System.Windows.Forms.Button write;
        private System.Windows.Forms.Button read;
        private System.Windows.Forms.NumericUpDown blocksStartNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Button_Remote;
        private System.Windows.Forms.Button Button_Vehicle_Data;
        private System.Windows.Forms.GroupBox BmwKeyMemory_Groupbox;
    }
}
