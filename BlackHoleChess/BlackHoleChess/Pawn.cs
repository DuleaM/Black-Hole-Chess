using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackHoleChess
{

    internal class Pawn : Piece
    {
        bool firstMove;
        public Pawn(int xCoord, int yCoord, string side) : base(xCoord, yCoord, side)
        {
            if (side == "Black")
                image = Image.FromFile(basePath + @"\BlackHoleChess\BlackHoleChess\PiecesPhotos\pawn_black.png");
            else if (side == "White")
                image = Image.FromFile(basePath + @"\BlackHoleChess\BlackHoleChess\PiecesPhotos\pawn_white.png");

            createPiece();
            firstMove = false;
        }

        private void createPiece()
        {
            button = new Button();
            button.Location = new Point(xCoord, yCoord);
            button.Size = piecesSize;
            button.Image = image;

            activeForm.Controls.Add(button);
        }


    }
}
