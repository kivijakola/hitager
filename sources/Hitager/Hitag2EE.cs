﻿/*
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

namespace Hitager
{
    public partial class Hitag2EE : UserControl
    {
        public Hitag2EE()
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

        private String WritePage(int page, String content, int len, bool LSB = false)
        {

            int cmd = 0x8200;
            if (LSB)
                cmd = 0xC000;
            cmd |= (page & 0x7) << 11 | (((~page) & 0x7) << 6);
            String pageReply = portHandler.portWR("i0a" + cmd.ToString("X4"));
            if (pageReply.Length == 0)
                return "ERROR";
            portHandler.portWR("i" + len.ToString("X2") + content);

            return "";
        }

        private String ReadPage(int page)
        {
            int cmd = 0xC000;
            cmd |= (page & 0x7) << 11 | (((~page) & 0x7) << 6);
            String pageReply = portHandler.portWR("i0a" + cmd.ToString("X4"));
            if (pageReply.Length == 0)
                return "ERROR";
            handleDebug(pageReply + Environment.NewLine);

            return pageReply;
        }

        private string selectBlock(int block)
        {
            String blockReply = portHandler.portWR("i0a26c0");//next
            if (blockReply.Length == 0)
                return "ERROR";

            return blockReply;
        }

        private void read_Click(object sender, EventArgs e)
        {
            read.Enabled = false;
            write.Enabled = false;
            portHandler.portWR("o");
            String pages = "";

            String xmaMode = portHandler.portWR("i0538");
            if (xmaMode.Length>=8)
                tbXmcfg.AppendText(xmaMode.Substring(0, 8));
            else
            {
                tbXmcfg.AppendText("ERROR");
                portHandler.portWR("f");
                read.Enabled = true;
                return;

            }
            xmaMode = portHandler.portWR("i0a2e80");
            int blockCount = (int)blocksToHandle.Value;

            for (int j = 0; j < blockCount; j++)
            {
                
                if (j > 0)
                {
                    if (selectBlock(j).Equals("ERROR"))
                    {
                        handleDebug("ERROR! Cannot read all blocks!");
                        break;
                    }
                }
                for (int i = 0; i < 8; i++)
                {
                    String received = "00000000";
                    if (!(j==0 && i>3))
                     received = ReadPage(i);
                    if (received.Length < 8)
                        received = received + "00000000";
                    pages += received.Substring(0,8);

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
                handleDebug("ERROR! Cannot parse bytes to array!");
                handleDebug(pages);
                read.Enabled = true;
                portHandler.portWR("f");
                return;
            }


            segmentCache = pages;
            if (blockCount > 0)
            {

            }
            HexUpdateRaiseEvent();
            write.Enabled = true;
            read.Enabled = true;
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

        private void write_Click(object sender, EventArgs e)
        {
            write.Enabled = false;
            portHandler.portWR("o");

            String xmaMode = portHandler.portWR("i0538");
            xmaMode = portHandler.portWR("i0a2e80");
            handleDebug(xmaMode + Environment.NewLine);

            int blockCount = (int)blocksToHandle.Value;
            for (int blocks = 0; blocks < blockCount; blocks++)
            {
                String pages = "";
                int startWrite = 0;

                for (int i = 0; i < 32; i++)
                {
                    if (hexBox.ByteProvider.Length < blocks * 32 + i + 1)
                        break;
                    pages += hexBox.ByteProvider.ReadByte(blocks * 32 + i).ToString("X2");
                }

                if (blocks > 0)
                {
                    selectBlock(blocks);
                }
                for (int i = startWrite; i < 8; i++)
                {
                    if (pages.Length < (i + 1) * 8)
                        break;
                    string nowWriting = pages.Substring(i * 8, 8);
                    if (!segmentCache.Substring(blocks * 64 + i * 8, 8).Equals(nowWriting))
                    {
                        WritePage(i, nowWriting, 32);
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
    }
}
