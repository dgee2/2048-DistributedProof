﻿using TwentyFortyEightRepresentation.Board;

namespace TwentyFortyEightRepresentation.Model
{
    public struct NewCell
    {
        public NewCell(Coordinate coordinate, uint value)
        {
            Coordinate = coordinate;
            Value = value;
        }

        public Coordinate Coordinate { get; }
        public uint Value { get; }
    }
}