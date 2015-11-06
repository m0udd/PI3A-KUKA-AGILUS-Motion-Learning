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
        XMLManager xml = new XMLManager();
        List<XMLManager.Target> ListOfTarget = new List<XMLManager.Target>();


        // gripper à false = OUVERT
        bool Status_Gripper = false;
        RobotController robot = null;
        bool debug = true;
        int MIN_X = 490 ;
        int MAX_X = 950;
        int MIN_Y = -500;
        int MAX_Y = 650;
        int MIN_Z = 90;
        int MAX_Z = 700;

        // Constructeur permettant de ce connecter au robot
        public Class_Kuka_Manager()
        {
            if (debug)
            {
                robot = new RobotController();
                try
                {
                    robot.Connect("192.168.1.1");
                    Console.WriteLine("connected");
                }
                catch (IOException e)
                {
                    Console.WriteLine(e);
                }
            }

        }

        public void Close_Connection()
        {
            if (debug){
                // voir s'il existe une fonction pour disconnect le robot
            }
            else
            {
                Console.WriteLine("je me déconnect du robot");
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
                Gripper = false;
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
                Gripper = true;
            }
            else
            {
                Console.WriteLine("Je ferme la pince");
            }           
        }

        public void Save_Point()
        {
            xml.addPoints(ListOfTarget);
        }

        public void Enregistrer_Point()
        {

            if (debug)
            {
                XMLManager.Target tmp = new XMLManager.Target();

                var position = robot.GetCurrentPosition();
                tmp.x = position.X;
                tmp.y = position.Y;
                tmp.z = position.Z;
                tmp.a = position.A;
                tmp.b = position.B;
                tmp.c = position.C;
                tmp.gripperState = robot.IsGripperOpen();

                ListOfTarget.Add(tmp);

            }
            else
            {
                Console.WriteLine("Je suis dans la fonction me permettant d'enregistrer le point");
            }
        }

        //public void Near_Piece()
        //{
        //    List<CartesianPosition> position = new List<CartesianPosition>();
        //    position.Add(new CartesianPosition
        //    {
        //        X = 512.07,
        //        Y = 145.51,
        //        Z = 214.84,
        //        A = -83.86,
        //        B = -79.63,
        //        C = -1.77,
        //    });

        //    if (debug)
        //    {
        //        robot.PlayTrajectory(position);
        //    }
        //    else
        //    {
        //        Console.WriteLine(" je prend la piece");
        //    }
        //}

        //public void Pick_Up_Piece()
        //{
        //    List<CartesianPosition> position = new List<CartesianPosition>();
        //    position.Add(new CartesianPosition
        //    {
        //        X = 512.07,
        //        Y = 232.50,
        //        Z = 214.84,
        //        A = -83.86,
        //        B = -79.63,
        //        C = -1.77,
        //    });

        //    if (debug)
        //    {
        //        robot.PlayTrajectory(position);
        //        Close_Gripper();
        //    }
        //    else
        //    {
        //        Console.WriteLine(" je prend la piece");
        //    }           
        //}

        //public void Up_Piece()
        //{
        //    List<CartesianPosition> position = new List<CartesianPosition>();
        //    position.Add(new CartesianPosition
        //    {
        //        X = 512.07,
        //        Y = 232.50,
        //        Z = 460.29,
        //        A = -83.86,
        //        B = -79.63,
        //        C = -1.77,
        //    });
        //    if (debug)
        //    {
        //        robot.PlayTrajectory(position);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Je suis en position");
        //        Console.WriteLine(position);
        //    }
        //}

        //public void Pose_Piece()
        //{
        //    List<CartesianPosition> position = new List<CartesianPosition>();
        //    position.Add(new CartesianPosition
        //    {
        //        X = 937.01,
        //        Y = -265.49,
        //        Z = 100.69,
        //        A = -95.68,
        //        B = 2.19,
        //        C = -89.63,
        //    });
        //    if (debug)
        //    {
        //        robot.PlayTrajectory(position);
        //    }
        //    else
        //    {

        //    }
        //}

        //public void Up_Pose_Piece()
        //{
        //    List<CartesianPosition> position = new List<CartesianPosition>();
        //    position.Add(new CartesianPosition
        //    {
        //        X = 937.01,
        //        Y = -265.49,
        //        Z = 500.69,
        //        A = -95.68,
        //        B = 2.19,
        //        C = -89.63,
        //    });
        //    if (debug)
        //    {
        //        robot.PlayTrajectory(position);
        //    }
        //    else
        //    {

        //    }
        //}

        public void Execute_Move(XMLManager.Target List)
        {
            if (debug)
            {
                List<CartesianPosition> position = new List<CartesianPosition>();
                position.Add(new CartesianPosition
                {
                    X = List.x,
                    Y = List.y,
                    Z = List.z,
                    A = List.a,
                    B = List.b,
                    C = List.c,
                });

                robot.PlayTrajectory(position);
                if (List.gripperState)
                {
                    Close_Gripper();
                    Status_Gripper = true;

                }
                else
                {
                    Open_Gripper();
                    Status_Gripper = true;
                }

            }
            else
            {

            }
        }

        public void Mode_Move()
        {
            if (debug)
            {
                //Open_Gripper();
                //Near_Piece();
                //Pick_Up_Piece();
                //Up_Piece();
                //Up_Pose_Piece();

                /*
                position.Add(new CartesianPosition
                {
                    X = 937.01,
                    Y = -265.49,
                    Z = 100.69,
                    A = -95.68,
                    B = 2.19,
                    C = -89.63,
                });
                robot.PlayTrajectory(position);
                */


                List<XMLManager.Target> List = xml.GetAllPoints();
                for(int i = 0; i < List.Count; i++)
                {
                    Execute_Move(List[i]);
                }
               // for list.size do function Execute_Move(List[i])
               // dans Execute_Move stocker x,y,z,a,b,c dans un List CartesianPoint -> PlayTrajectorie et regarder si Gripper est ouvert ou fermé et faire en conséquence le bon code

            }
            else
            {
                Console.WriteLine("Mode move");
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
