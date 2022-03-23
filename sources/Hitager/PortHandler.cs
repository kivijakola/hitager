using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hitager
{
    public class PortHandler
    {
        static SerialPort _serialPort;
        private string portName = "";
        bool initDone = false;

        public void setPort(string port)
        {
            portName = port;
        }

        private bool portOpen()
        {
            if (_serialPort == null)
                _serialPort = new SerialPort();
            if (!_serialPort.IsOpen)
            {
                _serialPort.BaudRate = 115200;
                _serialPort.PortName = portName;
                try
                {
                    _serialPort.Open();
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                _serialPort.NewLine = "\n";
                _serialPort.ReadTimeout = 2000;
                byte[] tmpBuffer = new byte[1000];
                if(!initDone)
                {
                    handleDebug("Tag reader communication init...");


                    //System.Threading.Thread.Sleep(200);
                    _serialPort.DiscardInBuffer();
                    _serialPort.DiscardOutBuffer();
                    
                    _serialPort.Write("f");
                    System.Threading.Thread.Sleep(2000);
                    for (int i = 0; i < 20; i++)
                    {
                        string indata = _serialPort.ReadExisting();
                        //System.Threading.Thread.Sleep(50);
                    }
                    _serialPort.Write("f");
                    System.Threading.Thread.Sleep(500);

                    string indata3 = _serialPort.ReadExisting();

                    //handleDebug(indata3);
                    initDone = true;
                    if (portWR("v").Contains("TIMEOUT"))
                    {
                        initDone = false;
                        return false;
                    }
                    initDone = true;
                    handleDebug("Done");

                }




                
            }
            return true;

        }

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
        private void portClose()
        {
            _serialPort.Close();

        }

        public string portWR(String cmd)
        {
            handleDebug("Sending: " + cmd);
           String data = "";
            if (!portOpen())
                return "ERROR";
            for (int i = 0; i < 1; i++)
            {
                String received = "";
                _serialPort.Write(cmd);
                while (!received.Contains("EOF"))
                {
                    

                    try
                    {
                        received = _serialPort.ReadLine();
                    }
                    catch (Exception)
                    {
                        handleDebug("Please reset reader!");
                        portClose();
                        return ("TIMEOUT");
                    }
                    handleDebug(received);
                    if (received.Contains("RESP") && (!received.Contains("ERROR")) && (!received.Contains("NORESP")))
                    {
                        data = received.Substring(5);
                        i = 5;

                    }
                    else if (received.Contains("RFON"))
                    {
                        System.Threading.Thread.Sleep(500);
                        return "OK";
                    }
                    else if(received.Contains("RFOFF"))
                    {
                        portClose();
                        return "OK";

                    }
                }
            }
            //System.Threading.Thread.Sleep(100);

            return data;

        }
    }
}
