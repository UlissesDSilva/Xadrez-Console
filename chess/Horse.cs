using board;

namespace chess
{
    class Horse : Piece
    {
        public Horse(Color color, Board board) : base(color, board) {}

        private bool canMove(Position position) {
            Piece piece = Board.piece(position);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] possibleMoves() {
            bool [,] possibleMoves = new bool [Board.Row, Board.Column];
            Position position = new Position(0, 0);

            // north - west
            position.setPosition(Position.Row - 2, Position.Column - 1);
            if(Board.validPosition(position) && canMove(position)) {
                possibleMoves[position.Row, position.Column] = true;
            }

            // north - east
            position.setPosition(Position.Row - 2, Position.Column + 1);
            if(Board.validPosition(position) && canMove(position)) {
                possibleMoves[position.Row, position.Column] = true;
            }

            //west - north
            position.setPosition(Position.Row - 1, Position.Column - 2);
            if(Board.validPosition(position) && canMove(position)) {
                possibleMoves[position.Row, position.Column] = true;
            }

            //east - north
            position.setPosition(Position.Row - 1, Position.Column + 2);
            if(Board.validPosition(position) && canMove(position)) {
                possibleMoves[position.Row, position.Column] = true;
            }

             // south - west
            position.setPosition(Position.Row + 2, Position.Column - 1);
            if(Board.validPosition(position) && canMove(position)) {
                possibleMoves[position.Row, position.Column] = true;
            }

            // south - east
            position.setPosition(Position.Row + 2, Position.Column + 1);
            if(Board.validPosition(position) && canMove(position)) {
                possibleMoves[position.Row, position.Column] = true;
            }

            return possibleMoves;
        }

        public override string ToString() 
        {
            return "H";
        }
    }
}