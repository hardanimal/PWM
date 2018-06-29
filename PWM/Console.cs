using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using igfxDHLib;
using System.Windows.Forms;

namespace PWM
{
    class Console
    {
        [STAThread]
        static void Main(string[] args)
        {
            /// PWM frequency setup in Hz
            int v = 21000;
            /// IMPORTANT
            /// 
            byte[] baseData;
            DataHandler dh;

            dh = new igfxDHLib.DataHandler();
            uint error = 0;
            baseData = new byte[8];
            dh.GetDataFromDriver(ESCAPEDATATYPE_ENUM.GET_SET_PWM_FREQUENCY, 4, ref error, ref baseData[0]);
            if (error != 0)
                MessageBox.Show(string.Format("failed to get PWM: {0:X}", error));

            byte[] b = BitConverter.GetBytes(v);
            Array.Copy(b, 0, baseData, 4, 4);
            dh.SendDataToDriver(ESCAPEDATATYPE_ENUM.GET_SET_PWM_FREQUENCY, 4, ref error, ref baseData[0]);
            if (error != 0)
                MessageBox.Show(string.Format("failed set get PWM: {0:X}", error));
        }
    }
}
