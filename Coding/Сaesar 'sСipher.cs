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
        public bool DecodeString(string text)
        {
            bool right = false;
                Byte[] encryptedDataByte;
                try
                {
                    encryptedDataByte = Input.SplitStringIntoBytes(text);
                    right = true;
                }
                catch
                {
                    Console.WriteLine("Данные некорректны, попробуйте снова:");
                    right = false;
                }
            return right;
        }
        public bool EncodeString(string text)
        {
            bool right = false;

            if (string.IsNullOrWhiteSpace(text))
            {
                right = false;
            }
            else right = true;
            return right;
        }
        public bool Key(string key)
        {
            bool right = false;
            int number = 0;
            if (!int.TryParse(key, out number))
            {
                right = false;
            }
            else right = true;
            key = number.ToString();
            return right;
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
