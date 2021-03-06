﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ismetles01
{
    class Program
    {

        static int gepNyer =0;
        static int embernyer = 0;
        static int menet = 0;
        

        static string[] lehetoseg = new string[] { "Kő", "Papír", "Olló" };

        static int GepValasztas()
        {
            Random vel = new Random();
            return vel.Next(0, 3);
        }
        static int JatekosValasztas()
        {
            Console.WriteLine("Kő (0), Papír (1), Olló (2)");
            Console.Write("Válasz: ");
            return Convert.ToInt32(Console.ReadLine());
        }
        static void EredmenyKiiras(int gep, int ember)
        {
            Console.WriteLine("Gép: {0} --- Játékos: {1}", lehetoseg[gep], lehetoseg[ember]);
            switch (EmberNyer(gep, ember))
            {
                case 0:
                    Console.WriteLine("Döntetlen!");
                    break;
                case 1:
                    Console.WriteLine("Skynet nyert!");
                    break;
                case 2:
                    Console.WriteLine("Játékos nyert!");
                    break;
            }
        }
        static int EmberNyer(int gep, int ember)
        {
            if (gep == 0 && ember == 1 || gep == 1 && ember == 2 || gep == 2 && ember == 0)
            {
                embernyer++;
                return 2;
            }
            else if (gep == ember)
            {
                return 0;
            }
            else
            {
                gepNyer++;
                return 1;

            }
            
            
        }

        private static bool akarjatszani()
        {

            Console.WriteLine("-------------------");
            Console.Write("Tovább [I/N]:");
            string valasz = Console.ReadLine().ToLower();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n-------------------");
            Console.ResetColor();
            if (valasz == "i")
            {
                return true;
            }
            else return false;

            //throw new NotImplementedException();



        }


        private static void Statisztikairas()
        {
            StreamWriter sw = new StreamWriter("Statisztika.txt");
            
            sw.Write(menet+";");
            sw.Write(embernyer+";");
            sw.WriteLine(gepNyer);




            sw.Close();
            Console.WriteLine("\t Menetek száma: {0},"+"játékos győzelmek száma: {1}"+"Gép győzelmek száma: {2}",menet, embernyer,gepNyer);


        }

        private static void StatisztikaFajlbol()
        {
            StreamReader sr = new StreamReader("Statisztika.txt");
            
            
            while (!sr.EndOfStream)
            {
                string[] atmeneti = sr.ReadLine().Split(';');
                int[] adat = new int[3];
                // adat[0] =int.Parse(atmeneti[0]);
                //   adat[1] = int.Parse(atmeneti[1]);
                //  adat[2] = int.Parse(atmeneti[2]);

                for (int i = 0; i < adat.Length; i++)
                {
                    adat[i] = int.Parse(atmeneti[i]);
                    
                }
                Console.WriteLine("{0} {1} {2}",adat[0],adat[1],adat[2]);
                


            }
            Console.WriteLine("------------->statisztika vége<----------------");


            sr.Close();
        }
        
        static void Main(string[] args)
        {
            StatisztikaFajlbol();

            bool tovabb = true;

            while (tovabb)
            {
                menet++;
                int jatekosValasz = JatekosValasztas();
                int gepValasz = GepValasztas();
                EredmenyKiiras(gepValasz, jatekosValasz);
                tovabb = akarjatszani();
            }

            Statisztikairas();
            Console.ReadKey();
        }
    }
}
