using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data.Common;
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
        public Button button;
        protected Size piecesSize = new Size(60, 90);

        protected string basePath = @"C:\Universtitate\An 3 sem 2\A.I\Proiect\BlackHoleChess";

        public string Side { get => side; set => side = value; }
        public int XCoord { get => xCoord; set => xCoord = value; }
        public int YCoord { get => yCoord; set => yCoord = value; }
        public Image Image { get => image; set => image = value; }
        public Button Button { get => button; set => button = value; }

        public Piece(int xCoord, int yCoord, string side) {
            button = new Button();
            button.BackColor = Color.Transparent;

            this.xCoord = xCoord;
            this.yCoord = yCoord;
            this.side = side;

            if (this is Pawn)
            {
                if (side == "Black")
                    image = Image.FromFile(basePath + @"\BlackHoleChess\BlackHoleChess\PiecesPhotos\pawn_black.png");
                else if (side == "White")
                    image = Image.FromFile(basePath + @"\BlackHoleChess\BlackHoleChess\PiecesPhotos\pawn_white.png");
            }
            else if (side == "")
                setWhiteSpace();
        }

        private void space_Click(object? sender, EventArgs e)
        {
            Button pressedSpace = sender as Button;

            if (pressedSpace.BackColor == Color.Red && pressedSpace.Name == "")
            {
                setTurn();
                clearPossibleMoveBlocks();
            }
        }
        protected bool arePressedPieces()
        {
            for (int i = 0; i < Table.height; i++)
            {
                for (int j = 0; j < Table.width; j++)
                {
                    if (Table.pieces[i, j].button.BackColor == Color.Red)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        protected bool pieceIsPressed(Button button)
        {
            if (button.BackColor == Color.Red)
                return true;
            return false;
        }
        protected Piece getPressedPiece()
        {
            for (int i = 0; i < Table.height; i++)
            {
                for (int j = 0; j < Table.width; j++)
                {
                    if (Table.pieces[i, j].side != "" && Table.pieces[i, j].button.BackColor == Color.Red)
                    {
                        return Table.pieces[i, j];
                    }
                }
            }
            return null;
        }
        protected void getIndexOfPressedPiece(ref int column, ref int line)
        {
            for (int i = 0; i < Table.height; i++)
            {
                for (int j = 0; j < Table.width; j++)
                {
                    if (Table.pieces[i, j] == this)
                    {
                        line = i;
                        column = j;
                        break;
                    }
                }
            }
        }
        protected void movePiece(ref Piece space, ref Piece piece)
        {
            //swap pieces
            Piece space_temp = space;

            space.Side = piece.side;
            space.Button = piece.button;
            space.XCoord = piece.xCoord;
            space.YCoord = piece.yCoord;

            piece.Side = space_temp.side;
            piece.Button = space_temp.button;
            piece.xCoord = space_temp.xCoord;
            piece.YCoord = space_temp.yCoord;

        }
        protected void clearPossibleMoveBlocks()
        {
            for (int i = 0; i < Table.height; i++)
            {
                for (int j = 0; j < Table.width; j++)
                {
                    if (Table.pieces[i, j].button.BackColor == Color.Red)
                    {
                        clearBlock(Table.pieces[i, j].button);
                    }
                }
            }
        }
        protected void colorBlock(Button button)
        {
            button.FlatStyle = FlatStyle.Standard;
            button.ForeColor = Color.Red;
            button.BackColor = Color.Red;
        }
        protected void clearBlock(Button button)
        {
            button.BackColor = Color.Transparent;
            button.ForeColor = Color.Transparent;
            button.FlatStyle = FlatStyle.Flat;
        }
        private void setWhiteSpace()
        {
            button.Location = new Point(xCoord, yCoord);
            button.Size = piecesSize;
            button.Click += space_Click;
            clearBlock(button);
            activeForm.Controls.Add(button);
        }

        protected bool isYourTurn(Button piece)
        {
            if (piece.Name == Table.turn)
                return true;
            return false;
                
        }
        protected void setTurn()
        {
            if (Table.turn == "White")
                Table.turn = "Black";
            else if (Table.turn == "Black")
                Table.turn = "White";
        }

    }
}
