using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tic_tac_toe.Domain.HelperClass;

namespace tic_tac_toe.Domain.Models
{
    public class Player
    {
        public Guid Id { get;}
        public string Name { get; set; }
        public int Code { get;} 
        public bool IsActive { get; set; }
        public bool IsPlaying { get; set; } 
        public Turn Turn { get; set; }

       public Player(string name) 
        {
            Id = Guid.NewGuid();
            Name = name;
            Code = RandomCodeGenerator.GenerateCode();
            IsActive = false;
            IsPlaying = false;
            Turn = new Turn();
        }

    }
}
