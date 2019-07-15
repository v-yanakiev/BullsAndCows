using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BullsAndCows.Data.DTOs
{
    public class ComputerAnswerDTO
    {
        public GuessDTO AIGuess { get; set; }
        public GuessDTO UserGuess { get; set; }
        public bool UserVictory { get; set; }
        public bool AIVictory { get; set; }
    }
}
