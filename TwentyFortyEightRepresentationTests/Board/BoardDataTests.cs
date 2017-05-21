using System;
using System.Linq;
using TwentyFortyEightRepresentation.Board;
using Xunit;

namespace TwentyFortyEightRepresentationTests.Board
{
    public class BoardDataTests
    {
        [Fact]
        public void Constructor_Throws_ArgumentNullException_When_cells_Is_Null()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new BoardData<uint>(null));
            Assert.Equal("cells", exception.ParamName);
        }

        [Fact]
        public void Constructor_Sets_Cells_With_cells()
        {
            var cells = new uint[5, 5];
            var sut = new BoardData<uint>(cells);
            Assert.Equal(cells, sut.Cells);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        public void SetCells_Sets_A_Cell_In_The_Cells(uint x, uint y, uint value)
        {
            var sut = new BoardData<uint>(5, 5);
            sut.SetCell(x, y, value);
            Assert.Equal(value, sut.Cells[y, x]);
        }

        [Fact]
        public void GetRow_Returns_The_Given_Row()
        {
            var sut = new BoardData<int>(new[,]
            {
                {0,1,2,3,4 },
                {5,6,7,8,9 },
                {10,11,12,13,14 }
            });

            var row = sut.GetRow(2);
            Assert.Equal(new[] { 10, 11, 12, 13, 14 }, row);
        }

        [Fact]
        public void GetRow_Returns_A_Collection_Of_Length_Width()
        {
            var sut = new BoardData<int>(4, 5);
            Assert.Equal(sut.Width, (uint)sut.GetRow(0).Count());
        }

        [Fact]
        public void GetColumn_Returns_The_Given_Column()
        {
            var sut = new BoardData<int>(new[,]
            {
                {0,1,2,3,4 },
                {5,6,7,8,9 },
                {10,11,12,13,14 }
            });

            var column = sut.GetColumn(1);
            Assert.Equal(new[] { 1, 6, 11 }, column);
        }

        [Fact]
        public void GetColumn_Returns_A_Collection_Of_Length_Height()
        {
            var sut = new BoardData<int>(4, 5);
            Assert.Equal(sut.Height, (uint)sut.GetColumn(0).Count());
        }

        [Fact]
        public void SetRow_Sets_The_Given_Row()
        {
            var data = new[] { 1, 2, 3, 4, 5 };
            var sut = new BoardData<int>(5, 4);
            sut.SetRow(2, data);
            Assert.Equal(data, sut.GetRow(2));
        }

        [Fact]
        public void SetRow_Throws_An_Exception_If_values_Is_Not_The_Same_Length_As_The_Width()
        {
            var sut = new BoardData<int>(2, 3);
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => sut.SetRow(1, new int[5]));
            Assert.Equal("values", exception.ParamName);
        }

        [Fact]
        public void SetColumn_Sets_The_Given_Column()
        {
            var data = new[] { 1, 2, 3, 4 };
            var sut = new BoardData<int>(5, 4);
            sut.SetColumn(2, data);
            Assert.Equal(data, sut.GetColumn(2));
        }

        [Fact]
        public void SetColumn_Throws_An_Exception_If_values_Is_Not_The_Same_Length_As_The_Height()
        {
            var sut = new BoardData<int>(2, 3);
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => sut.SetColumn(1, new int[5]));
            Assert.Equal("values", exception.ParamName);
        }

        [Fact]
        public void GetCell_Returns_A_Specific_Cell()
        {
            var sut = new BoardData<int>(new[,]
            {
                {0,1,2,3,4 },
                {5,6,7,8,9 },
                {10,11,12,13,14 }
            });
            Assert.Equal(13, sut.GetCell(3, 2));
        }

        [Fact]
        public void ToString_Returns_Correct_String_Representation()
        {
            var sut = new BoardData<int>(new[,]
            {
                {0,1,2,3,4 },
                {5,6,7,8,9 },
                {10,11,12,13,14 }
            });
            var expected =
                @"0,1,2,3,4
5,6,7,8,9
10,11,12,13,14";
            Assert.Equal(expected, sut.ToString());
        }

        [Fact]
        public void Can_Cast_From_String()
        {
            var data =
                @"0,1,2,3,4
5,6,7,8,9
10,11,12,13,14";
            Assert.Equal(data, ((BoardData<uint>)data).ToString());
        }

        [Fact]
        public void Cast_From_String_Throw_Exception_If_Not_Rectangular()
        {
            var data =
                @"0,1,2,3,4
5,6,7,8
10,11,12,13,14";
            Assert.Throws<ArgumentOutOfRangeException>(() => (BoardData<uint>)data);
        }
    }
}