using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BullsAndCows.Data.DTOs
{
    public class GuessDTO
    {
        public string Value { get; set; }
        public GuessOutcomeDTO GuessOutcome { get; set; }
    }
}
