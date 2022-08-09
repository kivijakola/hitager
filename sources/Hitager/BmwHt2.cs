/*
 * (c) Janne Kivijakola
 * janne@kivijakola.fi
 */
using Be.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Hitager
{
    public partial class BmwHt2 : UserControl
    {
        public BmwHt2()
        {
            InitializeComponent();
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Hex box updated")]
        public event EventHandler HexUpdated;

        private void HexUpdateRaiseEvent()
        {

            if (this.HexUpdated != null)
                this.HexUpdated(this, new EventArgs());
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Debug message updated")]
        public event EventHandler debugUpdated;

        private void DebugUpdateRaiseEvent(string debug)
        {
            DebugmessageEventArgs e = new DebugmessageEventArgs();
            e.Message = debug;

            if (this.debugUpdated != null)
                debugUpdated(this, e);
        }

        private string segmentCache = "";

        private HexBox hexBox;
        public void setHexbox(ref HexBox box)
        {
            hexBox = box;
        }

        public void handleDebug(String text)
        {
            DebugUpdateRaiseEvent(text + Environment.NewLine);
        }
        public PortHandler portHandler;
        public void SetPortHandler(ref PortHandler handler)
        {
            portHandler = handler;
        }

        private String WritePage(int page, String content, int len, bool LSB = false)
        {

            int cmd = 0x8b80;
            portHandler.portWR("i0a" + cmd.ToString("X4"));
            portHandler.portWR("i" + len.ToString("X2") + content);

            return "";
        }

        private String ReadPage(int page)
        {
            int cmd = 0xC1C0;
            String pageReply = portHandler.portWR("i0a" + cmd.ToString("X4"));
            if (pageReply.Length == 0)
                return "B1B1B1B1";
            handleDebug(pageReply + Environment.NewLine);

            return pageReply;
        }

        public String ReadID()
        {
            portHandler.portWR("o");

            String cardID;
            int tries = 0;

            do
            {
                cardID = portHandler.portWR("i05C0");
                tries++;
                
            } while (cardID.Length < 8 && tries < 3);
            
            if (cardID.Equals("TIMEOUT"))
            {
                handleDebug("TIMEOUT");

            }
            else if (cardID.Length < 8)
            {
                handleDebug("ERROR ID");
                handleDebug("Please retry reading!");
                cardID = "b1b1b1b1";
            }
            portHandler.portWR("f");

            return cardID;
        }
        private string selectBlock(int block)
        {
            String blockReply = portHandler.portWR("i20000700" + block.ToString("X2"));

            return blockReply;
        }

        public bool sendCmdUntilResponse(String CMD, String expectedResponse, int maxRepetitions)
        {
            int tries = 1;
            string response;
            
            do
            {
                if (tries > 1) handleDebug("Send cmd, try " + tries.ToString());
                response = portHandler.portWR(CMD);
                tries++;
            } while (!response.Contains(expectedResponse) && tries < maxRepetitions);

            return response.Contains(expectedResponse);
        }

        /* Read selected Block (= 8 pages = 256 byte) */
        public string readBlocks(int blockAddressStart, int blockAddressEnd)
        {
            bool resetBlocks = false;
            read.Enabled = false;
            write.Enabled = false;

            String Key_ID = ReadID();  //Necessary for distinguishing 5WK49125 /5WK49121

            portHandler.portWR("o");
            String pages = "";

            sendCmdUntilResponse("i0540", "FFFFFFE8", 10);  // Enter to XMA Mode

            for (int j = blockAddressStart; j <= blockAddressEnd; j++)
            {
                /* Select the block */
                if (!(j == 0 || j == 31))
                {
                    if (resetBlocks)
                    {
                        portHandler.portWR("i0500");
                        portHandler.portWR("i0540");
                    }

                    sendCmdUntilResponse("i0A83C0", "83C0", 10);
                    
                    if (selectBlock(j).Equals("ERROR"))     // Address_Write
                    {
                        handleDebug("ERROR! Cannot read all blocks!");
                        break;
                    }
                }

                /*Read pages from selected block */
                for (int i = 0; i < 8; i++)
                {
                    String received = "00000000";
                    
                    if (((j == 14 && i == 7) || j == 31))
                    {
                        /* Not readable pages */
                        received = "B1B1B1B1";
                    }
                    else if (j == 15 || j==0)
                    {
                        /* Special procedure for reading protected block PCF7944 5WK49121 */
                        Thread.Sleep(10);
                        sendCmdUntilResponse("i0540", "FFFFFFE8", 5);
                        Thread.Sleep(10);
                        received = ReadPage(i);
                    }
                    else
                    {
                        /* Normal Page */
                        Thread.Sleep(10);
                        received = ReadPage(i);
                    }
                         
                    if (received.Length < 8)
                        received = received + "B1B1B1B1";
                    pages += received.Substring(0, 8);

                }
            }

            write.Enabled = true;
            read.Enabled = true;
            portHandler.portWR("f");

            return pages;

        }


        private void read_Click(object sender, EventArgs e)
        {
            String blocks = readBlocks((int)blocksStartNum.Value, (int)blocksToHandle.Value);
    
            DynamicByteProvider dynamicByteProvider;
            try
            {
                dynamicByteProvider = new DynamicByteProvider(ConvertHexStringToByteArray(blocks));
                hexBox.ByteProvider = dynamicByteProvider;
            }
            catch (Exception x)
            {
                handleDebug("ERROR! Cannot parse bytes to array!");
                handleDebug(blocks);
                read.Enabled = true;
                portHandler.portWR("f");
                return;
            }

            segmentCache = blocks;

            HexUpdateRaiseEvent();
        }

        public byte[] ConvertHexStringToByteArray(string hexString)
        {
            if (hexString.Length % 2 != 0)
            {
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString));
            }

            byte[] data = new byte[hexString.Length / 2];
            for (int index = 0; index < data.Length; index++)
            {
                string byteValue = hexString.Substring(index * 2, 2);
                data[index] = Convert.ToByte(byteValue, 16);
            }

            return data;
        }

        private void write_Click(object sender, EventArgs e)
        {
            write.Enabled = false;
            bool resetBlocks = true;
            portHandler.portWR("o");

            String xmaMode = portHandler.portWR("i0540");

            int blockAddressEnd = (int)blocksToHandle.Value;
            int blockAddressStart = (int)blocksStartNum.Value;

            for (int blocks = blockAddressStart; blocks <= blockAddressEnd; blocks++)
            {
                String pages = "";
                int startWrite = 0;

                for (int i = 0; i < 32; i++)
                {
                    if (hexBox.ByteProvider.Length < blocks * 32 + i + 1)
                        break;
                    pages += hexBox.ByteProvider.ReadByte(blocks * 32 + i).ToString("X2");
                }

                if (!segmentCache.Substring(blocks * 64, 64).Equals(pages))
                {
                    if (resetBlocks)
                    {
                        portHandler.portWR("i0500");
                        portHandler.portWR("i0540");
                    }

                    portHandler.portWR("i0A83C0");

                    if (!(blocks == 0 || blocks == 15 || blocks == 31))
                    {
                        selectBlock(blocks);

                        for (int i = startWrite; i < 8; i++)
                        {
                            if (pages.Length < (i + 1) * 8)
                                break;
                            string nowWriting = pages.Substring(i * 8, 8);

                            WritePage(i, nowWriting, 32);
                        }
                    }
                }
            }

            portHandler.portWR("f");
            write.Enabled = true;
        }

        private void blocksToHandle_ValueChanged(object sender, EventArgs e)
        {
            write.Enabled = false;
        }

        private void Remote_Functions_Click(object sender, EventArgs e)
        {
            BMW_Remote Remote = new BMW_Remote(this);
            Remote.Show();
        }

        private void BMW_Vehicle_Data_Click(object sender, EventArgs e)
        {
            BMW_Vehicle_Data VehicleData = new BMW_Vehicle_Data(this);
            VehicleData.Show();
        }
    }
}
