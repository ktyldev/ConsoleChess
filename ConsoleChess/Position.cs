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
            var columns = new[] { "h", "g", "f", "e", "d", "c", "b", "a"};
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

        public static Position FromCoord(int x, int y) {
            return List.Where(p => p.X == x && p.Y == y).Single();
        }

        public static Position FromAlgebraic(string algebraic) {
            var coord = algebraic.Split();

            var col = coord[0];
            var row = coord[1];

            return List.Where(p => p.Column == col && p.Row == row).Single();
        }
    }

    public class Vector {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
