using board;

namespace chess
{
    class Pawn : Piece
    {
        public Pawn(Color color, Board board) : base(color, board) {}

        private bool canMove(Position position) {
            Piece piece = Board.piece(position);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] possibleMoves() {
            bool [,] possibleMoves = new bool [Board.Row, Board.Column];
            Position position = new Position(0, 0);

            //initial move
            position.setPosition(Position.Row - 2, Position.Column);
            if(Board.piece(Position).NumberMoves == 0) {
                if(Board.validPosition(position) && canMove(position)) {
                    possibleMoves[position.Row, position.Column] = true;
                }
            }

            //north
            position.setPosition(Position.Row - 1, Position.Column);
            if(Board.piece(position) == null) {
                if(Board.validPosition(position) && canMove(position)) {
                    possibleMoves[position.Row, position.Column] = true;
                }
            }

            //northwest
            position.setPosition(Position.Row - 1, Position.Column - 1);
            if(Board.piece(position) != null) {
                if(Board.validPosition(position) && canMove(position)) {
                    possibleMoves[position.Row, position.Column] = true;
                }
            }

            //northeast
            position.setPosition(Position.Row - 1, Position.Column + 1);
            if(Board.piece(position) != null) {
                if(Board.validPosition(position) && canMove(position)) {
                    possibleMoves[position.Row, position.Column] = true;
                }
            }

            return possibleMoves;
        }

        public override string ToString() 
        {
            return "P";
        }
    }
}