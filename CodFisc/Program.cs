using System;

namespace CodFisc
{
    class Program
    {
        static void Main(string[] args)
        {
            CodFisc c = new CodFisc("Cicale", "Assunta", new DateTime(1939,03,07),'F', "Pozzuoli");
           
            Console.WriteLine("Parte Cognome {0}", c.CreaParteCogn());
            Console.WriteLine("Parte Nome {0}", c.CreaParteNome());
            Console.WriteLine("Parte data {0}",c.CreaParteData());
            Console.WriteLine("Parte Luogo {0}",c.CreaParteLuogo());
            Console.WriteLine("Parte CIN {0}",c.CreaCin());
            Console.WriteLine($"Codice fiscale: {c.CreaParteCogn()}{c.CreaParteNome()}{c.CreaParteData()}{c.CreaParteLuogo()}{c.CreaCin()}");
            Console.WriteLine("Hello World!");
        }
    }
}
