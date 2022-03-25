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
        public static void KeyboardKeyNumber(ref string key)
        {
            Console.WriteLine("Введите ключ для шифра Цезаря - целое число");
            int number = 0;
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Ошибка ввода! Введите целое число");
            }
            key = number.ToString();
        }
        public static void KeyboardStr(ref string data)
        {
            data = "";
            while (data == "")
            {
                Console.WriteLine("Введите текст, длиной больше 0");
                data = Console.ReadLine();
            }
        }
        public static void KeyboardStrDecode(ref string data)
        {
            bool right = false;
            while (right == false)
            {
                KeyboardStr(ref data);
                Byte[] encryptedDataByte;
                try
                {
                    encryptedDataByte = Input.SplitStringIntoBytes(data);
                    right = true;
                }
                catch
                {
                    Console.WriteLine("Данные некорректны, попробуйте снова:");
                    right = false;
                }
            }
        }
    }
}
