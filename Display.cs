using board;
using chess;

namespace xadrez
{
    class Display
    {
        public static void printBoard(Board board)
        {
            for(int row = 0; row < board.Row; row++)
            {   
                Console.Write($"{8 - row} ");
                for(int column = 0; column < board.Column; column++){
                    printPiece(board.piece(row, column));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.WriteLine();
        }

        public static void newDisplay(ChessPlay chessPlay, bool[,] possibleMoves = null) {
            Console.Clear();
            if (possibleMoves == null) {
                printBoard(chessPlay.Board);
            } else {
                printBoard(chessPlay.Board, possibleMoves);
            }
            getCapturedPieces(chessPlay);
            Console.WriteLine($"Turno: {chessPlay.Turn}");
            if(!chessPlay.Endgame) {
                Console.WriteLine($"Jogada da: {chessPlay.PlayCurrent}");
                if(chessPlay.Check){
                    Console.WriteLine("Check");
                }
            } else {
                Console.WriteLine("Checkmate");
                Console.WriteLine($"The winner is {chessPlay.PlayCurrent}");
            }
        }

        public static void getCapturedPieces(ChessPlay chessPlay) {
            Console.WriteLine("Captured Pieces");
            Console.Write("White: ");
            getHashSetPieces(chessPlay.getCapturedPieces(Color.White));
            Console.Write("Pink: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Magenta;
            getHashSetPieces(chessPlay.getCapturedPieces(Color.Pink));
            Console.ForegroundColor = aux;

        }

        public static void getHashSetPieces(HashSet<Piece> hashSetPiece){
            Console.Write("[");
            foreach (Piece piece in hashSetPiece) {
                Console.Write(piece + " ");
            }
            Console.Write("]");
            Console.WriteLine();
        }

        public static void printBoard(Board board, bool[,] possibleMoves)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor auxBackground = ConsoleColor.DarkCyan;
            for(int row = 0; row < board.Row; row++)
            {   
                Console.Write($"{8 - row} ");
                for(int column = 0; column < board.Column; column++){
                    if(possibleMoves[row, column]) {
                        Console.BackgroundColor = auxBackground;
                    } else {
                        Console.BackgroundColor = originalBackground;
                    }
                    printPiece(board.piece(row, column));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackground;
            Console.WriteLine();
        }

        public static PositionChess writePositionPiece() {
            string move = Console.ReadLine();
            char column = move[0];
            int row = int.Parse(move[1] + "");

            return new PositionChess(column, row);
        }

        public static void printPiece(Piece piece)
        {
            if(piece == null) {
                Console.Write($"- ");
            } else {
                if(piece.Color == Color.White)
                {
                    Console.Write(piece);
                } else 
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}