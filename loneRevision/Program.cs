using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loneRevision
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Lönerevision";

            do
            {
                Console.Clear();

                string titelAntalLoner = "Ange antal löner att mata in: ";
                int braAntalLoner = 0;

                braAntalLoner = ReadInt(titelAntalLoner);

                if (braAntalLoner >= 2)
                {
                    ProcessSalaries(braAntalLoner);
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Du måste mata in minst två löner för att göra en beräkning!");
                    Console.ResetColor();
                }
         
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nTryck tangent för att fortsätta - ESC avslutar.");
                Console.ResetColor();

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        private static int ReadInt(string prompt)
        {
            int resultat = 0;
            string strTest = string.Empty;

            while (true)
                try
                {
                    Console.Write(prompt);
                    strTest = Console.ReadLine();
                    resultat = int.Parse(strTest);
                    break;
                }
                catch (Exception)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Fel! '{0}' kan inte tolkas som ett heltal!", strTest);
                    Console.ResetColor();
                }

            return resultat;
        }

        private static void ProcessSalaries(int antal)
        {
            string prompt = "Ange lön nummer ";
            int[] loner = new int[antal];

            for (int i = 0; i < antal; i++)
            {
                string text = String.Format("{0} {1} :", prompt, (i + 1));
                loner[i] = ReadInt(text);                                     
            }

            Console.WriteLine("\n------------------------------");

            double lonMedel = loner.Average();
            int medellon = (int)Math.Round(lonMedel);
            int maxlon = loner.Max();
            int minlon = loner.Min();
            int spridning = maxlon - minlon;

            int[] lonerSorted = new int[antal];
            Array.Copy(loner, lonerSorted, antal);

            Array.Sort(lonerSorted);

            int medianlon;

            if (lonerSorted.Length % 2 == 1)
            {
                medianlon = lonerSorted[(antal / 2)];
            }

            else
            {
                int tal1 = lonerSorted[(antal / 2)];
                int tal2 = lonerSorted[(antal / 2 - 1)];
                medianlon = (tal1 + tal2) / 2;
            }
     
            Console.WriteLine("{0}: {1, 13:C0}", "Medianlön", medianlon);
            Console.WriteLine("{0}: {1, 14:C0}", "Medellön", medellon);
            Console.WriteLine("{0}: {1, 9:c0}", "Lönespridning", spridning);
            Console.Write("------------------------------");

            for (int i = 0; i < loner.Length; i++)
            {
                if (i % 3 != 0)
                {
                    Console.Write("{0, 8}", loner[i]);
                }
                else
                {
                    Console.WriteLine();
                    Console.Write("{0, 8}", loner[i]);
                }
            }
            Console.WriteLine();
        }
    }
}