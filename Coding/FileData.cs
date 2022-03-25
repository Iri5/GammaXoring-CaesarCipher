using System;
using System.Collections.Generic;
using System.IO;

namespace Coding
{
    class FileData
    {
        public bool FileInputDecode(ref string data)
        {
            string filePath = GetPath();
            
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    if ((data = sr.ReadLine()) != null)
                    {
                        Byte[] encryptedDataByte;
                        try
                        {
                           encryptedDataByte = Input.SplitStringIntoBytes(data);
                        }
                        catch
                        {
                           Console.WriteLine("Данные некорректны, попробуйте снова:");
                           return false;
                        }   
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Проверьте путь к файлу");
                return false;
            }
            return true;
        }
        public bool FileInputStr(ref string data)
        {
            string filePath = GetPath();
            string line = "";
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    if ((line = sr.ReadLine()) != null)
                    {
                        data = line;
                    }
                    else
                    {
                        Console.WriteLine("Файл пуст, попробуйте снова");
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Проверьте путь к файлу");
                return false;
            }
            return true;
        }
        public string GetPath()
        {
            Console.WriteLine("Введите путь к файлу:");
            string path = Console.ReadLine();
            string filePath;
            try
            {
                filePath = Path.GetFullPath(path);
            }
            catch
            {
                Console.WriteLine("Проверьте путь");
                filePath = GetPath();
            }
            return path;
        }
        
        public string CreateFile()
        {
            string path = "";
            bool isSucced = false;
            while (!isSucced)
            {
                path = GetPath();
                FileStream fStream = null;
                try
                {
                    fStream = new FileStream(path, FileMode.CreateNew);
                    isSucced = true;
                }
                catch
                {
                    if (File.Exists(path))
                    {
                        Menu m = new Menu();
                        MenuAnswer rewrite = m.AskForRewriting();
                        if (rewrite == MenuAnswer.YES)
                        {
                            File.Delete(path);
                            fStream = new FileStream(path, FileMode.CreateNew);
                            isSucced = true;
                        }
                        else
                        {
                            isSucced = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректный файл или недопустимое имя файла");
                        isSucced = false;
                    }
                }
                if (fStream != null) try { fStream.Close(); } catch (Exception) { Console.WriteLine("Stream not closed!"); isSucced = false; }
            }
            return path;
        }
        public void SaveToFile(string data)
        {
            string path = CreateFile();
            File.WriteAllText(path,data);
        }
       
    }
}

