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
        public Pawn(int xCoord, int yCoord, int line, int column, string side) : base(xCoord, yCoord, line, column, side)
        {
            createPiece();
            firstMoveWhite = true;
            firstMoveBlack = true;
        }

        private void createPiece()
        {
            button = new Button();
            button.Location = new Point(XCoord, YCoord);
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
            if(Table.GameTurn == Table.PlayerSide) {
                displayBottomPlayerMoves();
            }
            else
            {
                displayTopPlayerMoves();
            }
        }

        private void displayBottomPlayerMoves()
        {
          
            colorBlock(this.button);
            if (Table.pieces[this.Line - 1, this.Column].Side == "") {
                colorBlock(Table.pieces[this.Line - 1, this.Column].button);
            }

            if (firstMoveWhite){
                if (Table.pieces[this.Line - 2, this.Column].Side == "")
                {
                    colorBlock(Table.pieces[this.Line - 2, this.Column].button);
                }
            }
        }
           

        private void displayTopPlayerMoves()
        {
            
            colorBlock(this.button);
            colorBlock(Table.pieces[this.Line + 1, this.Column].button);

            if (firstMoveWhite)
                colorBlock(Table.pieces[this.Line + 2, this.Column].button);
        }
        

    }
}
