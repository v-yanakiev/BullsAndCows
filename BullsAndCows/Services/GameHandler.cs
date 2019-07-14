using BullsAndCows.Data;
using BullsAndCows.Data.DTOs;
using BullsAndCows.Models;
using BullsAndCows.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BullsAndCows.Services
{
    public class GameHandler : IGameHandler
    {
        private BACContext _context;
        private UserManager<User> _userManager;

        public GameHandler(BACContext context, UserManager<User> userManager)
        {
            this._context = context;
            this._userManager = userManager;

        }
        public async Task<Game> GetActiveGame(HttpContext httpContext)
        {
            User user = await this._userManager.GetUserAsync(httpContext.User);
            await _context.Entry(user).Collection(a => a.Games).LoadAsync();
            Game game = user.Games.FirstOrDefault(a => a.IsActive == true);
            return game;
        }

        public async Task<GuessOutcomeDTO> GetAIGuessOutcome(HttpContext httpContext,ValueOnlyGuessDTO valueOnlyGuessDTO)
        {
            Game game = await GetActiveGame(httpContext);
            string guess = valueOnlyGuessDTO.Value;
            string numberToBeGuessed = game.NumberWhichAIMustGuess;
            return GetGuessOutcome(guess, numberToBeGuessed);
        }
        public async Task<GuessOutcomeDTO> GetUserGuessOutcome(HttpContext httpContext, ValueOnlyGuessDTO valueOnlyGuessDTO)
        {
            Game game = await GetActiveGame(httpContext);
            string guess = valueOnlyGuessDTO.Value;
            string numberToBeGuessed = game.NumberWhichUserMustGuess;
            return GetGuessOutcome(guess, numberToBeGuessed);
        }
        private GuessOutcomeDTO GetGuessOutcome(string guess,string numberToBeGuessed)
        {
            int bullNumber, cowNumber;
            bullNumber = cowNumber = 0;
            for(int i = 0; i < guess.Length; i++)
            {
                if (guess[i] == numberToBeGuessed[i])
                {
                    bullNumber++;
                }
            }
            for(int i = 0; i < guess.Length; i++)
            {
                if (numberToBeGuessed.Contains(guess[i])&&(guess[i]!=numberToBeGuessed[i]))
                {
                    cowNumber++;
                }
            }
            return new GuessOutcomeDTO() { BullNumber = bullNumber, CowNumber = cowNumber };
        }
    }
}
