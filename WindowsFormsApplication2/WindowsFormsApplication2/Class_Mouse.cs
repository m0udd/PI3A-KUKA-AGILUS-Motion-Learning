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

        static bool Mode = false;
        bool pince = false;
        static bool thread_Alive = true;

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
            if (translation.X > 1000)
            {
                translation.Y = 0;
                translation.Z = 0;
            }
            else if (translation.X < -1000)
            {
                translation.Y = 0;
                translation.Z = 0;
            }
            else if (translation.Y > 1000)
            {
                translation.X = 0;
                translation.Z = 0;
            }
            else if (translation.Y < -1000)
            {
                translation.X = 0;
                translation.Z = 0;
            }
            else if (translation.Z > 1000)
            {
                translation.X = 0;
                translation.Y = 0;
            }
            else if (translation.Z < -1000)
            {
                translation.X = 0;
                translation.Y = 0;
            }
            return translation;
        }

        public TDx.TDxInput.AngleAxis Supprimer_Bruit_Rotation(TDx.TDxInput.AngleAxis rotation)
        {
            if (rotation.X > 0.5)
            {
                rotation.Y = 0;
                rotation.Z = 0;
            }
            else if (rotation.X < -0.5)
            {
                rotation.Y = 0;
                rotation.Z = 0;
            }
            else if (rotation.Y > 0.5)
            {
                rotation.X = 0;
                rotation.Z = 0;
            }
            else if (rotation.Y < -0.5)
            {
                rotation.X = 0;
                rotation.Z = 0;
            }
            else if (rotation.Z > 0.5)
            {
                rotation.X = 0;
                rotation.Y = 0;
            }
            else if (rotation.Z < -0.5)
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
    }
}


