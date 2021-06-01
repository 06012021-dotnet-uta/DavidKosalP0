using System;

namespace Day1Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Enter your age: ");
            String age = Console.ReadLine();
            Console.WriteLine("Enter your name: ");
            String name = Console.ReadLine();
            Console.WriteLine($"Your name is {name} and your age is {age}.");
        }
    }
}
