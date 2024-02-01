using ChessBoardModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChessBoardGuiApp
{
    public partial class ChessBoardForm : Form
    {
        static public Board myBoard = new Board(8);
        public Button[,] btnGrid = new Button[myBoard.Size, myBoard.Size];

        public ChessBoardForm()
        {
            InitializeComponent();
            populateGrid();
        }
        public void populateGrid()
        {
            //This function will fill the pnlChessBoard control w buttons
            // cal the button width of each button on the Grid 
            int buttonSize = pnlChessBoard.Width / myBoard.Size;
            // set the grid to be square
            pnlChessBoard.Height = pnlChessBoard.Width;

            // nested loop. create buttons and place them in the panel
            for (int r = 0; r < myBoard.Size; r++)
            {
                for (int c = 0; c < myBoard.Size; c++)
                {
                    btnGrid[r, c] = new Button();

                    //Make each button square
                    btnGrid[r, c].Width = buttonSize;
                    btnGrid[r, c].Height = buttonSize;

                    // add same click event to each button 
                    btnGrid[r, c].Click += Grid_Button_Click;

                    //place the button on the panel
                    pnlChessBoard.Controls.Add(btnGrid[r, c]);

                    //postition it in x,y
                    btnGrid[r, c].Location = new Point(buttonSize * r, buttonSize * c);

                    //for testing purposes remove later
                    btnGrid[r, c].Text = r.ToString() + "|" + c.ToString();

                    // the Tag attribute will hold the row and column number in a string 
                    btnGrid[r, c].Tag = r.ToString() + "|" + c.ToString();
                }

            }
        }

        private void Grid_Button_Click(object? sender, EventArgs e)
        {
            // get the row and column number of the button we just clicked 
            string[] strArr = (sender as Button).Tag.ToString().Split('|');
            int r = int.Parse(strArr[0]);
            int c = int.Parse(strArr[1]);

            //RUN A HELPER FUNVTION TO LABEL ALL LEGAL MOVES FOR THIS PIECE
            Cell curentCell = myBoard.theGrid[r, c];
            myBoard.MarkNextLegalMoves(curentCell, "Knight");
            UpdateButtonLabels();

            // reset the background color of all button to default
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    btnGrid[r, c].BackColor = default(Color);
                }
            }

            // set the background color of the clicked button to something else 
            (sender as Button).BackColor = Color.Gainsboro;
        }

        public void UpdateButtonLabels()
        {
            for (int r = 0; r < myBoard.Size; r++)
            {
                for (int c = 0; c < myBoard.Size; c++)
                {
                    btnGrid[r, c].Text = "";
                    if (myBoard.theGrid[r, c].CurrentlyOcupied) btnGrid[r, c].Text = "Knight";
                    if (myBoard.theGrid[r, c].LegalNextMove) btnGrid[r, c].Text = "Legal";
                }
            }
        }
    }
}