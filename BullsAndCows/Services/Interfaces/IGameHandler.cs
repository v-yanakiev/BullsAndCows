using BullsAndCows.Data.DTOs;
using BullsAndCows.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BullsAndCows.Services.Interfaces
{
    public interface IGameHandler
    {
        Task<Game> GetActiveGame(HttpContext httpContext);
        Task<GuessOutcome> GetUserGuessOutcome(HttpContext httpContext, string guess);
        Task<GuessOutcome> GetAIGuessOutcome(HttpContext httpContext, string guess);
        Task<string> GetAIGuess(HttpContext httpContext);
        string GenerateUniqueDigitsNumber();
    }
}
