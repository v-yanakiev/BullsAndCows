using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BullsAndCows.Data;
using BullsAndCows.Data.DTOs;
using BullsAndCows.Models;
using BullsAndCows.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace BullsAndCows.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GameController : ControllerBase
    {
        private BACContext _context;
        private UserManager<User> _userManager;
        private Random _rnd;
        private IGameHandler _gameHandler;

        public GameController(BACContext context, UserManager<User> userManager, IGameHandler gameHandler)
        {
            this._context = context;
            this._userManager = userManager;
            _rnd = new Random();
            _gameHandler = gameHandler;
        }
        [HttpGet]
        [Authorize]
        [Route("data")]
        public async Task<GameDataDTO> GetGameData()
        {
            Game game= await _gameHandler.GetActiveGame(HttpContext);
            if (game == null)
            {
                return new GameDataDTO { GameExists = false };
            }
            return new GameDataDTO
            {
                AIGuesses = game.AIGuesses.ToList().Select(a => new GuessDTO
                {
                    Value = a.Value,
                    GuessOutcome = new GuessOutcomeDTO()
                    { BullNumber = a.BullNumber, CowNumber = a.CowNumber }
                }),
                UserGuesses = game.AIGuesses.ToList().Select(a => new GuessDTO
                {
                    Value = a.Value,
                    GuessOutcome = new GuessOutcomeDTO()
                    { BullNumber = a.BullNumber, CowNumber = a.CowNumber }
                }),
                GameExists = true,
                NumberWhichAIMustGuess=game.NumberWhichAIMustGuess
            };

        }
        [HttpPost]
        [Route("init")]
        public async Task<string> Initialize( InitializeDTO initializeDTO)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }
            User user = await this._userManager.GetUserAsync(HttpContext.User);
            int numberWhichUserMustGuess = _rnd.Next(1000, 9999);
            user.Games.Add(new Game()
            {
                NumberWhichUserMustGuess = numberWhichUserMustGuess.ToString(),
                NumberWhichAIMustGuess = initializeDTO.numberToGuess
            });
            await _context.SaveChangesAsync();
            return initializeDTO.numberToGuess;
        }
        [HttpPost]
        [Route("play")]
        public async Task<string> Play(ValueOnlyGuessDTO userGuessDTO)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }
            Game game=await _gameHandler.GetActiveGame(HttpContext);
            if (game == null)
            {
                return null;
            }
            GuessOutcomeDTO userGuessOutcomeDTO = await _gameHandler.GetUserGuessOutcome(HttpContext, userGuessDTO);
            game.UserGuesses.Add(new UserGuess
            {
                Value = userGuessDTO.Value,
                BullNumber = userGuessOutcomeDTO.BullNumber,
                CowNumber = userGuessOutcomeDTO.CowNumber
            });
            if (userGuessOutcomeDTO.BullNumber == userGuessDTO.Value.Length)
            {
                game.WonByUser = true;
            }

            return null;
        }
    }
}