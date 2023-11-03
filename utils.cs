using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluculeseiAndrei3131b
{
    public class utils
    {
        public void helpLab2 ()
        {
            Console.WriteLine("Deplasare la stanga se face cu butonul 'A' !!!!");
            Console.WriteLine("Deplasare la dreapta se face cu butonul 'D' !!!!");

        }

        public void helpLab3()
        {
            Console.WriteLine("Apasati c pentru a schimba culoarea");
        }

        public void meniu()
        {
            Console.WriteLine("Alegeti laboratorul pe care doriti sa il vedeti : \n" +
                "1.Laboratorul 1\n" +
                "2.Laboratorul 2(TRIUNGHI CARE SCHIMBA CULOAREA)\n" +
                "3.Va urma ");
            Console.WriteLine("Introduceti un numar intreg ca optiune : ");
        }
    }
}
