using board;

namespace chess
{
    class Horse : Piece
    {
        public Horse(Color color, Board board) : base(color, board) {}

        public override bool[,] possibleMoves() {
            bool [,] possibleMoves = new bool [Board.Row, Board.Column];
            return possibleMoves;
        }

        public override string ToString() 
        {
            return "H";
        }
    }
}