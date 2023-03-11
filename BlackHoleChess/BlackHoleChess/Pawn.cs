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
            image = Image.FromFile(basePath + @"\BlackHoleChess\BlackHoleChess\PiecesPhotos\pawn.png");
            createPiece();
        }

        private void createPiece()
        {

            button = new Button();
            
            button.Location = new Point(xCoord, yCoord);
            button.Image = image;
            button.Height = image.Height;
            button.Width = image.Width;

            activeForm.Controls.Add(button);
        }
    }
}
