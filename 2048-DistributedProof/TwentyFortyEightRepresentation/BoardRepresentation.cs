namespace TwentyFortyEightRepresentation
{
    public class BoardRepresentation
    {
        private readonly uint[,] _cells;

        public BoardRepresentation(uint width, uint height)
        {
            _cells = new uint[width, height];
            Width = width;
            Height = height;
        }

        public void SetCell(Coordinate coordinate, uint value)
        {
            SetCell(coordinate.X, coordinate.Y, value);
        }

        public void SetCell(uint x, uint y, uint value)
        {
            _cells[x, y] = value;
        }

        public uint[,] GetCells()
        {
            return _cells;
        }

        public uint GetCell(uint x, uint y)
        {
            return _cells[x, y];
        }

        public uint GetCell(Coordinate coordinate)
        {
            return GetCell(coordinate.X, coordinate.Y);
        }

        public uint Width { get; }

        public uint Height { get; }
    }
}