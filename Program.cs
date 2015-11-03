using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using TDx.TDxInput;
using NLX.Robot.Kuka.Controller;

namespace ConsoleApplication1
{
    class Program
    {
        // Cette méthode est appelé lors du lancement du thread
        public static void ThreadLoop()
        {
            double x, y, z;
            RobotController robot = new RobotController();
            List<CartesianPosition> position = new List<CartesianPosition>();

            robot.Connect("192.168.1.1");

            // Tant que le thread n'est pas tué, on travaille
            while (Thread.CurrentThread.IsAlive)
            {
                x = robot.GetCurrentPosition().X;
                y = robot.GetCurrentPosition().Y;
                z = robot.GetCurrentPosition().Z;

                Console.WriteLine("position x : " + x + ", position y : " + y + ", position z : " + z);

                    /*position.Add(new CartesianPosition
                    {
                        X = x + i,
                        Y = y + i,
                        Z = z + i,

                    });
                }
                robot.PlayTrajectory(position);*/

                Console.WriteLine("Thread en cours...");
                Thread.Sleep(500);
            }
        }


        static void Main(string[] args)
        {
            // Déclaration du thread
            Thread myThread = new Thread(new ThreadStart(ThreadLoop));

            // Lancement du thread
            myThread.Start();
            
           
        }
    }
}
