using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kassaKvitto2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "kassaKvitto";

            double totalSumma = 0d;
            int erhalletBelopp = 0;

            while (true)
            {
                try
                {
                    Console.Write("Ange totalsumman    : ");
                    totalSumma = double.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Fel! Totalsumman är felaktig.");
                    Console.ResetColor();
                }
            }

            if (totalSumma < 1)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Fel! Totalsumman är för liten. Köpet kunde inte genomföras.");
                Console.ResetColor();
                return;
            }

            while (true)
            {
                try
                {
                    Console.Write("Ange erhållet belopp: ");
                    erhalletBelopp = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Fel! Erhållet belopp är felaktig.");
                    Console.ResetColor();
                }
            }

            totalSumma = Math.Round(totalSumma, 2); 
            int summaTotal = (int)Math.Round(totalSumma);

            double restAvrundning = summaTotal - totalSumma;
            restAvrundning = Math.Round(restAvrundning, 2);

            if (erhalletBelopp < summaTotal)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Fel! Totalsumman är för liten. Köpet kunde inte genomföras.");
                Console.ResetColor();
                return;
            }

            int vaxelBelopp = erhalletBelopp - summaTotal;

            Console.WriteLine("\nKVITTO");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("{0, -17}: {1, 12:c2}", "Totalt", totalSumma);
            Console.WriteLine("{0, -17}: {1, 12:c2}", "Öresavrundning", restAvrundning);
            Console.WriteLine("{0, -17}: {1, 12:c0}", "Att betala", summaTotal);
            Console.WriteLine("{0, -17}: {1, 12:c0}", "Kontant", erhalletBelopp);
            Console.WriteLine("{0, -17}: {1, 12:c0}", "Tillbaka", vaxelBelopp);
            Console.WriteLine("-------------------------------\n");

            int vaxelTillbaka = vaxelBelopp;

            int femhundralappar = vaxelTillbaka / 500;
            vaxelTillbaka %= 500;

            int hundralappar = vaxelTillbaka / 100;
            vaxelTillbaka %= 100;

            int femtiolappar = vaxelTillbaka / 50;
            vaxelTillbaka %= 50;

            int tjugolappar = vaxelTillbaka / 20;
            vaxelTillbaka %= 20;

            int tiokronor = vaxelTillbaka / 10;
            vaxelTillbaka %= 10;

            int femkronor = vaxelTillbaka / 5;
            vaxelTillbaka %= 5;

            int enkronor = vaxelTillbaka;

            if (femhundralappar > 0)
            {
                Console.WriteLine("{0, -17}: {1}", "500-lappar", femhundralappar);
            }

            if (hundralappar > 0)
            {
                Console.WriteLine("{0, -17}: {1}", "100-lappar", hundralappar);
            }

            if (femtiolappar > 0)
            {
                Console.WriteLine("{0, -17}: {1}", "50-lappar", femtiolappar);
            }

            if (tjugolappar > 0)
            {
                Console.WriteLine("{0, -17}: {1}", "20-lappar", tjugolappar);
            }

            if (tiokronor > 0)
            {
                Console.WriteLine("{0, -17}: {1}", "10-kronor", tiokronor);
            }

            if (femkronor > 0)
            {
                Console.WriteLine("{0, -17}: {1}", "5-kronor", femkronor);
            }

            if (enkronor > 0)
            {
                Console.WriteLine("{0, -17}: {1}", "1-kronor", enkronor);
            }
            Console.WriteLine();
        }
    }
}