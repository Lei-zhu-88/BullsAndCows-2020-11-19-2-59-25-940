using System;
using BullsAndCows;

namespace BullsAndCowsRunner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SecretGenerator secretGenerator = new SecretGenerator();
            BullsAndCowsGame game = new BullsAndCowsGame(secretGenerator);
            int countGameTimes = 0;
            while (game.CanContinue)
            {
                var input = Console.ReadLine();
                if (!game.IsValid(input))
                {
                    continue;
                }

                var output = game.Guess(input);
                Console.WriteLine(output);
                countGameTimes++;
                if (output == "4A0B")
                {
                    Console.WriteLine("You win!");
                    break;
                }

                if (countGameTimes == 6)
                {
                    break;
                }
            }

            Console.WriteLine("Game Over");
        }
    }
}