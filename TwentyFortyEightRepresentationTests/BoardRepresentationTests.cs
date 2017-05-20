using FakeItEasy;
using TwentyFortyEightRepresentation;
using Xunit;

namespace TwentyFortyEightRepresentationTests
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
            A.CallTo(() => Board.GetCell(x,y)).Returns(value);
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
    }
}