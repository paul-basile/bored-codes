using System;

class RandNumGuesser
{
    static void Main()
    {
        Random rnd = new Random();
        int randNum = rnd.Next(1, 51); // 51 is exclusive, so this gives 1-50
        int guessAttempts = 0;
        bool gameRunning = true;

        Console.WriteLine("I'm thinking of a wacky number between 1 and 50. Guess it nowwwwww. You have 5 tries.");

        while (guessAttempts < 5 && gameRunning)
        {
            Console.Write("Enter your guess: ");
            string input = Console.ReadLine();
            int guess;

            if (int.TryParse(input, out guess))
            {
                if (checkValidGuess(guess))
                {
                    if (guess > randNum)
                    {
                        Console.WriteLine("You guessed way too high bruh");
                        guessAttempts++;
                    }
                    else if (guess < randNum)
                    {
                        Console.WriteLine("That mf too low");
                        guessAttempts++;
                    }
                    else
                    {
                        Console.WriteLine($"Shit man you guessed {guess} and that random number was {randNum}");
                        gameRunning = false;
                    }
                }
                else
                {
                    Console.WriteLine("Boy you got an invalid guess boy");
                }
            }
            else
            {
                Console.WriteLine("That ain't even a number bro");
            }
        }

        if (!gameRunning)
        {
            Console.WriteLine("Good shit man you got dat number");
        }
        else
        {
            Console.WriteLine($"Nahhhh you ain't get it. The number was {randNum}");
        }
    }

    static bool checkValidGuess(int guess)
    {
        return guess > 0 && guess <= 50;
    }
}
