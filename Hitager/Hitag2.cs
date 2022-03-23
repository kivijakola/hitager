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


namespace Hitager
{

    public partial class Hitag2 : UserControl
    {

        static Hitag_App.CryptoInterface cryptoInterface = new Hitag_App.CryptoInterface();

        public Hitag2()
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

        private void FactoryIsk_Click(object sender, EventArgs e)
        {
            TbISK.Text = "4D494B524F4E";
        }

        private bool pcf7937 = false;

        private void ReadButton_Click(object sender, EventArgs e)
        {
            ReadButton.Enabled = false;
            P0.Text = "";
            P1.Text = "";
            P2.Text = "";
            P3.Text = "";

            

            if (!handleISK())
            {
                ReadButton.Enabled = true;
                return;
            }
            else
            {
                portHandler.portWR("o");

                String cardID = portHandler.portWR("i05C0");
                if (cardID.Equals("TIMEOUT"))
                {
                    handleDebug("TIMEOUT");

                }
                else if (cardID.Length<8)
                {
                    handleDebug("ERROR ID");
                    handleDebug("Please retry reading!");
                }
                else
                {
                    int startIndex = 0;
                    if (cardID.Length == 10)
                    {
                        long icardID = 0;
                        try
                        {
                            icardID = long.Parse(cardID, System.Globalization.NumberStyles.HexNumber);
                            if((icardID & 0x3f) == 0)
                            {
                                icardID = (icardID >> 6)  &0xffffffff;

                                cardID = icardID.ToString("X8");
                                pcf7937 = true;
                            }
                            else
                                pcf7937 = false;

                        }
                        catch (Exception exp)
                        {
                            portHandler.portWR("f");
                            ReadButton.Enabled = true;
                            handleDebug("ERROR ID");

                            return;
                        }
                        //startIndex = 2;
                    }
                    cardID = cardID.Substring(startIndex, 8);
                    P0.Text = cardID;
                    hitag2Type1.autoDetetectType(cardID.Substring(0, 8));
                    String key = cryptoInterface.GetSignature(cardID);
                    handleDebug(key);
                    String page3c = portHandler.portWR("i"+(key.Length*4).ToString("X2") + key);
                    handleDebug(page3c);
                    if (page3c.Equals("TIMEOUT"))
                    {
                        handleDebug("TIMEOUT");
                    }
                    else
                    {
                        if(pcf7937)
                            page3c = parseExtra(page3c);
                        String page3 = cryptoInterface.CryptString(page3c, 32);
                        if (page3.Equals("ERROR"))
                        {
                            handleDebug("CRYPT ERROR");
                            P3.Text = "Wrong key";
                            P4.Text = "";
                            P5.Text = "";
                            P6.Text = "";
                            P7.Text = "";
                            P4_2.Text = "";
                            P5_2.Text = "";
                            P6_2.Text = "";
                            P7_2.Text = "";
                        }
                        else
                        {
                            page3 = page3.Substring(0, 8);
                            handleDebug("P3:" + page3);

                            

                            if (page3c.Equals("") || page3c.Equals("0AAAAAAA"))
                            {
                                P3.Text = "Wrong key";

                            }
                            else
                            {
                                P3.Text = ReadPage(3);
                                if (!ISKL)
                                {
                                    P1.Text = ReadPage(1);
                                    P2.Text = ReadPage(2);
                                }
                                else
                                {
                                    P1.Text = "LOCKED";
                                    P2.Text = "LOCKED";
                                }
                                
                                if (pageSelect.Checked | !modeCrypto.Checked)
                                {
                                    P4_2.Text = ReadPage(4);
                                    P5_2.Text = ReadPage(5);
                                    P6_2.Text = ReadPage(6);
                                    P7_2.Text = ReadPage(7);
                                }
                                else
                                {
                                    P4.Text = ReadPage(4);
                                    P5.Text = ReadPage(5);
                                    P6.Text = ReadPage(6);
                                    P7.Text = ReadPage(7);
                                    
                                }
                                selectPage(pageSelect.Checked | !modeCrypto.Checked);
                            }
                        }
                    }
                }

                portHandler.portWR("f");
                ReadButton.Enabled = true;

                DynamicByteProvider dynamicByteProvider;
                try
                {
                    String pages = "";
                    if (P0.Text.Length == 8)
                        pages += P0.Text;
                    else
                        pages += "00000000";
                    if (P1.Text.Length == 8)
                        pages += P1.Text;
                    else
                        pages += "00000000";
                    if (P2.Text.Length == 8)
                        pages += P2.Text;
                    else
                        pages += "00000000";
                    if (P3.Text.Length == 8)
                        pages += P3.Text;
                    else
                        pages += "00000000";
                    if (P4.Text.Length == 8)
                        pages += P4.Text;
                    else
                        pages += "00000000";
                    if (P5.Text.Length == 8)
                        pages += P5.Text;
                    else
                        pages += "00000000";
                    if (P6.Text.Length == 8)
                        pages += P6.Text;
                    else
                        pages += "00000000";
                    if (P7.Text.Length == 8)
                        pages += P7.Text;
                    else
                        pages += "00000000";
                    if (P4_2.Text.Length == 8)
                        pages += P4_2.Text;
                    else
                        pages += "00000000";
                    if (P5_2.Text.Length == 8)
                        pages += P5_2.Text;
                    else
                        pages += "00000000";
                    if (P6_2.Text.Length == 8)
                        pages += P6_2.Text;
                    else
                        pages += "00000000";
                    if (P7_2.Text.Length == 8)
                        pages += P7_2.Text;
                    else
                        pages += "00000000";

                    dynamicByteProvider = new DynamicByteProvider(ConvertHexStringToByteArray(pages));
                    hexBox.ByteProvider = dynamicByteProvider;
                    HexUpdateRaiseEvent();
                }
                catch (Exception x)
                {
                    handleDebug("ERROR! Cannot parse bytes to array!");
                }

            }
        }

        private string  parseExtra(string input)
        {
            long iinput = 0;
            try
            {
                iinput = long.Parse(input, System.Globalization.NumberStyles.HexNumber);
                if ((iinput & 0x3f) == 0)
                {
                    iinput = (iinput >> 6) & 0xffffffff;

                    return iinput.ToString("X8");
                }

            }
            catch (Exception exp)
            {
            }
            return input;
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
        private void selectPage(bool bsel)
        {

                P4.Enabled = !bsel;
                P5.Enabled = !bsel;
                P6.Enabled = !bsel;
                P7.Enabled = !bsel;
                P4_2.Enabled = bsel;
                P5_2.Enabled = bsel;
                P6_2.Enabled = bsel;
                P7_2.Enabled = bsel;

        }
        private bool handleISK()
        {
            String sisk = TbISK.Text;
            if (sisk.Length != 12)
            {
                handleDebug("Incorrect ISK");
                return false;
            }
            cryptoInterface.setISK(sisk); ;
            return true;
        }
        private String ReadPage(int page)
        {
            int cmd = 0xC000;
            cmd |= (page & 0x7) << 11 | (((~page) & 0x7) << 6);
            byte[] pageread = { (byte)(0xff & (cmd >> 8)), (byte)(0xff & cmd) };
            String pagereadc = cryptoInterface.Crypt(pageread, 10);
            String pagec = portHandler.portWR("i0a" + pagereadc);
            if (pagec.Length == 0)
                return "ERROR";
            handleDebug(pagec );
            if (pagec.Length < 8)
                return "ERROR";
            if (pcf7937)
                pagec = parseExtra(pagec);
            String pageText = cryptoInterface.CryptString(pagec, 32);
            pageText = pageText.Substring(0, 8);
            handleDebug("P" + page + ": " + pageText);
            return pageText;
        }

        private String WritePage(int page, String content)
        {

            handleISK();
            if (content.Length != 8)
            {
                handleDebug("INCORRECT CONTENT");
                return "ERROR";
            }

            portHandler.portWR("o");

            String cardID = portHandler.portWR("i05C0");
            if (cardID.Equals("TIMEOUT"))
            {
                handleDebug("TIMEOUT");
                portHandler.portWR("f");
                return "ERROR";
            }
            if (cardID.Equals(""))
            {
                handleDebug("ERROR ID");
                portHandler.portWR("f");
                return "ERROR";
            }

            String key = cryptoInterface.GetSignature(cardID);
            handleDebug(key);
            String page3c = portHandler.portWR("i" + (key.Length * 4).ToString("X2") + key);
            handleDebug(page3c);
            if (page3c.Equals("TIMEOUT"))
            {
                portHandler.portWR("f");
                return "ERROR";

            }
            String page3 = cryptoInterface.CryptString(page3c, 32);
            handleDebug("P3:" + page3);

            int cmd = 0x8200;
            cmd |= (page & 0x7) << 11 | (((~page) & 0x7) << 6);
            byte[] pagewrite = { (byte)(0xff & (cmd >> 8)), (byte)(0xff & cmd) };
            String pagewriteS = pagewrite[0].ToString("X2") + pagewrite[1].ToString("X2");
            String pagewritec = cryptoInterface.Crypt(pagewrite, 10);
            String pagewreplyc = portHandler.portWR("i0a" + pagewritec);
            if (pagewreplyc.Length == 0)
            {
                portHandler.portWR("f");
                return "ERROR";
            }
            handleDebug(pagewreplyc);
            String pagewreply = cryptoInterface.CryptString(pagewreplyc + "00", 10);
            if (pagewreply.StartsWith(pagewriteS.Substring(0, 2)))
            {
                String contentc = cryptoInterface.CryptString(content);
                pagewreplyc = portHandler.portWR("i20" + contentc);

                portHandler.portWR("f");

                return "OK";
            }
            else
            {
                portHandler.portWR("f");
                return "ERROR";

            }
        }

        private void Bw0_Click(object sender, EventArgs e)
        {
            WritePage(0, P0.Text);
        }

        private void Bw1_Click(object sender, EventArgs e)
        {
            WritePage(1, P1.Text);
        }

        private void Bw2_Click(object sender, EventArgs e)
        {
            WritePage(2, P2.Text);
        }

        private void Bw3_Click(object sender, EventArgs e)
        {
            WritePage(3, P3.Text);
            selectPage(pageSelect.Checked);
        }

        private void Bw4_Click(object sender, EventArgs e)
        {
            if(P4.Enabled)
                WritePage(4, P4.Text);
            else if(P4_2.Enabled)
                WritePage(4, P4_2.Text);
        }

        private void Bw5_Click(object sender, EventArgs e)
        {
            if (P5.Enabled)
                WritePage(5, P5.Text);
            else if (P5_2.Enabled)
                WritePage(5, P5_2.Text);
        }

        private void Bw6_Click(object sender, EventArgs e)
        {
            if (P6.Enabled)
                WritePage(6, P6.Text);
            else if (P6_2.Enabled)
                WritePage(6, P6_2.Text);
        }

        private void Bw7_Click(object sender, EventArgs e)
        {
            if (P7.Enabled)
                WritePage(7, P7.Text);
            else if (P7_2.Enabled)
                WritePage(7, P7_2.Text);
        }

        private void TbISK_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void P0_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !e.KeyChar.IsHex())
            {

                e.Handled = true;
            }
            else if(!char.IsControl(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        private void cardIskToFactory_Click(object sender, EventArgs e)
        {
            string newIsk = tbNewIsk.Text;
            string oldIsk = TbISK.Text;
            string oldIskP1 = P1.Text;
            string oldIskP2 = P2.Text;
            if (oldIsk.Length != 12 || newIsk.Length != 12 || oldIskP1.Length!=8 || oldIskP2.Length!=8 || !oldIsk.StartsWith(oldIskP1) || !oldIsk.Substring(8,4).Equals(oldIskP2.Substring(4,4)))
            {
                handleDebug("Incorrect ISK settings");
                return;
            }
            string ret = WritePage(1, newIsk.Substring(0,8));
            if(ret.Equals("ERROR"))
            {
                handleDebug("Error writing P1");
                return;
            }
            TbISK.Text = newIsk.Substring(0, 8) + oldIsk.Substring(8, 4);
            ret = WritePage(2, oldIskP2.Substring(0,4) + newIsk.Substring(8, 4));
            if (ret.Equals("ERROR"))
            {
                handleDebug("Error writing P2");
                return;
            }
            TbISK.Text = newIsk;

        }

        private void FactoryIskSet_Click(object sender, EventArgs e)
        {
            tbNewIsk.Text = "4D494B524F4E";
        }
        private bool ISKL = false;

        private void P3_TextChanged(object sender, EventArgs e)
        {
            String P3val =P3.Text;
            if (P3val.Length == 8)
            {
                byte[] bytes = Hitag_App.CryptoInterface.StringToByteArray(P3val);
                
                if (((int)(bytes[0]) & 0x8) != 0)
                {
                    pageSelect.Checked = true;
                }
                else
                {
                    pageSelect.Checked = false;
                }
                if (((int)(bytes[0]) & 0x80) != 0)
                {
                    ISKL = true;
                }
                else
                {
                    ISKL = false;
                }


                hitag2Type1.setValue(bytes[0]);
                hitag2Type1.Enabled = true;
            }
            else
            {
                //pageSelect.Enabled = false;
                hitag2Type1.Enabled = false;
            }
        }

        private void pageSelect_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void P4_TextChanged(object sender, EventArgs e)
        {

        }

        public void setFields(String fields)
        {
            P0.Text = fields.Substring(0, 8);
            P1.Text = fields.Substring(8, 8);
            P2.Text = fields.Substring(16, 8);
            P3.Text = fields.Substring(24, 8);
            P4.Text = fields.Substring(32, 8);
            P5.Text = fields.Substring(40, 8);
            P6.Text = fields.Substring(48, 8);
            P7.Text = fields.Substring(56, 8);

            P4_2.Text = fields.Substring(64, 8);
            P5_2.Text = fields.Substring(72, 8);
            P6_2.Text = fields.Substring(80, 8);
            P7_2.Text = fields.Substring(88, 8);
        }

        private void modeCrypto_CheckedChanged(object sender, EventArgs e)
        {
            bool crypto = true;
            if(modePassword.Checked)
            {
                crypto = false;
            }
            cryptoInterface.setCryptomode(crypto);
        }

        private void hitag2Type1_hexUpdated(object sender, EventArgs e)
        {
            HexChangedEventArgs hexe =e as HexChangedEventArgs;
            String P3val = P3.Text;
            if (P3val.Length == 8)
            {
                byte[] bytes = Hitag_App.CryptoInterface.StringToByteArray(P3val);

                bytes[0] = hexe.hex;
                P3.Text = bytes[0].ToString("X2") + bytes[1].ToString("X2") + bytes[2].ToString("X2") + bytes[3].ToString("X2");
            }
        }
    }
}

public static class Extensions
{
    public static bool IsHex(this char c)
    {
        return (c >= '0' && c <= '9') ||
                 (c >= 'a' && c <= 'f') ||
                 (c >= 'A' && c <= 'F');
    }
}