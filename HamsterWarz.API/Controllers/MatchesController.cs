using HamsterWarz.API.Data.Interfaces;
using HamsterWarz.API.Helper;
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
        
        [Route("registermatch")]
        [HttpPost]
        public async Task<IActionResult> PostMatchData(TransferObject obj)
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
    }
}
