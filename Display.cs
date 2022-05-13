using board;

namespace xadrez
{
    class Display
    {
        public static void printBoard(Board board)
        {
            for(int row = 0; row < board.Row; row++)
            {
                for(int column = 0; column < board.Column; column++){
                    if (board.piece(row, column) != null){
                        Console.Write($"{board.piece(row, column)} ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                        Console.WriteLine();
            }
        }
    }
}