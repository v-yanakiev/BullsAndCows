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
        Task<GuessOutcomeDTO> GetUserGuessOutcome(HttpContext httpContext, ValueOnlyGuessDTO valueOnlyGuessDTO);
        Task<GuessOutcomeDTO> GetAIGuessOutcome(HttpContext httpContext, ValueOnlyGuessDTO valueOnlyGuessDTO);

    }
}
