using System;

namespace CodFisc
{
    class Program
    {
        static void Main(string[] args)
        {
            CodFisc c = new CodFisc("Luongo", "Roberto", new DateTime(1968,06,01),'M', "Pozzuoli");
           
            Console.WriteLine("Parte Cognome {0}", c.CreaParteCogn());
            Console.WriteLine("Parte Nome {0}", c.CreaParteNome());
            Console.WriteLine("Parte data {0}",c.CreaParteData());
            //Console.WriteLine(c.CreaParteLuogo());
            Console.WriteLine($"Codice fiscale: {c.CreaParteCogn()}{c.CreaParteNome()}{c.CreaParteData()}{c.CreaParteLuogo()}");
            Console.WriteLine("Hello World!");
        }
    }
}
