using System;

namespace Antagningsprov_DavidStåhl_8809080032
{
    class Programs
    {
        static void Main(string[] args)
        {
            Console.WriteLine("David Ståhl 2019-05-13");
            //Writes the creator and the date of creation.
            int numberOfDices = ChooseNumberOfDices();
            Dices(numberOfDices);
            //Starts the Dice game by calling the Dice method, wich calling the Start method.
            ExitGame();
            //Calling the exit method, after the dice game ended to give the user a choice to play again
            // or end the application.
            Console.ReadLine();
        }
        public static void Dices(int dices) // The dice method takes the input of how many dices to play
        {
            int sumRolls = 0; // how many dices(randomnumbers) is looped.
            int sumNumbers = 0; // the sum of numbers from the randomnumbers. without the number 6.
            int bonusRolls = 0; // a variable to track the bonus rolls if the randomnumber rolls 6

            for (int i = 0; i < dices; i++) // a loop with variable i as the number of dices rolled
            {
                Random random = new Random(); // creating a random method
                int randomNumber = random.Next(1, 7); // gives randomNumber, the randomnumber from 1-6
                sumRolls = i + 1; // adds +1 every loop of how many dices rolled 
                Console.WriteLine("Totalt kastade tärningar: " + sumRolls + "\nVärdet på tärningen = "
                   + randomNumber); // tell the user number of rolled dices, the value of the roll
                if (randomNumber == 6) // if randomNumber is 6 do something
                {
                    dices += 2; // adds 2 extra dices to roll if the randomnumer is 6.
                    bonusRolls += 1;  // adds bonus rolls to keep the sumNumbers from adding the 6.
                    Console.WriteLine("Tärningen visade en 6a vilket" +
                        " betyder att du får två extra kast!"); // berättar att användaren fått två nya kast..
                }
                else if (bonusRolls > 0) // if there is bonusrolls from getting a 6, do those rolls
                {                           // before the next dice
                    bonusRolls--;            // after each bonusroll give bonusroll -1 each loop
                    sumNumbers += randomNumber;    // sum the the rolls randomnumbers
                }                                    // as long its not a 6.
                else
                {
                    sumNumbers += randomNumber;      // add the rolled value to the sumNumbers
                }
                Console.WriteLine("Tryck enter för att slå nästa tärning"); // tell the user too 
                Console.ReadLine();                                   //press enter to roll the dice again
            }
            Console.WriteLine("Totalasumman av alla tärningar: " + sumNumbers); // Write the end result of
                                                                                //the total value of the dices
            Console.WriteLine("Antal kastade tärningar: " + sumRolls + "st"); // total dices rolled           
        }
        public static int ChooseNumberOfDices()  // starts the game method
        {
            Console.Write("Välj antal tärningar, 1,2,3 eller 4 st: "); // let the user choice number of dices
            string theAnwserAsAString = Console.ReadLine(); // store the input from user

            if (int.TryParse(theAnwserAsAString, out int inputDices)) // check so the input is a int
            {
                // check so the user did choose 1-4 dices.
                if (inputDices > 0 && inputDices < 5)
                {
                    return inputDices;    // returns the number of dices user did choose 
                }
            }
            Console.WriteLine("fel, försök igen"); // tell the user it typed wrong
            ChooseNumberOfDices(); // let the user Choose again from the start of the method.
            return inputDices; // returns the number of dices from the start method.
        }
        public static void ExitGame() // a method that let the user choose what to do after the game ends
        {
            // let the user choose to start again or end the program by choosing number 1 or 2.
            Console.Write("För att spela igen skriv siffran 1, eller 2 för att avsluta programmet: ");
            string theAnwserAsAString = Console.ReadLine(); // store the input

            if (int.TryParse(theAnwserAsAString, out int anwser)) // check so the input is a int
            {
                if (anwser == 1) // if the user choosed 1 and to start the game again.
                {
                    Console.Clear(); // clear the consol to ease the view.
                    Dices(ChooseNumberOfDices()); // starts the game from beginning when calling this method
                    ExitGame(); // so the user can choose to start the game one more time or end the program.
                }
                else if (anwser == 2)
                {
                    System.Environment.Exit(0); // if input was 2 the program will end here.
                }
                else
                {
                    Console.WriteLine("Fel siffra, försök igen"); // tell the user it dident use the right number
                    ExitGame(); // let the user choose again to start the game again or end the consol.
                }
            }
            Console.WriteLine("ingen siffra, försök igen"); // tell the user it didnt write a int.
            ExitGame(); // let the user choose again from the beginnig of the method.
        }

    }
}
