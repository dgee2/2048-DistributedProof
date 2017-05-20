namespace TwentyFortyEightRepresentation.Board
{
    public struct Coordinate
    {
        public uint X { get; }
        public uint Y { get; }

        public Coordinate(uint x, uint y)
        {
            X = x;
            Y = y;
        }
    }
}