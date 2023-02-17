using board;

namespace chess
{
    class Pawn : Piece
    {
        public Pawn(Color color, Board board) : base(color, board) {}

        private bool thereIsAnOpponent(Position position) {
            Piece pieceOpponent = Board.piece(position);
            return pieceOpponent != null && pieceOpponent.Color != Color;
        }

        private bool freePosition(Position position) {
            return Board.piece(position) == null;
        }

        public override bool[,] possibleMoves() {
            bool [,] possibleMoves = new bool [Board.Row, Board.Column];
            Position position = new Position(0, 0);

            if(Color == Color.White) {
                //initial move
                position.setPosition(Position.Row - 2, Position.Column);
                if(Board.validPosition(position) && NumberMoves == 0) {
                    possibleMoves[position.Row, position.Column] = true;
                }

                //north
                position.setPosition(Position.Row - 1, Position.Column);
                if(Board.validPosition(position) && freePosition(position)) {
                    possibleMoves[position.Row, position.Column] = true;
                }

                //northwest
                position.setPosition(Position.Row - 1, Position.Column - 1);
                if(Board.validPosition(position) && thereIsAnOpponent(position)) {
                    possibleMoves[position.Row, position.Column] = true;
                }

                //northeast
                position.setPosition(Position.Row - 1, Position.Column + 1);
                if(Board.validPosition(position) && thereIsAnOpponent(position)) {
                    possibleMoves[position.Row, position.Column] = true;
                }
            } else {
                position.setPosition(Position.Row + 2, Position.Column);
                if(Board.validPosition(position) && NumberMoves == 0) {
                    possibleMoves[position.Row, position.Column] = true;
                }

                //north
                position.setPosition(Position.Row + 1, Position.Column);
                if(Board.validPosition(position) && freePosition(position)) {
                    possibleMoves[position.Row, position.Column] = true;
                }

                //northwest
                position.setPosition(Position.Row + 1, Position.Column - 1);
                if(Board.validPosition(position) && thereIsAnOpponent(position)) {
                    possibleMoves[position.Row, position.Column] = true;
                }

                //northeast
                position.setPosition(Position.Row + 1, Position.Column + 1);
                if(Board.validPosition(position) && thereIsAnOpponent(position)) {
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