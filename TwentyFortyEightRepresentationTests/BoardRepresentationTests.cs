using TwentyFortyEightRepresentation;
using Xunit;

namespace TwentyFortyEightRepresentationTests
{
    public class BoardRepresentationTests
    {
        [Fact]
        public void Constructor_Sets_Width()
        {
            var sut = new BoardRepresentation(3, 4);
            Assert.Equal((uint)3, sut.Width);
        }

        [Fact]
        public void Constructor_Sets_Height()
        {
            var sut = new BoardRepresentation(3, 4);
            Assert.Equal((uint)4, sut.Height);
        }

        [Theory]
        [InlineData(1, 2, 6)]
        public void A_Cell_Can_Be_Set_By_Indexes(uint x, uint y, uint value)
        {
            var sut = new BoardRepresentation(3, 4);
            sut.SetCell(x, y, value);
            Assert.Equal(value, sut.GetCells()[x, y]);
        }

        [Theory]
        [InlineData(1, 2, 6)]
        public void A_Cell_Can_Be_Got_By_Indexes(uint x, uint y, uint value)
        {
            var sut = new BoardRepresentation(3, 4);
            sut.SetCell(x, y, value);
            Assert.Equal(value, sut.GetCell(x, y));
        }

        [Theory]
        [InlineData(1, 2, 6)]
        public void A_Cell_Can_Be_Set_By_Coordinate(uint x, uint y, uint value)
        {
            var sut = new BoardRepresentation(3, 4);
            sut.SetCell(new Coordinate(x, y), value);
            Assert.Equal(value, sut.GetCell(x, y));
        }

        [Theory]
        [InlineData(1, 2, 6)]
        public void A_Cell_Can_Be_Get_By_Coordinate(uint x, uint y, uint value)
        {
            var sut = new BoardRepresentation(3, 4);
            sut.SetCell(x, y, value);
            Assert.Equal(value, sut.GetCell(new Coordinate(x, y)));
        }
    }
}