﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.CompilerServices;
using System.Net.Http.Headers;

namespace CodFisc
{
    
    public class CodFisc
    {
        private const string VOCALI = "aeiouAEIOU";

        public string Cognome { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascita { get; set; }
        public char Sesso { get; set; }
        public string Luogo { get; set; }

        public CodFisc(string cognome, string nome, DateTime dataNascita, char sesso, string luogo)
        {
            this.Cognome = cognome;
            this.Nome = nome;
            this.DataNascita = dataNascita;
            this.Sesso = sesso;
            this.Luogo = luogo;
        }

        private void DividiConsVoc(ref string parteC, ref string parteV, string cogNom)
        {
            cogNom = cogNom.Replace(" ", "");
            cogNom = cogNom.Replace("'", "");

            for (int i = 0; i < cogNom.Length; i++)
            {
                char c = cogNom[i];
                if (!VOCALI.Contains(c))
                {
                    parteC += c;
                }
                else
                {
                    parteV += c;
                }
            }
        }

        private string RestParte(string consonanti, string vocali)
        {
            string parte;

            parte = consonanti + vocali;
            parte = parte.PadRight(3, 'X');

            return parte.Substring(0, 3).ToUpper();
        }

        public string CreaParteCogn()
        {
            string parteConsonante = string.Empty;
            string parteVocale = string.Empty;

            DividiConsVoc(ref parteConsonante, ref parteVocale, Cognome);
            
            return RestParte(parteConsonante, parteVocale);
        }

        public string CreaParteNome()
        {
            string parteConsonante = string.Empty;
            string parteVocale = string.Empty;
            int l;

            DividiConsVoc(ref parteConsonante, ref parteVocale, Nome);

            l = parteConsonante.Length;

            if (l >= 4)
            {
                parteConsonante =($"{parteConsonante.Substring(0, 1)}{parteConsonante.Substring(2, 1)}{parteConsonante.Substring(3, 1)}");
                return parteConsonante.ToUpper();
            }
            
            return RestParte(parteConsonante, parteVocale);
        }

        public string CreaParteData()
        {
            string parteData;
            char[] codMese = new char[] { 'A', 'B', 'C', 'D', 'E', 'H', 'L', 'M', 'P', 'R', 'S', 'T' };
            byte indMese;
            byte indGiorno;

            indMese =byte.Parse(DataNascita.ToString("MM"));
            indGiorno = byte.Parse(DataNascita.ToString("dd"));

            if (this.Sesso == 'F')
            {
                indGiorno += 40;
            }

            parteData = DataNascita.ToString("yy") + codMese[indMese - 1] + indGiorno.ToString().PadLeft(2,'0');

            return parteData;
        }

        public string CreaParteLuogo()
        {
            string [] lines;
            
            try
            {
                lines = File.ReadAllLines(@"C:\prg\c#\CodFisc\listacomuni.txt");
            }

            catch
            {
                Console.WriteLine("Errore");
                return "Errore";
            }

            foreach (string line in lines)
            {
                if (line.Contains(Luogo+";"))
                {
                    string[] subs = line.Split(';');
                    return subs[6];                 
                }
            }
            return $"Comune {Luogo} non trovato";
        }

        private short ParDispPar(string[] car,int p)
        {
            string cF = $"{this.CreaParteCogn()}{this.CreaParteNome()}{this.CreaParteData()}{this.CreaParteLuogo()}";
            short parametro = 0;    

            for(int i=p;i<cF.Length;i+=2)
            {
                foreach (string d in car)
                {
                    if (d.Contains(cF[i] + ";"))
                    {
                        parametro += Convert.ToInt16(d.Substring(d.IndexOf(";") + 1));
                    }
                }
            }
            return parametro;
        }

        public string CreaCin()
        {
            int codCin;
            string[] carDisp;
            string[] carPar;
            string[] resto;
            
            try
            {
                carDisp = File.ReadAllLines(@"C:\prg\c#\CodFisc\CaratAlfaDispari.txt");
                carPar = File.ReadAllLines(@"C:\prg\c#\CodFisc\CaratAlfaPari.txt");
                resto = File.ReadAllLines(@"C:\prg\c#\CodFisc\Resto.txt");
            }

            catch (Exception e)
            {
                Console.WriteLine("Errore: " + e.Message);
                return "Errore";
            }
            
            codCin = (ParDispPar(carPar,1) + ParDispPar(carDisp,0))%26;
            byte i = 0;

            string [] r=new string[26];

            foreach(string d in resto)
            {
                r[i]= d.Substring(d.IndexOf(";")+1);
                i++;
            }

            return r[codCin];
        }
    }
}
