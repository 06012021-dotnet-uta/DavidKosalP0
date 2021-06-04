using System;

namespace RockPaperScissors1
{
    public class Game
    {
        public void startGame(){

            Person person = new Person();
            Console.WriteLine("Welcome to Rock-Paper-Scissors!\n\nEnter your first name: ");
            person.fname = Console.ReadLine();

            Console.WriteLine("\nEnter your last name: ");
            person.lname = Console.ReadLine();

            Console.WriteLine($"\nHello, {person.fname} {person.lname}, please make your choice");

        }
    }
}