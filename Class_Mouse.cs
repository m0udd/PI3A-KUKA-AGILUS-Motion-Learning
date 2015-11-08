using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLX.Robot.Kuka.Controller;
using System.Threading;

namespace Projet_Kuka
{
    class Class_Mouse
    {
        static TDx.TDxInput.Device device;
        static Class_Kuka_Manager my_kuka;
        static bool start = true;
        static Thread myThread;
        static int Nb_Mouvement = 0;
        static bool teaching = false;
        static bool Position_Bras = false;

        static bool coucou = true;

        // Constructeur de la Class_Mouse où on récupère l'instance de la Class_Kuka_Manager que l'on va utiliser
        public Class_Mouse(Class_Kuka_Manager kuka)
        {
            my_kuka = kuka;
            myThread = new Thread(new ThreadStart(Loop_Mouse));
        }

        ~Class_Mouse()
        {
            if (myThread.IsAlive)
            {
                myThread.Join();
            }
        }

        public TDx.TDxInput.Vector3D Suppimmer_Bruit_Translation(TDx.TDxInput.Vector3D translation)
        {
            if (translation.X > 500)
            {
                translation.Y = 0;
                translation.Z = 0;
            }else if(translation.X < -500)
            {
                translation.Y = 0;
                translation.Z = 0;
            }else if(translation.Y > 500)
            {
                translation.X = 0;
                translation.Z = 0;
            }else if(translation.Y < -500)
            {
                translation.X = 0;
                translation.Z = 0;
            }else if(translation.Z > 500)
            {
                translation.X = 0;
                translation.Y = 0;
            }else if(translation.Z < -500)
            {
                translation.X = 0;
                translation.Y = 0;
            }
            return translation;
        }

        public TDx.TDxInput.AngleAxis Supprimer_Bruit_Rotation(TDx.TDxInput.AngleAxis rotation)
        {
            if(rotation.X > 0.1)
            {
                rotation.Y = 0;
                rotation.Z = 0;
            }else if(rotation.X < -0.1)
            {
                rotation.Y = 0;
                rotation.Z = 0;
            }else if(rotation.Y > 0.1)
            {
                rotation.X = 0;
                rotation.Z = 0;
            }
            else if (rotation.Y < -0.1)
            {
                rotation.X = 0;
                rotation.Z = 0;
            }
            else if (rotation.Z > 0.1)
            {
                rotation.X = 0;
                rotation.Y = 0;
            }else if(rotation.Z < -0.1)
            {
                rotation.X = 0;
                rotation.Y = 0;
            }
            return rotation;
        }


        public void Loop_Mouse()
        {
            my_kuka.StartMotion();
            start = true;
            while (start)
            {
                if (Position_Bras)
                {
                    teaching = true;
                    switch (Nb_Mouvement)
                    {
                        case 0:
                            Console.WriteLine("ALLEZ PRENDRE LA PIECE");
                            Position_Bras = false;
                            my_kuka.Save_Position();
                            //Data_Mouse();
                            break;
                        case 1:
                            Console.WriteLine("ALLEZ PREMIERE POSITION");
                            Position_Bras = false;
                            my_kuka.Save_Position();
                            //start = true;
                            //Data_Mouse();

                            break;
                        case 2:
                            Console.WriteLine("ALLEZ SECONDE POSITION");
                            Position_Bras = false;
                            my_kuka.Save_Position();
                            //start = true;
                            // Data_Mouse();
                            break;
                        case 3:
                            Console.WriteLine("ALLEZ TROISIEME POSITION");
                            Position_Bras = false;
                            my_kuka.Save_Position();
                            //start = true;
                            //Data_Mouse();
                            break;
                        case 4:
                            Console.WriteLine("FIN TEACHING");
                            Position_Bras = false;
                            start = false;
                            Nb_Mouvement = 0;
                            teaching = false;
                            my_kuka.Teaching();
                            //Choix_Mode();

                            break;
                        default:
                            Console.WriteLine("Erreur...");
                            Console.WriteLine(Nb_Mouvement);
                            break;
                    }
                }

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    switch (key.Key)
                    {
                        case ConsoleKey.A:
                            Console.WriteLine("J'enregiste le point");
                            if (teaching)
                            {
                                //start = false;
                                my_kuka.StopMotion();
                                Nb_Mouvement++;
                                my_kuka.Save_Position();
                                Position_Bras = true;
                                //Positionner_Bras();
                            }
                            else
                            {
                                my_kuka.Enregistrer_Point();
                            }
                            break;
                        case ConsoleKey.B:
                            Console.WriteLine("Demande ouverture pince");
                            my_kuka.StopMotion();
                            my_kuka.Open_Gripper();
                            my_kuka.StartMotion();
                            break;
                        case ConsoleKey.C:
                            Console.WriteLine("Demande de fermeture pince");
                            my_kuka.StopMotion();
                            my_kuka.Close_Gripper();
                            my_kuka.StartMotion();
                            break;
                        case ConsoleKey.D:
                            Console.WriteLine("Je quite la boucle");
                            start = false;
                            if (teaching)
                            {
                                //my_kuka.StopMotion();
                                //Nb_Mouvement++;
                                //my_kuka.Save_Position();
                                //Positionner_Bras();
                            }
                            else
                            {
                                my_kuka.Save_Point();
                            }

                            my_kuka.StopMotion();
                            //Choix_Mode();
                            //myThread.();
                            break;
                        default:
                            Console.WriteLine("Je ne connais pas la touche");
                            break;
                    }
                }
                else
                {
                    var translation = device.Sensor.Translation;
                    var rotation = device.Sensor.Rotation;

                    // Appel des fonctions de suppression des bruits
                    translation = Suppimmer_Bruit_Translation(translation);
                    rotation = Supprimer_Bruit_Rotation(rotation);

                    // diviser translation pour normaliser les valeurs à envoyer au Kuka
                    // ces valeurs sont déterminer manuellement par l'appel du min et du max. NORMALISATION
                    translation.X = -(translation.X / 2729) * 10;
                    translation.Y = (translation.Y / 2832) * 10;
                    translation.Z = -(translation.Z / 2815) * 10;

                    rotation.X = rotation.X * (rotation.Angle / 2062);
                    rotation.Y = rotation.Y * (rotation.Angle / 2062);
                    rotation.Z = rotation.Z * (rotation.Angle / 2062);



                    // Console.WriteLine("Translation : " + translation.X + ";" + translation.Y + ";" + translation.Z);
                    // Console.WriteLine("Rotation : " + rotation.X + ";" + rotation.Y + ";" + rotation.Z);

                    // On appelle la fonction Move de la Class_Kuka_Manager
                    my_kuka.Kuka_Move(translation, rotation);

                    Thread.Sleep(10);
                }

            }
            my_kuka.StopMotion();
            //Choix_Mode();
            
        }

        // Fonction permettant de récupérer les données de mouvement de la souris
        public void Data_Mouse()
        {
            device = new TDx.TDxInput.Device();
            device.Connect();

            if(coucou == false){
                myThread = new Thread(new ThreadStart(Loop_Mouse));
                coucou = true;
            }
            myThread.Start();
        }

 
        public void StartProgramm()
        {
            Console.WriteLine("Programm Start ....");

        }
        public void Choix_Mode()
        {
            bool tamere = true;
            while(tamere)
            { 
            Console.WriteLine("..... MENU.....");
            Console.WriteLine("[1] : Move the Kuka ");
            Console.WriteLine("[2] : Execute mouvement");
            Console.WriteLine("[3] : Procedure d'apprentissage");
            Console.WriteLine("[q] : Exit");

            var key = Console.ReadKey();

            Console.WriteLine(" key : " + key.KeyChar);

            switch (key.KeyChar)
            {
                case '1':
                    Console.WriteLine("Apprendre un point à Kuka");
                    Data_Mouse();
                    if (myThread.IsAlive)
                    {
                        myThread.Join();
                        coucou = false;
                        // Choix_Mode();
                    }
                    break;

                case '2':
                    Console.WriteLine("Execution des points enregistré");
                    my_kuka.Mode_Move();
                    //Choix_Mode();
                    break;
                case '3':
                    Console.WriteLine("Execution apprentissage, appuyer sur la touche 1 pour enregistrer les points");
                    Position_Bras = true;
                    Data_Mouse();
                    if (myThread.IsAlive)
                    {
                        myThread.Join();
                        coucou = false;
                        // Choix_Mode();
                    }
                        //  Positionner_Bras();
                        break;
                case 'q':
                        tamere = false;
                    Console.WriteLine("Programm End, press a key to exit....");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Key non reconnue");
                    break;
            }
            }
        }
    }
}


