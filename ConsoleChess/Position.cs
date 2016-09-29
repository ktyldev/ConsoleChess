using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess {
    public class Position {
        static List<Position> List = new List<Position>();

        public Vector Coordinate { get; set; }
        public int X => Coordinate.X;
        public int Y => Coordinate.Y;
        public string Row { get; set; }
        public string Column { get; set; }
        public string AlgebraicNotation { get { return Column.ToString() + Row.ToString(); } }

        static Position() {
            var columns = new[] { "a", "b", "c", "d", "e", "f", "g", "h"};
            var rows = new[] { "8", "7", "6", "5", "4", "3", "2", "1" };
            
            int y = 0;

            foreach (var row in rows) {

                var x = 0;
                foreach (var column in columns) {
                    var position = new Position {
                        Column = column,
                        Row = row,
                        Coordinate = new Vector {
                            X = x,
                            Y = y
                        }
                    };

                    List.Add(position);
                    x++;
                }
                y++;
            }
        }

        private Position() { }

        public static Position FromCoord(Vector vector) {
            return FromCoord(vector.X, vector.Y);
        }

        public static Position FromCoord(int x, int y) {
            return List.Where(p => p.X == x && p.Y == y).Single();
        }

        public static Position FromAlgebraic(string algebraic) {
            var coord = algebraic.ToCharArray();

            var col = coord[0].ToString();
            var row = coord[1].ToString();

            return List.Where(p => p.Column == col && p.Row == row).Single();
        }

        public Position GetNeighbour(Vector direction) {
            var x = direction.X;
            var y = -direction.Y;
            
            return FromCoord(X + x, Y + y);
        }
    }

    public class Vector {
        public static readonly Vector Up = new Vector { X = 0, Y = 1 };
        public static readonly Vector Left = new Vector { X = 1, Y = 0 };
        public static readonly Vector Down = new Vector { X = 0, Y = -1 };
        public static readonly Vector Right = new Vector { X = -1, Y = 0 };
        public static readonly Vector UpLeft = Up + Left;
        public static readonly Vector DownLeft = Down + Left;
        public static readonly Vector DownRight = Down + Right;
        public static readonly Vector UpRight = Up + Right;

        public static Vector operator +(Vector a, Vector b) {
            return new Vector { X = a.X + b.X, Y = a.Y + b.Y };
        }

        public static List<Vector> FromIntArrays(params int[][] arrays) {
            return arrays.Select(a => new Vector { X = a[0], Y = a[1] }).ToList();
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
