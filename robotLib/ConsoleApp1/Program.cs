using RobotLibrary;
using System;
using System.Threading;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Robot robot1 = new Robot("Robot 1", 200, 199);
            Robot robot2 = new Robot("Robot 2", 200, 199);

            for (int i = 0; i < 5; i++)
            {
                robot1.StartMoving();
                robot2.StartMoving();

                Console.WriteLine(robot1.GetInfo());
                Console.WriteLine(robot2.GetInfo());
                Console.WriteLine("");

                Thread.Sleep(2000);
            }
        }
    }
}