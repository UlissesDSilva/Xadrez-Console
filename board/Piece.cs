namespace board 
{
    abstract class Piece 
    {
        public Piece(Color color, Board board)
        {
            Position = null;
            Color = color;
            Board = board;
            NumberMoves = 0;
        }

        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public Board Board { get; protected set; }
        public int NumberMoves { get; protected set; }

        public void incrementMovements() 
        {
            NumberMoves++;
        }

        public void decrementMovements() 
        {
            NumberMoves--;
        }

        public bool existPossibleMove(){
            bool[,] moves = possibleMoves();

            for (int row = 0; row < Board.Row; row++) {
                for (int column = 0; column < Board.Column; column++) {
                    if (moves[row, column])
                        return true;
                }
            }

            return false;
        }

        public bool canMoveTo(Position position) {
            return possibleMoves()[position.Row, position.Column];
        }

        public abstract bool [,] possibleMoves();
    }
}