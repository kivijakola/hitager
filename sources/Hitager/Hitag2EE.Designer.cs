
namespace Hitager
{
    partial class Hitag2EE
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
            this.read = new System.Windows.Forms.Button();
            this.write = new System.Windows.Forms.Button();
            this.blocksToHandle = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbXmcfg = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.blocksToHandle)).BeginInit();
            this.SuspendLayout();
            // 
            // read
            // 
            this.read.Location = new System.Drawing.Point(11, 3);
            this.read.Name = "read";
            this.read.Size = new System.Drawing.Size(109, 34);
            this.read.TabIndex = 0;
            this.read.Text = "Read";
            this.read.UseVisualStyleBackColor = true;
            this.read.Click += new System.EventHandler(this.read_Click);
            // 
            // write
            // 
            this.write.Enabled = false;
            this.write.Location = new System.Drawing.Point(14, 50);
            this.write.Name = "write";
            this.write.Size = new System.Drawing.Size(105, 32);
            this.write.TabIndex = 1;
            this.write.Text = "Write";
            this.write.UseVisualStyleBackColor = true;
            this.write.Click += new System.EventHandler(this.write_Click);
            // 
            // blocksToHandle
            // 
            this.blocksToHandle.Location = new System.Drawing.Point(257, 61);
            this.blocksToHandle.Maximum = new decimal(new int[] {
            14,
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
            this.blocksToHandle.TabIndex = 4;
            this.blocksToHandle.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.blocksToHandle.ValueChanged += new System.EventHandler(this.blocksToHandle_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Read Blocks:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "XMCFG:";
            // 
            // tbXmcfg
            // 
            this.tbXmcfg.Enabled = false;
            this.tbXmcfg.Location = new System.Drawing.Point(257, 19);
            this.tbXmcfg.Name = "tbXmcfg";
            this.tbXmcfg.Size = new System.Drawing.Size(91, 20);
            this.tbXmcfg.TabIndex = 3;
            // 
            // Hitag2EE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.blocksToHandle);
            this.Controls.Add(this.tbXmcfg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.write);
            this.Controls.Add(this.read);
            this.Name = "Hitag2EE";
            this.Size = new System.Drawing.Size(835, 137);
            ((System.ComponentModel.ISupportInitialize)(this.blocksToHandle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button read;
        private System.Windows.Forms.Button write;
        private System.Windows.Forms.NumericUpDown blocksToHandle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbXmcfg;
    }
}
