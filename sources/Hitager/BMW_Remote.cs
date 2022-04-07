﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

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
            else if (KeyID.Substring(6,1) != "4")
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


            if (remoteDataBlock.Length == 64)
            {
                this.maskedTextBox_RSK_HI.Text = remoteDataBlock.Substring((5 * 8) + 4, 4);
                this.maskedTextBox_RSK_LO.Text = remoteDataBlock.Substring(4 * 8, 8);
            }
            else
            {
                this.maskedTextBox_RSK_HI.Text = "ERROR";
                this.maskedTextBox_RSK_LO.Text = "ERROR";
            }


        }

        private void button_WriteRemote_Click(object sender, EventArgs e)
        {

            bmwHt2.portHandler.portWR("o");

            byte Checksum8 = 0;

            String[] KeyData = { maskedTextBox_RSK_LO.Text , maskedTextBox_RSK_HI.Text , maskedTextBox_Sync.Text ,
                                 maskedTextBox_KeyNumber.Text , maskedTextBox_Conf.Text, "00000000" };

            /* User confirmation */
            String message = "This feature was never tested with a real key. Writing Remote Data irreversibly locks the Hitag2 pages " +
                            "and remote data block. Key can not be written again and may be unusable in case of wrong data applied. Continue anyway?";
            String caption = "Warning";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;

            DialogResult result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                bmwHt2.portHandler.portWR("f");

                // Closes the parent form.
                return;
            }

            /* Enter XMA Mode */
            if(bmwHt2.sendCmdUntilResponse("i0540", "FFFFFFE8", 4) == false)
            {
                bmwHt2.handleDebug("Entering XMA Mode failed");
                bmwHt2.portHandler.portWR("f");
                return;
            }

            Thread.Sleep(10);

            /* Write 5 pages of data for remote */
            for (int i = 0; i < 6; i++)
            {
                if(i == 5)  KeyData[5] = "000000" + BitConverter.ToString(new byte[] { Checksum8 });     // Add CKS to last message

                /* Sending "Write Remote" Command (10010+inv) */
                if (bmwHt2.sendCmdUntilResponse("i0A9340", "9340", 4) == false)
                {
                    bmwHt2.handleDebug("Wrong response");
                    bmwHt2.portHandler.portWR("f");
                    return;
                }
                Thread.Sleep(10);       // Wait until CMD executed (robustness improvement, eventually not necessary)

                bmwHt2.portHandler.portWR("i20" + KeyData[i].PadLeft(8,'0'));

                Thread.Sleep(10);       // Wait until data is written (robustness improvement, eventually not necessary)

                byte[] CksBuff = new byte[4];
                Array.Copy(bmwHt2.ConvertHexStringToByteArray(KeyData[i]), CksBuff, bmwHt2.ConvertHexStringToByteArray(KeyData[i]).Length);

                /* Calc Checksum */
                for (byte j = 0; j < 4; j++)
                {
                    Checksum8 = (byte)(Checksum8 ^ CksBuff[j]);
                }

            }

            bmwHt2.portHandler.portWR("f");
        }
    }
}
