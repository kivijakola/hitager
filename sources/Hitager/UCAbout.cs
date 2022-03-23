using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.IO;

namespace Hitager
{
	/// <summary>
	/// Summary description for UCAbout.
	/// </summary>
	public class UCAbout : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lblAuthor;
		private System.Windows.Forms.Label lblVersion;
		private System.Windows.Forms.TabPage tabLicense;
		private System.Windows.Forms.RichTextBox txtLicense;
		private System.Windows.Forms.TabPage tabChanges;
		private System.Windows.Forms.RichTextBox txtChanges;
		private System.Windows.Forms.LinkLabel lnkWorkspace;
		private System.Windows.Forms.TabControl tabControl;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public UCAbout()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

            try
            {
                Assembly ca = Assembly.GetExecutingAssembly();

                string resLicense = "Hitager.Resources.license.txt";
                txtLicense.LoadFile(ca.GetManifestResourceStream(resLicense), RichTextBoxStreamType.PlainText);

                string resChanges = "Hitager.Resources.Changes.rtf";
                txtChanges.LoadFile(ca.GetManifestResourceStream(resChanges), RichTextBoxStreamType.RichText);

                lblVersion.Text = ca.GetName().Version.ToString();
            }
            catch (Exception)
            {
                return;
            }
		}

        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            
            base.ScaleControl(factor, specified);
        }

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCAbout));
            this.label1 = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lnkWorkspace = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabLicense = new System.Windows.Forms.TabPage();
            this.txtLicense = new System.Windows.Forms.RichTextBox();
            this.tabChanges = new System.Windows.Forms.TabPage();
            this.txtChanges = new System.Windows.Forms.RichTextBox();
            this.tabControl.SuspendLayout();
            this.tabLicense.SuspendLayout();
            this.tabChanges.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lblAuthor
            // 
            resources.ApplyResources(this.lblAuthor, "lblAuthor");
            this.lblAuthor.BackColor = System.Drawing.Color.White;
            this.lblAuthor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAuthor.Name = "lblAuthor";
            // 
            // lnkWorkspace
            // 
            resources.ApplyResources(this.lnkWorkspace, "lnkWorkspace");
            this.lnkWorkspace.BackColor = System.Drawing.Color.White;
            this.lnkWorkspace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lnkWorkspace.Name = "lnkWorkspace";
            this.lnkWorkspace.TabStop = true;
            this.lnkWorkspace.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCompany_LinkClicked);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // lblVersion
            // 
            resources.ApplyResources(this.lblVersion, "lblVersion");
            this.lblVersion.BackColor = System.Drawing.Color.White;
            this.lblVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVersion.Name = "lblVersion";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // tabControl
            // 
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Controls.Add(this.tabLicense);
            this.tabControl.Controls.Add(this.tabChanges);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // tabLicense
            // 
            this.tabLicense.Controls.Add(this.txtLicense);
            resources.ApplyResources(this.tabLicense, "tabLicense");
            this.tabLicense.Name = "tabLicense";
            // 
            // txtLicense
            // 
            this.txtLicense.BackColor = System.Drawing.Color.White;
            this.txtLicense.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtLicense, "txtLicense");
            this.txtLicense.Name = "txtLicense";
            this.txtLicense.ReadOnly = true;
            this.txtLicense.TextChanged += new System.EventHandler(this.txtLicense_TextChanged);
            // 
            // tabChanges
            // 
            this.tabChanges.Controls.Add(this.txtChanges);
            resources.ApplyResources(this.tabChanges, "tabChanges");
            this.tabChanges.Name = "tabChanges";
            // 
            // txtChanges
            // 
            this.txtChanges.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtChanges, "txtChanges");
            this.txtChanges.Name = "txtChanges";
            // 
            // UCAbout
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lnkWorkspace);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.label1);
            this.Name = "UCAbout";
            this.Load += new System.EventHandler(this.UCAbout_Load);
            this.tabControl.ResumeLayout(false);
            this.tabLicense.ResumeLayout(false);
            this.tabChanges.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void lnkCompany_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(this.lnkWorkspace.Text));
			}
			catch (Exception ex1)
			{
				MessageBox.Show(ex1.Message);
			}
		}

        private void UCAbout_Load(object sender, EventArgs e)
        {
            this.tabControl.Width = this.Width - 10;
            this.tabControl.Height = this.Height - this.tabControl.Top - 10;
            this.lblAuthor.Width = this.Width - this.lblAuthor.Left - 10;
            this.lnkWorkspace.Width = this.Width - this.lnkWorkspace.Left - 10;
            this.lblVersion.Width = this.Width - this.lblVersion.Left - 10;
        }

        private void txtLicense_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
