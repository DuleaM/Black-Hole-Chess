using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackHoleChess
{
    internal class Piece
    {
        protected Form activeForm = Form.ActiveForm;
        protected Image image;
        private string side;
        protected int xCoord;
        protected int yCoord;
        public Button button;
        protected Size piecesSize = new Size(60, 90);

        protected string basePath = @"C:\Universtitate\An 3 sem 2\A.I\Proiect\BlackHoleChess";

        public string Side { get => side; set => side = value; }

        public Piece(int xCoord, int yCoord, string side) {
            button = new Button();
            button.BackColor = Color.Transparent;

            this.xCoord = xCoord;
            this.yCoord = yCoord;
            this.side = side;

            if (side == "Black")
                image = Image.FromFile(basePath + @"\BlackHoleChess\BlackHoleChess\PiecesPhotos\pawn_black.png");
            else if (side == "White")
                image = Image.FromFile(basePath + @"\BlackHoleChess\BlackHoleChess\PiecesPhotos\pawn_white.png");
            else if (side == "")
                setWhiteSpace();
        }

        private void space_Click(object? sender, EventArgs e)
        {

        }
        protected bool arePressedPieces()
        {
            for (int i = 0; i < Table.height; i++)
            {
                for (int j = 0; j < Table.width; j++)
                {
                    if (Table.pieces[i, j].button.BackColor == Color.Red)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        protected void getIndexOfCurrentPiece(ref int column, ref int line)
        {
            for (int i = 0; i < Table.height; i++)
            {
                for (int j = 0; j < Table.width; j++)
                {
                    if (Table.pieces[i, j] == this)
                    {
                        line = i;
                        column = j;
                        break;
                    }
                        

                }
            }
        }
        protected void clearPossibleMoveBlocks()
        {
            for (int i = 0; i < Table.height; i++)
            {
                for (int j = 0; j < Table.width; j++)
                {
                    if (Table.pieces[i, j].button.BackColor == Color.Red)
                    {
                        clearBlock(Table.pieces[i, j].button);
                    }
                }
            }
        }
        protected void colorBlock(Button button)
        {
            button.FlatStyle = FlatStyle.Standard;
            button.ForeColor = Color.Red;
            button.BackColor = Color.Red;
        }
        protected void clearBlock(Button button)
        {
            button.BackColor = Color.Transparent;
            button.ForeColor = Color.Transparent;
            button.FlatStyle = FlatStyle.Flat;
        }
        private void setWhiteSpace()
        {
            button.Location = new Point(xCoord, yCoord);
            button.Size = piecesSize;
            button.Click += space_Click;
            clearBlock(button);
            activeForm.Controls.Add(button);
        }

        protected bool pieceIsPressed(Button button)
        {
            if(button.BackColor == Color.Red)
                return true;
            return false;
        }
    }
}
