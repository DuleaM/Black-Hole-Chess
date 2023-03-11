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

        private int width;
        private int height;
        private Piece[,] pieces;

        public Table(int width, int height) {
            this.width = width;
            this.height = height;
            this.pieces = new Piece[width, height];
        }


        public void createTable2()
        {
            Pawn pawn = new Pawn(20, 20, "Black");
        }

        public void createTable()
        {
            for (int column = 0; column < width; ++column)

            {
                for(int line = 0; line < height; ++height)
                {
                    //create pieces
                }
            }

        }

    }
}
