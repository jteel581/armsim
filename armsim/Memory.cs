// RAM.cs
// This file contains the RAM class, a class that is necessary for this project and is used to hold the 
// virtual memory for the simulator.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace armsim
{
    // This class holds the virtual memory for the simulator. It also has several key functions that are 
    // used to manipulate the bits and bytes in memory.
    class Memory
    {
        // This variable is a byte array which is used as our simulated RAM
        public byte[] memory;
        // This variable holds the size of the memory
        int size = 0;
        // These two methods are getter and setter methods for the size variable
        public int getSize() { return size; }
        public void setSize(int newSize)
        {
            size = newSize;
        }
        // This is the constructor for the RAM class, it takes 'ramSize' and creates a new byte array
        // of that size and stores it in memory. It also sets the size variable.
        public Memory(int ramSize)
        {
            memory = new byte[ramSize];
            size = ramSize;
        }
        public int getReg(int regNum)
        {
            int address = regNum * 4;
            int regVal = 0;
            regVal = ReadWord(address);
            return regVal;
        }

        public void setReg(int regNum, int newVal)
        {
            int address = regNum * 4;
            WriteWord(address, (uint)newVal);

        }

        // This method is used to check whether a bit is 0 or 1 in a word at a given address.
        // The method takes two parameters: 'address', which it uses to find the word the bit is in,
        // and 'bit' which it uses to find the location of the bit within the word. It returns true
        // if the bit is 1 and false if the bit is 0.
        public bool TestFlag(int address, int bit)
        {
            uint word = (uint)ReadWord(address);
            word <<= (31 - bit);
            word >>= 31;
            return word == 1 ? true : false;
            
        }

        // This method is used to set a bit within a word at a given address. This method takes three
        // parameters: 'address', which is used to find the word in which the bit to be changed is 
        // located, 'bit' which is the number of the place within the word that the bit resides, and 
        // 'flag' which is true or false. If flag is true, the bit will be made 1, if it is false, the
        // bit will be made 0.
        public void SetFlag(int address, int bit, bool flag)
        {
            bool flagEqual = TestFlag(address, bit) == flag ? true : false;
            if(!flagEqual)
            {
                uint mask = 1;
                uint word = (uint)ReadWord(address);
                mask <<= bit;
                word = word ^ mask;
                WriteWord(address, word);
            }

        }


        // This method is used to extract the bits within the range from start bit to end bit within
        // the given word. It takes 3 parameters: 'word' which is the word of memory to extract the bits
        // from, 'startBit', which is the location of the first bit in the range to extract, and 'endBit'
        // which is the last bit in the range to be extracted. It returns the bits extracted with all other
        // bits set to 0.
        public static uint ExtractBits(uint word, int startBit, int endBit)
        {
            int numOfBits = (endBit - startBit);
            uint mask = 0xFFFFFFFF;
            uint result;
            mask >>= 31 - numOfBits;
            mask <<= startBit;
            result = word & mask;
            return result;

        }

        // This method is used to read a word from memory. It takes 1 parameter: 'address', 
        // which is used to denote the address in memory from which the word must be read.
        // 'address' must be evenly divisible by 4. It returns the value of the word read
        // at 'address'.
        public int ReadWord(int address)
        {
            if (address % 4 != 0)
            {
                return -1;
            }
            else
            {
                int halfWordA = ReadHalfWord(address);
                int halfWordB = ReadHalfWord(address + 2);
                halfWordB <<= 16;
                halfWordB |= halfWordA;
                return halfWordB;
            }
            
        }

        // This method is used to write a word to memory at a certain address. It takes
        // twp parameters: 'address' which is the location it writes the word at, and 
        // 'value' which is the word to write at the given address. 'adress' must be 
        // evenly divisible by 4.
        public void WriteWord(int address, uint value)
        {
            if (address % 4 != 0)
            {
                return;
            }
            else if (address <= getSize() - 4)
            {
                short[] word = Converter.wordToShortArray(value);
                foreach (short hw in word)
                {
                    WriteHalfWord(address, hw);
                    address += 2;
                }

            }
        }

        // This method is used to read a half word from memory. It takes one parameter: 'address',
        // which is used to denote the location in memory from which to read a half word. 'address 
        // must be evenly divisible by 2. It returns the half word read from memory at the 'address'.
        public short ReadHalfWord(int address)
        {
            if (address % 2 != 0)
            {
                return -1;
            }
            else
            {
                short byteA = memory[address];
                short byteB = memory[address + 1];
                byteB <<= 8;
                byteB |= byteA;
                return byteB;
            }
            
        }

        // This method is used to write a half word to memory at a given location. It takes
        // two parameters: 'address' which is used to denote the location in memory to write 
        // the half word, and 'value' which is the half word to be written at the given location.
        // 'address' must be evenly divisible by 2.
        public void WriteHalfWord(int address, short value)
        {
            if (address % 2 != 0)
            {
                return;
            }
            else if (address <= getSize() - 2)
            {
                byte[] halfWord = Converter.halfToByteArray(value);
                foreach (byte b in halfWord)
                {
                    WriteByte(address, b);
                    address++;
                }

            }
        }

        // This method is used to read one byte from memory at a given location.
        // This method takes one parameter: 'address', which it uses to denote the 
        // loccation in memory where it must read the byte from. It returns the byte
        // read from the 'address'.
        public byte ReadByte(int address)
        {
            byte b = memory[address];
            return b;
        }

        // This method is used to wrtie one byte to memory at a given location.
        // It takes two parameters: 'address', which is used to denote the location
        // in memory to write the given byte, and 'value' which is the byte to write
        // to memory at the said location.
        public void WriteByte(int address, byte value)
        {
            memory[address] = value;
        }

        // This method is used to calculate the check sum of memory. It takes one parameter: 'memory',
        // which is the byte array to preform the calculations on. It returns the value of the check sum.
        public int calculateChecksum(byte[] memory)
        {
            int cksum = 0;
            for (int i = 0; i < memory.Length; i++)
            {
                cksum += memory[i] ^ i;
            }
            return cksum;
        }

    }
}
