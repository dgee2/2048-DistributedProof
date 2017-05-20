using System.Collections.Generic;

namespace TwentyFortyEightRepresentation
{
    public interface IBoardRepresentation<T>
    {
        uint Height { get; }
        uint Width { get; }

        T GetCell(Coordinate coordinate);
        T GetCell(uint x, uint y);
        IBoardData<T> Cells { get; }

        void SetCell(Coordinate coordinate, T value);
        void SetCell(uint x, uint y, T value);
        IEnumerable<T> GetRow(uint y);
        IEnumerable<T> GetColumn(uint x);
        void SetRow(uint y, IEnumerable<T> values);
        void SetColumn(uint x, IEnumerable<T> values);
    }
}