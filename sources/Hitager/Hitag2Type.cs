/*
 * (c) Janne Kivijakola
 * janne@kivijakola.fi
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hitager
{
    public partial class Hitag2Type : UserControl
    {
        [Browsable(true)]
        [Category("Action")]
        [Description("Hex value updated")]
        public event EventHandler hexUpdated;

        private void HexUpdateRaiseEvent(int  hex)
        {
            HexChangedEventArgs e = new HexChangedEventArgs();
            e.hex = (byte)hex;

            if (this.hexUpdated != null)
                hexUpdated(this, e);
        }

        public Hitag2Type()
        {
            InitializeComponent();
        }

        private int bitvalue = 0;

        private bool events = true;

        string ide = "";

        public void autoDetetectType(String ide)
        {
            if (ide.Length == 8)
            {
                this.ide = ide;
                if (autoDetect.Checked)
                {
                   if(!selectType(ide[6]))
                    {
                        autoDetect.Checked = false;
                    }
                }

            }
        }
        private bool selectType(char ide6)
        {
            switch (ide[6])
            {
                case '1':
                    radioButton1.Checked = true;
                    break;
                case '2':
                    radioButton6.Checked = true;
                    break;
                case '3':
                    radioButton7.Checked = true;
                    break;
                case '4':
                    radioButton3.Checked = true;
                    break;
                case '5':
                    radioButton4.Checked = true;
                    break;
                case '6':
                    radioButton2.Checked = true;
                    break;
                case '7':
                    radioButton8.Checked = true;
                    break;
                case '8':
                    radioButton9.Checked = true;
                    break;
                case '9':
                    radioButton5.Checked = true;
                    break;
                case 'B':
                    radioButton10.Checked = true;
                    break;
                default:
                    return false;
            }
            return true;
        }

        public void setValue(int value)
        {
            events = false;

            if ((value & 0x1) != 0)
                bit0.Checked = true;
            else
                bit0.Checked = false;
            if ((value & 0x2) != 0)
                bit1.Checked = true;
            else
                bit1.Checked = false;
            if ((value & 0x4) != 0)
                bit2.Checked = true;
            else
                bit2.Checked = false;
            if ((value & 0x8) != 0)
                bit3.Checked = true;
            else
                bit3.Checked = false;
            if ((value & 0x10) != 0)
                bit4.Checked = true;
            else
                bit4.Checked = false;
            if ((value & 0x20) != 0)
                bit5.Checked = true;
            else
                bit5.Checked = false;
            if ((value & 0x40) != 0)
                bit6.Checked = true;
            else
                bit6.Checked = false;
            if ((value & 0x80) != 0)
                bit7.Checked = true;
            else
                bit7.Checked = false;

            bitvalue = value;
            bits.Text = "0x" + value.ToString("X2");
            events = true;

        }

        private void bit0_CheckedChanged(object sender, EventArgs e)
        {
            if (events)
            {
                if (bit0.Checked)
                    bitvalue |= 0x1;
                else
                    bitvalue &= 0xfe;
                bits.Text = "0x" + bitvalue.ToString("X2");
                HexUpdateRaiseEvent(bitvalue);
            }
        }

        private void bit1_CheckedChanged(object sender, EventArgs e)
        {
            if (events)
            {
                if (bit1.Checked)
                    bitvalue |= 2;
                else
                    bitvalue &= 0xfd;
                bits.Text = "0x" + bitvalue.ToString("X2");
                HexUpdateRaiseEvent(bitvalue);
            }
        }

        private void bit2_CheckedChanged(object sender, EventArgs e)
        {
            if (events)
            {
                if (bit2.Checked)
                    bitvalue |= 0x4;
                else
                    bitvalue &= 0xfb;
                bits.Text = "0x" + bitvalue.ToString("X2");
                HexUpdateRaiseEvent(bitvalue);
            }
        }

        private void bit3_CheckedChanged(object sender, EventArgs e)
        {
            if (events)
            {
                if (bit3.Checked)
                    bitvalue |= 0x8;
                else
                    bitvalue &= 0xf7;
                bits.Text = "0x" + bitvalue.ToString("X2");
                HexUpdateRaiseEvent(bitvalue);
            }
        }

        private void bit4_CheckedChanged(object sender, EventArgs e)
        {
            if (events)
            {
                if (bit4.Checked)
                    bitvalue |= 0x10;
                else
                    bitvalue &= 0xef;
                bits.Text = "0x" + bitvalue.ToString("X2");
                HexUpdateRaiseEvent(bitvalue);
            }
        }

        private void bit5_CheckedChanged(object sender, EventArgs e)
        {
            if (events)
            {
                if (bit5.Checked)
                    bitvalue |= 0x20;
                else
                    bitvalue &= 0xdf;
                bits.Text = "0x" + bitvalue.ToString("X2");
                HexUpdateRaiseEvent(bitvalue);
            }
        }

        private void bit6_CheckedChanged(object sender, EventArgs e)
        {
            if (events)
            {
                if (bit6.Checked)
                    bitvalue |= 0x40;
                else
                    bitvalue &= 0xbf;
                bits.Text = "0x" + bitvalue.ToString("X2");
                HexUpdateRaiseEvent(bitvalue);
            }
        }

        private void bit7_CheckedChanged(object sender, EventArgs e)
        {
            if (events)
            {
                if (bit7.Checked)
                    bitvalue |= 0x80;
                else
                    bitvalue &= 0x7f;
                bits.Text = "0x" + bitvalue.ToString("X2");
                HexUpdateRaiseEvent(bitvalue);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked || radioButton2.Checked)
            {
                bit0.Text = "Data Coding (0=MC,1=BF)";
                bit1.Text = "MS0, Read Only Mode Select";
                bit2.Text = "MS1, Read Only Mode Select";
                bit3.Text = "ENC, Enable Crypto Mode";
                bit4.Text = "PWP0, Page Write Protect 0 (OTP)";
                bit5.Text = "PWP1, Page Write Protect 1 (OTP)";
                bit6.Text = "PG3L, Page3 Lock (OTP)";
                bit7.Text = "SKL, Secrect Key Lock (OTP)";
            }
            else
            {
                bit0.Text = "Data Coding (0=MC,1=BF)";
                bit1.Text = "MS0, Read Only Mode Select";
                bit2.Text = "WOFDI, Wakeup on Field Detect Init";
                bit3.Text = "BSEL, Bank Select (0=Remote, 1=User)";
                bit4.Text = "PWUP, Protect Write User Pages";
                bit5.Text = "RCFL Remote Configuration Lock (OTP)";
                bit6.Text = "PG3L, Page3 Lock (OTP)";
                bit7.Text = "ISKL, Immo Secrect Key Lock (OTP)";
            }
        }

        private void autoDetect_CheckedChanged(object sender, EventArgs e)
        {
            if(autoDetect.Checked)
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
                radioButton4.Enabled = false;
                radioButton5.Enabled = false;
                radioButton6.Enabled = false;
                radioButton7.Enabled = false;
                radioButton8.Enabled = false;
                radioButton9.Enabled = false;
                radioButton10.Enabled = false;
                if (ide.Length == 8)
                    selectType(ide[6]);
            }
            else
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
                radioButton4.Enabled = true;
                radioButton5.Enabled = true;
                radioButton6.Enabled = true;
                radioButton7.Enabled = true;
                radioButton8.Enabled = true;
                radioButton9.Enabled = true;
                radioButton10.Enabled = true;
            }
        }
        
    }
}