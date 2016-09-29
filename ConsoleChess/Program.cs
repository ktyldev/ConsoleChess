using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess {
    class Program {
        static void Main(string[] args) {
            Console.ForegroundColor = ConsoleColor.White;

            Board board = new Board();
            board.SetUpPieces();
            board.Draw();

            var piece = board.PickPiece("b2");
            board.HighlightMovePatterns(piece);

            board.Draw();

            Console.ReadKey();
        }
    }
}
