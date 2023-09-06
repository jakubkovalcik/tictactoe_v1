using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsAndClasses
{
    internal class TicTacToe
    {
        // void function to print the current state of a playing field - prints straight to console.
        static void updateTable(string[,] arr)
        {
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(" "+ arr[i,j]+ " |");
                }
                Console.Write("\n---+---+---+\n");
            }  
        }


        // Checks for a sequence of 3 identical symbols inputed by players, checks for winner, returns true if the winner is found.
        static bool checkWinner(string[,] arr)
        {

            // Checks for the sequence
            bool winner = false;
            string character = "";

            for (int i = 0; i < 3; i++)
            {
                if (arr[i, 0] == arr[i, 1] && arr[i, 1] == arr[i, 2])
                {
                    winner = true; 
                    character = arr[i, 0];
                    break;
                }
                else if (arr[0, i] == arr[1, i] && arr[1, i] == arr[2, i])
                {
                    winner = true; 
                    character = arr[0,i];
                    break;
                }
            }

            if (arr[2, 0] == arr[1, 1] && arr[1, 1] == arr[0, 2])
            {
                winner = true;
                character = arr[2, 0];
            }
            else if (arr[0, 0] == arr[1, 1] && arr[1, 1] == arr[2, 2])
            {
                winner = true;
                character = arr[0, 0];
            }

            if (winner == true)
            {
                // Game Ends - updates the table first, so it can be seen, then prints a name of the winner.

                Console.Clear();
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(" " + arr[i, j] + " |");
                    }
                    Console.Write("\n---+---+---+\n");
                }

                if (character == "X")
                {
                    Console.WriteLine("Player 2 wins!");
                    return winner;
                }
                else
                {
                    Console.WriteLine("Player 1 wins!");
                    return winner;
                }
            }
            else { return false; }
        }

        static void Main(string[] args)
        {
            // initialize an array as a 3x3 playing field grid. numbers 1-9 will represent the positions
            string[,] pole = new string[,] { 
                { "1", "2", "3" }, 
                { "4", "5", "6" }, 
                { "7", "8", "9" } 
            };

            // set condition for the continuation of the game and set players' order: player number 1 will be the first to play.
            bool winner = false;
            int player_turn = 1;

            while (!winner) // while no one has won, continue the game
            {
                //prints the current state of a 3x3 playing field grid
                updateTable(pole);

                Console.WriteLine("Choose a square you wish to play (P1 = O; P2 = X)");
                if (player_turn == 1 && !winner)
                {
                    Console.WriteLine("Player 1's turn:");
                }
                else if (player_turn == 2 && !winner)
                {
                    Console.WriteLine("Player 2's turn:");
                }

                // Validate the input and mark the position

                string input = Console.ReadLine();
                int num_input = 0;
                bool success = false;
                while (!success)
                {
                    success = int.TryParse(input, out num_input);
                    if (success && (num_input < 10 && num_input > 0))
                    {
                        break;
                    }
                    else if(!success || (num_input > 9 && num_input < 1))
                    {
                        updateTable(pole);
                        Console.WriteLine("Choose a square you wish to play (P1 = O; P2 = X)");
                        Console.WriteLine("Invalid entry. Choose a position between 1 and 9, as shown:");
                        input = Console.ReadLine();
                    }
                    else { Console.WriteLine("Unexpected Error: TryParse_Cycle section"); }
                }

                // Change the value of designated square of the playing field

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (pole[i, j] == num_input.ToString())
                        {
                            if (player_turn == 1)
                            {
                                pole[i, j] = "O";
                                player_turn = 2;
                                //break;
                            }
                            else
                            {
                                pole[i, j] = "X";
                                player_turn = 1;
                                //break;
                            }
                        }
                    }
                }

                // Checks an array for 3 identical characters in a sequence [3x3 grid], returns bool for the while cycle condition
                winner = checkWinner(pole);
            }  
        }
    }
}
