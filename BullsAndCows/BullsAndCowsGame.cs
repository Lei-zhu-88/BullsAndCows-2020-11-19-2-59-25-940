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

        private string Compare(string secret, string guess)
        {
            int countWrongPosition = secret.Where(secretChar => guess.Contains(secretChar)).ToList().Count;
            int countRightNumber = guess.Where((singleNumber, index) => singleNumber == secret[index]).ToList().Count;
            countWrongPosition -= countRightNumber;
            //int countWrongPosition = 0;
            //if (secret == guess)
            //{
            //    countRightNumber = 4;
            //}
            return $"{countRightNumber}A{countWrongPosition}B";
        }
    }
}