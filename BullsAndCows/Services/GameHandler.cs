using BullsAndCows.Data;
using BullsAndCows.Data.DTOs;
using BullsAndCows.Models;
using BullsAndCows.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
            User user = await _context.Users.Where(a => a.UserName == httpContext.User.Identity.Name).
                Include(a => a.Games).ThenInclude(a => a.Guesses).ThenInclude(a=>a.GuessOutcome).FirstAsync();
            await _context.Entry(user).Collection(a => a.Games).LoadAsync();
            Game game = user.Games.FirstOrDefault(a => a.IsActive == true);
            return game;
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
            return new GuessOutcome() { BullsNumber = bullNumber, CowsNumber = cowNumber };
        }
    }
}
