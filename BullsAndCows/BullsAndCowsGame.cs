using System;
using System.Linq;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        private readonly string secret = string.Empty;
        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            this.secret = this.secretGenerator.GenerateSecret();
        }

        public bool CanContinue => true;

        public string Guess(string guess)
        {
            var guessWithoutSpace = guess.Replace(" ", string.Empty);
            return this.Compare(this.secret, guessWithoutSpace);
        }

        public bool IsValid(string guess)
        {
            guess = guess.TrimEnd();
            var guessWithoutSpace = guess.Replace(" ", string.Empty);
            string validNumbers = "0123456789";
            int countDuplicate = guessWithoutSpace.Where(inputChar => guessWithoutSpace.Replace(inputChar.ToString(), string.Empty).Contains(inputChar)).ToList().Count();
            int countValidInt = guessWithoutSpace.Where(inputChar => validNumbers.Contains(inputChar)).ToList().Count();
            if (guess.Length != 7 || countValidInt != 4 || countDuplicate > 1)
            {
                Console.WriteLine("Wrong Input, input again");
                return false;
            }

            return true;
        }

        private string Compare(string secret, string guess)
        {
            int countWrongPosition = secret.Where(secretChar => guess.Contains(secretChar)).ToList().Count;
            int countRightNumber = guess.Where((singleNumber, index) => singleNumber == secret[index]).ToList().Count;
            countWrongPosition -= countRightNumber;
            return $"{countRightNumber}A{countWrongPosition}B";
        }
    }
}