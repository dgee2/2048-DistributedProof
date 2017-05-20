using System.Collections.Generic;
using FakeItEasy;
using Xunit;
using TwentyFortyEightRepresentation.Board;

namespace TwentyFortyEightRepresentationTests.Board
{
    public class BoardRepresentationTests
    {
        private IBoardData<uint> Board { get; }

        public BoardRepresentationTests()
        {
            Board = A.Fake<IBoardData<uint>>();
            A.CallTo(() => Board.Width).Returns((uint)3);
            A.CallTo(() => Board.Height).Returns((uint)4);
        }

        [Fact]
        public void Constructor_Sets_Width()
        {
            var sut = new BoardRepresentation<uint>(Board);
            Assert.Equal((uint)3, sut.Width);
        }

        [Fact]
        public void Constructor_Sets_Height()
        {
            var sut = new BoardRepresentation<uint>(Board);
            Assert.Equal((uint)4, sut.Height);
        }

        [Theory]
        [InlineData(1, 2, 6)]
        public void A_Cell_Can_Be_Set_By_Indexes(uint x, uint y, uint value)
        {
            var sut = new BoardRepresentation<uint>(Board);
            sut.SetCell(x, y, value);
            A.CallTo(() => Board.SetCell(x, y, value)).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Theory]
        [InlineData(1, 2, 6)]
        public void A_Cell_Can_Be_Got_By_Indexes(uint x, uint y, uint value)
        {
            var sut = new BoardRepresentation<uint>(Board);
            A.CallTo(() => Board.GetCell(x, y)).Returns(value);
            Assert.Equal(value, sut.GetCell(x, y));
        }

        [Theory]
        [InlineData(1, 2, 6)]
        public void A_Cell_Can_Be_Set_By_Coordinate(uint x, uint y, uint value)
        {
            var sut = new BoardRepresentation<uint>(Board);
            sut.SetCell(new Coordinate(x, y), value);
            A.CallTo(() => Board.SetCell(x, y, value)).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Theory]
        [InlineData(1, 2, 6)]
        public void A_Cell_Can_Be_Got_By_Coordinate(uint x, uint y, uint value)
        {
            var sut = new BoardRepresentation<uint>(Board);
            A.CallTo(() => Board.GetCell(x, y)).Returns(value);
            Assert.Equal(value, sut.GetCell(new Coordinate(x, y)));
        }

        [Fact]
        public void GetRow_Returns_Result_From_Board()
        {
            var sut = new BoardRepresentation<uint>(Board);
            var row = A.Fake<IEnumerable<uint>>();
            A.CallTo(() => Board.GetRow(2)).Returns(row);
            Assert.Equal(row, sut.GetRow(2));
        }

        [Fact]
        public void GetColumn_Returns_Result_From_Board()
        {
            var sut = new BoardRepresentation<uint>(Board);
            var column = A.Fake<IEnumerable<uint>>();
            A.CallTo(() => Board.GetColumn(2)).Returns(column);
            Assert.Equal(column, sut.GetColumn(2));
        }

        [Fact]
        public void SetRow_Passes_Row_To_Board()
        {
            var sut = new BoardRepresentation<uint>(Board);
            var row = A.Fake<IEnumerable<uint>>();
            sut.SetRow(2, row);
            A.CallTo(() => Board.SetRow(2, row)).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Fact]
        public void SetColumn_Passes_Column_To_Board()
        {
            var sut = new BoardRepresentation<uint>(Board);
            var column = A.Fake<IEnumerable<uint>>();
            sut.SetColumn(2, column);
            A.CallTo(() => Board.SetColumn(2, column)).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Fact]
        public void Cells_Returns_Board()
        {
            var sut = new BoardRepresentation<uint>(Board);
            Assert.Equal(Board,sut.Cells);
        }
    }
}