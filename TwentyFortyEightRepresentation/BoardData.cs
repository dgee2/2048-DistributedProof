using System;
using System.Collections.Generic;
using System.Linq;

namespace TwentyFortyEightRepresentation
{
    public class BoardData<T> : IBoardData<T>
    {
        public BoardData(T[,] cells)
        {
            Cells = cells ?? throw new ArgumentNullException(nameof(cells));
        }

        public BoardData(uint width, uint height) : this(new T[width, height]) { }

        public T[,] Cells { get; }

        public T GetCell(uint x, uint y) => Cells[x, y];
        public void SetCell(uint x, uint y, T value)
        {
            Cells[x, y] = value;
        }

        public IEnumerable<T> GetColumn(uint x) => Enumerable.Range(0, (int)Height).Select(y => GetCell(x, (uint)y));

        public IEnumerable<T> GetRow(uint y) => Enumerable.Range(0, (int)Width).Select(x => GetCell((uint)x, y));
        public void SetColumn(uint x, IEnumerable<T> values)
        {
            var valueArray = values as T[] ?? values.ToArray();
            if (valueArray.Length != Height)
            {
                throw new ArgumentOutOfRangeException(nameof(values));
            }

            for (var y = (uint)0; y < valueArray.Count(); y++)
            {
                SetCell(x, y, valueArray[y]);
            }
        }

        public void SetRow(uint y, IEnumerable<T> values)
        {
            var valueArray = values as T[] ?? values.ToArray();
            if (valueArray.Length != Width)
            {
                throw new ArgumentOutOfRangeException(nameof(values));
            }

            for (var x = (uint)0; x < valueArray.Count(); x++)
            {
                SetCell(x, y, valueArray[x]);
            }
        }


        public uint Width => (uint)Cells.GetLength(0);
        public uint Height => (uint)Cells.GetLength(1);
    }
}