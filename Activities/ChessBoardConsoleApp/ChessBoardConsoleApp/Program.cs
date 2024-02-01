using ChessBoardModel;
using System.Runtime.InteropServices;

namespace ChessBoardConsoleApp 
{ 

class Program
{
    static Board myBoard = new Board(8); 

        static public void printGrid(Board myBoard)
        {
            // show the chess board
            // use . for an empty space 
            // X for the piece location
            // + for possible legal moves
            for(int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    if (myBoard.theGrid[i, j].CurrentlyOcupied)
                    {
                        Console.Write("X");
                    }
                    else if (myBoard.theGrid[i, j].LegalNextMove)
                    {
                        Console.Write("+");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                      
                }
                Console.WriteLine(); 
            }
            Console.WriteLine("=========================================");
        }
        static public Cell setCurrentCell()
        {
            Console.Out.Write("Enter your current row number "); 
            int currentRow = int.Parse(Console.ReadLine());

            Console.Out.Write("Enter your current column number");
            int currentCol = int.Parse(Console.ReadLine());

            myBoard.theGrid[currentRow, currentCol].CurrentlyOcupied = true;

            return myBoard.theGrid[currentRow, currentCol]; 
        }

        static void Main(String[] args)
    {
            // show the empty chess board
            printGrid(myBoard);

            // get the location of the chess piece
            Cell myLocation = setCurrentCell();

            // calculate and mark the cells where legal moves are possible
            myBoard.MarkNextLegalMoves(myLocation, "Knight");

            // show the chess board
            // use . for an empty space 
            // X for the piece location
            // + for possible legal moves
            printGrid(myBoard); 

            // wait for another return key to end the program
            Console.ReadLine();
    }
}


}
