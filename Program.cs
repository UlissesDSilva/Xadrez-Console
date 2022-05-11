using System;
using board;

namespace xadrez 
{

  public class Program 
  {
    static void Main(string[] args) {
      Board board = new Board(8, 8);
      Display.printBoard(board);
    }
  }
}