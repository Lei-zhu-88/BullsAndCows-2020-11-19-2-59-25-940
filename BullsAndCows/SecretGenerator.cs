using System;

namespace BullsAndCows
{
    public class SecretGenerator
    {
        public virtual string GenerateSecret()
        {
            return " ";
        }

        //{
        //    //int firstNumber = GenerateInt();
        //    string randomString = GenerateInt().ToString();
        //    string newNumber;
        //    while (randomString.Length < 4)
        //    {
        //         newNumber = GenerateInt().ToString();
        //        if (!randomString.Contains(newNumber))
        //        {
        //            randomString += newNumber;
        //        }
        //    }

        // //   Console.WriteLine(randomString);
        //    return randomString;
        //}

        //private int GenerateInt()
        //{
        //    Random random = new Random();
        //    return random.Next(0, 10);
        //}
    }
}