using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TwentyFortyEightRepresentation.Board;

namespace TwentyFortyEightRepresentation.Model
{
    public struct Game
    {
        public Game(uint boardWidth, uint boardHeight)
            : this(ImmutableList<Move>.Empty, boardWidth, boardHeight)
        { }
        public uint BoardWidth { get; }
        public uint BoardHeight { get; }
        public Game(IImmutableList<Move> moves, uint boardWidth, uint boardHeight)
        {
            Moves = moves;
            BoardWidth = boardWidth;
            BoardHeight = boardHeight;
        }
        public IImmutableList<Move> Moves { get; }

        public IEnumerable<Game> NewGamesFromMoves(IEnumerable<uint> values, IEnumerable<Coordinate> coordinates, IEnumerable<EDirection> directions)
        {
            var moves = values.SelectMany(
                value => coordinates.SelectMany(
                    coordinate => directions.Select(
                        direction => new Move(new NewCell(coordinate, value), direction)
                    )));
            return NewGamesFromMoves(moves);
        }

        public IEnumerable<Game> NewGamesFromMoves(IEnumerable<Move> moves) => moves.Select(NewGame);

        public Game NewGame(Move move) => new Game(Moves.Add(move), BoardWidth, BoardHeight);
    }
}