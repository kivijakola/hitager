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

        public enum CasMasks : byte
        {
            L15Y = 0,
            L01Y = 1,
            INI = 3
        }

        CasMasks CasMaskDet = CasMasks.INI;

        /* Definition of CAS3 memory layout */
        public struct CasMemLayout
        {
            public UInt16 KeyID;
            public UInt16 RemoteID;
            public UInt16 RSK_Hi;
            public UInt16 RSK_Lo;
            public UInt16 Sync;
            public String CasMaskString;
        }

        CasMemLayout[] Cas3 = new CasMemLayout[2];

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
                this.maskedTextBox_RemoteID.Text = remoteDataBlock.Substring((7 * 8), 4);

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
                                 maskedTextBox_RemoteID.Text , maskedTextBox_Conf.Text, "00000000" };

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

                if(i != 3)
                {
                    bmwHt2.portHandler.portWR("i20" + KeyData[i].PadLeft(8, '0'));
                }
                else
                {
                    bmwHt2.portHandler.portWR("i20" + KeyData[i].PadRight(8, '0'));
                }
                

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
            bool[] CasDumpPlausible = { true, true };

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "All files (*.*)|*.*|Binary files (*.bin)|*.bin";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                /* Create database with key's addresses */
                Cas3[0].CasMaskString = "0L15Y";
                Cas3[0].KeyID = 0xA8C;
                Cas3[0].RemoteID = 0x830;
                Cas3[0].RSK_Hi = 0x848;
                Cas3[0].RSK_Lo = 0x860;
                Cas3[0].Sync = 0x8E4;

                Cas3[1].CasMaskString = "0L01Y";
                Cas3[1].KeyID = 0x28C;
                Cas3[1].RemoteID = 0x30;
                Cas3[1].RSK_Hi = 0x48;
                Cas3[1].RSK_Lo = 0x60;
                Cas3[1].Sync = 0x8C;


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if(new FileInfo(openFileDialog.FileName).Length == 4096)
                    {
                        filePath = openFileDialog.FileName;
                     
                        var fileStream = openFileDialog.OpenFile();

                        using (BinaryReader br = new BinaryReader(File.OpenRead(openFileDialog.FileName)))
                        {
                            casDump = br.ReadBytes(4096);
                            br.Close();
                        }

                        /* Check for which mem layout the checksum is correct */
                        for (byte i=0; i< Cas3.Length; i++)
                        {
                            int cks8mod256 = 0;
                            /* Calc checksum over transponder ID block */
                            for (int j = Cas3[i].KeyID; j < (Cas3[i].KeyID + 4 * 10); j++)
                            {
                                cks8mod256 += (byte)casDump.GetValue(j);
                                cks8mod256 %= 256;
                            }

                            CasDumpPlausible[i] &= (cks8mod256 == (byte)casDump.GetValue((Cas3[i].KeyID + 4 * 10 )));
                        }

                        if (CasDumpPlausible[0])
                        {
                            CasMaskDet = CasMasks.L15Y;
                        }
                        else if (CasDumpPlausible[1])
                        {
                            CasMaskDet = CasMasks.L01Y;
                        }
                        else
                        {
                            CasMaskDet = CasMasks.INI;
                        }

                        if (CasMaskDet != CasMasks.INI)
                        {
                            label_CasDumpStatus.ForeColor = Color.Green;
                            label_CasDumpStatus.Text = "Dump valid";
                            label_CasMask.Text = Cas3[(int)CasMaskDet].CasMaskString;
                            label_CasMask.ForeColor = Color.Green;

                            /* Extract Transponder IDs and create elements for dropdown list */
                            for (int i = 0; i < 10; i++)
                            {
                                byte[] ID_bytearray = new byte[4];
                                Array.Copy(casDump, (Cas3[(int)CasMaskDet].KeyID + i * 4), ID_bytearray, 0, 4);
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
                            label_CasDumpStatus.ForeColor = Color.Red;
                            label_CasDumpStatus.Text = "Dump Not Valid";
                            label_CasMask.ForeColor = Color.Black;
                            label_CasMask.Text = "N/A";
                        }

                    }
                    else
                    {
                        String message = "No valid CAS3 dump. Filesize must be 4096 byte!";
                        String caption = "Warning";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;

                        MessageBox.Show(message, caption, buttons);

                        label_CasDumpStatus.ForeColor = Color.Red;
                        label_CasDumpStatus.Text = "Dump Not Valid";
                        label_CasMask.ForeColor = Color.Black;
                        label_CasMask.Text = "N/A";
                    }
                }
            }
        }

        private void button_FetchRemoteData_Click(object sender, EventArgs e)
        {
            int BankNr = comboBox_bankSelect.SelectedIndex;
            byte[] temp = new byte[4];

            if(CasMaskDet == CasMasks.INI)
            {
                String message = "No valid CAS3 detected. Please load a valid dump first!";
                String caption = "Warning";
                MessageBoxButtons buttons = MessageBoxButtons.OK;

                MessageBox.Show(message, caption, buttons);
            }
            else
            {
                /* Remote secret key High */
                Array.Copy(casDump, (Cas3[(int)CasMaskDet].RSK_Hi + BankNr * 2), temp, 0, 2);
                maskedTextBox_RSK_HI.Text = BitConverter.ToString(temp).Replace("-", "");

                /* Remote secret key Low */
                Array.Copy(casDump, (Cas3[(int)CasMaskDet].RSK_Lo + BankNr * 4), temp, 0, 4);
                maskedTextBox_RSK_LO.Text = BitConverter.ToString(temp).Replace("-", "");

                /* Remote ID */
                Array.Copy(casDump, (Cas3[(int)CasMaskDet].RemoteID + BankNr * 2), temp, 0, 2);
                maskedTextBox_RemoteID.Text = BitConverter.ToString(temp).Replace("-", "");

                /* Remote Sync */
                Array.Copy(casDump, (Cas3[(int)CasMaskDet].Sync + BankNr * 4), temp, 0, 4);
                maskedTextBox_Sync.Text = BitConverter.ToString(temp).Replace("-", "");
            }
            
        }
    }
}
