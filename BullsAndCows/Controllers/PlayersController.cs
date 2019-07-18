using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BullsAndCows.Data;
using BullsAndCows.Data.DTOs;
using BullsAndCows.Models;
using BullsAndCows.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BullsAndCows.Controllers
{
    public class PlayersController : Controller
    {
        private const int NumberOfTopPlayersToShow = 25;
        private readonly BACContext _context;


        public PlayersController(BACContext context)
        {
            this._context = context;
        }
        public IActionResult Ranking()
        {
            List<PlayerDTO> players = _context.Users.Include(a => a.Games).ToList().
                OrderByDescending(a => a.Score).ThenByDescending(a => a.PercentageWins).Take(NumberOfTopPlayersToShow).
                Select(a => new PlayerDTO(a)).ToList(); ;
            TopPlayersDTO topPlayersDTO = new TopPlayersDTO { Players = players };
            return View(topPlayersDTO);
        }
    }
}