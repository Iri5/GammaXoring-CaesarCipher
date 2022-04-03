using System;
using System.Text;
namespace Coding
{
    public class GammaXoring : ICipher
    {
        public string Encode(string openData, string key)
        {
            Byte[] openDataByte = Encoding.UTF8.GetBytes(openData);
            Byte[] keyBytes = FillKeyBytes(openDataByte.Length, key);
            Byte[] encryptedDataByte = Coding(openDataByte, keyBytes);
            return BitConverter.ToString(encryptedDataByte, 0);
        }
        public string Decode(string encryptedData, string key)
        {
            Byte[] encryptedDataByte = null;
            encryptedDataByte = Input.SplitStringIntoBytes(encryptedData);
            Byte[] keyBytes = FillKeyBytes(encryptedDataByte.Length, key);
            Byte[] openDataByte = Coding(encryptedDataByte, keyBytes);
            String openData = Encoding.UTF8.GetString(openDataByte);
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

            if (string.IsNullOrWhiteSpace(key))
            {
                right = false;
            }
            else right = true;
            return right;
        }
        private Byte[] Coding(Byte[] data, Byte[] key)
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i] ^= key[i];
            }
            return data;
        }

        private Byte[] FillKeyBytes(int lengthKey, string key)
        {
            Byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            int differenceSize = lengthKey - keyBytes.Length;
            if (differenceSize > 0)
            {
                Byte[] newKeyBytes = new Byte[keyBytes.Length + differenceSize];
                keyBytes.CopyTo(newKeyBytes, 0);
                for (int i = 0; i < differenceSize; i++)
                {
                    newKeyBytes[keyBytes.Length + i] = keyBytes[i % keyBytes.Length];
                }
                keyBytes = newKeyBytes;
            }
            return keyBytes;
        }
        
        
        
        
    }
}
