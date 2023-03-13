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
        protected Button button;
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
            {
                button.Location = new Point(xCoord, yCoord);
                button.Size = piecesSize;
                button.Click += space_Click;
                createInvisibleSpace();
            }
        }

        private void space_Click(object? sender, EventArgs e)
        {

        }

        private void createInvisibleSpace()
        {
            clearBlock(button);
            activeForm.Controls.Add(button);
        }


        protected void displayPossibleMoves()
        {
            if(this is Pawn)
            {

                if (this.button.BackColor == Color.Red)
                {
                    clearPossibleMoveBlocks();
                }
                else
                {
                    int line = 0, column = 0;
                    getIndexOfCurrentPiece(ref column, ref line);
                    colorBlock(Table.pieces[line, column].button);
                    colorBlock(Table.pieces[line - 1, column].button);
                    
                    if (Pawn.firstMove)
                        colorBlock(Table.pieces[line - 2, column].button);
                }
            }

        }
        private void getIndexOfCurrentPiece(ref int column, ref int line)
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

        private void clearPossibleMoveBlocks()
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


        private void colorBlock(Button button)
        {
            button.FlatStyle = FlatStyle.Standard;
            button.ForeColor = Color.Red;
            button.BackColor = Color.Red;
        }
        private void clearBlock( Button button)
        {
            button.BackColor = Color.Transparent;
            button.ForeColor = Color.Transparent;
            button.FlatStyle = FlatStyle.Flat;
        }
    }
}
