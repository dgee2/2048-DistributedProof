using System;
using System.Collections.Generic;
using System.Linq;
using TwentyFortyEightRepresentation.Board;
using TwentyFortyEightRepresentation.Model;

namespace TwentyFortyEightRepresentation
{
    public class GameProcessor
    {
        private static readonly IEnumerable<EDirection> Directions = new[]
        {
            EDirection.Left, EDirection.Down, EDirection.Right, EDirection.Up
        };
        public GameProcessor(Game game)
        {
            Game = game;
            Board = new TwentyFortyEightBoard(game.BoardWidth, game.BoardHeight);
            foreach (var move in game.Moves)
            {
                Board.SetCell(move.NewCell);
                Board.SlideCells(move.Direction);
            }
            IsEndGame = !Board.GetEmptyCells().Any();
        }

        public bool IsEndGame { get; }
        public uint Score => Board.Score;
        
        public IEnumerable<Game> GetNewGames()
        {
            return Game.NewGamesFromMoves(new uint[] { 1 }, Board.GetEmptyCells(), Directions);
        }

        public TwentyFortyEightBoard Board { get; }

        public Game Game { get; }
    }
}