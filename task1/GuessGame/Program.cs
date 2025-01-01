
using System;

class program{
    static void Main(){
        console.WriteLine("Hello, Welcome to Guess Game !!!");
        console.WriteLine("Can you guess right?");
        console.WriteLine("You have only five tries to guess a number from 1 to 10")


Random guessNum = Random(1, 10);
        for (int i = 1; i <= 5, i++)
        {
            console.WriteLine("Your Guess(1-10):");
            string guess = console.ReadLine();
            guessInt = int.parse(guess);

            if (guessInt == guessNum)
            {
                console.WriteLine("You guess right!!!");
                break;
            }
            else
            {
                if  i < 6 {
                    console.WriteLine("you guessed wrong !!! :(", );
                    int triesLeft = 5 - i
                    if (triesLeft > 1)
                    {
                        console.WriteLine($"{triesLeft} tries left");
                    }
                    else
                    {
                        console.WriteLine("I guess this is your last try");
                    }
                }
                else
                {
                    console.WriteLine("You guessed wrong :(");
                }
            }

        }


    }
}
