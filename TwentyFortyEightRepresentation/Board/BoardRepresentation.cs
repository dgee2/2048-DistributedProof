using System;
using System.Collections.Generic;
using System.Linq;

namespace TwentyFortyEightRepresentation.Board
{
    public class BoardRepresentation<T> : IBoardRepresentation<T>
    {
        private IBoardData<T> Board { get; }

        public BoardRepresentation(IBoardData<T> board)
        {
            Board = board;
        }

        public void SetCell(Coordinate coordinate, T value) => SetCell(coordinate.X, coordinate.Y, value);

        public void SetCell(uint x, uint y, T value) => Board.SetCell(x, y, value);

        public IEnumerable<Coordinate> GetCells(Func<T, bool> predicate)
            => Board.GetCells(predicate).Select(x => new Coordinate(x.Item1, x.Item2));

        public IEnumerable<T> GetRow(uint y) => Board.GetRow(y);

        public IEnumerable<T> GetColumn(uint x) => Board.GetColumn(x);
        public void SetRow(uint y, IEnumerable<T> values) => Board.SetRow(y, values);

        public void SetColumn(uint x, IEnumerable<T> values) => Board.SetColumn(x, values);

        public IBoardData<T> Cells => Board;

        public T GetCell(uint x, uint y) => Board.GetCell(x, y);

        public T GetCell(Coordinate coordinate) => GetCell(coordinate.X, coordinate.Y);

        public uint Width => Board.Width;

        public uint Height => Board.Height;
    }
}