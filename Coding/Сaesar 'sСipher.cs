using System;
using System.Text;

namespace Coding
{
    public class СaesarsСipher : ICipher
    {
        public string Encode(string arrOriginal, string key)
        {
            byte key1 = byte.Parse(key);
            Byte[] openDataByte = Encoding.UTF8.GetBytes(arrOriginal);
            Byte[] encryptedDataByte = Coding(openDataByte, key1);
            return BitConverter.ToString(encryptedDataByte, 0);
        }
        public string Decode(string encrypted, string key)
        {
            byte key1 = byte.Parse(key);
            Byte[] encryptedDataByte = Input.SplitStringIntoBytes(encrypted);
            Byte[] openDataByte = Decoding(encryptedDataByte, key1);
            string openData = Encoding.UTF8.GetString(openDataByte);
            return openData;
        }
        private Byte[] Coding(Byte[] data, byte key)
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i] += key;
            }
            return data;
        }
        private Byte[] Decoding(Byte[] data, byte key)
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i] -= key;
            }
            return data;
        }
    }
}
