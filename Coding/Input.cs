using System;

namespace Coding
{
    class Input
    {
        public static Byte[] SplitStringIntoBytes(string data)
        {
            string[] splitData = new string[data.Length];
            int byteIndex = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == '-')
                {
                    byteIndex++;
                    continue;
                }
                splitData[byteIndex] += data[i];
            }
            Byte[] dataByte = new Byte[++byteIndex];
            for (int i = 0; i < byteIndex; i++)
            {
                dataByte[i] = byte.Parse(splitData[i], System.Globalization.NumberStyles.HexNumber);
            }
            return dataByte;
        }
        
    }
}
