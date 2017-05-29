using System;
using System.Collections.Generic;

namespace TwentyFortyEightRepresentation.Board
{
    public interface IReadonlyBoardData<T>
    {
        uint Height { get; }
        uint Width { get; }

        T GetCell(uint x, uint y);
        IEnumerable<T> GetColumn(uint x);
        IEnumerable<T> GetRow(uint y);
        IEnumerable<Tuple<uint,uint>> GetCells(Func<T, bool> predicate);
        string ToString();
    }
}