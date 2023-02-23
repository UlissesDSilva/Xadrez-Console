using board;

namespace chess
{
    class King : Piece
    {
        public King(Color color, Board board, ChessPlay chessPlay) : base(color, board) {
            ChessPlay = chessPlay;
        }

        private ChessPlay ChessPlay;

        private bool canMove(Position position) {
            Piece piece = Board.piece(position);
            return piece == null || piece.Color != Color;
        }

        private bool testCastling(Position position) {
            Piece tower = Board.piece(position);
            return tower is Tower && tower != null && tower.Color == Color && tower.NumberMoves == 0;
        }

        public override bool[,] possibleMoves() {
            bool [,] possibleMoves = new bool [Board.Row, Board.Column];
            Position position = new Position(0, 0);

            //melhorias para o Position.Row. Se o position já recebi a posição da peça, é só usar position

            // north
            position.setPosition(Position.Row - 1, Position.Column);
            if(Board.validPosition(position) && canMove(position)) {
                possibleMoves[position.Row, position.Column] = true;
            }

            //northeast
            position.setPosition(Position.Row - 1, Position.Column + 1);
            if(Board.validPosition(position) && canMove(position)) {
                possibleMoves[position.Row, position.Column] = true;
            }

            //east
            position.setPosition(Position.Row, Position.Column + 1);
            if(Board.validPosition(position) && canMove(position)) {
                possibleMoves[position.Row, position.Column] = true;
            }

            //southeast
            position.setPosition(Position.Row + 1, Position.Column + 1);
            if(Board.validPosition(position) && canMove(position)) {
                possibleMoves[position.Row, position.Column] = true;
            }

            //south
            position.setPosition(Position.Row + 1, Position.Column);
            if(Board.validPosition(position) && canMove(position)) {
                possibleMoves[position.Row, position.Column] = true;
            }

            //southwest
            position.setPosition(Position.Row + 1, Position.Column - 1);
            if(Board.validPosition(position) && canMove(position)) {
                possibleMoves[position.Row, position.Column] = true;
            }

            //west
            position.setPosition(Position.Row, Position.Column - 1);
            if(Board.validPosition(position) && canMove(position)) {
                possibleMoves[position.Row, position.Column] = true;
            }

            //northwest
            position.setPosition(Position.Row - 1, Position.Column - 1);
            if(Board.validPosition(position) && canMove(position)) {
                possibleMoves[position.Row, position.Column] = true;
            }

            //Castling
            if(NumberMoves == 0 && !ChessPlay.Check) {
                Position positionTower1 = new Position(Position.Row, Position.Column + 3);
                Position positionTower2 = new Position(Position.Row, Position.Column - 4);

                //Small Castling
                if(testCastling(positionTower1)) {
                    Position p1 = new Position(Position.Row, Position.Column + 1);
                    Position p2 = new Position(Position.Row, Position.Column + 2);

                    if(Board.piece(p1) == null && Board.piece(p2) == null) {
                        possibleMoves[Position.Row, Position.Column + 2] = true;
                    }
                }

                //Big Castling
                if(testCastling(positionTower2)) {
                    Position p1 = new Position(Position.Row, Position.Column - 1);
                    Position p2 = new Position(Position.Row, Position.Column - 2);
                    Position p3 = new Position(Position.Row, Position.Column - 3);

                    if(Board.piece(p1) == null && Board.piece(p2) == null && Board.piece(p3) == null) {
                        possibleMoves[Position.Row, Position.Column - 2] = true;
                    }
                }
            }

            return possibleMoves;
        }

        public override string ToString() 
        {
            return "K";
        }
    }
}