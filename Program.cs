using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
namespace Program
{
    internal class Set3Ex17
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introdu un numar in baza int baza 10: ");
            double n = double.Parse(Console.ReadLine());

            Console.WriteLine("Introdu o baza in care vrei sa fie convertit numarul(1<b<17): ");
            int b = int.Parse(Console.ReadLine());

            if(b < 2 || b >17)
            {
                Console.WriteLine("Baza trebuie sa fie intre 2 si 16");
                return;
            }
            else
            {
                string rezultat = BaseTenToBaseB(n, b);
                Console.WriteLine($"Numarul {n} convertit in baza {b} este {rezultat}");
                
            }
        }
        static string BaseTenToBaseB(double n, int b)
        {
            if (n == 0)
            {
                return "0";
            }

            string cifre = "0123456789ABCDEF";
            int parteIntreaga = (int)Math.Floor(Math.Abs(n));
            double parteFractionara = Math.Abs(n)- parteIntreaga;
            string rezultatIntreg = "";
            while(parteIntreaga > 0)
            {
                int rest = parteIntreaga % b;
                rezultatIntreg = cifre[rest] + rezultatIntreg;
                parteIntreaga /= b;
            }
            if(rezultatIntreg == "")
            {
                rezultatIntreg = "0";
            }

            string rezultatFractionar = "";
            int precizieMaxima = 10;
            int contor = 0;
            while(parteFractionara > 0 && contor < precizieMaxima)
            {
                parteFractionara *= b;
                int cifra = (int)Math.Floor(parteFractionara);
                rezultatFractionar += cifre[cifra];
                parteFractionara -= cifra;
                contor++;
            }
            string rezultatFinal = (n<0 ? "-" : "") + rezultatIntreg;
            if(rezultatFractionar != "")
            {
                rezultatFinal += "." + rezultatFractionar;
            }
            return rezultatFinal;
        }
    }
}
