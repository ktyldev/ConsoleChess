using System;
using System.Collections.Generic;

namespace ConsoleChess {
    public abstract class Piece {
        public abstract string Character { get; }
        public abstract int Value { get; }
        public Colour Colour { get; private set; }

        public Piece(Colour colour) {
            Colour = colour;
        }

        
    }

    public class Pawn : Piece {
        public Pawn(Colour colour) : base(colour) { }

        public override string Character => "p";
        public override int Value => 1;
    }

    public class Bishop : Piece {
        public Bishop(Colour colour) : base(colour) { }

        public override string Character => "B";
        public override int Value => 3;
    }

    public class Knight : Piece {
        public Knight(Colour colour) : base(colour) { }

        public override string Character => "N";
        public override int Value => 3;
    }

    public class Rook : Piece {
        public Rook(Colour colour) : base(colour) { }

        public override string Character => "R";
        public override int Value => 5;
    }

    public class Queen : Piece {
        public Queen(Colour colour) : base(colour) { }

        public override string Character => "Q";
        public override int Value => 9;
    }

    public class King : Piece {
        public King(Colour colour) : base(colour) { }

        public override string Character => "K";
        public override int Value => 0;
    }
}