//using HamsterWarz.API.Data.Interfaces;
using DataAccess.Data.Interfaces;
using DataAccess.Data.Services;
//using HamsterWarz.API.Helper;
using HamsterWarz.Entities.Helper;
using HamsterWarz.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HamsterWarz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly IMatchDataService _service;

        public MatchesController(IMatchDataService service)
        {
            _service = service;
        }
        //Getting all matchdata
        [HttpGet]
        public async Task<IEnumerable<MatchResultDTO>> GetAllMatches()
        {
            return await _service.GetAllHamsterMatches();
        }

        //Getting specific matchdata
        [Route("get/{id}")]
        [HttpGet]
        public async Task<MatchData> GetById(int id)
        {
            return await _service.GetMatchById(id);
        }

        //posting match data
        [Route("registermatch")]
        [HttpPost]
        public async Task<IActionResult> PostMatchData(MatchWinnersDTO obj)
        {
            if (!ModelState.IsValid)
            {
                return NotFound("No valid object");
            }
            try
            {
                await _service.RegisterMatchData(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(obj.Hamsters);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> RemoveMatchData(int id)
        {
            if(id < 1)
            {
                return BadRequest();
                
            }
            await _service.DeleteMatch(id);
            return Ok();
        }

        [Route("statistics/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetHamsterMatchData(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            var temp = await _service.GetSpecificHamsterMatchData(id);
            return Ok(temp);
        }

    }
}
