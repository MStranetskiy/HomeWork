using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lesson11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            test_1();
        }

        static public void test_1()
        {
            var stackTest = new Stack(["a", "b", "c"], "stackTest");

            Console.WriteLine($"size = {stackTest.Size}, Top = '{stackTest.Top}'");

            var deleted = stackTest.Pop();
            Console.WriteLine($"Последний удаленный элемент '{deleted}' текущий Size = {stackTest.Size}");

            stackTest.Add("d");
            Console.WriteLine($"size = {stackTest.Size}, Top = '{stackTest.Top}'");
            stackTest.Pop();
            stackTest.Pop();
            stackTest.Pop();

            Console.WriteLine($"size = {stackTest.Size}, Top = {(stackTest.Top == null ? "null" : stackTest.Top)}");
            stackTest.Pop();

            var stack1 = new Stack(["a", "b", "c"], "stack1");
            var stack2 = new Stack(["1", "2", "3"], "stack2");

            stack1.Merge(stack2);
            stack1.Write();

            var concat = Stack.Concat([stack1, stack2], stackTest);
            Console.WriteLine("---------------------------------------------");
            concat.Write();

        }
    }

    public static class StackExtensions {
        public static void Merge(this Stack stack, Stack stack2)
        {

            for (int i = stack2.Size; i > 0; i--)
            {
                stack.Add(stack2.Pop());
            }
        }
    }

    public class Stack
    {
        private string NameClases;
        private List<String> list = new List<String>();

        public Stack(String[] name, String nameClass) {
          
            NameClases = nameClass;

            foreach (String s in name)
            {
                Add(s);
            }
        }

        public static Stack Concat(Stack[] stack, Stack stackConcat)
        {
           
            foreach (Stack s in stack)
            {
                stackConcat.Merge(s);
            }
   
            return stackConcat;
        }

        public void Write()
        {
            for (int i = 0; i != list.Count; i++)
            {
                var item = list[i];

                Console.WriteLine($"Stack Name '{NameClases}' Element[{i}] = {item}");
            }
        }

        public void Add(String name)
        {         
            list.Add(name);
            Console.WriteLine($"Stack Name '{NameClases}' Добавлен элемент '{name}'");
        }

        public string Pop()
        {
            var ret = "null";
            try
            {
                ret = list.Last();
                list.Remove(list.Last());
                Console.WriteLine($"Stack Name '{NameClases}' Удален элемент '{ret}'");
            }
            catch (Exception)
            {
                Console.WriteLine($"Stack Name '{NameClases}' Ошибка: Стек пустой");
            }
            return ret;
        }

        public int Size
        {
            get
            {
                return list.Count;
            }
        }
        public string Top
        {
            get
            {
                if (Size == 0) return "null";
                return list.Last();
            }
        }
    }
}
