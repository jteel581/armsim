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
        public RAM(int ramSize)
        {
            memory = new byte[ramSize];
            size = ramSize;
        }




        // Read/Write Word/HalfWord/Byte methods
        public int ReadWord(int address)
        {
            int halfWordA = ReadHalfWord(address);
            int halfWordB = ReadHalfWord(address + 2);
            halfWordA <<= 16;
            halfWordA |= halfWordB;
            return halfWordA;
        }
        public void WriteWord(int address, int value)
        {
            memory[address] = Convert.ToByte(value);
        }
        public short ReadHalfWord(int address)
        {
            short byteA = memory[address];
            short byteB = memory[address + 1];
            byteA <<= 8;
            byteA |= byteB;
            return byteA;
        }
        public void WriteHalfWord(int address, short value)
        {

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
