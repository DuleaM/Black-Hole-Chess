using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackHoleChess
{

    internal class Pawn : Piece
    {
        public static bool firstMove;
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
            button.Click += pawn_Click;
            activeForm.Controls.Add(button);
        }

    
        public void move()
        {
            if(firstMove)
            {
                firstMove = false;
            }
        }


        private void pawn_Click(object? sender, EventArgs e)
        {
            displayPossibleMoves();
        }


    }
}
