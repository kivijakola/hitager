using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hitager
{
    public partial class BMW_Remote : Form
    {
        private BmwHt2 bmwHt2;

        public BMW_Remote(BmwHt2 bmwHt2)
        {
            this.bmwHt2 = bmwHt2;
            InitializeComponent();
        }

        private void Read_Remote_Click(object sender, EventArgs e)
        {
            String KeyID;
            int tries = 0;

            do
            {
                KeyID = bmwHt2.ReadID();
                tries++;
            } while (KeyID.Length != 8 && tries < 3);

            /* Check if ID is valid and Key is a PCF7944 */
            String message;
            String caption = "Warning";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;

            if (KeyID.Length != 8)
            {
                message = "Key ID could not be read. Try to read Remote data anyway?";

                DialogResult result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Cancel)
                {
                    // Closes the parent form.
                    return;
                }
            }
            else if(KeyID.Substring(6,1) != "4") 
            {
                message = "Reading Remote only working for PCF7944 (5WK49121) Key. Do you want to try to read it anyway?";

                DialogResult result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Cancel)
                {
                    // Closes the parent form.
                    return;
                }
            }

            string remoteDataBlock;
            tries = 0;

            do
            {
                remoteDataBlock = bmwHt2.readBlocks(15, 15);
                tries++;
            } while ((remoteDataBlock.Substring(5 * 8, 4) != "0000") && (tries < 3));
            

            if(remoteDataBlock.Length == 64)
            {
                this.Textbox_RSK_Hi.Text = remoteDataBlock.Substring(5 * 8, 8);
                this.Textbox_RSK_Lo.Text = remoteDataBlock.Substring(4 * 8, 8);
            }
            else
            {
                this.Textbox_RSK_Hi.Text = "ERROR";
                this.Textbox_RSK_Lo.Text = "ERROR";
            }
            

        }
    }
}
