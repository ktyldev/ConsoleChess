using System;
using System.Linq;

namespace ConsoleChess {
    public class Square {
        const string WhiteSquare = "#";
        const string BlackSquare = " ";

        public Position Position { get; private set; }
        public string Colour { get { return (Position.X + Position.Y) % 2 == 0 ? WhiteSquare : BlackSquare; } }
        public Piece Piece { get; set; }
        public bool IsOccupied { get { return Piece != null; } }
        public ConsoleColor Highlight { get; set; }

        public Square(int x, int y) {
            Position = Position.FromCoord(x, y);
            Highlight = ConsoleColor.Black;
        }

        public void PlacePiece(Piece piece) {
            Piece = piece;
            piece.Position = Position;
        }

        public Piece PickUpPiece() {
            var temp = Piece;
            Piece = null;
            return temp;
        }
    }
}
