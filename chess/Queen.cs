using board;

namespace chess
{
    class Queen : Piece
    {
        public Queen(Color color, Board board) : base(color, board) {}

        public override bool[,] possibleMoves() {
            bool [,] possibleMoves = new bool [Board.Row, Board.Column];
            return possibleMoves;
        }

        public override string ToString() 
        {
            return "Q";
        }
    }
}