// Converter.cs 
// This File holds the Converter class, a class of my own creation that I use to convert between
// words, shorts, and bytes

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    // This class is used to hold a couple of methods used to convert between words, shorts, and bytes
    class Converter
    {
        // This method takes an unsigned int 'word' and seperates it into two short values that it stores
        // in an array 'wordarray' in little endian fashion and then returns said array.
        public static short[] wordToShortArray(int word)
        {
            short[] wordArray = new short[2];
            short firstShort = (short)(word >> 16);
            short secondShort = (short)(word);
            //secondShort >>= 16;
            wordArray[1] = firstShort;
            wordArray[0] = secondShort;
            return wordArray;

        }

        // This method takes a short 'halfWord' and seperates it into two byte values that it stores
        // in an array 'halfWordArray' in little endian fashion and then returns said array.
        public static byte[] halfToByteArray(short halfWord)
        {
            byte[] halfWordArray = new byte[2];
            byte firstByte = (byte)(halfWord >> 8);
            byte secondByte = (byte)(halfWord);
            halfWordArray[1] = firstByte;
            halfWordArray[0] = secondByte;
            return halfWordArray;

        }


        public static string wordToString(int word)
        {
            string wordStr = "";
            short[] wordAsShortArray = wordToShortArray(word);
            byte[] wordAsByteArray1 = halfToByteArray(wordAsShortArray[0]);
            byte[] wordAsByteArray2 = halfToByteArray(wordAsShortArray[1]);
            wordStr += Convert.ToChar(wordAsByteArray1[0]);
            wordStr += Convert.ToChar(wordAsByteArray1[1]);
            wordStr += Convert.ToChar(wordAsByteArray2[0]);
            wordStr += Convert.ToChar(wordAsByteArray2[1]);
            return wordStr;

        }

    }
}
