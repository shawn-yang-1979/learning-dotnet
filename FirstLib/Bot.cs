using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FirstLib
{
    public class Bot
    {
        public string SayHi()
        {
            return "Hi!";
        }

        public IEnumerable<decimal> FindUniqueNumbers(IEnumerable<decimal> numbers)
        {
            var query = from number in numbers
                        group number by number into g
                        where g.Count() == 1
                        select g.Key;
            return query.ToList();
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

        public Breakfast MakeBreakfast()
        {
            Task<Coffee> makeCoffee = this.HaveCoffeeMachineMakeCoffee(); // 20 seconds parallel
            Task<Bread> toastBread = this.HaveToasterToastBread(); // 20 seconds parallel

            Juice juice = PourJuice(); // 10 seconds
            Coffee coffee = makeCoffee.Result;
            Bread bread = toastBread.Result;
            List<Bacon> bacons = this.FryBacon(1); // 20 seconds
            List<Egg> eggs = this.FryEggs(1); // 20 seconds

            this.ApplyButter(bread); // 3 seconds
            this.ApplyJam(bread); // 3 seconds

            return new Breakfast
            {
                Coffee = coffee,
                Juice = juice,
                Bread = bread,
                Bacons = bacons,
                Eggs = eggs
            };
        }

        private Juice PourJuice()
        {
            Thread.Sleep(10000);
            return new Juice();
        }

        private void ApplyJam(Bread bread)
        {
            Thread.Sleep(3000);
            bread.Jamed = true;
        }

        private void ApplyButter(Bread bread)
        {
            Thread.Sleep(3000);
            bread.Buttered = true;
        }

        private List<Bacon> FryBacon(int howMany)
        {
            List<Bacon> bacons = new();
            for (var i = 0; i < howMany; i++)
            {
                Thread.Sleep(20000);
                bacons.Add(new Bacon());
            }
            return bacons;
        }

        private List<Egg> FryEggs(int howMany, int time = 20000)
        {
            List<Egg> eggs = new();
            for (var i = 0; i < howMany; i++)
            {
                Thread.Sleep(time);
                eggs.Add(new Egg());
            }
            return eggs;
        }

        // Reference: https://stackoverflow.com/questions/14186009/how-can-i-update-my-api-to-use-the-async-keyword-without-using-await-for-all-cal
        private async Task<Coffee> HaveCoffeeMachineMakeCoffee(int time = 20000)
        {
            await Task.Delay(time).ConfigureAwait(false);
            return new Coffee();

        }

        private async Task<Bread> HaveToasterToastBread(int time = 20000)
        {
            await Task.Delay(time).ConfigureAwait(false);
            return new Bread();
        }
    }

    public class Coffee
    {
    }

    public class Egg
    {
    }

    public class Bread
    {
        public bool Buttered { get; set; }

        public bool Jamed { get; set; }

    }

    public class Bacon
    {
    }

    public class Juice
    {
    }

    public class Breakfast
    {
        public Juice Juice { get; set; }

        public Coffee Coffee { get; set; }

        public Bread Bread { get; set; }

        public List<Bacon> Bacons { get; set; }

        public List<Egg> Eggs { get; set; }
    }
}