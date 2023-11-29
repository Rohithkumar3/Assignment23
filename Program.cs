using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment23
{
    public delegate void SpinDelegate(ref int energyLevel, ref int winningProbability, int luckyNumber);
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Your Name: ");
            string playerName = Console.ReadLine();

            Console.Write("Enter Your Lucky Number from 1 to 10: ");
            int luckyNumber;
            while (!int.TryParse(Console.ReadLine(), out luckyNumber) || luckyNumber < 1 || luckyNumber > 10)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 10.");
            }

            int energyLevel = 1;
            int winningProbability = 100;
            int spinCount = 1;

            SpinDelegate spinDelegate = Spin;

            while (spinCount <= 10)
            {
                Console.WriteLine($"Spin {spinCount}:");
                spinDelegate(ref energyLevel, ref winningProbability, luckyNumber);
                Console.WriteLine($"Energy Level: {energyLevel}, Winning Probability: {winningProbability}");

                spinCount++;
            }

            Console.WriteLine($"\nGame Over! Checking results for {playerName}...");

            if (energyLevel >= 4 && winningProbability > 60)
                Console.WriteLine($"{playerName} is the Winner!");
            else if (energyLevel >= 1 && winningProbability > 50)
                Console.WriteLine($"{playerName} is the Runner Up!");
            else
                Console.WriteLine($"{playerName} is the Loser. Better luck next time!");
            Console.ReadKey();
        }

        static void Spin(ref int energyLevel, ref int winningProbability, int luckyNumber)
        {
            switch (luckyNumber)
            {
                case 1:
                    energyLevel += 1;
                    winningProbability += 10;
                    break;
                case 2:
                    energyLevel += 2;
                    winningProbability += 20;
                    break;
                case 3:
                    energyLevel -= 3;
                    winningProbability -= 30;
                    break;
                case 4:
                    energyLevel += 4;
                    winningProbability += 40;
                    break;
                case 5:
                    energyLevel += 5;
                    winningProbability += 50;
                    break;
                case 6:
                    energyLevel -= 1;
                    winningProbability -= 60;
                    break;
                case 7:
                    energyLevel += 1;
                    winningProbability += 70;
                    break;
                case 8:
                    energyLevel -= 2;
                    winningProbability -= 20;
                    break;
                case 9:
                    energyLevel -= 3;
                    winningProbability -= 30;
                    break;
                case 10:
                    energyLevel += 10;
                    winningProbability += 100;
                    break;
                default:
                    break;
            }
        }
    }
}

