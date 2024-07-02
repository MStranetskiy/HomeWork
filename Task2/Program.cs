using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;


namespace Task2
{
    internal class Program
    {
        private static int count = 1000000;
        public static Stopwatch stopWatch = new Stopwatch();
        static void Main(string[] args)
        {
            CheckList();
            Console.WriteLine("\n");

            CheckArrayList();
            Console.WriteLine("\n");

            CheckLinkedList();
            Console.WriteLine("\n");
        }

        static void CheckLinkedList() {

            var linkedList = new LinkedList<int>();
            
            for (int i = 0; i < count; i++)
            {
                if (i == 0) stopWatch.Start();

                var rnd = new Random().Next();
                linkedList.AddLast(rnd);

                if (i == count - 1)
                {
                    stopWatch.Stop();
                    ShowResult("Run time LinkedList");
                }
            }

            stopWatch.Start();
            for (int i = 0; i < linkedList.Count; i++)
            {
                if (i == 496753)
                {
                    stopWatch.Stop();
                    ShowResult("search item in LinkedList");
                }
            }

            stopWatch.Start();
            foreach (var item in linkedList)
            {
                if (item % 777 == 0)
                {
                    Console.WriteLine($"item ={item}");
                }
            }
            stopWatch.Stop();
            ShowResult("duration operation division LinkedList");
        }
        static void CheckList() { 
        
            var listColliction= new List<int>();

            for (int i = 0; i < count; i++) {
                if (i == 0) stopWatch.Start();

                var rnd = new Random().Next();
                listColliction.Add(rnd);

                if (i == count-1)
                {
                    stopWatch.Stop();
                    ShowResult("Run time List");
                }
            }
            
            stopWatch.Start();
            Console.WriteLine($"item index[496753]= {listColliction[496753]}");
            stopWatch.Stop();
            ShowResult("search item in List");

            stopWatch.Start();
            foreach (var item in listColliction)
            {
                if (item % 777 == 0)
                {
                    Console.WriteLine($"item ={item}");
                }
            }
            stopWatch.Stop();
            ShowResult("duration operation division List");
        }

        static void CheckArrayList() {

            ArrayList arrayList = new ArrayList(); 
            for (int i = 0; i < count; i++)
            {
                if (i == 0) stopWatch.Start();

                var rnd = new Random().Next();
                arrayList.Add(rnd);

                if (i == count - 1)
                {
                    stopWatch.Stop();                   
                    ShowResult("ArrayList");                  
                }
            }

            stopWatch.Start();
            Console.WriteLine($"item index[496753]= {arrayList[496753]}");
            stopWatch.Stop();
            ShowResult("search item in arrayList");

            stopWatch.Start();
            foreach (var item in arrayList)
            {
                if ((int)item % 777 == 0)
                {
                    Console.WriteLine($"item ={item}");
                }
            }
            stopWatch.Stop();
            ShowResult("duration operation division ArrayList");

        }

        static void ShowResult(string collictionName) {
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine($"{collictionName} = {elapsedTime}");
            stopWatch.Reset();
        }
    }
}
