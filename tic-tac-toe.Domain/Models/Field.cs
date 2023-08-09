using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using tic_tac_toe.Domain.HelperClass;

namespace tic_tac_toe.Domain.Models
{
    public class Field
    {
        public Size Size { get; set; }
        public int[,] Board { get; set; }
        public Field()
        {
            Size = new Size(3, 3);
            Board = new int[Size.Width, Size.Height];
        }
        public bool IsFull()
        {
            for (int row = 0; row < Board.GetLength(0); row++)
            {
                for (int column = 0; column < Board.GetLength(1); column++)
                {
                    if (Board[row, column] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool MakeMove(int row, int column, Player player)
        {
            if (IsValidMove(row, column))
            {
                Board[row, column] = player.Turn.Turned;
                return true;
            }
            return false;
        }
        public bool IsValidMove(int row, int column)
        {
            if (row >= 0 && row < Size.Width && column >= 0 && column < Size.Height && Board[row, column] == 0)
            {
                return true;
            }
            return false;
        }
    }
}