using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace Hitager
{
    public partial class BMW_Remote : Form
    {
        private BmwHt2 bmwHt2;

        private String[] bankID = { "0: N/A", "1: N/A", "2: N/A", "3: N/A", "4: N/A", "5: N/A", "6: N/A", "7: N/A", "8: N/A", "9: N/A" };

        private byte[] casDump = new byte[4096];

        public BMW_Remote(BmwHt2 bmwHt2)
        {
            this.bmwHt2 = bmwHt2;
            InitializeComponent();
            comboBox_bankSelect.DataSource = bankID;
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
                this.maskedTextBox_KeyNumber.Text = remoteDataBlock.Substring((7 * 8), 4);

                /* Address seems different between PCF7944 and China Key -> Select plausible value */
                if (remoteDataBlock.Substring(0, 8) == "FFFFFFFF" || remoteDataBlock.Substring(0, 8) == "b1b1b1b1")
                {
                    this.maskedTextBox_Sync.Text = remoteDataBlock.Substring((6 * 8), 8);
                }
                else
                {
                    this.maskedTextBox_Sync.Text = remoteDataBlock.Substring(0, 8);
                }
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

        private void button_OpenCasDump_Click(object sender, EventArgs e)
        {
            String fileContent = string.Empty;
            String filePath = string.Empty;


            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if(new FileInfo(openFileDialog.FileName).Length == 4096)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;

                        //Read the contents of the file into a stream
                        var fileStream = openFileDialog.OpenFile();

                        using (BinaryReader br = new BinaryReader(File.OpenRead(openFileDialog.FileName))) //Sets a new integer to the BinaryReader
                        {
                            //casDump = Encoding.UTF8.GetString(br.ReadBytes(4096)); //Reads as many bytes as it can
                            casDump = br.ReadBytes(4096); //Reads as many bytes as it can
                            br.Close();
                        }

                        /* Check the dump */


                        for (int i=0; i < 10; i++)
                        {
                            byte[] ID_bytearray = new byte[4];
                            Array.Copy(casDump, (0xA8C + i*4), ID_bytearray, 0, 4);
                            if (ID_bytearray.SequenceEqual(new byte[] { 0xFF, 0xFF, 0xFF, 0xFF }))
                            {
                                bankID[i] = i.ToString() + ": Empty";
                            }
                            else
                            {
                                bankID[i] = i.ToString() + ": " + BitConverter.ToString(ID_bytearray).Replace("-", "");
                            }
                                                        
                        }

                        comboBox_bankSelect.DataSource = null;
                        comboBox_bankSelect.DataSource = bankID;



                    }
                    else
                    {
                        String message = "No valid CAS3 dump. Filesize must be 4096 byte!";
                        String caption = "Warning";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;

                        DialogResult result = MessageBox.Show(message, caption, buttons);
                    }

                }
            }
        }

        private void button_FetchRemoteData_Click(object sender, EventArgs e)
        {
            int BankNr = comboBox_bankSelect.SelectedIndex;
            byte[] temp = new byte[4];

            /* Remote secret key High */
            Array.Copy(casDump, (0x848 + BankNr * 2), temp, 0, 2);
            maskedTextBox_RSK_HI.Text = BitConverter.ToString(temp).Replace("-", "");
            
            /* Remote secret key Low */
            Array.Copy(casDump, (0x860 + BankNr * 4), temp, 0, 4);
            maskedTextBox_RSK_LO.Text = BitConverter.ToString(temp).Replace("-", "");
        }
    }
}
