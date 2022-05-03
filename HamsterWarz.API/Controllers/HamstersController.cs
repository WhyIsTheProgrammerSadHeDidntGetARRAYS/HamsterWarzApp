using HamsterWarz.Entities.Helper;
using HamsterWarz.Entities.Models;
using HamsterWarz.Entities.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HamsterWarz.Entities.ViewModels;

namespace HamsterWarz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HamstersController : ControllerBase
    {
        private readonly IHamsterService _service;

        public HamstersController(IHamsterService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _service.GetHamstersAsync();

            if (!list.Any())
            {
                return NotFound();
            }
            return Ok(list);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var hamster = await _service.GetHamsterById(id)!;

            if (hamster == null)
            {
                return NotFound();
            }

            return Ok(hamster);
        }
        [HttpDelete("delete/{id}")] //TODO: tror inte jag behöver en delete-route, utan räcker nog med id't bara
        public async Task<IActionResult> DeleteHamster(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            return Ok(await _service.DeleteHamster(id));
        }

        [Route("random")]
        [HttpGet]
        public async Task<IActionResult> GetHamsterCompetitors()
        {
            var list = await _service.GetHamsterCompetitorsAsync();

            if (!list.Any())
            {
                return BadRequest("No hamsters found");
            }
            return Ok(list);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>status code</returns>
        [Route("vote")]
        [HttpPost]
        public async Task<IActionResult> VoteForHamster(MatchWinnersDTO obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
            try
            {
                await _service.VoteHamster(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(obj.Hamsters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>IEnumerable of top 5 rated hamsters</returns>
        [HttpGet]
        [Route("topfive")]
        public async Task<IActionResult> GetTopFiveHamsterCompetitors()
        {
            var topFive = await _service.TopFiveWinners()!;

            if (!topFive.Any())
            {
                return NotFound("Not enough matches to gather data");
            }

            return Ok(topFive);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>IEnumerable of lowest 5 rated hamsters</returns>
        [HttpGet]
        [Route("bottomfive")]
        public async Task<IActionResult> GetBottomFiveHamsterCompetitors()
        {
            var botFive = await _service.TopFiveLosers()!;

            if (!botFive.Any())
            {
                return NotFound("Not enough matches to gather data");
            }

            return Ok(botFive);
        }

        [HttpPost]
        public async Task<IActionResult> AddHamster([FromBody] HamsterViewModel hamster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                await _service.AddHamster(hamster);
                return Ok(hamster);
            }
            catch
            {
                throw;
            }
        }
    }
}
