/*
 * (c) Janne Kivijakola
 * janne@kivijakola.fi
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Be.Windows.Forms;

namespace Hitager
{
    public partial class HitagPro : UserControl
    {

        private string segmentCache = "";
        private int blockCountCache = 0;

        public HitagPro()
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

        private HexBox hexBox;
        public void setHexbox(ref HexBox box)
        {
            hexBox = box;
        }
        private void handleDebug(String text)
        {
            DebugUpdateRaiseEvent(text + Environment.NewLine);
        }

        private PortHandler portHandler;
        public void SetPortHandler(ref PortHandler handler)
        {
            portHandler = handler;
        }

        private String ReadPage(int page)
        {
            int cmd = 0x0000;
            cmd |= (page & 0x7);
            String pageReply = portHandler.portWR("i08" + cmd.ToString("X2"));
            if (pageReply.Length == 0)
                return "ERROR";
            handleDebug(pageReply + Environment.NewLine);
            return pageReply;
        }

        private String WritePage(int page, String content, int len, bool LSB = false)
        {

            int cmd = 0x80;
            cmd |= (page & 0x7);
            string writeCmd = cmd.ToString("X2") + content;
            byte crc = Crc8.ComputeChecksum(writeCmd);

            String pageReply = portHandler.portWR("i30" + writeCmd+crc.ToString("X2"));
            if (pageReply.Length == 0)
                return "ERROR";

            return "";
        }

        private String WriteByte(int page, int bytenum, String content)
        {
            if (content.Length != 2)
                return "ERROR";
            int cmd = 0xa0;
            cmd |= (page & 0x7)| (bytenum&0x3)<<3;
            string writeCmd = cmd.ToString("X2") + content;
            byte crc = Crc8.ComputeChecksum(writeCmd);

            String pageReply = portHandler.portWR("i18" + writeCmd + crc.ToString("X2"));
            if (pageReply.Length == 0)
                return "ERROR";

            return "";
        }

        private string selectSegment(int segment, int block=0)
        {
            int cmd = 0xd800;
            if (segment == 8)
                cmd |= 0xff;
            else
                cmd |= (segment & 0x7) << 8 | block;
            String segmentReply = portHandler.portWR("i10" + cmd.ToString("X4"));
            if (segmentReply.Length == 0)
                return "ERROR";

            return segmentReply;
        }

        private string selectBlock(int block)
        {
            int cmd = 0x4400;
            cmd |= (block & 0x7) << 11 | (((~block) & 0x7) << 6);
            String blockReply = portHandler.portWR("i0a" + cmd.ToString("X4"));
            if (blockReply.Length == 0)
                return "ERROR";

            return blockReply;
        }

        private void Read_Click(object sender, EventArgs e)
        {
            
            portHandler.portWR("o");
            String pages = "";
            String start = "";
            int selected = selectedSegment.SelectedIndex;
            if (selected == 8)
            {
                start = portHandler.portWR("i28ff" + ide.Text);
            }
            else
            {
                start = portHandler.portWR("i2800" + ide.Text);
                String segmentConf = selectSegment(selected);
                handleDebug(segmentConf + Environment.NewLine);
            }

            int blockCount = 1;
            int pageMode = 0;
            try
            {
                int raw = int.Parse(SegmentConfig.Text.Substring(0, 4), System.Globalization.NumberStyles.HexNumber);
                pageMode = (raw >> 8) & 0xf;
                blockCount = raw & 0xf;
                blockCountCache = blockCount;

            }
            catch (Exception xe)
            {
                handleDebug("ERROR! Cannot parse  segment configuration!");
                portHandler.portWR("f");
                return;
            }
           
            WriteConfig.Enabled = true;
            WriteConfigLSB.Enabled = true;
            for (int j = 0; j < blockCount; j++)
            {
                if (j > 0)
                {
                    String blockConf = selectSegment(selected, j);
                    handleDebug(blockConf + Environment.NewLine);
                }
                for (int i = 0; i < 8; i++)
                {
                    string readpage = ReadPage(i);
                    if(readpage.Length>=8)
                        pages += readpage.Substring(0, 8);
                    else
                    {
                        handleDebug("ERROR! Cannot read all blocks!");
                        j = blockCount;
                        break;
                    }

                }

            }


            DynamicByteProvider dynamicByteProvider;
            try
            {

                dynamicByteProvider = new DynamicByteProvider(ConvertHexStringToByteArray(pages));
                hexBox.ByteProvider = dynamicByteProvider;
            }
            catch (Exception x)
            {
                portHandler.portWR("f");
                handleDebug("ERROR! Cannot parse bytes to array!");
                handleDebug(pages);

                return;
            }


            segmentCache = pages;
            if (blockCount > 0)
            {
                Write.Enabled = true;
            }

            portHandler.portWR("f");
            HexUpdateRaiseEvent();

        }
        
        private void WriteConfig_Click(object sender, EventArgs e)
        {
            portHandler.portWR("o");
            String config = "";

            String configMode = portHandler.portWR("i28ff" + ide.Text);
            handleDebug(configMode + Environment.NewLine);

            config = SegmentConfig.Text.Replace(" ", "");
            int targetbyte = selectedSegment.SelectedIndex % 4;
            int targetpage = selectedSegment.SelectedIndex/4+2;

            WriteByte(targetpage, targetbyte, config.Substring(0, 2));

            portHandler.portWR("f");

            handleDebug(configMode + Environment.NewLine);
        }

        private void Write_Click(object sender, EventArgs e)
        {
            portHandler.portWR("o");

            String start = "";
            int currentSegment = selectedSegment.SelectedIndex;
            if (currentSegment == 8)
            {
                start = portHandler.portWR("i28ff" + ide.Text);
            }
            else
            {
                start = portHandler.portWR("i2800" + ide.Text);
                String segmentConf = selectSegment(currentSegment);
                handleDebug(segmentConf + Environment.NewLine);
            }

            for (int blocks = 0; blocks < blockCountCache; blocks++)
            {
                String pages = "";
                int startWrite = 0;


                for (int i = 0; i < 32; i++)
                {
                    if (hexBox.ByteProvider.Length < blocks * 32 + i+1)
                        break;
                    pages += hexBox.ByteProvider.ReadByte(blocks * 32 + i).ToString("X2");
                }

                if (blocks > 0)
                {
                    selectSegment(currentSegment, blocks);
                }
                for (int i = startWrite; i < 8; i++)
                {
                    if (pages.Length < (i + 1) * 8)
                        break;
                    string nowWriting = pages.Substring(i * 8, 8);
                    if (!segmentCache.Substring(blocks * 64 + i * 8, 8).Equals(nowWriting))
                    {
                        if (!(currentSegment == 0 && blocks == 0 && i == 0 && nowWriting.Equals("00000000")))
                            WritePage(i, nowWriting, 32);
                    }

                }
            }

            portHandler.portWR("f");
        }

        public static byte[] ConvertHexStringToByteArray(string hexString)
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

        private void selectedSegment_SelectedIndexChanged(object sender, EventArgs e)
        {
            Read.Enabled = false;
            Write.Enabled = false;
        }



        private void setSegment_Click(object sender, EventArgs e)
        {
            string idee = ide.Text;
            if (idee.Length != 8)
                return;

            portHandler.portWR("o");
            int selected = selectedSegment.SelectedIndex;


            String start = portHandler.portWR("i28ff"+idee);
            String segmentConf = "";
            String segmentAccessConf = "";
            if (selected < 4)
            { 
                segmentConf = portHandler.portWR("i0800");
                segmentAccessConf = portHandler.portWR("i0802");
                
                if (segmentAccessConf.Length >= 8 && segmentConf.Length >= 8)
                {
                    segmentConf = segmentConf.Substring(selected * 2, 2);
                    segmentAccessConf = segmentAccessConf.Substring(selected * 2, 2);
                    segmentConf = segmentAccessConf + segmentConf;
                }
                else
                {
                    SegmentConfig.Text = "ERROR";
                    return;
                }
            }
            else if(selected < 8)
            {
                segmentConf = portHandler.portWR("i0801");
                segmentAccessConf = portHandler.portWR("i0803");
                if (segmentAccessConf.Length >= 8 && segmentConf.Length >= 8)
                {
                    segmentConf = segmentConf.Substring((selected - 4) * 2, 2);
                    segmentAccessConf = segmentAccessConf.Substring((selected - 4) * 2, 2);
                    segmentConf = segmentAccessConf + segmentConf;
                }
                else
                {
                    SegmentConfig.Text = "ERROR";
                    return;
                }
            }
            else
            {
                segmentConf ="8F81";
            }


            SegmentConfig.Text = segmentConf;
            Write.Enabled = false;
            Read.Enabled = true;
            WriteConfig.Enabled = true;
            WriteConfigLSB.Enabled = true;
            hexBox.ByteProvider = null;


            portHandler.portWR("f");
            return;

        }

        private void WriteConfigLSB_Click(object sender, EventArgs e)
        {
            portHandler.portWR("o");
            String config = "";

            String configMode = portHandler.portWR("i28ff" + ide.Text);
            handleDebug(configMode + Environment.NewLine);

            config = SegmentConfig.Text.Replace(" ", "");
            int targetbyte = selectedSegment.SelectedIndex % 4;
            int targetpage = selectedSegment.SelectedIndex / 4;

            WriteByte(targetpage, targetbyte, config.Substring(2, 2));

            portHandler.portWR("f");

            handleDebug(configMode + Environment.NewLine);
        }



        private void SegmentConfig_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !e.KeyChar.IsHex())
            {
                e.Handled = true;
            }
            else
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        private void HitagAes_Load(object sender, EventArgs e)
        {
            selectedSegment.SelectedIndex = 0;
        }

        private void getIde_Click(object sender, EventArgs e)
        {
            portHandler.portWR("o");

            String ide = portHandler.portWR("i0430");
            if (ide.Length >= 8)
            {
                this.ide.Text = ide.Substring(0, 8);
                setSegment.Enabled = true;
            }

            portHandler.portWR("f");
        }
    }
}
