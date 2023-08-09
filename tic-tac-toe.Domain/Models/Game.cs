using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe.Domain.Models
{
    public class Game
    {
        private Match match;

        public Game()
        {
            match = new Match();
        }

        public void AddPlayer(string playerName)
        {
            var player = new Player(playerName);
            match.Players.Add(player.Id, player);
        }

        public void StartMatch()
        {
            while (match.Players.Count < 2)
            {
                AddPlayer("saske");
                AddPlayer("naruto");
            }

            if (match.Players.Count < 2)
            {
                throw new InvalidOperationException("Недостаточно игроков для начала игры");
            }

            Console.WriteLine($"Матч начался, код матча: {match.Code}");

            Player player = GetNextPlayer();

            while (!match.IsComplete)
            {
                MakeTurn(player);

                if (CheckWinCondition(player))
                {
                    Console.WriteLine($"Игрок {player.Name} победил!");
                    match.IsComplete = true;
                }
                else if (match.Field.IsFull())
                {
                    Console.WriteLine("Матч окончился ничьей!");
                    match.IsComplete = true;
                }
                else
                {
                    player = GetNextPlayer();
                }
            }
        }

        public void MakeTurn(Player player)
        {
            Console.WriteLine($"Ход игрока {player.Name}");
            Console.WriteLine("Введите координаты хода (например, 1 2):");
            string input = Console.ReadLine();
            string[] coordinates = input.Split(' ');
            int row = int.Parse(coordinates[0]);
            int column = int.Parse(coordinates[1]);

            if (!match.Field.IsValidMove(row, column))
            {
                Console.WriteLine("Некорректные координаты хода. Попробуйте ещё раз.");
                MakeTurn(player);
                return;
            }

            match.Field.MakeMove(row, column, player);
        }

        public Player GetNextPlayer()
        {
            var player = match.Players.Values.FirstOrDefault(p => !p.IsActive && !p.IsPlaying);

            if (player != null)
            {
                player.IsPlaying = true;
                player.IsActive = true;
                return player;
            }

            throw new InvalidOperationException("Нет доступных игроков для хода");
        }

        private bool CheckWinCondition(Player player)
        {
            int[,] board = match.Field.Board;

            // Check rows
            for (int row = 0; row < board.GetLength(0); row++)
            {
                bool hasWinningCombination = true;

                for (int column = 0; column < board.GetLength(1); column++)
                {
                    if (board[row, column] != player.Turn.Turned)
                    {
                        hasWinningCombination = false;
                        break;
                    }
                }

                if (hasWinningCombination)
                {
                    return true;
                }
            }

            // Check columns
            for (int column = 0; column < board.GetLength(1); column++)
            {
                bool hasWinningCombination = true;

                for (int row = 0; row < board.GetLength(0); row++)
                {
                    if (board[row, column] != player.Turn.Turned)
                    {
                        hasWinningCombination = false;
                        break;
                    }
                }

                if (hasWinningCombination)
                {
                    return true;
                }
            }

            // Check diagonals
            bool hasDiagonalWinningCombination1 = true;
            bool hasDiagonalWinningCombination2 = true;

            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[i, i] != player.Turn.Turned)
                {
                    hasDiagonalWinningCombination1 = false;
                }

                if (board[i, board.GetLength(1) - 1 - i] != player.Turn.Turned)
                {
                    hasDiagonalWinningCombination2 = false;
                }
            }

            if (hasDiagonalWinningCombination1 || hasDiagonalWinningCombination2)
            {
                return true;
            }

            return false;
        }
    }
}