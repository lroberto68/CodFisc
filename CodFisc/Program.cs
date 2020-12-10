using System;

namespace CodFisc
{
    class Program
    {
        static void Main(string[] args)
        {
            CodFisc c = new CodFisc("Luongo","Roberto");
           
            Console.WriteLine("Parte Cognome {0}", c.CreaParteCogn());
            Console.WriteLine("Parte Nome {0}", c.CreaParteNome());
            Console.WriteLine($"Codice fiscale: {c.CreaParteCogn()}{c.CreaParteNome()}");
            Console.WriteLine("Hello World!");
        }
    }
}
