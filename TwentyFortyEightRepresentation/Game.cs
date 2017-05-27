using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TwentyFortyEightRepresentation.Board;

namespace TwentyFortyEightRepresentation
{
    public struct Game
    {
        public Game(IImmutableList<Move> moves)
        {
            Moves = moves;
        }
        public IImmutableList<Move> Moves { get; }

        public IEnumerable<Game> AddMoves(IEnumerable<uint> values, IEnumerable<Coordinate> coordinates, IEnumerable<EDirection> directions)
        {
            var moves = values.SelectMany(
                value => coordinates.SelectMany(
                    coordinate => directions.Select(
                        direction => new Move(new NewCell(coordinate, value), direction)
                    )));
            return AddMoves(moves);
        }

        public IEnumerable<Game> AddMoves(IEnumerable<Move> moves) => moves.Select(AddMove);

        public Game AddMove(Move move) => new Game(Moves.Add(move));
    }
}