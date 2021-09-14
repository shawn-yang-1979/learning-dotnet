using System;
using Humanizer;
using firstLib;

namespace firstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Robot().Greeting());
            Console.WriteLine("Cat".Pluralize());
            Console.WriteLine("Dog".Pluralize());
            Console.WriteLine("Data".Singularize());
            Console.ReadLine();
        }
    }
}
