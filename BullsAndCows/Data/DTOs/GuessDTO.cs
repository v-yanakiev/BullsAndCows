using BullsAndCows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BullsAndCows.Data.DTOs
{
    public class GuessDTO
    {
        public GuessDTO()
        {

        }
        public GuessDTO(Guess guess)
        {
            this.Value = guess.Value;
            this.GuessOutcome = new GuessOutcomeDTO(guess.GuessOutcome);
        }
        public string Value { get; set; }
        public GuessOutcomeDTO GuessOutcome { get; set; }

    }
}
