using System;
namespace PigDiceGame
{
    internal class Program
    {
        private const int winningPoints = 20;
        private static int turnScore = 0, totalScore = 0, turnCount = 0;
        private static bool rollAgain = true, turnOver = false;
        static void Main(string[] args)
        {
            Console.WriteLine("Let's Play PIG! \nScore 20 or above to winn\n");
            while (!turnOver)
            {
                if (totalScore >= winningPoints)
                {
                    Console.WriteLine($"You Win! You finished in {turnCount} turn/s!\nGame over!");
                    turnOver = true;
                }
                else
                {
                    rollAgain = true;
                    turnCount++;
                    PrintTurnDetails(turnCount);
                }
            }
        }
        static void PrintTurnDetails(int turnCount)
        {
            turnScore = 0;
            Console.WriteLine($"\nTURN {turnCount}:\n");
            while (rollAgain)
            {
                RollingDiceResults();
                if (rollAgain)
                {
                    Console.WriteLine("Enter 'r' to roll again, 'h' to hold.");
                    string choice = Console.ReadLine().ToLower();
                    if (choice == "h")
                    {
                        rollAgain = false;
                        totalScore = turnScore + totalScore;
                        Console.WriteLine($"Your turn score is {turnScore} and your total score is {totalScore}");
                    }
                }
            }
        }
        static void RollingDiceResults()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 7);
            if (randomNumber == 1)
            {
                turnScore = 0;
                Console.WriteLine($"You rolled: {randomNumber}");
                Console.WriteLine("Turn Over. No Score.");
                rollAgain = false;
            }
            else
            {
                turnScore += randomNumber;
                Console.WriteLine($"You rolled: {randomNumber}");
                Console.WriteLine($"Your turn score is {turnScore} and your total score is {totalScore}");
                Console.WriteLine($"If you hold, you will have {turnScore + totalScore} points.");
            }
        }
    }
}
