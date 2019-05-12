using System;

namespace Antagningsprov_DavidStåhl_8809080032
{
    class Programs
    {
        static void Main(string[] args)
        {
            Console.WriteLine("David Ståhl 2019-05-13"); // Writes the creator and the date of creation.                                                              
            ChooseNumberOfDices(); // Starts the game when calling this method
            Console.ReadLine();
        }
        public static void RollDice(int dices) // The dice method takes the input of how many dices to play.
        {
            int sumRolls = 0; // How many dices(randomnumbers) is looped.
            int sumNumbers = 0; // The sum of numbers from the random numbers. without the number six.
            int bonusRolls = 0; // A variable to track the bonus rolls if the randomnumber rolls six.

            for (int i = 0; i < dices; i++) // A loop with variable i as the number of dices rolled.
            {
                Random random = new Random(); // Creating a random method.
                int randomNumber = random.Next(1, 7); // Gives randomNumber, the random number from 1-6.
                sumRolls = i + 1; // Adds +1 every loop of how many dices rolled .
                Console.WriteLine("Totalt kastade tärningar: " + sumRolls + // Tell the user number of rolled dices,
                                 "\nVärdet på tärningen = " + randomNumber); // the value of the roll.
                if (randomNumber == 6) // If the random number is six do something.
                {
                    dices += 2; // Adds two extra dices to roll if the random number is six.
                    bonusRolls += 1;  // Adds bonus rolls to keep the sumNumbers from adding the six.
                    Console.WriteLine("Tärningen visade en sexa, vilket" +
                                      " betyder att du får två extra tärningar!"); // Tell the user it got two extra dices
                }                                                                     // to throw, because the dice rolled a six.                                                    
                else if (bonusRolls > 0) // If there is bonusrolls from getting a six, do those rolls
                {                         // Before the next dice.
                    bonusRolls--;            // After each bonusroll give bonusroll -1 each loop.
                    sumNumbers += randomNumber;    // Add the the randomnumbers to total sum
                }                                    // as long its not a six.
                else
                {
                    sumNumbers += randomNumber;      // Add the rolled value to the sumNumbers
                }               
                Console.WriteLine("Tryck enter för slå nästa tärning");
                Console.ReadLine();  // press enter to roll the next dice.


            }
            Console.WriteLine("Slut på tärningar, för att se resultat tryck enter");
            Console.ReadLine();  // press enter to se the result.
            Console.WriteLine("Totalsumman av alla tärningar: " + sumNumbers); // Write the end result of
                                                                               // the total value of the dice,
                                                                               // without the dice that gave a six.
            Console.WriteLine("Antal kastade tärningar: " + sumRolls + "st"); // Write the total dices rolled.
            ExitGame();
        }
        public static void ChooseNumberOfDices()  // The method that lets the user choose number of dices.
        {
            Console.Write("Välj antal tärningar, 1,2,3 eller 4 st: "); // let the user choose number of dices.
            string theAnwserAsAString = Console.ReadLine(); // Store the input from user.

            if (int.TryParse(theAnwserAsAString, out int inputDices)) // Check so the input is a number.
            {
                if (inputDices >= 1 && inputDices <= 4) // Check so the user did choose 1-4 dices.
                {
                    Console.WriteLine("För att kasta första tärningen, tryck enter"); // Press enter to start the game         
                    Console.ReadLine();  // Pause the program so user can start the game with pressing enter.
                    RollDice(inputDices);   //Starts the rollDice method, with inputDices as parameter.
                }
                else
                {
                    Console.WriteLine("fel antal tärningar, försök igen"); // Tell the user it typed wrong number of dices.
                    ChooseNumberOfDices(); // A recursive method , so the user can choose dices again.
                }
            }
            Console.WriteLine("fel inmatning, försök igen"); // Tell the user it typed wrong input.
            ChooseNumberOfDices(); // A recursive method , so the user can choose dices again. 
        }
        public static void ExitGame() // A method that let the user choose what to do after the game ends
        {
            Console.Write("För att spela igen skriv siffran 1," +  // let the user choose to start again or end
                         " eller 2 för att avsluta programmet: "); // the program by choosing number 1 or 2.
            string theAnwserAsAString = Console.ReadLine(); // Store the input

            if (int.TryParse(theAnwserAsAString, out int anwser)) // Check so the input is a number
            {
                if (anwser == 1) // If the user choosed number one do this.
                {
                    Console.Clear(); // Clear the consol to ease the view.
                    ChooseNumberOfDices(); // Starts the game from the beginning, when calling this method            
                }
                else if (anwser == 2)  // If the user choosed number two, do this.
                {
                    System.Environment.Exit(0); // If the input was number two, the program will end here.
                }
                else    // If user did write a number, but not number one or two.
                {
                    Console.WriteLine("Fel siffra, försök igen"); // Tell the user it didn't use a correct number
                    ExitGame(); // A recursive method, so the user can choose again to start the game,                             
                }               // again or end the program.
            }
            Console.WriteLine("Fel inmatning, försök igen"); // Tell the user it didn't write a number.
            ExitGame();   // A recursive method, so the user can choose again to start the game, 
        }                 // again or end the program.

    }
}
