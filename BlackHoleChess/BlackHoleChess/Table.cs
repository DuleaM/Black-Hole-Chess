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
        private int width = 9;
        private int height = 13;
        private Piece[,] pieces;
        private int left_space;
        private int under_space;
        public Table() {
            pieces = new Piece[height, width];
            left_space = currentForm.Width / width;
            under_space = currentForm.Height / height;
        }

        public void createTable(string playerSide)
        {
            if(playerSide == "Black")
            {

                createEnemyTeam("White");
                createUserTeam("Black");
            }
            else
            {
                createEnemyTeam("Black");
                createUserTeam("White");
            }
        }

        private void createEnemyTeam(string side)
        {
           for (int line = 1; line < 3; ++line) {
                for (int column = 0; column < width; ++column){

                    int xCoord = left_space * column;
                    int yCoord = under_space * line;

                    pieces[line, column] = new Pawn(xCoord, yCoord, side);
                }
           }
        }

        private void createUserTeam(string side)
        {
            for (int line = 10; line < 12; ++line){
                for (int column = 0; column < width; ++column){

                    int xCoord = left_space * column;
                    int yCoord = under_space * line;

                    pieces[line, column] = new Pawn(xCoord, yCoord, side);
                }
            }
        }

    }
}
