using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BullsAndCows.Data.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BullsAndCows.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GameController : ControllerBase
    {
        public GameController()
        {

        }
        [HttpPost]
        [Route("init")]
        public async Task<string> Initialize( InitializeDTO initializeDTO)
        {
            if (!ModelState.IsValid)
            {
                return "Error";
            }
            return "Success!";
        }
        [HttpGet]
        [Route("play")]
        public async Task<string> Play()
        {
            return "Success!";
        }
    }
}