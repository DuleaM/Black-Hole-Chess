using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackHoleChess
{

    internal class Pawn : Piece
    {
        public Pawn(int xCoord, int yCoord, string side): base(xCoord, yCoord, side)
        {
            if(side == "Black")
                image = Image.FromFile(basePath + @"\BlackHoleChess\BlackHoleChess\PiecesPhotos\pawn_black.png");
            else
                image = Image.FromFile(basePath + @"\BlackHoleChess\BlackHoleChess\PiecesPhotos\pawn_white.png");

            createPiece();
        }

        private void createPiece()
        {

            button = new Button();
            
            button.Location = new Point(xCoord, yCoord);
            button.Size = new Size(60, 90);
            button.Image = image;


            activeForm.Controls.Add(button);
        }
    }
}
