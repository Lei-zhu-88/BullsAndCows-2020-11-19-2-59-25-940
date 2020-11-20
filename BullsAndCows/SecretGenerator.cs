using System;

namespace BullsAndCows
{
    public class SecretGenerator
    {
        public virtual string GenerateSecret()
        {
            string randomString = GenerateInt().ToString();
            while (randomString.Length < 4)
            {
                string newNumber = GenerateInt().ToString();
                if (!randomString.Contains(newNumber))
                {
                    randomString += newNumber;
                }
            }

            Console.WriteLine(randomString);
            return randomString;
        }

        private int GenerateInt()
        {
            Random random = new Random();
            return random.Next(0, 10);
        }
    }
}