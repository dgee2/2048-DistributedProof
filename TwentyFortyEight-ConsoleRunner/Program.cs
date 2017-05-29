using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using TwentyFortyEightRepresentation;
using TwentyFortyEightRepresentation.Model;

namespace TwentyFortyEight_ConsoleRunner
{
    class Program
    {
        GameProcessor BestGame { get; set; }
        private IList<Game> Games { get; set; } = new List<Game>();
        private bool WriteAllGames { get; }

        static void Main(string[] args)
        {
            var program = new Program(new Game(2, 2), false);
            program.Run();
            Console.Read();
        }

        Program(Game startGame, bool writeAllGames)
        {
            WriteAllGames = writeAllGames;
            Games.Add(startGame);
        }

        void Run()
        {
            while (Games.Any())
            {
                Games = Games.AsParallel().SelectMany(ProcessGame).ToList();
                Console.WriteLine("Best Game So Far:");
                WriteGame(BestGame);
                Console.WriteLine($"Games to Process: {Games.Count}");
            }
            Console.WriteLine("Best Game:");
            WriteGame(BestGame);
        }

        IEnumerable<Game> ProcessGame(Game game)
        {
            var processor = new GameProcessor(game);
            if (BestGame == null || BestGame.Score < processor.Score)
            {
                BestGame = processor;
            }
            if (WriteAllGames) WriteGame(processor);
            return processor.GetNewGames();
        }

        void WriteGame(GameProcessor game)
        {
            Console.WriteLine(
                $"Score: {game.Score}, IsEndGame: {game.IsEndGame}, MoveCount: {game.Game.Moves.Count}, Width: {game.Game.BoardWidth}, Height: {game.Game.BoardHeight}, Game: {JsonConvert.SerializeObject(game.Game)}");
            Console.WriteLine(game.Board.ToString());
        }
    }
}