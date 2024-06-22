using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;

namespace Task1
{
    public class Program
    {
        private static string nameUser = "";
        private static bool authorization = false;
        private static List<string> listMenu = new List<string> { "Авторизация", "Помощь", "Инфо", "Выход" };
        private static string version = "0.0001";

        static void Main(string[] args)
        {
            ShowMenu();
        }

        static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine($"Приветсвую пользователь{nameUser}! \nВы можете воспользоваться одной из следующих команд:\n");
            
            for (int index = 0; index < listMenu.Count; index++)
            {
                string item = listMenu[index];
                Console.WriteLine($"{index+1} = {item}");
            }

            var response = Console.ReadLine();

            switch (response)
            {
                case "1" when authorization == false:
                    Authorize();
                    break;

                case "1" when authorization:
                    RunEcho();
                    break;

                case "2":
                    ShowHelp();
                    break;

                case "3":
                    ShowVersion();
                    break;

                case "4":
                    Exit();
                    break;

                default:
                    Console.Beep();
                    ShowMenu();
                    break;
            }
        }
        static void RunEcho()
        {
            Console.Clear();
            Console.WriteLine($"Дорогой{nameUser}! \nНапечатай любой текст что бы потворить его");
            var userInput = Console.ReadLine();
            Console.WriteLine($"Дорогой{nameUser}! Сколько раз повторить текст?");
            var count = 0; ;

            while (!Int32.TryParse(Console.ReadLine(), out count))
            {
                Console.WriteLine($"Дорогой{nameUser}! Ошибка значения. Введите число");
            }

            for (int index = 0; index < count; index++)
            {
                Console.WriteLine(userInput);
            }

            Console.WriteLine($"Дорогой{nameUser}! Дело сделано. Нажми любую кнопку что бы вернуться в меню");
            Console.ReadLine();
            ShowMenu();
        }
        static void Authorize()
        {
            Console.Clear();
            Console.WriteLine("Для начала представьтесь! Ваше имя?");
            nameUser = Console.ReadLine();
            nameUser = nameUser.Insert(0, ", ");
            listMenu[0] = "Программа эхо";
            authorization = true;
            ShowMenu();
        }
        static void Exit()
        {
            Console.WriteLine($"Пращайте{nameUser}! \nНажмите любую кнопку для завершения");
            Console.ReadLine();
            Environment.Exit(0);
        }
        static void ShowVersion() {
            Console.Clear();
            Console.WriteLine($"Версия ПО {version} дата создания 21.06.2024");
            Console.WriteLine($"Нажми любую кнопку что бы вернуться в меню");
            Console.ReadLine();
            ShowMenu();
        }
        static void ShowHelp() {
            Console.Clear();
            Console.WriteLine($"Дорогой{nameUser}!\nэто справочная информация о программе. Нажми 1 в главном меню что бы многократно напечатать текст");
            Console.WriteLine($"Нажми любую кнопку что бы вернуться в меню");
            Console.ReadLine();
            ShowMenu();
        }
    }
}
