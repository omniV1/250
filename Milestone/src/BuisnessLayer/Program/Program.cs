


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

            // Step 1: Ask the user for a row and column number.
            Console.WriteLine("Enter the row number:");
            int row = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the column number:");
            int column = Convert.ToInt32(Console.ReadLine());

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
                for (int i = 0; i < board.Size; i++)
                {
                    for (int j = 0; j < board.Size; j++)
                    {
                        // Directly access the Cell properties
                        Cell cell = board.Grid[i, j];
                        if (cell.Visited)
                        {
                            // Display the number of live neighbors or an empty square
                            Console.Write(cell.LiveNeighbors > 0 ? $"{cell.LiveNeighbors} " : "□ ");
                        }
                        else
                        {
                            // Unvisited cells are represented with a question mark
                            Console.Write("? ");
                        }
                    }
                    Console.WriteLine(); // New line at the end of each row
                }
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







