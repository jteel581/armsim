using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    class Converter
    {
        public Converter()
        {
            /*
            word = new byte[4];
            halfWord = new byte[2]; */
        }

        public static short[] wordToShortArray(int word)
        {
            short[] wordArray = new short[2];
            short firstShort = (short)(word >> 16);
            short secondShort = (short)(word << 16);
            secondShort >>= 16;
            wordArray[0] = firstShort;
            wordArray[1] = secondShort;
            return wordArray;

        }

        public static byte[] halfToByteArray(short halfWord)
        {
            byte[] halfWordArray = new byte[2];
            byte firstByte = (byte)(halfWord >> 8);
            byte secondByte = (byte)(halfWord << 8);
            secondByte >>= 8;
            halfWordArray[0] = firstByte;
            halfWordArray[1] = secondByte;
            return halfWordArray;

        }
    }
}
