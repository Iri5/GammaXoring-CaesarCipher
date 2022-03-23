using System;
using System.Collections.Generic;

namespace Coding
{

    class Menu
    {
       
        public void Action( )//ГЛАВНАЯ ФУНКЦИЯ
        {
            FileData input = new FileData();
            ICipher gamma = new GammaXoring();
            ICipher ceaser = new СaesarsСipher();
            Menu m = new Menu();
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
                                        InputType inputType = m.AskForInput();
                                        switch (inputType)
                                        {
                                            case InputType.KEYBOARD:
                                                {
                                                    KeyForGamma(ref key);
                                                    Console.WriteLine("Введите строку для шифрования");
                                                    Input.KeyboardStr(ref data);
                                                    SaveInput(data);
                                                    break;
                                                }
                                            case InputType.FILE:
                                                {
                                                    FileInputStr(ref data);
                                                    KeyForGamma(ref key);
                                                    break;
                                                }
                                        }
                                        string result = gamma.Encode(data, key);
                                        Result(ref result);
                                        break;
                                    }
                                case CodingType.CAESAR:
                                    {
                                        InputType inputType = m.AskForInput();
                                        switch (inputType)
                                        {
                                            case InputType.KEYBOARD:
                                                {
                                                    KeyForCaesar(ref key);
                                                    Console.WriteLine("Введите строку для шифрования");
                                                    Input.KeyboardStr(ref data);
                                                    SaveInput(data);
                                                    break;
                                                }
                                            case InputType.FILE:
                                                {
                                                    FileInputStr(ref data);
                                                    KeyForCaesar(ref key);
                                                    break;
                                                }
                                        }
                                        string result = ceaser.Encode(data, key);
                                        Result(ref result);
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
                                        InputType inputType = m.AskForInput();
                                        switch (inputType)
                                        {
                                            case InputType.KEYBOARD:
                                                {
                                                    KeyForGamma(ref key);
                                                    Console.WriteLine("Введите строку для расшифровки");
                                                    Input.KeyboardStrDecode(ref data);
                                                    SaveInput(data);
                                                    break;
                                                }
                                            case InputType.FILE:
                                                {
                                                    FileInputDec(ref data);
                                                    KeyForGamma(ref key);
                                                    break;
                                                }
                                        }
                                        string result = gamma.Decode(data, key);
                                        Result(ref result);
                                        break;
                                    }
                                case CodingType.CAESAR:
                                    {
                                        InputType inputType = m.AskForInput();
                                        switch (inputType)
                                        {
                                            case InputType.KEYBOARD:
                                                {
                                                    KeyForCaesar(ref key);
                                                    Console.WriteLine("Введите строку для расшифровки");
                                                    Input.KeyboardStrDecode(ref data);
                                                    SaveInput(data);
                                                    break;
                                                }
                                            case InputType.FILE:
                                                {
                                                    FileInputDec(ref data);
                                                    KeyForCaesar(ref key);
                                                    break;
                                                }
                                        }
                                        string result = ceaser.Decode(data, key);
                                        Result(ref result);
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
        //public void MyProgram()
        //{
        //    Greeting();
        //    List<int> toFile = new List<int>();
        //    Menu m = new Menu();
        //    WhatToDo action = m.ChoiceAction();
        //    while (m.Action(ref action, toFile) != WhatToDo.COMPLEATE) ;
        //}
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
        public void KeyForGamma(ref string key)
        {
            Console.WriteLine("Введите ключ: строка");
            Input.KeyboardStr(ref key);
        }
        public void KeyForCaesar(ref string key)
        {
            Console.WriteLine("Введите ключ: число");
            Input.KeyboardKeyNumber(ref key);
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
            Console.WriteLine($"Бовчурова Ирина группа 403 {Environment.NewLine} Необходимо реализовать программу для шифровки и расшифровывания,{Environment.NewLine} шифров Цезаря и гаммирования {Environment.NewLine} ");
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