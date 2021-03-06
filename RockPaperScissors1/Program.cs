using System;

namespace RockPaperScissors1
{
    class Program
    {
        public enum RpsChoice
        {
            Rock = 1, //equivalent to 0
            Paper = 2, //equivalent to 1
            Scissors = 3 //equivalent to 2
        }
        static void Main(string[] args)
        {
            Person person = new Person();

            int count = 0;
            int playerWin = 0;
            int computerWin = 0;

            Game game = new Game();
            game.startGame();

            bool successfulConversion = false;
            int playerChoiceInt;

            while (count < 3)
            {

                do
                {
                    Console.WriteLine("1. Rock\n2. Paper\n3. Scissors\n");
                    string playerChoice = Console.ReadLine();

                    //create a int variable to catch the converted choice
                    successfulConversion = Int32.TryParse(playerChoice, out playerChoiceInt);

                    //checks if the user inputted a number but the number is out of bounds
                    if (playerChoiceInt > 3 || playerChoiceInt < 1)
                    {
                        Console.WriteLine($"You inputted {playerChoiceInt}. That is not a valid choice.");
                    }
                    else if (!successfulConversion)
                    {
                        Console.WriteLine($"You inputted {playerChoice}. This is not a valid choice");
                    }

                } while (!successfulConversion || (playerChoiceInt < 1 || playerChoiceInt > 3));


                if (successfulConversion == true)
                {
                    Console.WriteLine($"The conversion returned {successfulConversion} and the player chose {playerChoiceInt}\n");
                }
                else
                {
                    Console.WriteLine($"The conversion returned {successfulConversion}\n");
                }

                //get a random number generator object
                Random rand = new Random();
                int computerChoice = rand.Next(1, 4);

                //print the choices
                Console.WriteLine($"The player's choice is {playerChoiceInt}");
                Console.WriteLine($"The computer's choice is {computerChoice}");

                //check who won
                if (playerChoiceInt == 1 && computerChoice == 2 ||
                playerChoiceInt == 2 && computerChoice == 3 ||
                playerChoiceInt == 3 && computerChoice == 1)
                {
                    computerWin++;
                    Console.WriteLine($"\n{person.fname}{person.lname}'s score is {playerWin} and the computer's score is {computerWin}");
                    count++;

                }
                else if (playerChoiceInt == computerChoice)
                {

                    Console.WriteLine("\nTie game");
                }
                else
                {
                    playerWin++;
                    Console.WriteLine($"\n{person.fname}{person.lname}'s score is {playerWin} and the computer's score is {computerWin}");
                    count++;
                }

                if (count == 3 && playerWin > computerWin)
                {
                    Console.WriteLine($"\n{person} wins");
                }
                else if (count == 3 && computerWin > playerWin)
                {
                    Console.WriteLine("\nThe computer wins");
                }
            }

        }
    }
}
