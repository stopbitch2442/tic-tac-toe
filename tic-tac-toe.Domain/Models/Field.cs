using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe.Domain.Models
{
    public class Field
    {
        public Size Size { get; set; }
        public int[,] Board { get; set; }
        public Field()
        {
            Size = new Size(2,2);  
            Board = new int[Size.Width, Size.Height];
        }
    }
}
