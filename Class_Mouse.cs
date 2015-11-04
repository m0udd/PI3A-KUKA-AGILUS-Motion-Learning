using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLX.Robot.Kuka.Controller;

namespace Projet_Kuka
{
    class Class_Mouse
    {
        static TDx.TDxInput.Device device;
        static Class_Kuka_Manager my_kuka;

        // Constructeur de la Class_Mouse où on récupère l'instance de la Class_Kuka_Manager que l'on va utiliser
        public Class_Mouse(Class_Kuka_Manager kuka)
        {
            my_kuka = kuka;
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

        // Fonction permettant de récupérer les données de mouvement de la souris
        public void Data_Mouse()
        {
            Console.WriteLine("Programm Start ....");

            device = new TDx.TDxInput.Device();
            device.Connect();
            bool test = true;

            //my_kuka.Start();

            while (test)
            {
                var translation = device.Sensor.Translation;
                var rotation = device.Sensor.Rotation;



                // Appel des fonctions de suppression des bruits
                translation = Suppimmer_Bruit_Translation(translation);
                rotation = Supprimer_Bruit_Rotation(rotation);

                // diviser translation pour normaliser les valeurs à envoyer au Kuka
                // ces valeurs sont déterminer manuellement par l'appel du min et du max.
                translation.X = translation.X / 2729;
                translation.Y = translation.Y / 2832;
                translation.Z = translation.Z / 2815;

                Console.WriteLine("Translation : " + translation.X + ";" + translation.Y + ";" + translation.Z);
                Console.WriteLine("Rotation : " + rotation.X + ";" + rotation.Y + ";" + rotation.Z);



                // On appelle la fonction Move de la Class_Kuka_Manager

                //my_kuka.Kuka_Move(translation, rotation);
                //Console.WriteLine(" j'ai bougé");

                System.Threading.Thread.Sleep(50);
            }

            Console.WriteLine("Programm End, press a key to exit....");
            Console.ReadKey();
            my_kuka.Stop();
        }
    }
}


