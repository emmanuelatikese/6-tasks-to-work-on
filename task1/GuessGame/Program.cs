
using System;

class Program{

    static void IntroductionFunction(){
        Console.WriteLine("Hello, Welcome to Guess Game !!!");
        Console.WriteLine("Can you guess right?");
        Console.WriteLine("You have only five tries to guess a number from 1 to 10");
    }

    static bool PlayAgain(){
        Console.WriteLine("Do you want to play again (yes(Y/y) or no (N/n)?");
        string response = Console.ReadLine() ?? string.Empty;
        if (response == "y" || response == "yes" || response == "Y")
        {
            return true;
        }
        return false;
    }

    static bool GameLogic(){
        Random random = new Random();
        int guessNum = random.Next(1, 11);
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine("Your Guess(1-10):");
            string guess = Console.ReadLine() ?? string.Empty;

            int guessInt;
            if (int.TryParse(guess, out guessInt) && (guessInt > 0 && guessInt < 11))
            {
                if (guessInt == guessNum)
                {
                    Console.WriteLine("You guess right!!!");
                    bool answer = PlayAgain();
                    return answer;
                }
                else
                {
                    if (i < 6)
                    {
                        Console.WriteLine("you guessed wrong !!! :(");
                        int triesLeft = 5 - i;
                        if (triesLeft > 1)
                        {
                            Console.WriteLine($"{triesLeft} tries left");
                        }
                        else
                        {
                            Console.WriteLine("I guess this is your last shot");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You guessed wrong :(");
                    }
                }
            }
            else
            {
                Console.WriteLine("Type in numbers only from (1 - 10)");
            }

        }

        Console.WriteLine($"The number is: {guessNum}");
        bool reply = PlayAgain();
        return reply;
    }
    static void Main(){
        
        bool start = true;

        while (start){
            IntroductionFunction();
            bool res = GameLogic();
            start = res;
            if (start == false){
                Console.WriteLine("Thanks for playing the game. Bye...");
            }
        }

    }
}
