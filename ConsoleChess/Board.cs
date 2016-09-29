using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleChess {
    public class Board {


        const int SideLength = 8;

        List<Square> squares = new List<Square>();

        public Board() {
            for (int row = 0; row < SideLength; row++) {
                for (int column = 0; column < SideLength; column++) {
                    squares.Add(new Square(column, row));
                }
            }
        }

        public void SetUpPieces() {
            PlacePieces(Piece.GetOfficerRow(), GetSquares("*1"), Colour.White);
            PlacePieces(Piece.GetPawnRow(), GetSquares("*2"), Colour.White);
            PlacePieces(Piece.GetPawnRow(), GetSquares("*7"), Colour.Black);
            PlacePieces(Piece.GetOfficerRow(), GetSquares("*8"), Colour.Black);
        }

        public void PlacePieces(List<Piece> pieces, List<Square> squares, Colour colour) {
            if (pieces.Count != squares.Count)
                return;

            for (int i = 0; i < pieces.Count; i++) {
                pieces[i].Colour = colour;
                pieces[i].Position = squares[i].Position;
                squares[i].PlacePiece(pieces[i]);
            }
        }

        private Square GetSquare(string algebraicCoordinate) {
            if (algebraicCoordinate.Length != 2)
                return null;

            var coordArray = algebraicCoordinate.ToCharArray();

            var col = coordArray[0].ToString();
            var row = coordArray[1].ToString();

            return squares.Where(s => s.Position.Column == col && s.Position.Row == row).Single();
        }

        private List<Square> GetSquares(List<Position> positions) {
            var squares = new List<Square>();

            foreach (var position in positions) {
                squares.Add(this.squares.Where(s => s.Position.X == position.X && s.Position.Y == position.Y).Single());
            }

            return squares;
        }

        public Piece PickPiece(string algebraic) {
            var square = GetSquare(algebraic);
            return square.Piece;
        }

        private List<Square> GetSquares(params string[] algebraicCoordinates) {
            if (algebraicCoordinates.Any(c => c.Length != 2))
                return null;

            if (algebraicCoordinates.Length == 1) {
                var wildChar = "*";
                var coord = algebraicCoordinates.Single();
                var coordArray = coord.ToCharArray();

                var col = coordArray[0].ToString();
                var row = coordArray[1].ToString();

                if (col == wildChar) {
                    return GetRow(row);
                } else if (row == wildChar) {
                    return GetColumn(col);
                } else {
                    return new List<Square> { GetSquare(coord) };
                }
            }

            var squares = new List<Square>();
            foreach (var coord in algebraicCoordinates) {
                squares.Add(GetSquare(coord));
            }

            return squares;
        }

        private List<Square> GetColumn(string column) {
            return squares.Where(s => s.Position.Column == column).ToList();
        }

        private List<Square> GetRow(string row) {
            return squares.Where(s => s.Position.Row == row).ToList();
        }

        public void Draw() {
            Console.WriteLine(" +--------+");
            for (int row = 0; row < SideLength; row++) {

                Console.Write((SideLength - row) + "|");

                for (int column = 0; column < SideLength; column++) {
                    var square = squares.Where(s => s.Position.X == column && s.Position.Y == row).First();

                    DrawSquare(square);
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine(" +--------+");
            Console.WriteLine("  abcdefgh ");
        }

        private void DrawSquare(Square square) {
            if (square.IsOccupied) {
                DrawPiece(square.Piece);
                return;
            }
            if (square.Highlight != ConsoleColor.Black) {
                Console.BackgroundColor = square.Highlight;
            }

            Console.Write(square.Colour);

            Console.BackgroundColor = ConsoleColor.Black;
        }

        private void DrawPiece(Piece piece) {
            if (piece.Colour == Colour.White) {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.Write(piece.Character);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void HighlightMovePatterns(Piece piece) {
            var availableMoves = piece.GetMovePatterns();
            var piecePosition = piece.Position;

            var positions = new List<Position>();
            foreach (var move in availableMoves) {
                positions.Add(Position.FromCoord(piecePosition.Coordinate + move));
            }

            var squares = GetSquares(positions);
            foreach (var square in squares) {
                square.Highlight = ConsoleColor.Green;
            }

        }
    }
}