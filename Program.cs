using System;
using board;

namespace xadrez {

  public class Program {
    static void Main(string[] args) {
      Board board = new Board(4, 4);

      Console.Write(board);
    }
  }
}