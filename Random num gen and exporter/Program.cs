using System;
using System.IO;
using System.Diagnostics;

namespace Random_num_gen_and_exporter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            int output = 0;
            double decOutput = 0;
            double doubleOutput = 0;
            bool finished = false;
            string outputString = "";
            string decOutputString = "";
            string randomFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Random Numbers");

            if (!Directory.Exists(randomFolder))
            {
                Directory.CreateDirectory(randomFolder);
            }
            else
            {
                Console.WriteLine("Random number folder already found, continuing...\n");
            }

            while (!finished)
            {
                bool randDec = false;
                string numbers = "";
                string decNumbers = "";
                Console.WriteLine("\nThis program generates random numbers between two specified whole numbers.");
                Console.WriteLine("If you want to generate random decimals between 0 and 1, please press '1', otherwise press enter");
                string one = Console.ReadLine();
                if(one == "1")
                {
                    randDec = true;
                }
                if (!randDec)
                {
                    Console.WriteLine("\nThis program generates random numbers between two specified whole numbers");
                    Console.WriteLine("Please enter number 1:");
                    int num1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please enter number 2:");
                    int num2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("How many random numbers do you want generated?");
                    int genAmount = Convert.ToInt32(Console.ReadLine());
                    int fileAmount = genAmount;
                    if (num1 > num2)
                    {
                        int num3 = num2;
                        num2 = num1;
                        num1 = num3;
                    }
                    while (genAmount > 0)
                    {
                        output = rand.Next(num1, num2);
                        Console.WriteLine(output);
                        genAmount--;
                        outputString = Convert.ToString(output);
                        numbers += outputString + " ";
                    }
                    Console.WriteLine("Do you want to export as a txt file? Y/N");
                    string yn = Console.ReadLine();
                    if (yn == "Y")
                    {
                        string docs = Path.Combine(randomFolder, fileAmount + " random numbers between " + num1 + " and " + num2 + ".txt");
                        File.WriteAllText(docs, numbers);
                        Console.WriteLine("File created at " + docs);
                        Console.WriteLine("Press enter to continue.");
                        Console.ReadLine();
                        Console.WriteLine("Do you want to open the file? Y/N");
                        string open = Console.ReadLine();
                        if (open == "Y")
                        {
                            Process.Start("notepad.exe", docs);
                        }
                        Console.WriteLine("Do you want to use again? Y/N");
                    }
                    else
                    {
                        Console.WriteLine("Do you want to use again? Y/N");
                    }
                    string rerun = Console.ReadLine();
                    if (rerun == "N")
                    {
                        finished = true;
                    }
                }
                if (randDec)
                {
                    Console.WriteLine("\nThis program generated random decimal numbers between 0 and 1");
                    Console.WriteLine("Please enter how many decimal places are needed:");
                    int decimalPlaces = Convert.ToInt32(Console.ReadLine());
                    double randDecPlaces = Math.Pow(10, decimalPlaces+1);
                    Console.WriteLine("Please enter how many numbers you want generated:");
                    int decAmount = Convert.ToInt32(Console.ReadLine());
                    int decFileAmount = decAmount;
                    while(decAmount > 0)
                    {
                        decOutput = rand.Next(0, Convert.ToInt32(randDecPlaces));
                        doubleOutput = decOutput / randDecPlaces;
                        Console.WriteLine(doubleOutput);
                        decAmount--;
                        decOutputString = Convert.ToString(doubleOutput);
                        decNumbers += decOutputString + " ";
                    }
                    Console.WriteLine("Do you want to export as a txt file? Y/N");
                    string yn = Console.ReadLine();
                    if (yn == "Y")
                    {
                        string decDocs = Path.Combine(randomFolder, decFileAmount + " random decimals.txt");
                        File.WriteAllText(decDocs, decNumbers);
                        Console.WriteLine("File created at " + decDocs);
                        Console.WriteLine("Press enter to continue.");
                        Console.ReadLine();
                        Console.WriteLine("Do you want to open the file? Y/N");
                        string decOpen = Console.ReadLine();
                        if (decOpen == "Y")
                        {
                            Process.Start("notepad.exe", decDocs);
                        }
                        Console.WriteLine("Do you want to use again? Y/N");
                    }
                    else
                    {
                        Console.WriteLine("Do you want to use again? Y/N");
                    }
                    string rerun = Console.ReadLine();
                    if (rerun == "N")
                    {
                        finished = true;
                    }
                }
            }
        }
    }
}
