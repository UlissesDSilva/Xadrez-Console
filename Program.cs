using System;
using board;
using chess;

namespace xadrez 
{

  public class Program 
  {
    static void Main(string[] args) {

      try
      {
        Board board = new Board(8, 8);

        board.positionPiece(new King(Color.Black, board), new Position(0,0));
        board.positionPiece(new Tower(Color.Black, board), new Position(1,0));
        board.positionPiece(new Horse(Color.Black, board), new Position(2,0));

        Display.printBoard(board);
        
      }
      catch (BoardException e)
      {
        Console.WriteLine(e.Message);
      }

    }
  }
}