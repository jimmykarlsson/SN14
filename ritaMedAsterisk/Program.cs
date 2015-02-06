using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ritaMedAsterisker
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int rad = 0; rad < 25; rad++)
            {
                if (rad % 2 != 0)
                {
                    Console.Write(" ");
                }

                for (int kolumn = 0; kolumn < 38; kolumn++)
                {
                    switch (rad % 3)
                    {
                        case 0:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                    }
                    Console.Write("* ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }
}