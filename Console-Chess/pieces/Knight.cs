using board;

namespace pieces
{
    class Knight : Piece
    {
        public Knight(Board brd, Color color) : base(brd, color)
        {
        }

        public override string ToString()
        {
            return "L"; //not to come into conflict with the King
        }
    }
}