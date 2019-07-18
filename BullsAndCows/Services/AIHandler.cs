using BullsAndCows.Data;
using BullsAndCows.Models;
using BullsAndCows.Services.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BullsAndCows.Services
{
    public class AIHandler:IAIHandler
    {
        private readonly RNGHandler _rng;
        private readonly int NumberSize;
        public AIHandler(IOptions<AppSettings> appSettings)
        {
            this.NumberSize = appSettings.Value.NumberDigitSize;
            this._rng = new RNGHandler(appSettings);
        }

        public string GetNextAIMove(Game game)
        {
            List<string> mutablePermutations = this._rng.GeneratePermutations(NumberSize).ToList();
            foreach(Guess aiGuess in game.Guesses.Where(a => a.GuessMaker == GuessMaker.AI).OrderBy(a=>a.Id))
            {
                TakeIntoAccountPreviousGuess(ref mutablePermutations, aiGuess);
                if (mutablePermutations.Count == 1)
                {
                    return mutablePermutations[0];
                }
            }
            
            return mutablePermutations[0];
        }
        private void TakeIntoAccountPreviousGuess(ref List<string> mutablePermutations,Guess aiGuess) //this is the AI part
        {
            string guess = aiGuess.Value;
            for (int ans = mutablePermutations.Count - 1; ans >= 0; ans--)
            {
                int tb = 0, tc = 0;
                for (int ix = 0; ix < NumberSize; ix++)
                {
                    string guessHypothetical = mutablePermutations[ans];
                    if (guessHypothetical[ix] == guess[ix])
                        tb++;
                    else if (mutablePermutations[ans].Contains(guess[ix]))
                        tc++;
                }
                if ((tb != aiGuess.GuessOutcome.BullsNumber) || (tc != aiGuess.GuessOutcome.CowsNumber))
                    mutablePermutations.RemoveAt(ans);
            }
        }
    }
}
