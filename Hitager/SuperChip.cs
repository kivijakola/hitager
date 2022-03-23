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
    public partial class SuperChip : UserControl
    {
        public SuperChip()
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

        private void handleDebug(String text)
        {
            DebugUpdateRaiseEvent(text + Environment.NewLine);
        }
        private PortHandler portHandler;
        public void SetPortHandler(ref PortHandler handler)
        {
            portHandler = handler;
        }

        private void SuperChip_Load(object sender, EventArgs e)
        {
            comboBoxChipType.SelectedIndex = 4;
        }

        private void buttonSync_Click(object sender, EventArgs e)
        {
            string[] bruteCmd = { "263A",
                                "A81C",
                                "018E5995",
                                "9468",
                                "C642",
                                "C2E79D32",
                                "9C60",
                                "7D74",
                                "23D0363E",
                                "D579",
                                "2DEB",
                                "5372F1DA",
                                "7FAA",
                                "C4AC",
                                "F585F7C8",
                                "8FC8",
                                "B4A2",
                                "661BC05B",
                                "2F8A",
                                "6934",
                                "6E927A0D",
                                "95EE",
                                "2DED",
                                "C48B0B56",
                                "27C5",
                                "9F0A",
                                "D4DA670D",
                                "DA5B",
                                "383B",
                                "30905FCA",
                                "A405",
                                "A1B4",
                                "2440DD33",
                                "2330",
                                "3486",
                                "5D794307",
                                "59FE",
                                "2920",
                                "347C06D3",
                                "FDCA",
                                "318B" };

            int targetTiming = 0x263A;

            targetTiming = Reverse(targetTiming);
            targetTiming ^= (0xa36f ^ 0x5eed);
            targetTiming = (targetTiming - 0x5000) & 0xffff;
            if (targetTiming < 0x5000)
                targetTiming += 0xffff;

            portHandler.portWR("o");
            portHandler.portWR("f");
            System.Threading.Thread.Sleep(500);

            int iterations = 0;
            int retries = 0;
            while (true)
            {
                int icurrentTiming = 0;
                System.Threading.Thread.Sleep(500);

                String currentTiming = portHandler.portWR("q");

                if (currentTiming.Length >= 4)
                    currentTiming = currentTiming.Substring(0, 4);
                else
                {
                    handleDebug("No reply!");
                    if(iterations != 0 && retries < 4)
                    {
                        handleDebug("Retrying..");
                        portHandler.portWR("f");
                        System.Threading.Thread.Sleep(200);
                        //portHandler.portWR("o");
                        retries++;
                        continue;
                    }
                    return;
                }
                try
                {
                    icurrentTiming = int.Parse(currentTiming, System.Globalization.NumberStyles.HexNumber);
                }
                catch(Exception exp)
                {
                    portHandler.portWR("f");
                    handleDebug("Could not sync!");
                    
                    return;
                }

                icurrentTiming ^= (0xaa6a ^ 0x5eed);
                icurrentTiming = (icurrentTiming - 0x5000)&0xffff;
                if (icurrentTiming < 0x5000)
                    icurrentTiming += 0xffff;

                int timingAdjust = (targetTiming - icurrentTiming) * 3;
                if (timingAdjust > 1000 || timingAdjust < -1000)
                {
                    portHandler.portWR("f");
                    handleDebug("Timing out of range! Could not sync!");

                    return;
                }
                if (targetTiming > icurrentTiming && timingAdjust <=3)
                    timingAdjust = 1;
                else if (targetTiming < icurrentTiming && timingAdjust >= -3)
                    timingAdjust = -1;

                handleDebug("timing: " + currentTiming +"/"+icurrentTiming + " target: " + targetTiming);

                if (targetTiming == icurrentTiming)
                {
                    break;

                }

                else
                {
                    portHandler.portWR("f");

                    if (timingAdjust > 0x7fff)
                        timingAdjust = 0x7fff;
                    if (timingAdjust < -0x7fff)
                        timingAdjust = -0x7fff;
                    short timingAdjust16 = Convert.ToInt16(timingAdjust);
                    portHandler.portWR("w" + timingAdjust16.ToString("X4"));
                    iterations++;
                    retries = 0;
                }
            }
            handleDebug("Sync succesful! Next enable mem access");
            int bruteCmds = 3;
            if (checkBoxBrute.Checked)
                bruteCmds = bruteCmd.Length;

            for (int i = 0; i< bruteCmds; i++)
                portHandler.portWR("i" + (bruteCmd[i].Length * 4).ToString("X2") + bruteCmd[i]);
            portHandler.portWR("f");
            handleDebug("Drilling..");
            System.Threading.Thread.Sleep(500);
            portHandler.portWR("o");
            
            string drillID = portHandler.portWR("i0430");
            if(drillID.Length>=8)
            {
                drillID = drillID.Substring(0, 8);
                portHandler.portWR("i28ff" + drillID);
                portHandler.portWR("i30800F0F020028");
                portHandler.portWR("f");
                handleDebug("Mem access successful!");
            }
            else
            {
                portHandler.portWR("f");
                handleDebug("Failed to get mem access!");
            }
  
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {

        }

        private static int Reverse( int b)
        {
            int a = 0;
            for (int i = 0; i < 16; i++)
                if ((b & (1 << i)) != 0)
                    a |= 1 << (15 - i);
            return a;
        }

        private void listBoxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonHaltChip_Click(object sender, EventArgs e)
        {
            //id 8a
            portHandler.portWR("r6200003d07250732073207250725072507320732072507320732073207250725073207250725072507250732073207250732073207250725072507250725072507250725072507250725072507250725072507250725072507250725072507250725072507250725072507250725072507250725072507250725072507250725072507250725072507250725072507250725072507250725072507250725072507250725072507250725072507320725073207250725072507320725073207250725073207ff00000000");
            //id 48
            portHandler.portWR("r2e00800d0F0d420d0F0d0F0d280d0F0d0F0d280d280d280d280d0F0d280d0F0d280d0F0d0F0d0F0d0F0d280d280d280d0F0d420d280d0F0d0F0d280d280d280d420d0F0d0F0d0F0d280d280d280d0F0d0F0d0F0d420d0F0d280d0F0d0F0d420d");
            //id 11
            portHandler.portWR("r2A00082e142e142e2a2e142e2a2e142e142e2a2e2a2e142e2a2e2a2e142e142e2a2e2a2e2a2e142e2a2e142e142e142e142e2a2e2a2e142e142e2a2e142e142e2a2e2a2e2a2e142e2a2e142e2a2e142e142e2a2e2a2e142e");
            //id33
            portHandler.portWR("r39057203350369036903690398033503690369039803350369036903690369036903690369039803350369036903980335036903690369039803350369036903980335036903980369033503690398036903350369036903690398033503690369039803350398033503980335039803350398033503");

        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            portHandler.portWR("o");
            String pages = "";
            String start = "";
            int selected = 0;
            string drillID = portHandler.portWR("i0430");
            if (drillID.Length >= 8)
            {
                drillID = drillID.Substring(0, 8);
                handleDebug("Mem access successful!");
            }
            else
            {
                handleDebug("Failed to get mem access!");
                return;
            }

            start = portHandler.portWR("i2800" + drillID);
            int readBlocks = (int)numericUpDownBlocks.Value;
            for (int segment = 0; segment <= readBlocks  / 0xf; segment++)
            {
                int blockCount = readBlocks - segment * 0xf;
                if (blockCount > 0xf)
                    blockCount = 0xf;

                for (int j = 0; j < blockCount; j++)
                {
                   // if (j > 0)
                    {
                        String blockConf = selectSegment(segment, j);
                        handleDebug(blockConf + Environment.NewLine);
                    }
                    for (int i = 0; i < 8; i++)
                    {
                        string readpage = ReadPage(i);
                        if (readpage.Length >= 8)
                            pages += readpage.Substring(0, 8);
                        else
                        {
                            handleDebug("ERROR! Cannot read all blocks!");
                            j = blockCount;
                            break;
                        }
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

            portHandler.portWR("f");
            HexUpdateRaiseEvent();
        }
        private string selectSegment(int segment, int block = 0)
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

        private String WritePage(int page, String content, int len, bool LSB = false)
        {

            int cmd = 0x80;
            cmd |= (page & 0x7);
            string writeCmd = cmd.ToString("X2") + content;
            byte crc = Crc8.ComputeChecksum(writeCmd);

            String pageReply = portHandler.portWR("i30" + writeCmd + crc.ToString("X2"));
            if (pageReply.Length == 0)
                return "ERROR";

            return "";
        }
        private int selectedType = 0x36;

        private void comboBoxChipType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBoxChipType.SelectedIndex)
            {
                case 0:
                case 1:
                case 2:
                    selectedType = 0x8C;
                    break;
                case 3:
                    selectedType = 0x35;
                    break;
                case 4:
                    selectedType = 0x36;
                    break;
                case 5:
                    selectedType = 0x37;
                    break;
                case 6:
                    selectedType = 0x47;
                    break;
                case 7:
                    selectedType = 0x39;
                    break;
                case 8:
                    selectedType = 0x46;
                    break;
                case 9:
                    selectedType = 0x48;
                    break;
                case 10:
                    selectedType = 0x4C;
                    break;
                case 11:
                    selectedType = 0x4D;
                    break;
                case 12:
                    selectedType = 0x80;
                    break;
                case 13:
                    selectedType = 0x64;
                    break;
                case 14:
                    selectedType = 0x8A;
                    break;
                case 15:
                    selectedType = 0x8c;
                    break;
                case 16:
                    selectedType = 0x8E;
                    break;

            }
        }

        private void buttonSetType_Click(object sender, EventArgs e)
        {
            portHandler.portWR("o");
            string drillID = portHandler.portWR("i0430");
            if (drillID.Length >= 8)
            {
                drillID = drillID.Substring(0, 8);
                portHandler.portWR("i28ff" + drillID);
                WritePage(5, "000000" + selectedType.ToString("X2"), 0);
                portHandler.portWR("f");
                handleDebug("SuperChip type activated successful!");
            }
            else
            {
                portHandler.portWR("f");
                handleDebug("Failed to set Type!");
                return;
            }
        }

        private void buttonWrite_Click(object sender, EventArgs e)
        {
            portHandler.portWR("o");

            String start = "";
            int currentSegment = 0;

            string drillID = portHandler.portWR("i0430");
            if (drillID.Length >= 8)
            {
                drillID = drillID.Substring(0, 8);
                handleDebug("Mem access successful!");
            }
            else
            {
                handleDebug("Failed to get mem access!");
                return;
            }

            start = portHandler.portWR("i2800" + drillID);

            for (int segment = 0; segment < 0x20; segment++)
            {

                int blockCount = 0x20 - segment * 0xf;
                if (blockCount > 0xf)
                    blockCount = 0xf;

                for (int blocks = 0; blocks < blockCount; blocks++)
                {
                    String pages = "";
                    int startWrite = 0;


                    for (int i = 0; i < 32; i++)
                    {
                        if (hexBox.ByteProvider.Length < (segment * 0xf + blocks) * 32 + i + 1)
                            break;
                        pages += hexBox.ByteProvider.ReadByte((segment * 0xf + blocks) * 32 + i).ToString("X2");
                    }

                    if (pages.Length == 0)
                        break;

                    selectSegment(segment, blocks);


                    for (int i = startWrite; i < 8; i++)
                    {
                        if (pages.Length < (i + 1) * 8)
                            break;
                        string nowWriting = pages.Substring(i * 8, 8);
                        if (segmentCache.Length ==0 || !segmentCache.Substring((segment * 0xf + blocks) * 64 + i * 8, 8).Equals(nowWriting))
                        {
                            WritePage(i, nowWriting, 32);
                        }
                    }
                }
            }

            portHandler.portWR("f");
        }
    }
}
