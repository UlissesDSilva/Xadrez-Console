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

        public abstract bool [,] possibleMoves();
    }
}