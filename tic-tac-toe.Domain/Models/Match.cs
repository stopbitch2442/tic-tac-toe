using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tic_tac_toe.Domain.HelperClass;

namespace tic_tac_toe.Domain.Models
{
    public class Match
    {
        public Guid Id { get; }
        public int Code { get; }
        public bool IsComplete { get; set; }
        public Dictionary<Guid, Player> Players { get; }
        public Dictionary<Guid, Turn> Turns { get; }
        public Field Field { get; }
        public Match()
        {
            Id = Guid.NewGuid();
            Code = RandomCodeGenerator.GenerateCode();
            IsComplete = false;
            Players = new Dictionary<Guid, Player>();
            Turns = new Dictionary<Guid, Turn>();
            Field = new Field();
        }
    }
}