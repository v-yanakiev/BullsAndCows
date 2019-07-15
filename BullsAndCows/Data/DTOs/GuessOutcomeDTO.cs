using BullsAndCows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BullsAndCows.Data.DTOs
{
    public class GuessOutcomeDTO
    {
        public GuessOutcomeDTO()
        {

        }
        public GuessOutcomeDTO(GuessOutcome  guessOutcome)
        {
            this.BullsNumber = guessOutcome.BullsNumber;
            this.CowsNumber = guessOutcome.CowsNumber;
        }
        public int BullsNumber { get; set; }
        public int CowsNumber { get; set; }
    }
}
