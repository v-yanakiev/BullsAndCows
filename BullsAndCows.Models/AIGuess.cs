using System;
using System.Collections.Generic;
using System.Text;

namespace BullsAndCows.Models
{
    public class AIGuess
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public int BullNumber { get; set; }
        public int CowNumber { get; set; }
    }
}
