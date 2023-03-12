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
        private Piece[,] pieces;
        private int left_space = 200;
        private int under_space = 100;
        private int test;
        public Table() {
            this.height = 9;
            this.width = 13;
            pieces = new Piece[width, height];
            left_space = currentForm.Width / width;
        }



        public void createTable()
        {
            createBlackTeam();
            //createWhiteTeam();
        }

        private void createBlackTeam()
        {
           for (int line = 0; line < 13; ++line) {
                for (int column = 0; column < height; ++column){
                    pieces[line, column] = new Pawn(left_space * column, under_space * line, "Black");
                }
           }
        }

        private void createWhiteTeam()
        {
            for (int line = 7; line < 9; ++line)
            {
                for (int column = 0; column < height; ++column)
                {
                    //pieces[line, height] = new Pawn(space * column, space * line, "Black");
                }
            }

        }

    }
}
