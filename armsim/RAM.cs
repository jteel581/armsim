using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace armsim
{
    class RAM
    {
        public byte[] memory;

        int size = 0;
        public int getSize() { return size; }
        public void setSize(int newSize)
        {
            size = newSize;
        }
        public RAM(int ramSize)
        {
            memory = new byte[ramSize];
            size = ramSize;
        }

        // TestFlag method

        public bool TestFlag(int address, int bit)
        {
            uint word = (uint)ReadWord(address);
            word <<= (31 - bit);
            word >>= 31;
            return word == 1 ? true : false;
            
        }

        // SetFlag Method

        public void SetFlag(int address, int bit, bool flag)
        {
            bool flagEqual = TestFlag(address, bit) == flag ? true : false;
            if(!flagEqual)
            {
                uint mask = 1;
                uint word = (uint)ReadWord(address);
                mask <<= bit;
                word = word ^ mask;
                WriteWord(address, (int)word);
            }

        }


        // Extract bits method

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

        // Read/Write Word/HalfWord/Byte methods
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
        public void WriteWord(int address, int value)
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
        public byte ReadByte(int address)
        {
            byte b = memory[address];
            return b;
        }
        public void WriteByte(int address, byte value)
        {
            memory[address] = value;
        }

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
