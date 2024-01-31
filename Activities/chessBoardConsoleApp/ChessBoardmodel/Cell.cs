using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardmodel
{
    class Cell
    {
        // row and col are the cell's location on the grid.
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }

        // T/F is the chess piece on this cell? 
        public bool CurrentlyOcupied { get; set; }

        //is this square a legal move for the chess piece on the board? 
        public bool LegalNextMove { get; set; }

        // constructor
        public Cell(int r, int c)
        {
            RowNumber = r; 
            ColumnNumber = c;
        }
    }
}
