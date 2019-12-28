using System;
using System.IO;
using System.Collections.Generic;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("Input.txt");
            string originalInput = sr.ReadLine();
            sr.Close();
            List<int> intcomp = new List<int>();

            string num = "";
            // Make a list of the input numbers
            for (int i = 0; i < originalInput.Length; i++)
            {
                if (originalInput[i] == ',')
                {
                    intcomp.Add(Convert.ToInt32(num));
                    num = "";
                }
                else
                {
                    num = num + originalInput[i];
                }
            }
            intcomp.Add(Convert.ToInt32(num));
            List<int> originalList = new List<int>(intcomp);

            Console.WriteLine("Running...");

            // Changes the noun and verb
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    // Sets the noun and verb
                    ResetInput(ref intcomp, originalList);
                    intcomp[1] = i;
                    intcomp[2] = j;
                    RunProgram(intcomp);

                    // If it is the correct number, it should print the answer
                    if (intcomp[0] == 19690720)
                    {
                        Console.Clear();
                        Console.WriteLine("Noun=" + i);
                        Console.WriteLine("Verb=" + j);
                        Console.WriteLine("Answer: " + (100 * i + j));
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                }
            }
        }

        static void RunProgram(List<int> intcomp)
        {
            // Do the calculations
            for (int i = 0; i < intcomp.Count; i++)
            {
                // True if the first opcode = 99 and halts the program
                bool halt = false;

                // If i is divisible by 4, than that means it is the start of an opcode
                if ((i % 4) == 0)
                {
                    try
                    {
                        // Choses what should happen depending on the first opcode
                        switch (intcomp[i])
                        {
                            case 1:
                                int sum = intcomp[intcomp[i + 1]] + intcomp[intcomp[i + 2]];
                                i += 3;
                                intcomp[intcomp[i]] = sum;
                                break;
                            case 2:
                                int factor = intcomp[intcomp[i + 1]] * intcomp[intcomp[i + 2]];
                                i += 3;
                                intcomp[intcomp[i]] = factor;
                                break;
                            case 99:
                                halt = true;
                                break;
                            default:
                                //Console.WriteLine("***Something went wrong***");
                                break;
                        }
                    }
                    catch
                    {
                        // Just exist to counter a crash
                    }
                }

                // Stops the loop if there is a 99
                if (halt)
                {
                    break;
                }
            }
        }

        static void ResetInput(ref List<int> resetList, List<int> originalList)
        {
            resetList = new List<int>(originalList);
        }
    }
}
