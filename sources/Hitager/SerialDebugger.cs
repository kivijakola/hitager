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
    public partial class SerialDebugger : UserControl
    {
        private FormHexEditor FormHexEditor;

        public SerialDebugger(FormHexEditor FormHexEditor)
        {
            this.FormHexEditor = FormHexEditor;
            InitializeComponent();
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

        //TextBox debugTextBox;
        private void handleDebug(String text)
        {
            DebugUpdateRaiseEvent(text + Environment.NewLine);
        }
        /*
        public void setDebug(ref TextBox textbox)
        {
            debugTextBox = textbox;
        }
        */

        private PortHandler portHandler;
        public void SetPortHandler(ref PortHandler handler)
        {
            portHandler = handler;
        }

        private void sendCommand(string command)
        {
            string binary = command;
            int left = command.Length % 4;
            if (left != 0)
            {
                for (int i = 0; i < 4 - left; i++)
                    binary += "0";
            }
            string hex = Convert.ToUInt64(binary, 2).ToString("X");
            //if (hex.Length % 2 != 0)
            //    hex += "0";
            while(hex.Length < (command.Length+3)/4)
                hex = "0"+ hex;
            if (hex.Length % 2 != 0)
                hex += "0";
            string outcommand = "i" + command.Length.ToString("X2") + hex;
            portHandler.portWR(outcommand);
        }

        private string invert(string input)
        {
            string output = "";
            foreach (char c in input)
            {
                if (c == '1')
                    output += "0";
                else
                    output += "1";

            }
            return output;
        }



        private void bits1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && e.KeyChar!='1' && e.KeyChar != '0')
            {

                e.Handled = true;
            }
  
        }


        private void rfOn_Click(object sender, EventArgs e)
        {
            portHandler.portWR("o");
        }

        private void rfOff_Click(object sender, EventArgs e)
        {
            portHandler.portWR("f");
        }

        private void clear_Click(object sender, EventArgs e)
        {
            //debugTextBox.Clear();
        }

        private void addInvert_Click(object sender, EventArgs e)
        {
            bits1.AppendText(invert(bits1.Text));
        }

        private void addInvert2_Click(object sender, EventArgs e)
        {
            bits2.AppendText(invert(bits2.Text));
        }

        private void addInvert3_Click(object sender, EventArgs e)
        {
            bits3.AppendText(invert(bits3.Text));
        }

        private void addInvert4_Click(object sender, EventArgs e)
        {
            bits4.AppendText(invert(bits4.Text));
        }

        private void addInvert5_Click(object sender, EventArgs e)
        {
            bits5.AppendText(invert(bits5.Text));
        }

        private void addInvert6_Click(object sender, EventArgs e)
        {
            bits6.AppendText(invert(bits6.Text));
        }

        private void addInvert7_Click(object sender, EventArgs e)
        {
            bits7.AppendText(invert(bits7.Text));
        }

        private void addInvert8_Click(object sender, EventArgs e)
        {
            bits8.AppendText(invert(bits8.Text));
        }


        private void send1_Click(object sender, EventArgs e)
        {
            sendCommand(bits1.Text);
        }

        private void send2_Click(object sender, EventArgs e)
        {
            sendCommand(bits2.Text);
        }

        private void send3_Click(object sender, EventArgs e)
        {
            sendCommand(bits3.Text);
        }

        private void send4_Click(object sender, EventArgs e)
        {
            sendCommand(bits4.Text);
        }

        private void send5_Click(object sender, EventArgs e)
        {
            sendCommand(bits5.Text);
        }

        private void send6_Click(object sender, EventArgs e)
        {
            sendCommand(bits6.Text);
        }

        private void send7_Click(object sender, EventArgs e)
        {
            sendCommand(bits7.Text);
        }

        private void send8_Click(object sender, EventArgs e)
        {
            sendCommand(bits8.Text);
        }

        private void rawSend_Click(object sender, EventArgs e)
        {
            portHandler.portWR(tbRawData.Text);
        }

        private void debugOnBtn_Click(object sender, EventArgs e)
        {
            portHandler.portWR("d01");
        }

        private void debugOffBtn_Click(object sender, EventArgs e)
        {
            portHandler.portWR("d00");
        }

        private void decodeManBtn_Click(object sender, EventArgs e)
        {
            portHandler.portWR("b00");
        }

        private void decodeBipBtn_Click(object sender, EventArgs e)
        {
            portHandler.portWR("b01");
        }


        private void pulse0Num_ValueChanged(object sender, EventArgs e)
        {
            portHandler.portWR("z" + ((int)pulse0Num.Value & 0xff).ToString("X2"));
        }

        private void pulse1Num_ValueChanged(object sender, EventArgs e)
        {
            portHandler.portWR("x" + ((int)pulse1Num.Value & 0xff).ToString("X2"));
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void hysteresisCB_CheckedChanged(object sender, EventArgs e)
        {
            if (hysteresisCB.Checked)
            {
                portHandler.portWR("h01");
            }
            else
            {
                portHandler.portWR("h00");
            }
        }

        private void button_GainAutoAdjust_Click(object sender, EventArgs e)
        {
            /* Auto-adjust ABIC gain at first key access to optimize reading results */
            string response;
            int[] nrAnswersPerGain = new int[3];

            for (int gain = 0; gain < 3; gain++)
            {
                string[] responses = new string[10];

                portHandler.portWR("g0" + ((int)gain & 0x03));

                /* Get result of card ID read 10 times */
                for (int i = 0; i < 10; i++)
                {
                    portHandler.portWR("o");
                    response = portHandler.portWR("i05C0");
                    if (!responses.Contains(response))
                    {
                        int test = Array.FindIndex(responses, j => j == null);
                        Array.Copy(new string[] { response}, 0, responses, test, 1);
                    }
                    portHandler.portWR("f");
                }

                nrAnswersPerGain[gain] = Array.FindIndex(responses, j => j == null);
            }

            /* Set AbicGain to value with the least number of different responses */
            int idxSmallest = Array.IndexOf(nrAnswersPerGain, nrAnswersPerGain.Min());
            portHandler.portWR("g0" + (idxSmallest & 0x03));
            FormHexEditor.AbicGain = idxSmallest;

            handleDebug("Best gain value is " + idxSmallest + " (" + nrAnswersPerGain[0] + " " + nrAnswersPerGain[1] + " " +
                nrAnswersPerGain[2] + ")");
        }
    }
}
