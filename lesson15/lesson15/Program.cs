using System;
using System.Collections.Generic;

namespace lesson15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Quadcopter robot1 = new Quadcopter();
            IFlyingRobot robot2 = new Quadcopter();
            IRobot robot3 = new Quadcopter();

            Console.WriteLine("robot1 Charge");
            robot1.Charge(); 
            Console.WriteLine("robot1 GetInfo" + robot1.GetInfo());
            
            foreach (var item in robot1.GetComponents())
            {
                Console.WriteLine("robot1 GetComponents" + item);
            }

            Console.WriteLine("robot2 RobotType" + robot2.GetRobotType());
            Console.WriteLine("robot3 RobotType" + robot3.GetRobotType());

        }

        public interface IRobot 
        {
            string GetInfo();
            List<string> GetComponents();
            string GetRobotType()
            {
                return "I am a simple robot";
            }
        }

        public interface IChargeable {
            void Charge();
            string GetInfo();
        }

        public interface IFlyingRobot : IRobot
        {
           new string GetRobotType() 
            {
                return "I am a flying robot";
            }
        }

        public class Quadcopter : IFlyingRobot, IChargeable 
        {
            List<string> _components = new List<string> { "rotor1", "rotor2", "rotor3", "rotor4" };
            public List<string> GetComponents()
            {
                return _components;
            }

            public string GetInfo()
            {
                return "Robot version 26.1.964054";
            }

            public void Charge() {

                Console.WriteLine("Charging...");
                Thread.Sleep(3000);
                Console.WriteLine("Charged!");
            }
        }
    }
}
