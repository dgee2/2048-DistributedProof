using System;
using System.Collections.Generic;
using System.Linq;

namespace TwentyFortyEightRepresentation.Board
{
    public class BoardData<T> : IBoardData<T>
    {
        public BoardData(T[,] cells)
        {
            Cells = cells ?? throw new ArgumentNullException(nameof(cells));
        }

        public BoardData(uint width, uint height) : this(new T[height, width]) { }

        /// <summary>
        /// First index is the y position, second index is the x position
        /// This is counter-intuitive here but makes things a lot easier
        /// when we're creating and testing the arrays outside of this class
        /// The arrays are 0 based
        /// </summary>
        public T[,] Cells { get; }

        public T GetCell(uint x, uint y) => Cells[y, x];
        public void SetCell(uint x, uint y, T value)
        {
            Cells[y, x] = value;
        }

        private IEnumerable<int> ColumnEnumerable => Enumerable.Range(0, (int)Height);

        public IEnumerable<T> GetColumn(uint x) => ColumnEnumerable.Select(y => GetCell(x, (uint)y));

        private IEnumerable<int> RowEnumerable => Enumerable.Range(0, (int)Width);
        public IEnumerable<T> GetRow(uint y) => RowEnumerable.Select(x => GetCell((uint)x, y));
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


        public uint Width => (uint)Cells.GetLength(1);
        public uint Height => (uint)Cells.GetLength(0);

        public override string ToString()
        {
            return String.Join(Environment.NewLine, ColumnEnumerable.Select(y => String.Join(",", GetRow((uint)y))));
        }

        public static explicit operator BoardData<T>(string data)
        {
            var items = data.Split(new[] { Environment.NewLine }, StringSplitOptions.None).Select(row => row.Split(',')).ToList();

            var width = items.First().Length;
            var height = items.Count;

            if (items.Any(value => value.Length != width))
            {
                throw new ArgumentOutOfRangeException(nameof(data), data, "Not rectangular data");
            }

            var array = new T[height, width];

            var type = typeof(T);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    array[y, x] = (T)Convert.ChangeType(items[y][x], type);
                }
            }

            return new BoardData<T>(array);
        }
    }
}