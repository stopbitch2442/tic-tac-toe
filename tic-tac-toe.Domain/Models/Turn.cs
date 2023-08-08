using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe.Domain.Models
{
    public class Turn
    {
        public Guid Id { get;}
        public int Turned { get; set; } //1 - крест 0 - ноль
        
    }
}
