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
            board.PlacePieces();
            board.Draw();

            Console.ReadKey();
        }
    }
}
