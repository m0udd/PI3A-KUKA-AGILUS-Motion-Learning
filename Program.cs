using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDx.TDxInput;
using NLX.Robot.Kuka.Controller;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            double x, y, z;
            RobotController robot = new RobotController();
            List<CartesianPosition> position = new List<CartesianPosition>();

            try{
                robot.Connect("192.168.1.1");
            }
            catch(IOExeception e){
                Console.WriteLine(e);
            }

            for (int i=0; i<100; i++){
                x = robot.GetCurrentPosition().X;
                y = robot.GetCurrentPosition().Y;
                z = robot.GetCurrentPosition().Z;

                Console.WriteLine("position x : " + x + ", position y : " + y + ", position z : " + z);

                position.Add(new CartesianPosition
                {
                    X = x + i,
                    Y = y + i,
                    Z = z + i,

                });
            }
            robot.PlayTrajectory(position);
        }
    }
}
