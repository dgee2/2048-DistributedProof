using System;
using System.Collections.Generic;
using System.Linq;
using TwentyFortyEightRepresentation.Model;

namespace TwentyFortyEightRepresentation.Board
{
    public class TwentyFortyEightBoard
    {
        public TwentyFortyEightBoard(uint width, uint height)
            : this(new BoardRepresentation<uint>(new BoardData<uint>(width, height)))
        { }

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
                    var column = Board.Cells.GetColumn(x).ToArray();
                    if (direction == EDirection.Down)
                    {
                        Array.Reverse(column);
                    }
                    column = SlideCells(column).ToArray();
                    if (direction == EDirection.Down)
                    {
                        Array.Reverse(column);
                    }
                    Board.Cells.SetColumn(x, column);
                }
            }
            else
            {
                for (uint y = 0; y < Cells.Height; y++)
                {
                    var row = Board.Cells.GetRow(y).ToArray();
                    if (direction == EDirection.Right)
                    {
                        Array.Reverse(row);
                    }
                    row = SlideCells(row).ToArray();
                    if (direction == EDirection.Right)
                    {
                        Array.Reverse(row);
                    }
                    Board.Cells.SetRow(y, row);
                }
            }
        }

        private IEnumerable<uint> SlideCells(IEnumerable<uint> cells)
        {
            uint score;
            var results = SlideCells(cells, out score);
            Score += score;
            return results;
        }

        public static IEnumerable<uint> SlideCells(IEnumerable<uint> cells, out uint score)
        {
            var list = cells.ToList();
            var originalSize = list.Count;
            score = 0;
            // Remove zeros
            list = list.Where(x => x != 0).ToList();

            // Merge any values that are the same once
            var i = 0;
            while (i < list.Count - 1)
            {
                if (list[i] == list[i + 1])
                {
                    var newValue = list[i] + list[i + 1];
                    score += newValue;
                    list[i] = newValue;
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

        public void SetCell(Coordinate coordinate, uint value) => Board.SetCell(coordinate, value);
        public void SetCell(NewCell cell) => SetCell(cell.Coordinate, cell.Value);

        public IEnumerable<Coordinate> GetEmptyCells() => Board.GetCells(x => x == 0);


        public IReadonlyBoardData<uint> Cells => Board.Cells;
        public uint Width => Board.Width;
        public uint Height => Board.Height;

        public uint Score { get; private set; }

        public override string ToString()
        {
            return Cells.ToString();
        }
    }
}