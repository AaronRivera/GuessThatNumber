using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessThatNumber
{
    public class Program
    {
        //this is the number the user needs to guess.  Set its value in your code using a RNG.
        static int NumberToGuess = 0; 
       
        static void Main(string[] args)
        {


            PlayGame();
            Console.ReadKey();
        }

        /// <summary>
        /// Plays the game guess a number function
        /// </summary>
        public static void PlayGame()
        {
            //Displays the game instructions
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("               Lets play guess the number!!!!!");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("The guess the number game is exactly what it sounds like:");
            Console.WriteLine("a number is guessed at random by the computer, and you must");
            Console.WriteLine("guess that number to win!!!");
            Console.WriteLine("The only thing the computer tells you is if your guess");
            Console.WriteLine("below or above the number ");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("                    Generatig a randon number ");

            //Generates random number
            Random rnd = new Random();
            NumberToGuess = rnd.Next(1, 101);

            //Animates generating random number
            for (int i = 0; i < 60; i++)
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(50);
            }
            Console.WriteLine("");
            //Reserved words for the game in case the user wants to exit the game
            Console.WriteLine("Quit Game : Quit or Exit");
            Console.WriteLine("");
            Console.WriteLine("                  S T A R T    G A M E ! ! !");
            Console.WriteLine("");

            //initialize variables
            bool stillGuessing = false;
            int numberOfTries = 0;
            string yourGuessString = "";
            int yourGuess = 0;

            //while the usuer is guessing the game
            while (!stillGuessing)
            {
                numberOfTries++;
                //ask the user for the guess and shows the number of tries so far
                Console.Write("Whats your {0} guess? ", numberOfTries);
                //reads the comand line
                yourGuessString = Console.ReadLine().ToString();
                //Validate the input
                if (ValidateInput(yourGuessString))
                {
                    //convert validated input to int
                    yourGuess = Convert.ToInt32(yourGuessString);
                    //if guess equals to number to guess
                    if (yourGuess == NumberToGuess)
                    {
                        //changes the flag to true so it breaks the while
                        stillGuessing = true;
                        //displays wining banner 
                        Console.WriteLine("");
                        Console.WriteLine("        **************************************************");
                        string youWon = "                         YOU WON!!!!!!!!!!!!!!!";
                        //animates you won
                        for (int i=0 ; i< youWon.Length; i++ ){
                            Console.Write(youWon[i]);
                            System.Threading.Thread.Sleep(30);

                        }
                        Console.WriteLine("");

                        Console.WriteLine("        **************************************************");
                        Console.WriteLine("");


                        //flag to control the while 
                        bool flag = false;

                        //while the input keeps giving bad input
                        while(!flag)

                        {
                            //asks user if he/she wants to keep playing
                            Console.Write("Would you like to play another game (Y/N)? ");
                            //reads the command line
                            string answer = Console.ReadLine().ToString().ToLower();
                            //if answer is yes
                            if (answer == "y" || answer == "yes")
                            {
                                //calls another game function
                                flag = true;
                                Console.Clear();
                                PlayGame();
                            }
                            //if the answer is no
                            if (answer == "n" || answer == "no") {
                                //exit the program
                                System.Environment.Exit(0);
                            }
                            else
                            {
                                //else the user keeps enetering something else
                                Console.WriteLine("Type in Y, Yes or N, No please ");
                            }
                           
                        }
                        


                    }

                    else
                    {
                        if (IsGuessTooHigh(yourGuess))
                        {
                            //Too high hint
                            Console.WriteLine("H------>");
                        }
                        if (IsGuessTooLow(yourGuess))
                        {
                            //Too low hint
                            Console.WriteLine("<------L");
                        }
                    }

                }


            }
        }
        
        public static bool ValidateInput(string userInput)
        {

                //Checks that the strings contains numbers only
                foreach (char c in userInput)
                {
                    if (c < '0' || c > '9')
                    {
                        //checks if its a reserved word 
                        Console.WriteLine("Numbers or reserved words Only!");
                        if (userInput.ToLower() == "quit" || userInput.ToLower() == "exit")
                        {
                           //if input equals quit or exit
                            System.Environment.Exit(0);
                        }
                        return false; }
                }

                //check to make sure that the users input is a valid number between 1 and 100.
                //convert string to integer
                int number = Convert.ToInt32(userInput);
                //checks if number its between 1 and 100
                if (number > 0 && number < 101)
                {
                    return true;
                }
                else
                {
                    //displays a message if the number is out of range
                    Console.WriteLine("The number has to be between 1 and 100");
                    return false;
                }    
            



        }

        public static void SetNumberToGuess(int number)
        {
            //TODO: make this function override your global variable holding the number the user needs to guess.  This is used only for testing methods.

            NumberToGuess = number;
        }

        public static bool IsGuessTooHigh(int userGuess)
        {
            //TODO: return true if the number guessed by the user is too high
            if (userGuess > NumberToGuess)
            {
                //defines a range to be able to say if user is too high, high, warm or cold, too cold
                int range = userGuess - NumberToGuess;
                    if (range <= 5){
                        //when the user is 5 numbers close to guessing
                        Console.WriteLine("Very Hot");
                    }
                    if (range > 5 && range <= 10)
                    {
                        //when the user is 10 numbers close to guessing
                        Console.WriteLine("Hot");
                    }
                    if (range > 10 && range <= 20)
                    {
                        //when the user is 20 numbers close to guessing
                        Console.WriteLine("Warm");
                    }
                    if (range >  20 && range <= 40)
                    {
                        //when the user is 20 numbers or more
                        Console.WriteLine("Cold");
                    }

                    if (range > 40 && range <= 100)
                    {
                        //when the user is 40 numbers or more
                        Console.WriteLine("Very Cold");
                    }
                
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsGuessTooLow(int userGuess)
        {
            //TODO: return true if the number guessed by the user is too low

            if (userGuess < NumberToGuess)
            {

                int range = NumberToGuess - userGuess;
                if (range <= 5)
                {
                    //when the user is 5 numbers close to guessing
                    Console.WriteLine("Very Hot");
                }
                if (range > 5 && range <= 10)
                {
                    //when the user is 10 numbers close to guessing
                    Console.WriteLine("Hot");
                }
                if (range > 10 && range <= 20)
                {
                    //when the user is 20 numbers close to guessing
                    Console.WriteLine("Warm");
                }
                if (range > 20 && range <= 40)
                {
                    //when the user is 20 numbers or more
                    Console.WriteLine("Cold");
                }
                if (range > 40 && range <= 100)
                {
                    //when the user is 40 numbers or more
                    Console.WriteLine("Very Cold");
                }                

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
