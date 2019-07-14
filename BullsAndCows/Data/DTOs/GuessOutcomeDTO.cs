using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BullsAndCows.Data.DTOs
{
    public class GuessOutcomeDTO
    {
        public int BullNumber { get; set; }
        public int CowNumber { get; set; }
        public bool AIVictory { get; set; }
        public bool UserVictory { get; set; }
    }
}
