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

            return new GameDataDTO()
            {
                AIGuesses = game.Guesses.Where(a=>a.GuessMaker==GuessMaker.AI).ToList().Select(a => new GuessDTO
                {
                    Value = a.Value,
                    GuessOutcome = new GuessOutcomeDTO(a.GuessOutcome)
                }),
                UserGuesses = game.Guesses.Where(a => a.GuessMaker==GuessMaker.User).ToList().Select(a => new GuessDTO
                {
                    Value = a.Value,
                    GuessOutcome = new GuessOutcomeDTO(a.GuessOutcome)
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
        public async Task<ComputerAnswerDTO> Play(ValueOnlyGuessDTO ValueOnlyUserGuessDTO)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }
            Game game = await _gameHandler.GetActiveGame(HttpContext);
            _context.Attach(game);
            if (game == null)
            {
                return null;
            }

            GuessOutcome userGuessOutcome = await _gameHandler.GetUserGuessOutcome(HttpContext, ValueOnlyUserGuessDTO.Value);
            Guess userGuess = new Guess()
            {
                Value = ValueOnlyUserGuessDTO.Value,
                GuessOutcome = userGuessOutcome,
                GuessMaker=GuessMaker.User,
                Game=game
            };            
            _context.Attach(userGuess);

            string AINumber = _rnd.Next(1000, 9999).ToString();
            GuessOutcome aiGuessOutcomeDTO = await _gameHandler.GetAIGuessOutcome(HttpContext, AINumber);
            Guess aiGuess = new Guess()
            {
                Value = AINumber,
                GuessOutcome = aiGuessOutcomeDTO,
                GuessMaker=GuessMaker.AI,
                Game=game
            };
            _context.Attach(aiGuess);
            
            GuessDTO aiGuessDTO = new GuessDTO(aiGuess);
            GuessDTO userGuessDTO = new GuessDTO(userGuess);
            ComputerAnswerDTO computerAnswer = new ComputerAnswerDTO();
            computerAnswer.AIGuess = aiGuessDTO;
            computerAnswer.UserGuess = userGuessDTO;
            if (userGuessOutcome.BullsNumber == ValueOnlyUserGuessDTO.Value.Length)//All numbers match - User wins
            {
                game.WonByUser = true;
                computerAnswer.UserVictory = true;
                computerAnswer.AIGuess = null;
            }
            else if (aiGuessOutcomeDTO.BullsNumber == AINumber.Length)//All numbers match - AI wins
            {
                game.WonByAI = true;
                computerAnswer.AIVictory = true;
            }
            await _context.SaveChangesAsync();
            return computerAnswer;
        }
    }
}