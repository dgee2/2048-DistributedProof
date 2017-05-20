using System;
using System.Collections.Generic;
using System.Linq;

namespace TwentyFortyEightRepresentation.Board
{
    public class TwentyFortyEightBoard
    {
        public TwentyFortyEightBoard(IBoardRepresentation<uint> board)
        {
            Board = board ?? throw new ArgumentNullException(nameof(board));
        }

        private IBoardRepresentation<uint> Board { get; }

        public void SlideCells(EDirection direction)
        {
            if (direction.IsVertical())
            {
                for (uint x = 0; x < Cells.Width; x++)
                {
                    var column = Cells.GetColumn(x).ToArray();
                    if (direction == EDirection.Down)
                    {
                        Array.Reverse(column);
                    }
                    column = SlideCells(column).ToArray();
                    if (direction == EDirection.Down)
                    {
                        Array.Reverse(column);
                    }
                    Cells.SetColumn(x, column);
                }
            }
            else
            {
                for (uint y = 0; y < Cells.Width; y++)
                {
                    var row = Cells.GetRow(y).ToArray();
                    if (direction == EDirection.Right)
                    {
                        Array.Reverse(row);
                    }
                    row = SlideCells(row).ToArray();
                    if (direction == EDirection.Right)
                    {
                        Array.Reverse(row);
                    }
                    Cells.SetRow(y, row);
                }
            }
        }

        public static IEnumerable<uint> SlideCells(IEnumerable<uint> cells)
        {
            var list = cells.ToList();
            var originalSize = list.Count;

            // Remove zeros
            list = list.Where(x => x != 0).ToList();

            // Merge any values that are the same once
            var i = 0;
            while (i < list.Count - 1)
            {
                if (list[i] == list[i + 1])
                {
                    list[i] = list[i] + list[i + 1];
                    list.RemoveAt(i + 1);
                }
                i++;
            }
            while (list.Count < originalSize)
            {
                list.Add(0);
            }
            return list;
        }


        public IBoardData<uint> Cells => Board.Cells;
        public uint Width => Board.Width;
        public uint Height => Board.Height;
    }
}