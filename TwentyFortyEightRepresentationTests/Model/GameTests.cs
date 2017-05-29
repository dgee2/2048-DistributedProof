using System.Collections.Immutable;
using System.Linq;
using FakeItEasy;
using TwentyFortyEightRepresentation.Board;
using TwentyFortyEightRepresentation.Model;
using Xunit;

namespace TwentyFortyEightRepresentationTests.Model
{
    public class GameTests
    {
        [Fact]
        public void NewGame_Returns_A_New_Game_With_A_New_List()
        {
            var list = A.Fake<IImmutableList<Move>>();
            var sut = new Game(list, 4, 4);
            var newGame = sut.NewGame(new Move());
            Assert.NotSame(sut, newGame);
            Assert.NotSame(sut.Moves, newGame.Moves);
        }

        [Fact]
        public void NewGame_Has_New_Move_In_Returned_Game()
        {
            var list = ImmutableList.Create<Move>();
            var sut = new Game(list, 4, 4);
            var newMove = new Move();
            var newGame = sut.NewGame(newMove);
            Assert.Contains(newMove, newGame.Moves);
            Assert.Equal(1, newGame.Moves.Count);
        }

        [Fact]
        public void NewGame_Has_Original_Moves_In_Moves()
        {
            var expected = ImmutableList.Create<Move>(new Move(new NewCell(), EDirection.Down), new Move(new NewCell(), EDirection.Up));
            var sut = new Game(expected, 4, 4);
            var newMove = new Move(new NewCell(), EDirection.Left);
            var newGame = sut.NewGame(newMove);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i], newGame.Moves[i]);
            }
            Assert.Equal(newMove, newGame.Moves.Last());
        }
    }
}