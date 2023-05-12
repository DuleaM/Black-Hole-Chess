using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackHoleChess
{

    internal class Pawn : Piece
    {
        private static bool firstMoveWhite;
        private static bool firstMoveBlack;
        public Pawn(int xCoord, int yCoord, string side) : base(xCoord, yCoord, side)
        {
            createPiece();
            firstMoveWhite = true;
            firstMoveBlack = true;
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
            Button pressedPawn = sender as Button;

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
            if(this.Side == "White")
            {
                displayWhiteMoves();
            }

            if(this.Side == "Black")
            {
                displayBlackMoves();
            }
            
        }

        private void displayWhiteMoves()
        {
            int line = 0, column = 0;
            getIndexOfPressedPiece(ref column, ref line);

            colorBlock(this.button);

            if (Table.pieces[line - 1, column].Side == "") {
                colorBlock(Table.pieces[line - 1, column].button);
            }

            if (firstMoveWhite){
                if (Table.pieces[line - 2, column].Side == "")
                {
                    colorBlock(Table.pieces[line - 2, column].button);
                }
            }
        }
           

        private void displayBlackMoves()
        {
            int line = 0, column = 0;
            getIndexOfPressedPiece(ref column, ref line);

            colorBlock(this.button);
            colorBlock(Table.pieces[line + 1, column].button);

            if (firstMoveWhite)
                colorBlock(Table.pieces[line + 2, column].button);
        }
        

    }
}
