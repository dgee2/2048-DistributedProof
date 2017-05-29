using System.Collections.Generic;

namespace TwentyFortyEightRepresentation.Board
{
    public interface IBoardData<T> : IReadonlyBoardData<T>
    {
        T[,] Cells { get; }

        void SetCell(uint x, uint y, T value);
        void SetRow(uint y, IEnumerable<T> values);
        void SetColumn(uint x, IEnumerable<T> values);
    }
}