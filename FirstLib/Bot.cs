using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstLib
{
    public class Bot
    {
        public string SayHi()
        {
            return "Hi!";
        }

        public string SplitCandies(int numbers, int groups)
        {
            int remained = numbers % groups;
            string output = $"Each groups can have {numbers / groups} candies.";
            if (remained != 0)
            {
                output = output + $" {remained} candies remained.";
            }
            return output;
        }

        public decimal AddNumbers(List<decimal> numbers)
        {
            return numbers.Sum();
        }
    }
}