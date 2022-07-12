namespace TicTacToe
{
    class Program
    {
        public static int playerTurn = 1;
        public static string mark = "";
        public static string _playerInput = "";

        public static void Main(string[] args)
        {
            StartRound();
        }

        public static void StartRound() // Round starter method
        {
            DisplayTable();

            if (gameEnded)
            {
                Console.WriteLine("");
                Console.WriteLine("Game Ended");
                Console.WriteLine(winnerPlayer + " Has Won");
            }

            else
            {
                Console.WriteLine("");
                Console.WriteLine("Player " + playerTurn + " Turn");
                Console.WriteLine("Select A Slot");

                if (playerTurn == 1)
                {
                    mark = "X";
                } // Player 1 mark is X

                else
                {
                    mark = "O";
                } // Player 2 mark is O

                _playerInput = Console.ReadLine();

                CheckPlayerInput(_playerInput);
            }
        }

        public static void CheckPlayerInput(string playerInput) // Control player input 
        {
            int playerInputAsInteger;

            try // We use try-catch to detect user is giving us a number or string. With try catch, program runs all time
            {
                playerInputAsInteger = int.Parse(playerInput);

                if(playerInputAsInteger < 0 || playerInputAsInteger > 9) // Index must be between 0-9
                {
                    Console.Clear();

                    Console.WriteLine("Enter Valid Number!");
                }

                else
                {
                    if (filledSlots.Count == 0)
                    {
                        Console.Clear();

                        filledSlots.Add(playerInputAsInteger); // Add to the list

                        WriteToTable(playerInputAsInteger); // Write given index to the table
                    }

                    else
                    {
                        foreach (var filledSlot in filledSlots) // Index must be not used before
                        {
                            if (playerInputAsInteger == filledSlot)
                            {
                                Console.Clear();
                                Console.WriteLine("That Slot Is Filled Before!");
                            }

                            else
                            {
                                Console.Clear();

                                filledSlots.Add(playerInputAsInteger);

                                WriteToTable(playerInputAsInteger); // Write given index to the table
                            }
                        }
                    }
                }
            }

            catch(Exception e)
            {
                Console.Clear();

                //Console.WriteLine("Enter Valid Number!");

                StartRound();
            }
        }

        //---
        public static List<int> filledSlots = new List<int>();

        public static string[,] table = { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9"} }; // Our game table

        public static void DisplayTable() // Display tictactoe table
        {
            for (int i = 0; i < table.GetLength(0); i++)
            {
                Console.WriteLine("");

                for(int j = 0; j < table.GetLength(1); j++)
                {
                    Console.Write(" | ");
                    Console.Write(table[i, j]);
                    Console.Write(" | ");
                }

                Console.WriteLine("");
            }
        }

        public static void WriteToTable(int givenIndex) // Convert one coordinate to (x,y)
        {
            switch (givenIndex)
            {
                case 1:
                    table[0, 0] = mark;
                    break;

                case 2:
                    table[0, 1] = mark;
                    break;

                case 3:
                    table[0, 2] = mark;
                    break;

                case 4:
                    table[1, 0] = mark;
                    break;

                case 5:
                    table[1, 1] = mark;
                    break;

                case 6:
                    table[1, 2] = mark;
                    break;

                case 7:
                    table[2, 0] = mark;
                    break;

                case 8:
                    table[2, 1] = mark;
                    break;

                case 9:
                    table[2, 2] = mark;
                    break;
            }

            if(playerTurn == 1) { playerTurn = 2; }

            else if(playerTurn == 2) { playerTurn = 1; }

            CheckWinner();
        }

        public static string[] playerMarks = { "X", "O" };
        public static bool gameEnded;
        public static string winnerPlayer = "";

        public static void CheckWinner()
        {
            for(int i = 0; i < playerMarks.Length; i++)
            {
                if (!gameEnded && ((table[0, 0] == playerMarks[i]) && (table[0, 1] == playerMarks[i]) && table[0,2] == playerMarks[i]) 
                    || ((table[1, 0] == playerMarks[i]) && (table[1, 1] == playerMarks[i]) && table[1, 2] == playerMarks[i])
                    || ((table[2, 0] == playerMarks[i]) && (table[2, 1] == playerMarks[i]) && table[2, 2] == playerMarks[i])
                    || ((table[0, 0] == playerMarks[i]) && (table[1, 0] == playerMarks[i]) && table[2, 0] == playerMarks[i])
                    || ((table[0, 1] == playerMarks[i]) && (table[1, 1] == playerMarks[i]) && table[2, 1] == playerMarks[i])
                    || ((table[0, 2] == playerMarks[i]) && (table[1, 2] == playerMarks[i]) && table[2, 2] == playerMarks[i])
                    || ((table[0, 0] == playerMarks[i]) && (table[1, 1] == playerMarks[i]) && table[2, 2] == playerMarks[i])
                    || ((table[0, 2] == playerMarks[i]) && (table[1, 1] == playerMarks[i]) && table[2, 0] == playerMarks[i]))
                {
                    gameEnded = true;

                    if(playerMarks[i] == "X")
                    {
                        Console.WriteLine("PLAYER 1 WON");

                        winnerPlayer = "Player 1";
                    }

                    else
                    {
                        Console.WriteLine("PLAYER 2 WON");

                        winnerPlayer = "Player 2";
                    }

                    Console.WriteLine("GAME ENDED");
                }
            }

            StartRound();
        }
    }
}
