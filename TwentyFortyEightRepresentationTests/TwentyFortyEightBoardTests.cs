using System;
using FakeItEasy;
using TwentyFortyEightRepresentation;
using Xunit;

namespace TwentyFortyEightRepresentationTests
{
    public class TwentyFortyEightBoardTests
    {
        [Fact]
        public void Constructor_Throws_ArgumentNullException_If_board_Is_Null()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new TwentyFortyEightBoard(null));
            Assert.Equal("board", exception.ParamName);
        }

        [Fact]
        public void Constructor_Does_Not_Throw_An_Exception_If_All_Parameters_Are_Non_Null()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new TwentyFortyEightBoard(A.Fake<IBoardRepresentation<uint>>());
        }

        [Fact]
        public void Height_Returns_Board_Height()
        {
            var board = A.Fake<IBoardRepresentation<uint>>();
            A.CallTo(() => board.Height).Returns((uint)15);
            var sut = new TwentyFortyEightBoard(board);
            var i = sut.Height;
            A.CallTo(() => board.Height).MustHaveHappened(Repeated.Exactly.Once);
            Assert.Equal((uint)15, i);
        }
        [Fact]
        public void Height_Returns_Board_Width()
        {
            var board = A.Fake<IBoardRepresentation<uint>>();
            A.CallTo(() => board.Width).Returns((uint)17);
            var sut = new TwentyFortyEightBoard(board);
            var i = sut.Width;
            A.CallTo(() => board.Width).MustHaveHappened(Repeated.Exactly.Once);
            Assert.Equal((uint)17, i);
        }

        [Fact]
        public void GetCell_Returns_Board_GetCells()
        {
            var cells = A.Fake<IBoardData<uint>>();
            var board = A.Fake<IBoardRepresentation<uint>>();
            A.CallTo(() => board.Cells).Returns(cells);

            var sut = new TwentyFortyEightBoard(board);
            Assert.Equal(cells, sut.Cells);
        }

        [Fact]
        public void SlideCells_From_End_To_Beginning()
        {
            var input = new uint[] { 0, 0, 0, 5 };
            var expected = new uint[] { 5, 0, 0, 0 };
            Assert.Equal(expected, TwentyFortyEightBoard.SlideCells(input));
        }

        [Fact]
        public void SlideCells_From_Middle_To_Beginning()
        {
            var input = new uint[] { 0, 0, 5, 0 };
            var expected = new uint[] { 5, 0, 0, 0 };
            Assert.Equal(expected, TwentyFortyEightBoard.SlideCells(input));
        }

        [Fact]
        public void SlideCells_From_Beginning_To_Beginning()
        {
            var input = new uint[] { 5, 0, 0, 0 };
            var expected = new uint[] { 5, 0, 0, 0 };
            Assert.Equal(expected, TwentyFortyEightBoard.SlideCells(input));
        }

        [Fact]
        public void SlideCells_Merges_Value_That_Is_Same()
        {
            var input = new uint[] { 5, 0, 5, 0 };
            var expected = new uint[] { 10, 0, 0, 0 };
            Assert.Equal(expected, TwentyFortyEightBoard.SlideCells(input));
        }

        [Fact]
        public void SlideCells_Merges_Multiple_Values_That_Are_Same()
        {
            var input = new uint[] { 5, 5, 5, 5 };
            var expected = new uint[] { 10, 10, 0, 0 };
            Assert.Equal(expected, TwentyFortyEightBoard.SlideCells(input));
        }
    }
}