using board;

namespace xadrez
{
    class Display
    {
        public static void printBoard(Board board)
        {
            for(int row = 0; row < board.Row; row++)
            {
                for(int column = 1; column < board.Column; column++){
                    if (board.play(row, column) != null){
                        Console.Write($"{board.play(row, column)} ");
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