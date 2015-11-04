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

        // Constructeur permettant de ce connecter au robot
        public Class_Kuka_Manager()
        {
            if (debug)
            {
                robot = new RobotController();
                try
                {
                    robot.Connect("192.168.1.1");
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


        // Fonction permettant d'utiliser les translations et rotations de la souris et de les envoyer au Kuka
        public void Kuka_Move(TDx.TDxInput.Vector3D translation, TDx.TDxInput.AngleAxis rotation)
        {

            if (debug)
            {
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
