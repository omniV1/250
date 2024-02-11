


/// <summary>
/// The main entry point for the console application.
/// </summary>
class Program
{
    /// <summary>
    /// The Main method that drives the application.
    /// </summary>
    static void Main(string[] args)
    {
        // Initialize the board and game state
        Board board = new(10); // Assume a 10x10 board for this example.
        board.SetupLiveNeighbors(); // Place live bombs on the board.
        board.CalculateLiveNeighbors(); // Calculate live neighbors for all cells.

        bool gameOver = false;
        while (!gameOver)
        {
            Console.Clear(); // Optional: Clear the console for a clean game board display.
            PrintBoard(board); // Print the current state of the board.

            //  Ask the user for a row and column number.
            Console.WriteLine("Enter the row number:");
            int row = Convert.ToInt32(Console.ReadLine()) - 1; // Subtract 1 to convert to zero-based index
            Console.WriteLine("Enter the column number:");
            int column = Convert.ToInt32(Console.ReadLine()) - 1; // Subtract 1 to convert to zero-based index


            // Validate the input
            if (row < 0 || row >= board.Size || column < 0 || column >= board.Size)
            {
                Console.WriteLine("Invalid coordinates. Please try again.");
                continue;
            }

            // Step 2: Check if the chosen cell contains a bomb.
            if (board.Grid[row, column].Live)
            {
                gameOver = true;
                Console.WriteLine("Boom! You hit a bomb! Game Over.");
                break;
            }

            // Mark the cell as visited
            board.Grid[row, column].Visited = true;

            // Step 3: Check if all non-bomb cells have been revealed.
            board.Grid[row, column].Visited = true; // Mark the cell as visited

            // Check for victory after each move
            if (CheckVictory(board))
            {
                gameOver = true;
                Console.Clear(); // Clear the console for a final display of the board
                PrintBoard(board); // Print the final state of the board
                Console.WriteLine("Congratulations! You've cleared all non-bomb cells!");
                break;
            }

            // Step 4: Print the grid.
            PrintBoard(board);
        }
    }

        /// <summary>
        /// Prints the board to the console. Each cell is represented by a character:
        /// '.' for an unvisited cell, 'B' for a live bomb, or the number of live neighbors.
        /// </summary>
        /// <param name="board">The game board to print.</param>
        // New method to display the board during the game
        public static void PrintBoard(Board board)
            {
        // Top border
        Console.Write("   "); // Space for row numbers
        for (int k = 0; k < board.Size; k++)
        {
            Console.Write("+---");
        }
        Console.WriteLine("+"); // Rightmost border

        for (int i = 0; i < board.Size; i++)
        {
            // Print the row number at the start of the row with padding for single digit numbers
            Console.Write((i < 9 ? " " : "") + (i + 1) + " |");

            for (int j = 0; j < board.Size; j++)
            {
                // Directly access the Cell properties
                Cell cell = board.Grid[i, j];
                char symbol;
                if (cell.Visited)
                {
                    // Display the number of live neighbors or an empty square
                    symbol = cell.LiveNeighbors > 0 ? cell.LiveNeighbors.ToString()[0] : ' ';
                }
                else
                {
                    // Unvisited cells are represented with a question mark
                    symbol = '?';
                }

                // Print the cell with borders
                Console.Write(" " + symbol + " |");
            }

            // End of row
            Console.WriteLine();

            // Print the row separator
            Console.Write("   "); // Space for row numbers
            for (int k = 0; k < board.Size; k++)
            {
                Console.Write("+---");
            }
            Console.WriteLine("+"); // Rightmost border
        }

        // Print the column numbers at the bottom
        Console.Write("    "); // Align with the column
        for (int i = 0; i < board.Size; i++)
        {
            // Adjusted for single digit numbers with proper spacing
            Console.Write(" " + (i + 1) + "  ");
        }
        Console.WriteLine();
        Console.WriteLine("    " + new string('=', 4 * board.Size)); // Adjusted the bottom line
    }

    /// <summary>
    /// Checks if the player has won the game by revealing all non-bomb cells.
    /// </summary>
    /// <param name="board">The game board containing all cells.</param>
    /// <returns>
    /// A boolean value that is true if all non-bomb cells have been revealed and false otherwise.
    /// This indicates whether the player has successfully completed the game without hitting a bomb.
    /// </returns>
    private static bool CheckVictory(Board board)
        {
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    Cell cell = board.Grid[i, j];
                    // If there's a cell that is not a bomb and has not been visited, the player hasn't won yet.
                    if (!cell.Live && !cell.Visited)
                    {
                        return false;
                    }
                }
            }
            // If all non-bomb cells have been visited, the player wins.
            return true;
        }


    }







