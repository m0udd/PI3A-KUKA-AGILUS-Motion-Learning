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
        List<CartesianPosition> list = new List<CartesianPosition>();

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
        public void Close_Connection()
        {
            Console.WriteLine("je me déconnect du robot");
        }

        // Fonction pour Start la connexion avec le Kuka
        public void StartMotion()
        {
            robot.StartRelativeMovement();
        }

        // Fonction pour Stopper la connexion avec le Kuka
        public void StopMotion()
        {
            robot.StopRelativeMovement();
        }


        // Vérifie si la position où l'on veut déplacer le robot est valide
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


        // Fonction pour ouvrir la pince
        public void Open_Gripper()
        {
            robot.OpenGripper();
            Status_Gripper = false;
        }


        // Fonction pour fermer la pince
        public void Close_Gripper()
        {
            robot.CloseGripper();
            Status_Gripper = true;         
        }


        // Fonction pour enregistrer dans un fichier XML l'ensemble des points sauvegardés
        public void Save_Point()
        {
            xml.addPoints(ListOfTarget);

            ListOfTarget.Clear();
        }


        // Fonction pour enregistrer un point dans la liste servant à la création du fichier XML
        public void Enregistrer_Point()
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

        // fonction permettant d'approcher du magasin pour prendre la piece
        public void Near_Magasin()
        {
            List<CartesianPosition> position = new List<CartesianPosition>();
            position.Add(new CartesianPosition
            {
                X = 512.07,
                Y = 145.51,
                Z = 214.84,
                A = -83.86,
                B = -79.63,
                C = -1.77,
            });

            robot.PlayTrajectory(position);
        }

        // fonction pour prendre la pièce dans le magasin
        public void Pick_Piece()
        {
            List<CartesianPosition> position = new List<CartesianPosition>();
            position.Add(new CartesianPosition
            {
                X = 512.07,
                Y = 232.50,
                Z = 214.84,
                A = -83.86,
                B = -79.63,
                C = -1.77,
            });

            robot.PlayTrajectory(position);
            Close_Gripper();
        }

        // fonction pour soulever la pièce pour la faire sortir du magasin
        public void Up_Piece()
        {
            List<CartesianPosition> position = new List<CartesianPosition>();
            position.Add(new CartesianPosition
            {
                X = 512.07,
                Y = 232.50,
                Z = 460.29,
                A = -83.86,
                B = -79.63,
                C = -1.77,
            });

            robot.PlayTrajectory(position);
        }

        // fonction pour poser la piece sur la première case du plateau
        public void Pose_Piece()
        {
            List<CartesianPosition> position = new List<CartesianPosition>();
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
        }


        // fonction pour ce mettre au dessus de la première case du plateau
        public void Up_Pose_Piece()
        {
            List<CartesianPosition> position = new List<CartesianPosition>();
            position.Add(new CartesianPosition
            {
                X = 937.01,
                Y = -265.49,
                Z = 500.69,
                A = -95.68,
                B = -12.19,
                C = -89.63,
            });
            robot.PlayTrajectory(position);
        }


        // execute le mouvement contenu dans lu dans le fichier XML 
        public void Execute_Move(XMLManager.Target List)
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

            Console.WriteLine(" je me déplace à : " + position[0].X + " ; " + position[0].Y + " ; " + position[0].Z + " ; " + position[0].A + " ; " + position[0].B + " ; " + position[0].C + " Gripper :  " + List.gripperState);
            robot.PlayTrajectory(position);

            // Console.WriteLine("j'ai bougé");
            if (List.gripperState)
            {
                //Close_Gripper();
                Open_Gripper();
                Status_Gripper = true;
            }
            else
            {
                //Open_Gripper();
                Close_Gripper();
                Status_Gripper = true;
            }
        }


        // on execute tous les mouvements lu dans un fichier XML, on appelle la fonction Execute_Move pour réaliser le mouvement
        public void Mode_Move()
        {           
            List<XMLManager.Target> List = xml.GetAllPoints();
            for(int i = 0; i < List.Count; i++)
            {
                Execute_Move(List[i]);
            }      
        }


        // fonction permettant de générer le fichier XML contenant toutes les coordonnées à exécuter par le programme.
        public void Points_XML_Generator(List<CartesianPosition> lp)
        {
            // (0) Point : Go to piece
            // (1) Point : position 0 on the plate (min X, min Y)
            // (2) Point : position 1 on the plate (max X, min Y)
            // (3) Point : position 3 on the plate (min X , max Y)
            // Motion = GOTO then Set gripper state
            // For the rest OG = Open gripper = false , CG = Close gripper = true

            // Generation

            double A1 = 88.67;
            double B1 = -0.01;
            double C1 = 90.93;

            
          

            List<XMLManager.Target> motionPoints = new List<XMLManager.Target>();

            // Get the Grid
            List<CartesianPosition> lsp = creationPlateau(lp);

            // GoTo near plate, CG
            AddPointToList(motionPoints, lsp[0].X, lsp[0].Y, lsp[0].Z + 400, A1, B1, C1, true);

            // Place the first piece (inside the gripper) to position [0], OG
            AddPointToList(motionPoints, lsp[0].X, lsp[0].Y, lsp[0].Z, A1, B1, C1, false);

            // GoTo near plate, OG
            AddPointToList(motionPoints, lsp[0].X, lsp[0].Y, lsp[0].Z + 400, A1, B1, C1, false);

            // Place piece
            for (int i = 1; i < 16; i++)
            {
                // GoTo near stock, OG
                AddPointToList(motionPoints, lp[0].X + 200, lp[0].Y, lp[0].Z + 200, lp[0].A, lp[0].B, lp[0].C, false);

                // GoTo stock, CG
                AddPointToList(motionPoints, lp[0].X, lp[0].Y, lp[0].Z, lp[0].A, lp[0].B, lp[0].C, true);

                // GoTo translate to take piece, CG
                AddPointToList(motionPoints, lsp[i].X, lsp[i].Y, lsp[i].Z + 100, lsp[i].A, lsp[1].B, lsp[i].C, true);

                // GoTo near plate (and piece), CG
                AddPointToList(motionPoints, lsp[i].X, lsp[i].Y, lsp[i].Z + 400, A1, B1, C1, true);

                // GoTo place piece (inside the gripper) to position [0], OG
                AddPointToList(motionPoints, lsp[i].X, lsp[i].Y, lsp[i].Z, A1, B1, C1, false);

                // GoTo near plate (and piece), CG
                AddPointToList(motionPoints, lsp[i].X, lsp[i].Y, lsp[i].Z + 400, A1, B1, C1, true);
            }

            xml.addPoints(motionPoints);
        }


        // fonction pour ajouter un nouveau point à la liste conçu spécialement pour le XML
        void AddPointToList(List<XMLManager.Target> motionPoints, double x, double y, double z, double a, double b, double c, bool gripperState)
        {
            XMLManager.Target tmp = new XMLManager.Target();
            tmp.x = x;
            tmp.y = y;
            tmp.z = z;
            tmp.a = a;
            tmp.b = b;
            tmp.c = c;
            tmp.gripperState = gripperState;

            motionPoints.Add(tmp);
        }


        // fonction permettant de déterminer tous les points du plateau pour pouvoir placer les pièces
        static List<CartesianPosition> creationPlateau(List<CartesianPosition> list)
        {
            int nbPointHauteur = 4;
            int nbPointLongueur = 4;

            List<CartesianPosition> listPoints = new List<CartesianPosition>();

           
                // calcul des 16 points du support
                // recuperation des coordonnees de l'origine du support
            double ptOrigine_X = list[1].X;
            double ptOrigine_Y = list[1].Y;
            double ptOrigine_Z = list[1].Z;

            double deltaX = Math.Abs(ptOrigine_X - list[2].X);
            double deltaY = Math.Abs(ptOrigine_Y - list[2].Y);
                // calcul angle en degre
            double Angle = Math.Atan2(deltaY, deltaX) * 180.0 / Math.PI;
            Console.WriteLine(Angle + " Degres");
            // conversion angle en radian
            Angle = Angle * (Math.PI / 180);
            Console.WriteLine(Angle + " Radiant");

                // Distance y et x
            double distX = Math.Sqrt(Math.Pow(list[2].X - ptOrigine_X, 2) + Math.Pow(list[2].Y - ptOrigine_Y, 2));
            double distY = Math.Sqrt(Math.Pow(list[3].X - ptOrigine_X, 2) + Math.Pow(list[3].Y - ptOrigine_Y, 2));
            Console.WriteLine("Distance X :" + distX + " Distance en Y :" + distY + "\n");


            for (int j = 0; j < nbPointHauteur; j++)
            {
                for (int i = 0; i < nbPointLongueur; i++)
                {
                        // Ajout du point a la liste
                    listPoints.Add(new CartesianPosition
                    {
                        X = -((distY * i * Math.Cos(Angle)) + (distX * j * Math.Sin(Angle))) / 3 + ptOrigine_X,
                        Y = ((distX * j * Math.Cos(Angle)) - (distY * i * Math.Sin(Angle))) / 3 + ptOrigine_Y,
                        Z = ptOrigine_Z,
                    });

                    double X = -((distY * i * Math.Cos(Angle)) + (distX * j * Math.Sin(Angle))) / 3 + ptOrigine_X;
                    double Y = ((distX * j * Math.Cos(Angle)) - (distY * i * Math.Sin(Angle))) / 3 + ptOrigine_Y;
                    Console.WriteLine(X + " ; " + Y);
                }
            }

            return listPoints;
        }


        // fonction qui enregistre la position actuelle du robot dans une liste
        public void Save_Position()
        {
            var position = robot.GetCurrentPosition();
            list.Add(new CartesianPosition
            {
                X = position.X,
                Y = position.Y,
                Z = position.Z,
                A = position.A,
                B = position.B,
                C = position.C,
            });
        }


        // methode qui appelle la fonction pour réaliser l'ensemble des points à executer par le fichier XML
        public void Teaching()
        {
            Points_XML_Generator(list);
        }

        // Fonction permettant d'utiliser les translations et rotations de la souris et de les envoyer au Kuka
        public void Kuka_Move(TDx.TDxInput.Vector3D translation, TDx.TDxInput.AngleAxis rotation)
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
               // Console.WriteLine(Position.X + " ; " + Position.Y + " ; " + Position.Z);
          
                // on envoi ces valeurs au Kuka
            robot.SetRelativeMovement(Position);
        }



        /*
        public void New_Up_Pose_Piece(double TX, double TY)
        {
            List<CartesianPosition> position = new List<CartesianPosition>();
            position.Add(new CartesianPosition
            {
                X = TX,
                Y = TY,
                Z = 500.69,
                A = -95.68,
                B = 2.19,
                C = -89.63,
            });

            robot.PlayTrajectory(position);    
        }

        public void New_Pose_Piece(double TX, double TY)
        {
            List<CartesianPosition> position = new List<CartesianPosition>();
            position.Add(new CartesianPosition
            {
                X = TX,
                Y = TY,
                Z = 150.00,  // valeur a modifier si elle est correcte
                A = -79.57,
                B = -10.65,
                C = -89.63,
            });

            robot.PlayTrajectory(position);
        }

        public void Deplacer_All_Piece()
        {
            int longueur = 0;
            int largeur = 0;
            double largeurX = -32.15;
            double largeurY = 38.26;
            double longueurX = -53.55;
            double longueurY = -44.68;

            double TX = 937.01;
            double TY = -265.49;

            while(longueur < 4)
            {

                TX = TX + (largeurX * largeur) + (longueurX * longueur);
                TY = TY + (largeurY * largeur) + (longueurY * longueur);

                Near_Magasin();
                Pick_Piece();
                Up_Piece();
                New_Up_Pose_Piece(TX, TY);
                New_Pose_Piece(TX, TY);
                New_Up_Pose_Piece(TX, TY);

                largeur++;

                if (largeur == 4)
                {
                    largeur = 0;
                    longueur++;
                }
            }
        }*/
    }
}



