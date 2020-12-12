﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CodFisc
{
    
    public class CodFisc
    {
        const string VOCALI = "aeiouAEIOU";

        public string Cognome { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascita { get; set; }
        public char Sesso { get; set; }

        public CodFisc(string cognome, string nome, DateTime dataNascita, char sesso)
        {
            this.Cognome = cognome;
            this.Nome = nome;
            this.DataNascita = dataNascita;
            this.Sesso = sesso;
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
            string parteData=string.Empty;
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
    }
}
