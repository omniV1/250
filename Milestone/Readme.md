##### Owen Lindsey
##### CST-250
##### Milestone 1
---
### UML Diagrams 

- The Board class is responsible for setting the size, difficulty (amount of bombs) , and the grid itself that displays in the console. 

![Board Uml](https://github.com/omniV1/250/blob/main/Milestone/UML-diagrams/CST-250-Board-class.drawio.png)

- The cell calss is repsonsible for setting the cell as an active bomb or an empty space.

![Cell uml](https://github.com/omniV1/250/blob/main/Milestone/UML-diagrams/CST-250-Cell-Class.drawio.png) 

- The Program class acts as the main entry point for the minesweeper application.

![Program uml](https://github.com/omniV1/250/blob/main/Milestone/UML-diagrams/CST-250-Program-class.drawio.png) 

---

### Src code 

 - This code reprsents the game board, which is a square grid of cells.

   

``` C#
{
using System;

/// <summary>
/// Represents the game board, which is a square grid of cells.
/// </summary>
public class Board
{
    // The size of the board (number of cells in each row and column).
    public int Size { get; private set; }

    // The grid of cells, represented as a 2D array.
    public Cell[,] Grid { get; private set; }

    // The difficulty level, represented as a percentage of cells that will be "live".
    public float Difficulty { get; set; }

    /// <summary>
    /// Constructor for the Board class. Initializes a square grid of Cell objects.
    /// </summary>
    /// <param name="size">The size of the sides of the square grid.</param>
    public Board(int size)
    {
        Size = size;
        Difficulty = 0.1f; // Default difficulty, can be adjusted externally.
        Grid = new Cell[size, size];

        // Initialize each cell in the grid.
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Grid[i, j] = new Cell();
                Grid[i, j].Row = i;
                Grid[i, j].Column = j;
            }
        }
    }

    /// <summary>
    /// Populates the grid with live bombs based on the difficulty level.
    /// </summary>
    public void SetupLiveNeighbors()
    {
        Random random = new Random();
        // Calculate the number of live bombs to place based on difficulty.
        int liveCellsCount = (int)(Size * Size * Difficulty);

        while (liveCellsCount > 0)
        {
            int row = random.Next(Size);
            int column = random.Next(Size);

            // Place a live bomb in a random cell if it's not already live.
            if (!Grid[row, column].Live)
            {
                Grid[row, column].Live = true;
                liveCellsCount--;
            }
        }
    }

    /// <summary>
    /// Calculates the live neighbors for each cell in the grid.
    /// </summary>
    public void CalculateLiveNeighbors()
    {
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                if (Grid[i, j].Live)
                {
                    // If the cell itself is live, set its neighbor count to 9.
                    Grid[i, j].LiveNeighbors = 9;
                }
                else
                {
                    // Check all neighboring cells.
                    int liveNeighbors = 0;
                    for (int x = Math.Max(i - 1, 0); x <= Math.Min(i + 1, Size - 1); x++)
                    {
                        for (int y = Math.Max(j - 1, 0); y <= Math.Min(j + 1, Size - 1); y++)
                        {
                            if (Grid[x, y].Live && !(x == i && y == j))
                            {
                                liveNeighbors++;
                            }
                        }
                    }

                    Grid[i, j].LiveNeighbors = liveNeighbors;
                }
            }
        }
    }
}

```



- This class src code represents a single cell on the game board

  

``` C#
{
﻿using System;


/// <summary>
/// Represents a single cell on a game board.
/// </summary>
public class Cell
{
    // Properties of the cell, with default values
    public int Row { get; set; } = -1;
    public int Column { get; set; } = -1;
    public bool Visited { get; set; } = false;
    public bool Live { get; set; } = false;
    public int LiveNeighbors { get; set; } = 0;

    /// <summary>
    /// Constructor for the Cell class.
    /// </summary>
    public Cell()
    {
        // The properties are already initialized with default values.
    }
}

```



- This is the main entry point for our minesweeper application.



  

```C# 
{

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
```

--- 

### Running program 

- This image shows our current console.out to the terminal when we run program.cs.

  ![Running program](https://github.com/omniV1/250/blob/main/Milestone/UML-diagrams/program-running.png)


