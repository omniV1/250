


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
        // Create an instance of the Board class.
        Board board = new(10); // Assume a 10x10 board for this example.
        board.SetupLiveNeighbors(); // Place live bombs on the board.
        board.CalculateLiveNeighbors(); // Calculate live neighbors for all cells.

        // Call the PrintBoard method to display the board.
        PrintBoard(board);
    }

    /// <summary>
    /// Prints the board to the console. Each cell is represented by a character:
    /// '.' for an unvisited cell, 'B' for a live bomb, or the number of live neighbors.
    /// </summary>
    /// <param name="board">The game board to print.</param>
    static void PrintBoard(Board board)
    {
        for (int i = 0; i < board.Size; i++)
        {
            for (int j = 0; j < board.Size; j++)
            {
                // If the cell is a live bomb, print 'B'.
                if (board.Grid[i, j].Live)
                {
                    Console.Write("B ");
                }
                else
                {
                    // If the cell is not visited, print '.', otherwise print the number of live neighbors.
                    char toPrint = board.Grid[i, j].Visited ? board.Grid[i, j].LiveNeighbors.ToString()[0] : '.';
                    Console.Write($"{toPrint} ");
                }
            }
            Console.WriteLine(); // New line after each row.
        }
    }
}

