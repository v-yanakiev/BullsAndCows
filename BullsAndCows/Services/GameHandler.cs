using BullsAndCows.Data;
using BullsAndCows.Data.DTOs;
using BullsAndCows.Models;
using BullsAndCows.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BullsAndCows.Services
{
    public class GameHandler : IGameHandler
    {
        private readonly int NumberOfGuessesAIHasToMakeBeforeItStartsUsingAnOptimalStrategy;
        //We use this variable so that the game will be easier for the player. 
        //It may be altered to raise or lower the difficulty, so long as it remains >=1 .

        private readonly BACContext _context;
        private readonly IAIHandler _aiHandler;
        private readonly RNGHandler _rng;

        public GameHandler(BACContext context,IAIHandler aIHandler,IOptions<AppSettings> appSettings)
        {
            this._context = context;
            this._aiHandler = aIHandler;
            this._rng = new RNGHandler(appSettings);
            this.NumberOfGuessesAIHasToMakeBeforeItStartsUsingAnOptimalStrategy=
                appSettings.Value.NumberOfGuessesAIHasToMakeBeforeItStartsUsingAnOptimalStrategy;
        }
        public async Task<Game> GetActiveGame(HttpContext httpContext)
        {
            User user = await _context.Users.Where(a => a.UserName == httpContext.User.Identity.Name).
                Include(a => a.Games).ThenInclude(a => a.Guesses).ThenInclude(a=>a.GuessOutcome).FirstAsync();
            await _context.Entry(user).Collection(a => a.Games).LoadAsync();
            Game game = user.Games.FirstOrDefault(a => a.IsActive == true);
            return game;
        }

        public async Task<string> GetAIGuess(HttpContext httpContext)
        {
            Game game = await GetActiveGame(httpContext);
            int numberOfGuessesAIHasAlreadyMade = game.Guesses.Count(a => a.GuessMaker == GuessMaker.AI);
            if (numberOfGuessesAIHasAlreadyMade < NumberOfGuessesAIHasToMakeBeforeItStartsUsingAnOptimalStrategy)
            {
                string randomGuess = GenerateUniqueDigitsNumber();
                return randomGuess;
            }
            string guess = this._aiHandler.GetNextAIMove(game);
            return guess;
        }

        public async Task<GuessOutcome> GetAIGuessOutcome(HttpContext httpContext,string guess)
        {
            Game game = await GetActiveGame(httpContext);
            string numberToBeGuessed = game.NumberWhichAIMustGuess;
            return GetGuessOutcome(guess, numberToBeGuessed);
        }
        public async Task<GuessOutcome> GetUserGuessOutcome(HttpContext httpContext, string guess)
        {
            Game game = await GetActiveGame(httpContext);
            string numberToBeGuessed = game.NumberWhichUserMustGuess;
            return GetGuessOutcome(guess, numberToBeGuessed);
        }
        
        private GuessOutcome GetGuessOutcome(string guess,string numberToBeGuessed)
        {
            int bullNumber, cowNumber;
            bullNumber = cowNumber = 0;
            for(int i = 0; i < guess.Length; i++)
            {
                if (guess[i] ==numberToBeGuessed[i])
                {
                    bullNumber++;
                }
            }
            for(int i = 0; i < guess.Length; i++)
            {
                if (guess.Contains(numberToBeGuessed[i])&&(guess[i]!=numberToBeGuessed[i]))
                {
                    cowNumber++;
                }
            }
            return new GuessOutcome() { BullsNumber = bullNumber, CowsNumber = cowNumber };
        }
        public string GenerateUniqueDigitsNumber()
        {
            return this._rng.GenerateUniqueDigitsNumber();
        }
        
    }
}
