using System.Linq;

namespace ConsoleChess {
    public class Square {
        private string[] letters = new[] { "a", "b", "c", "d", "e", "f", "g", "h" };
        private int[] numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

        public string AlbebraicPosition { get {
                var letter = _backwardsLetters[Y];
                var number = numbers[X];

                return letter + number;
            } }
        public int X { get; set; }
        public int Y { get; set; }
        public string Colour { get { return (X + Y) % 2 == 0 ? "white" : "black"; } }

        private string[] _backwardsLetters => letters.Reverse().ToArray();

        public Square(int x, int y) {
            X = x;
            Y = y;
        }
    }
}