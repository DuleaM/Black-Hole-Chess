using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackHoleChess
{
    internal class Table
    {
        Form currentForm = Form.ActiveForm;
        private int width;
        private int height;
        private Piece[,] pieces = new Piece[20, 20];

        public Table() {
            this.width = currentForm.Width;
            this.height = currentForm.Height;

        }

        public void createTable2()
        {
            pieces[0, 0] = new Pawn(0, 100, "Black");
            pieces[0, 1] = new Pawn(100, 100, "Black");
            pieces[0, 2] = new Pawn(200, 100, "Black");
            pieces[0, 3] = new Pawn(300, 100, "Black");
            pieces[0, 4] = new Pawn(400, 100, "Black");
            pieces[0, 5] = new Pawn(500, 100, "Black");

        }

        public void createTable()
        {
            for (int column = 0; column < width; ++column)

            {
                for(int line = 0; line < height; ++line)
                {
                    //create pieces
                }
            }

        }

    }
}
