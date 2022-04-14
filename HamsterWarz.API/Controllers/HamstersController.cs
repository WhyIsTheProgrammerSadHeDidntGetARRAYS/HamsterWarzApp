using HamsterWarz.API.Data.Interfaces;
using HamsterWarz.API.Helper;
using HamsterWarz.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [Route("getall")]
        [HttpGet]
        public async Task<IEnumerable<Hamster>> GetAll()
        {
            return await _service.GetHamstersAsync();
        }
        
        [Route("get/{id}")]
        [HttpGet]
        public async Task<Hamster> GetById(int id)
        {
            return await _service.GetHamsterById(id);
        }

        [Route("getcompetitors")]
        [HttpGet]
        public async Task<IActionResult> GetHamsterCompetitors()
        {
            var list = await _service.GetHamsterCompetitorsAsync();
            if (list.Any())
            {
                return Ok(list);
            }
            return BadRequest("No hamsters found");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>status code</returns>
        [Route("vote")]
        [HttpPost]
        public async Task<IActionResult> VoteForHamster(TransferObject obj)
        {
            if(obj == null)
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
        public async Task<IActionResult> GetTopFive()
        {
            var topFive = await _service.TopFiveWinners();
            
            if (!topFive.Any())
            {
                return NotFound("Not enough matches to gather data");
            }

            return Ok(topFive);
        }
        //TODO: Fixa så att man på clientsidan kan få fram 5 hamstrarna som förlorat mest, detta ska visas på statisticspagen
        /// <summary>
        /// 
        /// </summary>
        /// <returns>IEnumerable of lowest 5 rated hamsters</returns>
        [HttpGet]
        [Route("bottomfive")]
        public async Task<IActionResult> GetBottomFive()
        {
            var botFive = await _service.TopFiveLosers();

            if (!botFive.Any())
            {
                return NotFound("Not enough matches to gather data");
            }

            return Ok(botFive);
        }
    }
}
