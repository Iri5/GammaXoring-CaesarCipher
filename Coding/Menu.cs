using System;

namespace Coding
{
    class Menu
    {
        public void Action( )
        {
            FileData input = new FileData();
            Menu m = new Menu();
            ICipher icipher;
            string data = "";
            string key = "";
            bool isRestart = true;
            do
            {
                WhatToDo action = m.ChoiceAction();
                switch (action)
                {
                    case WhatToDo.ENCODE:
                        {
                            CodingType type = m.ChoiceCodingType();
                            switch (type) 
                            {
                                case CodingType.GAMMA:
                                    {
                                        icipher = new GammaXoring();
                                        CaseEncode(icipher, ref key, ref data);
                                        break;
                                    }
                                case CodingType.CAESAR:
                                    {
                                        icipher = new СaesarsСipher();
                                        CaseEncode(icipher, ref key, ref data);
                                        break;
                                    }
                            }
                            break;
                        }
                    case WhatToDo.DECODE:
                        {
                            CodingType type = m.ChoiceCodingType();
                            switch (type) 
                            {
                                case CodingType.GAMMA:
                                    {
                                        icipher = new GammaXoring();
                                        CaseDecode(icipher, ref key, ref data);
                                        break;
                                    }
                                case CodingType.CAESAR:
                                    {
                                        icipher = new СaesarsСipher();
                                        CaseDecode(icipher, ref key, ref data);
                                        break;
                                    }
                            }
                            break ;
                        }
                    case WhatToDo.COMPLETE:
                        {
                            isRestart = false;
                            break;
                        }
                }
            }
            while (isRestart);
            
        }
        public void CaseEncode(ICipher icipher, ref string key, ref string data)
        {
            Menu m = new Menu();
            InputType inputType = m.AskForInput();
            switch (inputType)
            {
                case InputType.KEYBOARD:
                    {
                        key = KeyStr(icipher);
                        Console.WriteLine("Введите строку для шифрования");
                        data = EncodingStr(icipher);
                        SaveInput(data);
                        break;
                    }
                case InputType.FILE:
                    {
                        FileInputStr(ref data);
                        key = KeyStr(icipher);
                        break;
                    }
            }
            string result = icipher.Encode(data, key);
            Result(ref result);
        }
        
        public void CaseDecode(ICipher icipher, ref string key, ref string data)
        {
            Menu m = new Menu();
            InputType inputType = m.AskForInput();
            switch (inputType)
            {
                case InputType.KEYBOARD:
                    {
                        key = KeyStr(icipher);
                        Console.WriteLine("Введите строку для расшифровки");
                        data = DecodingStr(icipher);
                        SaveInput(data);
                        break;
                    }
                case InputType.FILE:
                    {
                        FileInputDec(ref data);
                        key = KeyStr(icipher);
                        break;
                    }
            }
            string result = icipher.Decode(data, key);
            Result(ref result);
        }
        public string DecodingStr(ICipher icipher)
        {
            string data = Console.ReadLine();
            while (!icipher.DecodeString(data))
            {
                data = Console.ReadLine();
            }
            return data;
        }
        public string EncodingStr(ICipher icipher)
        {
            string data = Console.ReadLine();
            while (!icipher.EncodeString(data))
            {
                Console.WriteLine("Неверный формат! Используйте любую ненулевую строку");
                data = Console.ReadLine();
            }
            return data;
        }
        public string KeyStr(ICipher icipher)
        {
            Console.WriteLine("Введите ключ:");
            string key = Console.ReadLine();
            while (!icipher.Key(key))
            {
                Console.WriteLine("Неверный формат! Для шифра цезаря используйте число, для гаммирования любую ненулевую строку");
                key = Console.ReadLine();
            }
            return key;
        }
        public void MyProgram()
        {
            Greeting();
            Action();
        }
        public void SaveInput(string data)
        {
            FileData input = new FileData();
            MenuAnswer toSaveInput = AskForSavingInput();
            if (toSaveInput == MenuAnswer.YES)
            {
                input.SaveToFile(data);
            }
        }
        public void SaveOutput(string result)
        {
            FileData input = new FileData();
            MenuAnswer toSaveOutput = AskForSavingOutput();
            if (toSaveOutput == MenuAnswer.YES)
            {
                input.SaveToFile(result);
            }
        }
        public void FileInputStr(ref string data)
        {
            FileData input = new FileData();
            bool x = input.FileInputStr(ref data);
            while (x == false)
            {
                x = input.FileInputStr(ref data);
            }
        }
        public void FileInputDec(ref string data)
        {
            FileData input = new FileData();
            bool x = input.FileInputDecode(ref data);
            while (x == false)
            {
                x = input.FileInputDecode(ref data);
            }
        }
        public void Result(ref string result)
        {
            Console.WriteLine("Получившаяся строка:");
            Console.WriteLine(result);
            SaveOutput(result);
        }
        public MenuAnswer GetChoice()
        {
            MenuAnswer a = 0;
            while (!MenuAnswer.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Ошибка ввода! Введите нужное число");
            }
            return a;
        }
        public InputType GetInput()
        {
            InputType a = 0;
            while (!InputType.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Ошибка ввода! Введите нужный вариант");
            }
            return a;
        }
        public WhatToDo GetAction()
        {
            WhatToDo a = 0;
            while (!WhatToDo.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Ошибка ввода! Введите нужный вариант");
            }
            return a;
        }
        public CodingType GetCodingType()
        {
            CodingType a = 0;
            while (!CodingType.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Ошибка ввода! Введите нужный вариант");
            }
            return a;
        }

        public void Greeting()
        {
            Console.WriteLine($"Бовчурова Ирина группа 403 {Environment.NewLine} Необходимо реализовать программу для шифровки и расшифровки,{Environment.NewLine} шифров Цезаря и гаммирования {Environment.NewLine} ");
        }
        bool RightMenuChoice(MenuAnswer choice)
        {
            if ((choice == MenuAnswer.NO) || (choice == MenuAnswer.YES))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Ошибка ввода, введите 1 или 2");
                return false;
            }
        }
        bool RightInputChoice(InputType choice)
        {
            if ((choice == InputType.KEYBOARD) || (choice == InputType.FILE))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Ошибка ввода, введите 1 или 2");
                return false;
            }
        }
        bool RightActionChoice(WhatToDo choice)
        {
            if ((choice == WhatToDo.ENCODE) || (choice == WhatToDo.DECODE) || (choice == WhatToDo.COMPLETE))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Ошибка ввода, введите 1, 2 или 3");
                return false;
            }
        }
        bool RightCodingType(CodingType choice)
        {
            if ((choice == CodingType.GAMMA) || (choice == CodingType.CAESAR))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Ошибка ввода, введите 1 или 2");
                return false;
            }
        }

        public WhatToDo ChoiceAction()
        {
            Console.WriteLine("Какое действие необходимо выполнить?");
            Console.WriteLine($" 1 - Зашифровать {Environment.NewLine} 2 - Расшифровать {Environment.NewLine} 3 - Завершить");
            Console.WriteLine("Ваш выбор:");
            WhatToDo decision = GetAction();
            while (!RightActionChoice(decision))
            {
                decision = GetAction(); ;
            }
            return decision;
        }
        public CodingType ChoiceCodingType()
        {
            Console.WriteLine("Какое шифрование необходимо применить?");
            Console.WriteLine($" 1 - Гаммирование {Environment.NewLine} 2 - Шифр Цезаря");
            Console.WriteLine("Ваш выбор:");
            CodingType decision = GetCodingType();
            while (!RightCodingType(decision))
            {
                decision = GetCodingType(); ;
            }
            return decision;
        }
        public InputType AskForInput()
        {
            Console.WriteLine("Каким способом вы хотите ввести данные?");
            Console.WriteLine($" 1 - с клавиатуры {Environment.NewLine} 2 - из файла");
            Console.WriteLine("Ваш выбор:");
            InputType decision = GetInput();
            while (!RightInputChoice(decision))
            {
                decision = GetInput(); ;
            }
            return decision;
        }
        public MenuAnswer AskForSavingInput()
        {
            Console.WriteLine("Желаете сохранить исходные данные?");
            Console.WriteLine($" 1 - да {Environment.NewLine} 2 - нет");
            Console.WriteLine("Ваш выбор:");
            MenuAnswer decision = GetChoice();
            while (!RightMenuChoice(decision))
            {
                decision = GetChoice(); ;
            }
            return decision;
        }
        public MenuAnswer AskForSavingOutput()
        {
            Console.WriteLine("Желаете сохранить результат?");
            Console.WriteLine($" 1 - да {Environment.NewLine} 2 - нет");
            Console.WriteLine("Ваш выбор:");
            MenuAnswer decision = GetChoice();
            while (!RightMenuChoice(decision))
            {
                decision = GetChoice(); ;
            }
            return decision;
        }
        public MenuAnswer AskForRewriting()
        {
            Console.WriteLine("Файл уже существует, желаете перезаписать?");
            Console.WriteLine($" 1 - да {Environment.NewLine} 2 - нет");
            Console.WriteLine("Ваш выбор:");
            MenuAnswer decision = GetChoice();
            while (!RightMenuChoice(decision))
            {
                decision = GetChoice(); ;
            }
            return decision;
        }
    }
}