using System;
using System.Collections.Generic;
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

        protected string basePath = @"C:\Universtitate\An 3 sem 2\A.I\Proiect\BlackHoleChess";

        public string Side { get => side; set => side = value; }

        public Piece(int xCoord, int yCoord, string side) {
            this.xCoord = xCoord;
            this.yCoord = yCoord;
            this.Side = side;
        }

    }
}
