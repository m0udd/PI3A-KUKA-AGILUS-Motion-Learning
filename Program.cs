using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Projet_Kuka
{
    class Program
    {
        static void Main(string[] args)
        {
            Class_Mouse mouse;
            Class_Kuka_Manager kuka;

            kuka = new Class_Kuka_Manager();

            mouse = new Class_Mouse(kuka);

            mouse.Data_Mouse();
        }
    }
}
