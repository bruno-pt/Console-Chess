namespace board
{
    abstract class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int qntMoviments { get; protected set; }
        public Board brd{ get; protected set; }

        public Piece(Board brd, Color color)
        {
            this.position = null;
            this.color = color;
            this.brd = brd;
            this.qntMoviments = 0;
        }

        public void incrementQntMoviments()
        {
            qntMoviments++;
        }

        public void decrementQntMoviments()
        {
            qntMoviments--;
        }

        public bool existePossibleMovements()
        {
            bool[,] mat = possibleMovements();
            for(int i=0; i<brd.rows; i++)
            {
                for(int j=0; j<brd.columns; j++)
                {
                    if (mat[i, j] == true)
                        return true;
                }
            }
            return false;
        }

        public bool canMoveTo(Position pos)
        {
            return possibleMovements()[pos.row, pos.column];
        }

        public abstract bool[,] possibleMovements();
    }
}
