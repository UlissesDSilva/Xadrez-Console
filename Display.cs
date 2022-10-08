using board;

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
                    if (board.piece(row, column) != null)
                    {
                        printPiece(board.piece(row, column));
                        Console.Write(" ");                        
                    } else
                    {
                        Console.Write($"- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void printPiece(Piece piece)
        {
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
        }
    }
}