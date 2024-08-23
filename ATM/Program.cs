using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Atm a = new Atm();
            a.WelcomeMsg();
            Console.ReadLine();
        }
    }
}
