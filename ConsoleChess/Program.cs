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

            while (true) {
                board.DehightlightSqaures();
                Console.Write("Pick a piece's algebraic coordinate: ");
                var playerInput = Console.ReadLine();

                var piece = board.PickPiece(playerInput);
                board.HighlightMovePatterns(piece);

                Console.Clear();
                board.Draw();

            }
        }
    }
}
