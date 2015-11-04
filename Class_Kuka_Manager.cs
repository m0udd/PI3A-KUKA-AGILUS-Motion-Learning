using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NLX.Robot.Kuka.Controller;


namespace Projet_Kuka
{
    class Class_Kuka_Manager
    {
        RobotController robot = null;
        bool debug = false;
        int MIN_X = 490 ;
        int MAX_X = 950;
        int MIN_Y = -50;
        int MAX_Y = 650;
        int MIN_Z = 90;
        int MAX_Z = 540;

        // Constructeur permettant de ce connecter au robot
        public Class_Kuka_Manager()
        {
            if (debug)
            {
                robot = new RobotController();
                try
                {
                    robot.Connect("192.168.1.1");
                    Console.WriteLine("coonected");
                }
                catch (IOException e)
                {
                    Console.WriteLine(e);
                }
            }

        }

        // Fonction pour Start la connexion avec le Kuka
        public void StartMotion()
        {
            if (debug)
            {
                robot.StartRelativeMovement();
            }

        }

        // Fonction pour Stopper la connexion avec le Kuka
        public void StopMotion()
        {
            if (debug)
            {
                robot.StopRelativeMovement();
            }

        }

        public bool Is_Valid_Target(CartesianPosition Position)
        {

            var Current_Position = robot.GetCurrentPosition();
            CartesianPosition New_Position = new CartesianPosition();

            if (Position.X + Current_Position.X >= MAX_X)
            {
                return false;
            } else if (Position.X + Current_Position.X <= MIN_X) {

                return false;
            } else if (Position.Y + Current_Position.Y >= MAX_Y)
            {
                return false;
            }
            else if (Position.Y + Current_Position.Y <=  MIN_Y)
            {
                return false;
            }
            else if (Position.Z + Current_Position.Z >= MAX_Z)
            {
                return false;
            }
            else if (Position.Z + Current_Position.Z <= MIN_Z)
            {
                return false;
            }
            else
            {
                return true;
            }
        } 

        public void Open_Gripper()
        {
            if (debug)
            {
                robot.OpenGripper();
            }
            else
            {
                Console.WriteLine("J'ouvre la pince");
            }
           
        }

        public void Close_Gripper()
        {
            if (debug)
            {
                robot.CloseGripper();
            }
            else
            {
                Console.WriteLine("Je ferme la pince");
            }           
        }

        public void Enregistrer_Point()
        {
            if (debug)
            {

            }else
            {
                Console.WriteLine("Je suis dans la fonction me permettant d'enregistrer le point");
            }
        }


        // Fonction permettant d'utiliser les translations et rotations de la souris et de les envoyer au Kuka
        public void Kuka_Move(TDx.TDxInput.Vector3D translation, TDx.TDxInput.AngleAxis rotation)
        {

            if (debug)
            {
                Console.WriteLine("je suis dans kuka move");
                var Position = (new CartesianPosition
                {
                    X = translation.X,
                    Y = translation.Y,
                    Z = translation.Z,
                    A = rotation.X,
                    B = rotation.Y,
                    C = rotation.Z,
                });
                Console.WriteLine(Position.X + " ; " + Position.Y + " ; " + Position.Z);

                // on envoi ces valeurs au Kuka

                robot.SetRelativeMovement(Position);
            }
            // on recupere les valeurs des translations et rotations de la souris 3D

        }
    }
}
