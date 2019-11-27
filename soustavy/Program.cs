using System;
using System.Drawing;
using Console = Colorful.Console;
/*! \mainpage Programová dokumentace
 *
 * \section intro Úvod
 *
 * Program slouží k převodu z desítkové soustavy do Osmičkové a hexadecimální. 
 *
 * \section motiv Jak program funguje?
 *
 * Z uživatelského hlediska:
 *  - spustíme EXE soubor
 *  - zadáme vstup v desítkové soustavě
 *  - vybere soustavu, do které budeme vstup převádět
 *
 * Z programétorského hlediska
 *  - Jsou definované 4 funkce
 *  - pomocí knihovny Colorful console se vykreslí logo programu
 *  - funkce startconv provádí interakci s uživatelem
 *  - po zadání vstupu se dle výběru spustí vybraná funkce se vstupním parametrem
 *  - vybraná funkce provede výpočet
 *  - vybraná funkce zavolá numConv(), která převede číselné typy do typu string
 *  - vybraná funkce vypíše výstup
 */

/**
 * \file Program.cs
 * \brief Program pro převod soustav
 * \author Václav Bajtek, Jiří Šrytr, Martin Šmotek
 * \date Listopad 2019
 * \details Konzolová aplikace 
 *   - Uživatel zadává vstup v desítkové soustavě
 *   - Uživatel získá výstup ve zvolené soustavě
 *      + HExa
 *      + Octa
 *      + Bin
 *      
 * Zdrojové kódy jsou zapsány ve znakové sadě UTF-8
*/
namespace ciselne_soustavy
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.Clear();

            // Title
            int DA = 244;
            int V = 212;
            int ID = 255;

            for (int i = 0; i < 1; i++)
            {
                Console.WriteAscii("Num Sys Conv", Color.FromArgb(DA, V, ID));

                DA -= 18;
                V -= 36;
            }

            Console.WriteLine("\n-------------------------------------------------------------------\nHello, welcome to Numeric System Convertor.\n-------------------------------------------------------------------");
            p.startConv();
        }
        /**
 * \brief Třída charakterizující bankovní transakci
 */
        public void startConv()
        {
            Program p = new Program();
            string system, number_str;

            Console.Write("\nSet the number you want to convert: ");
            number_str = Console.ReadLine();

            Console.Write("\nPlease select the system. Type 'hex' or 'oct': ");
            system = Console.ReadLine();

            int number = Convert.ToInt32(number_str);

            if (system == "hex")
            {
                p.toHex(number);
            }
            else if (system == "oct")
            {
                p.toOct(number);
            }
            else
            {
                Console.WriteLine("\nIncorrect type. The program will be closed.");
            }

            Console.WriteLine("\nPress enter to repeat the program to close press anything else..");

            while (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                p.startConv();
            }
        }

        public string numConv(double num)
        {
            // Basic switch convertor

            switch (num)
            {
                case 10:
                    return "A";
                case 11:
                    return "B";
                case 12:
                    return "C";
                case 13:
                    return "D";
                case 14:
                    return "E";
                case 15:
                    return "F";
                default:
                    return Convert.ToString(num);
            }
        }

        public void toHex(double numToHex)
        {
            Console.WriteLine("\nYour number in decimal system was {0}.", numToHex);
            double divide1, divide2, firstResuide, secondResuide;

            if (numToHex <= 255)
            {
                divide1 = Math.Floor(numToHex / 16); // divide (num) by 16
                firstResuide = numToHex % 16; // get the residue of (num) / 16     - example : 255 / 16 -> 15

                Console.WriteLine("Your number in hex system is " + numConv(divide1) + numConv(firstResuide));
            }
            else if (numToHex <= 4095 && numToHex >= 255)
            {
                divide1 = Math.Floor(numToHex / 256);  // divide (num) by 256
                firstResuide = numToHex % 256; // get the residue of (num) / 256    - example : 300 / 256 -> 44
                divide2 = Math.Floor(firstResuide / 16); // divide (residue of num) by 16
                secondResuide = firstResuide % 16; // get residue of (residue of num)    - exapmple 44 / 16 -> 12

                // just for test
                // Console.WriteLine("\n\ntest - " + divide1 + " and madafakin " + divide2 + " the resuide " + firstResuide + " and second " + secondResuide + "\n\n");

                Console.WriteLine("Your number in hex system is " + numConv(divide1) + numConv(divide2) + numConv(secondResuide));
            }

        }

        public void toOct(double numToOct) ///ahojky ja jsem test
        {
            Console.WriteLine("\nYour number in decimal system was {0}.", numToOct);
            double divide1, divide2, firstResuide, secondResuide;

            if (numToOct <= 63)
            {
                divide1 = Math.Floor(numToOct / 8); // divide (num) by 8
                firstResuide = numToOct % 8; // get the residue of (num) / 8    

                Console.WriteLine("Your number in hex system is " + numConv(divide1) + numConv(firstResuide));
            }
            else if (numToOct <= 511 && numToOct >= 63)
            {
                divide1 = Math.Floor(numToOct / 64);  // divide (num) by 64
                firstResuide = numToOct % 64; // get the residue of (num) / 64    
                divide2 = Math.Floor(firstResuide / 8); // divide (residue of num) by 8
                secondResuide = firstResuide % 8; // get residue of (residue of num)   

                // just for test - Console.WriteLine("\n\ntest - " + divide1 + " and madafakin " + divide2 + " the resuide " + firstResuide + " and second " + secondResuide + "\n\n");

                Console.WriteLine("Your number in hex system is " + numConv(divide1) + numConv(divide2) + numConv(secondResuide));
            }
        }

    }
}
