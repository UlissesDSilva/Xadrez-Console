using board;

namespace chess
{
    class ChessPlay
    {
        public ChessPlay()
        {
            Board = new Board(8, 8);
            Turn = 1;
            PlayCurrent = Color.Pink;
            putPieces();
            Endgame = false;            
        }

        public Board Board {get; private set;}
        private int Turn;
        private Color PlayCurrent;
        public bool Endgame {get; private set;}

        public void movement(Position origin, Position destiny)
        {
            Piece piece = Board.removePiece(origin);
            piece.incrementMovements();
            Piece capturedPiece = Board.removePiece(destiny);
            Board.positionPiece(piece, destiny);
        }

        private void putPieces()
        {
            Board.positionPiece(new Tower(Color.White, Board), new PositionChess('a', 1).toPosition());
            Board.positionPiece(new Horse(Color.White, Board), new PositionChess('b', 1).toPosition());
            Board.positionPiece(new Bishop(Color.White, Board), new PositionChess('c', 1).toPosition());
            Board.positionPiece(new Queen(Color.White, Board), new PositionChess('d', 1).toPosition());
            Board.positionPiece(new King(Color.White, Board), new PositionChess('e', 1).toPosition());
            Board.positionPiece(new Bishop(Color.White, Board), new PositionChess('f', 1).toPosition());
            Board.positionPiece(new Horse(Color.White, Board), new PositionChess('g', 1).toPosition());
            Board.positionPiece(new Tower(Color.White, Board), new PositionChess('h', 1).toPosition());
            Board.positionPiece(new Pawn(Color.White, Board), new PositionChess('a', 2).toPosition());
            Board.positionPiece(new Pawn(Color.White, Board), new PositionChess('b', 2).toPosition());
            Board.positionPiece(new Pawn(Color.White, Board), new PositionChess('c', 2).toPosition());
            Board.positionPiece(new Pawn(Color.White, Board), new PositionChess('d', 2).toPosition());
            Board.positionPiece(new Pawn(Color.White, Board), new PositionChess('e', 2).toPosition());
            Board.positionPiece(new Pawn(Color.White, Board), new PositionChess('f', 2).toPosition());
            Board.positionPiece(new Pawn(Color.White, Board), new PositionChess('g', 2).toPosition());
            Board.positionPiece(new Pawn(Color.White, Board), new PositionChess('h', 2).toPosition());

            Board.positionPiece(new Tower(Color.Pink, Board), new PositionChess('a', 8).toPosition());
            Board.positionPiece(new Horse(Color.Pink, Board), new PositionChess('b', 8).toPosition());
            Board.positionPiece(new Bishop(Color.Pink, Board), new PositionChess('c', 8).toPosition());
            Board.positionPiece(new Queen(Color.Pink, Board), new PositionChess('d', 8).toPosition());
            Board.positionPiece(new King(Color.Pink, Board), new PositionChess('e', 8).toPosition());
            Board.positionPiece(new Bishop(Color.Pink, Board), new PositionChess('f', 8).toPosition());
            Board.positionPiece(new Horse(Color.Pink, Board), new PositionChess('g', 8).toPosition());
            Board.positionPiece(new Tower(Color.Pink, Board), new PositionChess('h', 8).toPosition());
            Board.positionPiece(new Pawn(Color.Pink, Board), new PositionChess('a', 7).toPosition());
            Board.positionPiece(new Pawn(Color.Pink, Board), new PositionChess('b', 7).toPosition());
            Board.positionPiece(new Pawn(Color.Pink, Board), new PositionChess('c', 7).toPosition());
            Board.positionPiece(new Pawn(Color.Pink, Board), new PositionChess('d', 7).toPosition());
            Board.positionPiece(new Pawn(Color.Pink, Board), new PositionChess('e', 7).toPosition());
            Board.positionPiece(new Pawn(Color.Pink, Board), new PositionChess('f', 7).toPosition());
            Board.positionPiece(new Pawn(Color.Pink, Board), new PositionChess('g', 7).toPosition());
            Board.positionPiece(new Pawn(Color.Pink, Board), new PositionChess('h', 7).toPosition());
        }

    }
}