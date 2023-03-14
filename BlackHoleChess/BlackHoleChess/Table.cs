using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackHoleChess
{
    internal class Table
    {
        Form currentForm = Form.ActiveForm;
        public static Piece[,] pieces;
        public static int width = 9;
        public static int height = 13;
        public static string turn = "White";
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
            createSpaces();
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

        private void createSpaces()
        {
            for (int column = 0; column < width; ++column)
            {
                pieces[0, column] = new Piece(left_space * column, 0, "");
            }
            
            for (int column = 0; column < width; ++column)
            {
                pieces[12, column] = new Piece(left_space * column, 12 * under_space, "");
            }

            for(int line = 3;line < 10; ++line)
            {
                for(int column = 0; column < width; ++column) {

                    int xCoord = left_space * column;
                    int yCoord = under_space * line;

                    pieces[line, column] = new Piece(xCoord, yCoord, "");
                }
            }

        }

    }
}
