/*
 * (c) Janne Kivijakola
 * janne@kivijakola.fi
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hitag_App
{
    class CryptoInterface
    {

        byte[,] Sectors = {
        { 0x52, 0x4D, 0x74, 0x79}, 
        { 0xa4, 0xc6, 0x58, 0xe1},
        { 0x00, 0x00, 0xf2, 0x8b}, 
        { 0x08, 0xcf, 0x33, 0x25},
        { 0x46, 0x5f, 0x4f, 0x4b},
        { 0x55, 0x55, 0x55, 0x55},
        { 0xaa, 0xaa, 0xaa, 0xaa},
        { 0x55, 0x55, 0x55, 0x55},
        { 0x00, 0x00, 0x00, 0x00}, 
        { 0x00, 0x00, 0x00, 0x00}, 
        { 0x00, 0x00, 0x00, 0x00}, 
        { 0x00, 0x00, 0x00, 0x00}
            }; 

        Hitag_App.Crypto myCrypto = new Hitag_App.Crypto();
        Hitag_App.Hitag2_tag tag = new Hitag_App.Hitag2_tag();

        byte[] cs = { 0x12, 0x34, 0x56, 0x78 };

        public void Reset()
        { 
            tag.Sectors = Sectors;
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(cs);

            myCrypto.hitag2_cipher_reset(ref tag, ref cs);
        }

        public string Crypt(byte [] input, int bits)
        {
            byte[] output = new byte[8];
            input.CopyTo(output,0);

            if (input.Length < (bits + 7) / 8)
                return "ERROR";

            String ret = "";

            if (cryptomode == true)
            {
                myCrypto.hitag2_cipher_transcrypt(ref tag.Cs, ref output, (ushort)(bits / 8), (ushort)(bits % 8));
            }

            for(int i = 0; i<(bits+7)/8; i++)
            {
                ret += output[i].ToString("X2");
            }


            return ret; ;

        }
        public void setISK(string ISK)
        {
            if (ISK.Length != 12)
                return;
            byte[] bisk = StringToByteArray(ISK);
            if(bisk.Length==6)
            {
                for (int i = 0; i < 4; i++)
                    Sectors[1, i] = bisk[i];
                for (int i = 2; i < 4; i++)
                    Sectors[2, i] = bisk[2+i];
            }
        }

        public string CryptString (string inputs, int bits)
        {

            byte[] output = StringToByteArray(inputs);

            String ret = "";

            if (inputs.Length < (bits + 3) / 4)
                return "ERROR";

            if (cryptomode == false)
            {
                return inputs;
            }

            myCrypto.hitag2_cipher_transcrypt(ref tag.Cs, ref output, (ushort)(bits / 8), (ushort)(bits % 8));

            foreach ( byte x in output)
            {
                ret += x.ToString("X2");
            }

            return ret;

        }

        public string CryptString(string inputs)
        {
            if (cryptomode == false)
            {
                return inputs;
            }

                int bits = inputs.Length * 4;

            return CryptString(inputs, bits);

        }

        public string GetSignature(String CardID)
        {
            if (CardID.Length == 0)
                return "ERROR";
            if (cryptomode == false)
            {
                string key = "";
                for (int i = 0; i < 4; i++)
                    key += Sectors[1, i].ToString("X2");
                return key;
            }
            byte[] bCardID;
            byte[] cipher = new byte[8];

            String ret = "";

            bCardID = StringToByteArray(CardID);
            if (CardID.Length < 8)
                return "ERROR";
            for(int i = 0; i < 4; i++)
                Sectors[0,i] = bCardID[i];

            Reset();

            myCrypto.hitag2_cipher_authenticate(ref tag.Cs, ref cipher);

            ret += cs[0].ToString("X2") + cs[1].ToString("X2") + cs[2].ToString("X2") + cs[3].ToString("X2")
                + cipher[0].ToString("X2") + cipher[1].ToString("X2") + cipher[2].ToString("X2") + cipher[3].ToString("X2");

            return ret;

        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
   
        }

        private bool cryptomode = true;
        public void setCryptomode (bool crypto)
        {
            cryptomode = crypto;
        }
    }
}
