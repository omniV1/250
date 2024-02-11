##### Owen Lindsey
##### CST-250
##### Milestone 2
---

# Minesweeper Game - Milestone 2 Synopsis

## Overview
In this milestone, we've implemented a console-based version of the classic Minesweeper game. The program is written in C# and showcases object-oriented programming principles.

## Key Features
- **Board Initialization**: The game begins by creating a 10x10 board, where bombs are placed randomly based on the difficulty level.
- **Gameplay Loop**: Players enter coordinates for the row and column they wish to reveal. The game continues until a bomb is hit or all safe cells are revealed.
- **Victory Check**: After each move, the game checks if the player has won by revealing all non-bomb cells.
- **User Interface**: The board is displayed in the console with clear demarcation of cells, using `.` for unvisited cells, `B` for bombs, and numbers representing the count of adjacent bombs.

## Classes and Methods
- `Program`
  - Contains the `Main` method, which drives the game by initializing the board and entering the gameplay loop.
  - `PrintBoard` method for displaying the board in a user-friendly format.
- `Board`
  - Manages the board size, the grid of cells, and the overall difficulty.
  - Methods for setting up bombs (`SetupLiveNeighbors`) and calculating adjacent live cells (`CalculateLiveNeighbors`).
- `Cell`
  - Represents each cell on the board with properties such as row, column, visited, live, and the count of live neighbors.
  - Includes methods to access and mutate its state, like `SetVisited` and `SetLive`.



## Enhancements in Milestone 2
- Improved `PrintBoard` method for enhanced readability and aesthetics in the console.
-  User input handling to check for zero-based array indexing, which corrects the previous off-by-one error.
-  Check for victory conditions.
-  
# logic flowchart 

## Gameplay Mechanics
1. The board is printed to the console with initial hidden cells.
2. The user inputs their desired cell to reveal.
3. Input is validated and checked against the board's state.
4. If a bomb is revealed, the game ends with a loss. Otherwise, gameplay continues.
5. If all safe cells are revealed, the game ends with a win.
# UML Diagrams 

![flowchart]()

- The Board class is responsible for setting the size, difficulty (amount of bombs) , and the grid itself that displays in the console. 

![Board Uml](https://github.com/omniV1/250/blob/main/Milestone/UML-diagrams/CST-250-Board-class.drawio.png)

- The cell calss is repsonsible for setting the cell as an active bomb or an empty space.

![Cell uml](https://github.com/omniV1/250/blob/main/Milestone/UML-diagrams/CST-250-Cell-Class.drawio.png) 

- The Program class acts as the main entry point for the minesweeper application. Also repsonible for updating the state of the board with our print board and check victory methods.  

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


