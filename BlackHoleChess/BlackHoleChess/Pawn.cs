using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackHoleChess
{

    internal class Pawn : Piece
    {
        private bool firstMove;
        public Pawn(int xCoord, int yCoord, string side) : base(xCoord, yCoord, side)
        {
            createPiece();
            firstMove = true;
        }

        private void createPiece()
        {
            button = new Button();
            button.Location = new Point(xCoord, yCoord);
            button.Size = piecesSize;
            button.Image = image;
            button.Name = Side;
            button.Click += pawn_Click;
            activeForm.Controls.Add(button);
        }


        private void pawn_Click(object? sender, EventArgs e)
        {
            Button pressedPawn = null;
            try { 
                pressedPawn = sender as Button;

            }
            catch{
                MessageBox.Show("Aolo ceva nu e bine");
            }


            if (isYourTurn(pressedPawn))
            {
                if (pieceIsPressed(pressedPawn))
                {
                    clearPossibleMoveBlocks();
                }
                else if (!arePressedPieces())
                {
                    displayMovesPlayer();
                }
            }
        }
        
        private void displayMovesPlayer()
        {
            int line = 0, column = 0;
            getIndexOfCurrentPiece(ref column, ref line);

            colorBlock(this.button);
            colorBlock(Table.pieces[line - 1, column].button);

            if (firstMove)
                colorBlock(Table.pieces[line - 2, column].button);
        }

        private void displayMovesEnemy()
        {

        }

    }
}
