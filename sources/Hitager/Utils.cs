using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hitager
{
    class Utils
    {
    }

    public class DebugmessageEventArgs : EventArgs
    {
        public string Message { get; set; }
    }

    public class HexChangedEventArgs : EventArgs
    {
        public byte hex { get; set; }
    }

    public static class Crc8
    {
        static byte[] table = new byte[256];
        // x8 + x7 + x6 + x4 + x2 + 1
        const byte poly = 0x07;

        public static byte ComputeChecksum(params byte[] bytes)
        {
            byte crc = 0;
            if (bytes != null && bytes.Length > 0)
            {
                foreach (byte b in bytes)
                {
                    crc = table[crc ^ b];
                }
            }
            return crc;
        }
        public static byte ComputeChecksum(string bytes)
        {
            byte[] arrayBytes = StringToByteArray(bytes);
            byte crc = 0;
            crc = ComputeChecksum(arrayBytes);

            return crc;
        }

        static Crc8()
        {
            for (int i = 0; i < 256; ++i)
            {
                int temp = i;
                for (int j = 0; j < 8; ++j)
                {
                    if ((temp & 0x80) != 0)
                    {
                        temp = (temp << 1) ^ poly;
                    }
                    else
                    {
                        temp <<= 1;
                    }
                }
                table[i] = (byte)temp;
            }
        }
        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();


        }
    }


}
