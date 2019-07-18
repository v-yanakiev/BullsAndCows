using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BullsAndCows.Services
{
    public class AppSettings
    {
        public int NumberDigitSize { get; set; }
        public int NumberOfGuessesAIHasToMakeBeforeItStartsUsingAnOptimalStrategy { get; set; }
    }
}
