using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLX.Robot.Kuka.Controller;
using System.Threading;

namespace WindowsFormsApplication2
{
    public class Class_Mouse
    {
        static TDx.TDxInput.Device device = null;
        static Class_Kuka_Manager my_kuka;
        static Thread myThread;
        static bool start = true;
        static int Nb_Mouvement = 0;
        static bool teaching = false;
        static bool Position_Bras = false;
        static bool debugSouris = true;
        TDx.TDxInput.Vector3D translation;
        TDx.TDxInput.AngleAxis rotation;

        // Constructeur de la Class_Mouse où on récupère l'instance de la Class_Kuka_Manager que l'on va utiliser
        public Class_Mouse(Class_Kuka_Manager kuka)
        {
            my_kuka = kuka;
            myThread = new Thread(new ThreadStart(Loop_Mouse));
            //translation = new TDx.TDxInput.Vector3D();
            //rotation = new TDx.TDxInput.AngleAxis();
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
            }
            else if (translation.X < -500)
            {
                translation.Y = 0;
                translation.Z = 0;
            }
            else if (translation.Y > 500)
            {
                translation.X = 0;
                translation.Z = 0;
            }
            else if (translation.Y < -500)
            {
                translation.X = 0;
                translation.Z = 0;
            }
            else if (translation.Z > 500)
            {
                translation.X = 0;
                translation.Y = 0;
            }
            else if (translation.Z < -500)
            {
                translation.X = 0;
                translation.Y = 0;
            }
            return translation;
        }

        public TDx.TDxInput.AngleAxis Supprimer_Bruit_Rotation(TDx.TDxInput.AngleAxis rotation)
        {
            if (rotation.X > 0.1)
            {
                rotation.Y = 0;
                rotation.Z = 0;
            }
            else if (rotation.X < -0.1)
            {
                rotation.Y = 0;
                rotation.Z = 0;
            }
            else if (rotation.Y > 0.1)
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
            }
            else if (rotation.Z < -0.1)
            {
                rotation.X = 0;
                rotation.Y = 0;
            }
            return rotation;
        }

        public void stopLoopMouse()
        {
            start = false;
        }
        public void Loop_Mouse()
        {
            my_kuka.StartMotion();
            start = true;
            while (start)
            {


                if (device != null)
                {
                    translation = device.Sensor.Translation;
                    rotation = device.Sensor.Rotation;


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
                }
                Thread.Sleep(10);

            }
            my_kuka.StopMotion();
            //Choix_Mode();

        }

        public void connectMouse()
        {
            if (!debugSouris)
            {
                device = new TDx.TDxInput.Device();
                device.Connect();
            }
        }

        // Fonction permettant de récupérer les données de mouvement de la souris
        public void Data_Mouse()
        {
            device = new TDx.TDxInput.Device();
            device.Connect();

            if (debugSouris == false)
            {
                myThread = new Thread(new ThreadStart(Loop_Mouse));
                debugSouris = true;
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
            while (tamere)
            {
                //var key = Console.ReadKey();

                //Console.WriteLine(" key : " + key.KeyChar);

                /*switch (key.KeyChar)
                {
                    case '1':
                        Console.WriteLine("Apprendre un point à Kuka");
                        Data_Mouse();
                        if (myThread.IsAlive)
                        {
                            myThread.Join();
                            debugSouris = false;
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
                            debugSouris = false;
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
                }*/
            }
        }
    }
}


