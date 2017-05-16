using TwentyFortyEightRepresentation;
using Xunit;

namespace TwentyFortyEightRepresentationTests
{
    public class CoordinateTests
    {
        Coordinate _coord;
        public CoordinateTests()
        {
            _coord = new Coordinate(4, 3);
        }

        [Fact]
        public void Constructor_Should_Store_The_Value_Of_x_In_X()
        {
            Assert.Equal((uint)4, _coord.X);
        }

        [Fact]
        public void Constructor_Should_Store_The_Value_Of_y_In_Y()
        {
            Assert.Equal((uint)3, _coord.Y);
        }
    }
}