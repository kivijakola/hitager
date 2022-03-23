using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hitag_App
{
    public class Hitag2_tag
    {
        public uint uid;
        public enum State
        {
            TAG_STATE_RESET = 0x01,       
            TAG_STATE_ACTIVATING = 0x02,      
            TAG_STATE_ACTIVATED = 0x03,      
            TAG_STATE_WRITING = 0x04,    
        };
        public uint Active_sector;
        public uint Crypto_active;
        public ulong Cs;
        public byte[,] Sectors = new byte[12, 4];
    };

    class Crypto
    {


        int I4(ref ulong x, int a, int b, int c, int d)
        {
            int v =(int)((((x) >> (a)) & 1) + (((x) >> (b)) & 1) * 2 + (((x) >> (c)) & 1) * 4 + (((x) >> (d)) & 1) * 8);

            return v;
        }

        byte REV8(byte x)
        {
           byte y= (byte)((((x) >> 7) & 1) + ((((x) >> 6) & 1) << 1) + ((((x) >> 5) & 1) << 2) + ((((x) >> 4) & 1) << 3) + ((((x) >> 3) & 1) << 4) + ((((x) >> 2) & 1) << 5) + ((((x) >> 1) & 1) << 6) + (((x) & 1) << 7));
            return y;
        }


        ushort REV16(ushort x)
        {
            byte low = REV8((byte)x);
            byte high = REV8((byte)((x) >> 8));
            ushort shift = (ushort)(((ushort)high )<< 8);
            ushort y = (ushort)(((ushort)low) + shift);
            return y;
        }

        uint REV32(uint x)
        {
            ushort low = REV16((ushort)x);
            ushort high = REV16((ushort)((x) >> 16));
            uint shift = (uint)(((uint)high) << 16);
            uint y = (uint)(((uint)low) + shift);
            return y;
        }

        ulong REV64(ulong x)
        {
            uint low = REV32((uint)x);
            uint high = REV32((uint)((x) >> 32));
            ulong shift = (ulong)(((ulong)high) << 32);
            ulong y = (ulong)(((ulong)low) + shift);
            return y;
        }



        const uint ht2_f4a = 0x2C79;  
        const uint ht2_f4b = 0x6671;     
        const uint ht2_f5c = 0x7907287B;

        uint F_f20( ulong x) 
            {
    uint i5;
            ulong x1 = x;

        i5 = ((ht2_f4a >> I4(ref x, 1, 2, 4, 5)) & 1) * 1
         + ((ht2_f4b >> I4(ref x, 7, 11, 13, 14)) & 1) * 2
         + ((ht2_f4b >> I4(ref x, 16, 20, 22, 25)) & 1) * 4
         + ((ht2_f4b >> I4(ref x, 27, 28, 30, 32)) & 1) * 8
         + ((ht2_f4a >> I4(ref x, 33, 42, 43, 45)) & 1) * 16;

    return (ht2_f5c >> (int)i5) & 1;
}

        ulong _hitag2_init(ulong key,  uint serial,  uint IV)
    {
        int i;
            ulong x = ((key & 0xFFFF) << 32) + serial;

        for (i = 0; i < 32; i++)
        {
            x >>= 1;
            x += (ulong)(F_f20(x) ^ (((IV >> i) ^ (key >> (i + 16))) & 1)) << 47;
        }
        return x;
    }

        ulong _hitag2_round(ref ulong state)
    {
            ulong x = state;

        x = (x >> 1) +
            ((((x >> 0) ^ (x >> 2) ^ (x >> 3) ^ (x >> 6)
               ^ (x >> 7) ^ (x >> 8) ^ (x >> 16) ^ (x >> 22)
               ^ (x >> 23) ^ (x >> 26) ^ (x >> 30) ^ (x >> 41)
               ^ (x >> 42) ^ (x >> 43) ^ (x >> 46) ^ (x >> 47)) & 1) << 47);

        state = x;
        return F_f20(x);
    }

    uint _hitag2_byte(ref ulong x)
    {
        int i;
        uint c;
        for (i = 0, c = 0; i < 8; i++)
        {
            c += (uint)_hitag2_round(ref x) << (i ^ 7);
        }
        return c;
    }

    public void hitag2_cipher_reset(ref Hitag2_tag tag, ref byte []iv) {
            ulong key = ((ulong)tag.Sectors[2,2]) |
                   ((ulong)tag.Sectors[2,3] << 8) |
                   ((ulong)tag.Sectors[1,0] << 16) |
                   ((ulong)tag.Sectors[1,1] << 24) |
                   ((ulong)tag.Sectors[1,2] << 32) |
                   ((ulong)tag.Sectors[1,3] << 40);
    uint uid = ((uint)tag.Sectors[0,0]) |
                   ((uint)tag.Sectors[0,1] << 8) |
                   ((uint)tag.Sectors[0,2] << 16) |
                   ((uint)tag.Sectors[0,3] << 24);
    uint iv_ = (((uint)(iv[0]))) |
                   (((uint)(iv[1])) << 8) |
                   (((uint)(iv[2])) << 16) |
                   (((uint)(iv[3])) << 24);
    tag.Cs = _hitag2_init(REV64(key), REV32(uid), REV32(iv_));
}

        public int hitag2_cipher_authenticate(ref ulong cs, ref byte [] authenticator_is)
{
    byte [] authenticator_should = new byte[4];
            authenticator_is[0] = (byte)~(int)_hitag2_byte(ref cs);
            authenticator_is[1] = (byte)~(int)_hitag2_byte(ref cs);
            authenticator_is[2] = (byte)~(int)_hitag2_byte(ref cs);
            authenticator_is[3] = (byte)~(int)_hitag2_byte(ref cs);

            return 0;
}

        public int hitag2_cipher_transcrypt(ref ulong cs, ref byte []data, ushort bytes, ushort bits)
{
    int i;
    for (i = 0; i < bytes; i++) data[i] ^= (byte)_hitag2_byte(ref cs);
    for (i = 0; i < bits; i++) data[bytes] ^= (byte)(_hitag2_round(ref cs) << (7 - i));
    return 0;
}


    }
}
