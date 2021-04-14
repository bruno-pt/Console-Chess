using board;

namespace pieces
{
    class Bishop : Piece
    {
        public Bishop(Board brd, Color color) : base(brd, color)
        {
        }

        public override string ToString()
        {
            return "B";
        }
    }
}