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

        public static short[] wordToShortArray(uint word)
        {
            short[] wordArray = new short[2];
            short firstShort = (short)(word >> 16);
            short secondShort = (short)(word);
            //secondShort >>= 16;
            wordArray[1] = firstShort;
            wordArray[0] = secondShort;
            return wordArray;

        }

        public static byte[] halfToByteArray(short halfWord)
        {
            byte[] halfWordArray = new byte[2];
            byte firstByte = (byte)(halfWord >> 8);
            byte secondByte = (byte)(halfWord);
            halfWordArray[1] = firstByte;
            halfWordArray[0] = secondByte;
            return halfWordArray;

        }
    }
}
