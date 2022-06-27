using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hitager
{
    public partial class BMW_Vehicle_Data : Form
    {
        private BmwHt2 bmwHt2;

        public BMW_Vehicle_Data(BmwHt2 bmwHt2)
        {
            this.bmwHt2 = bmwHt2;
            InitializeComponent();
        }

        private void Read_VehicleData_Button_Click(object sender, EventArgs e)
        {
            String vehicleDataBlocks = bmwHt2.readBlocks(1, 3);

            byte[] VinByte = bmwHt2.ConvertHexStringToByteArray(vehicleDataBlocks.Substring(72, 17 * 2));

            String VinString = System.Text.Encoding.ASCII.GetString(VinByte);

            byte[] OdoCountArray = new byte[4];
            Array.Copy(bmwHt2.ConvertHexStringToByteArray(vehicleDataBlocks.Substring(144, 6)),0,OdoCountArray,1,3);
            int OdoCount = BitConverter.ToInt32(OdoCountArray.Reverse().ToArray(),0);
           
            /* Display Odometer */
            this.textBox_OdoCount.Text = OdoCount.ToString() + " km";

            /*Display Mechanical Key Code */
            this.textBox_MechCode.Text = "HA000" + vehicleDataBlocks.Substring(35, 5);

            /* Display VIN */
            this.Textbox_VIN.Text = VinString;

        }
    }
}
