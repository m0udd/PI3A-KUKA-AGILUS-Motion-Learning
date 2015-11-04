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

            while (start)
            {
                var translation = device.Sensor.Translation;
                var rotation = device.Sensor.Rotation;

                // Appel des fonctions de suppression des bruits
                translation = Suppimmer_Bruit_Translation(translation);
                rotation = Supprimer_Bruit_Rotation(rotation);

                // diviser translation pour normaliser les valeurs à envoyer au Kuka
                // ces valeurs sont déterminer manuellement par l'appel du min et du max. NORMALISATION
                translation.X = translation.X / 2729;
                translation.Y = translation.Y / 2832;
                translation.Z = translation.Z / 2815;

                Console.WriteLine("Translation : " + translation.X + ";" + translation.Y + ";" + translation.Z);
                Console.WriteLine("Rotation : " + rotation.X + ";" + rotation.Y + ";" + rotation.Z);

                // On appelle la fonction Move de la Class_Kuka_Manager

                my_kuka.Kuka_Move(translation, rotation);
                
                Thread.Sleep(50);
            }
             my_kuka.StopMotion();
        }

        // Fonction permettant de récupérer les données de mouvement de la souris
        public void Data_Mouse()
        {
            device = new TDx.TDxInput.Device();
            device.Connect();

            // je démarre le thread réalisant la boucle de manipulation de la souris.
            myThread.Start();

        }


        public void Choix_Mode()
        {

            Console.WriteLine("Programm Start ....");

            Console.WriteLine("..... MENU.....");
            Console.WriteLine("[1] : Move the Kuka ");
            Console.WriteLine("[2] : Execute mouvement");
            Console.WriteLine("[q] : Exit");

            var key = Console.ReadKey();

            Console.WriteLine(" key : " + key.KeyChar);

            switch (key.KeyChar)
            {
                case '1':
                    Console.WriteLine("Apprendre un point à Kuka");
                    Data_Mouse();
                    break;
                case '2':
                    Console.WriteLine("Execution des points enregistré");
                    break;
                case 'q':
                    Console.WriteLine("Wait to End....");
                    break;
            }

            Console.WriteLine("Programm End, press a key to exit....");
            Console.ReadKey();

        }
    }
}


