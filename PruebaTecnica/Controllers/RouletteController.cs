using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Models;
using PruebaTecnica.Services;
using System;
using PruebaTecnica.DataObject;

namespace PruebaTecnica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RouletteController : Controller
    {
        private IRouletteService rouletteService;

        public RouletteController(IRouletteService rouletteService)
        {
            this.rouletteService = rouletteService;
        }
        /// <summary>
        /// Create a  new rulette
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public IActionResult CreateRulette()
        {
            RouletteModel roulette = rouletteService.CreateRoulette();
            return Ok(roulette);
        }


        [HttpGet]
        public IActionResult GetRoulettes()
        {
            return Ok(rouletteService.GetRoulettes());
        }

        /// <summary>
        /// Open the rulette id
        /// </summary>
        /// <param name="id">rulette id</param>
        /// <returns></returns>
        [HttpPut("{id}/open")]
        public IActionResult OpenRoulette ([FromRoute(Name = "id")] string id)
        {
            try
            {
                rouletteService.OpenRoulette(id);
                return Ok();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(405);
            }
        }

        /// <summary>
        /// Closes bets on a rulette
        /// </summary>
        /// <param name="id"> rulette id</param>
        /// <returns></returns>
        [HttpPut("{id}/close")]
        public IActionResult CloseRoulette([FromRoute(Name = "id")] string id)
        {
            try
            {
                RouletteModel roulette = rouletteService.CloseRoulette(id);
                return Ok(roulette);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(405);
            }
        }

        /// <summary>
        /// It lets make a bet between [0.5 and 10000, red or black]
        /// </summary>
        /// <param name="UserId">user id</param>
        /// <param name="id"> roulette id</param>
        /// <param name="request">piece number, [0,36] number [37=> red, 38=> black] </param>
        /// <returns></returns>
        [HttpPost("{id}/bet")]
        public IActionResult Bet([FromHeader(Name = "user-id")] string UserId, [FromRoute(Name = "id")] string id,
            [FromBody] Requested request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    error = true,
                    msg = "Bad Request"
                });
            }

            try
            {
                RouletteModel roulette = rouletteService.BetRoulette(id, UserId, request.position, request.money);
                return Ok(roulette);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(405);
            }

        }
    }
}
