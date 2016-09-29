using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleChess {
    public class Board {
        const string WhiteSquare = "#";
        const string BlackSquare = " ";
        const int SideLength = 8;

        List<Square> squares = new List<Square>();

        public Board() {
            for (int row = 0; row < SideLength; row++) {
                for (int column = 0; column < SideLength; column++) {
                    squares.Add(new Square(column, row));
                }
            }
        }

        public void Draw() {
            Console.WriteLine("+--------+");
            for (int row = 0; row < SideLength; row++) {
                Console.Write("|");
                for (int column = 0; column < SideLength; column++) {
                    var square = squares.Where(s => s.X == column && s.Y == row).First();
                    if (square.Colour == "white") {
                        Console.Write(WhiteSquare);
                    } else {
                        Console.Write(BlackSquare);
                    }
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("+--------+");
        }

        public void PrintSquaresInfo() {
            foreach (var square in squares) {
                Console.WriteLine(string.Join(" - ", square.AlbebraicPosition, square.X + " " + square.Y, square.Colour));
            }
        }
    }
}