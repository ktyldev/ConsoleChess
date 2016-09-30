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

            //board.SetUpPieces();
            var bishop = new Bishop();
            bishop.Colour = Colour.White;

            board.PlacePiece("e4", bishop);

            board.Draw();

            while (true) {
                board.DehighlightSqaures();
                Console.Write("Pick a piece to move: ");

                var piece = board.PickPiece(Console.ReadLine());
                board.HighlightMovePatterns(piece);

                Console.Write("Move to: ");
                var destination = Console.ReadLine();



                Console.Clear();
                board.Draw();

            }
        }
    }
}
