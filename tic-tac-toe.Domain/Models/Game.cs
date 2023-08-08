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
            if (match.Players.Count < 2)
            {
                Console.WriteLine("Недостаточно игроков для начала игры");
                return;
            }
            Console.WriteLine($"Матч начался, код матча:{match.Code}");
            Player player = GetNextPlayer();
        }

        public Player GetNextPlayer()
        {
            foreach (var player in match.Players.Values)
            {
                if (!player.IsActive && !player.IsPlaying)
                {
                    player.IsPlaying = true;
                    player.IsActive = true;
                    return player;
                }
            }
            return null;
        }
        private bool CheckWinCondition(Player player)
        {
            int[,] board = match.Field.Board;
            // Check rows
            for (int row = 0; row < board.GetLength(0); row++)
            {
                if (board[row, 0] * board[row, 1] * board[row, 2] == player.Turn.Turned)
                {
                    return true;
                }
            }

            // Check columns
            for (int column = 0; column < board.GetLength(1); column++)
            {
                if (board[0, column] * board[1, column] * board[2, column] == player.Turn.Turned)
                {
                    return true;
                }
            }

            // Check diagonals
            if (board[0, 0] * board[1, 1] * board[2, 2] == player.Turn.Turned ||
                board[0, 2] * board[1, 1] * board[2, 0] == player.Turn.Turned)
            {
                return true;
            }

            return false;
        }
    }
}
