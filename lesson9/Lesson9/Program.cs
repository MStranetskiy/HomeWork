using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9
{
    internal class Program
    {
        static int a, b, c;
        public enum Severity
        {
            Warning,
            Error
        }

        public static IDictionary<string, string> data =
            new Dictionary<string, string>();

        static void Main(string[] args)
        {

            Console.WriteLine("уравнение: a * x^2 + b * x + c = 0");
            GetData();

            try
            {  
                a = Int32.Parse(data["a"]);
            }

            catch (Exception)
            {
                string message = $"\"--------------------------------------------------" +
                    $"\nНе верный формат параметра  a" +
                    "\n--------------------------------------------------";

                FormatData(message, Severity.Error, data);
            }

            try
            {
                b = Int32.Parse(data["b"]);
            }

            catch (Exception)
            {
                string message = $"\"--------------------------------------------------" +
                    $"\nНе верный формат параметра  b" +
                    "\n--------------------------------------------------";

                FormatData(message, Severity.Error, data);
            }

            try
            {
                c = Int32.Parse(data["c"]);
            }

            catch (Exception)
            {
                string message = $"--------------------------------------------------" +
                    $"\nНе верный формат параметра  c" +
                    "\n--------------------------------------------------";

                FormatData(message, Severity.Error, data);
            }

        }


        public static void GetData()
        {
            var x = 1;
            Console.WriteLine("   Введите значение a:");
            Console.WriteLine("   Введите значение b:");
            Console.WriteLine("   Введите значение c:");

            Console.SetCursorPosition(0, x);
            Console.Write(">");
            Console.SetCursorPosition(22, x);

            while (true) {
                var cursor = Console.ReadKey(true);

                if (cursor.Key == ConsoleKey.DownArrow && x<3)
                {
                    x++;
                    Console.SetCursorPosition(0, x);
                    Console.Write(">");
                    Console.SetCursorPosition(22, x);
                }

                if (cursor.Key == ConsoleKey.UpArrow && x > 1)
                {
                    x--;
                    Console.SetCursorPosition(0, x);
                    Console.Write(">");
                    Console.SetCursorPosition(22, x);
                }
            }
        }

        public static void FormatData(string message, Severity severity, IDictionary<string,string> data)
        {

            switch (severity)
            {
                case Severity.Warning:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    break;
                case Severity.Error:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
                default:
                    break;
            }
            Console.WriteLine(message);

            foreach (var item in data)
            {
                Console.WriteLine(item.Key + " = " + item.Value);
            }
            
        }
    }
}
