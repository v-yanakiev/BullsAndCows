using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BullsAndCows.Data.DTOs
{
    public class GameDataDTO
    {
        public IEnumerable<GuessDTO> AIGuesses { get; set; }
        public IEnumerable<GuessDTO> UserGuesses { get; set; }
        public string NumberWhichAIMustGuess { get; set; }
        public bool GameExists { get; set; }
    }
}
