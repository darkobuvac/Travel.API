using Microsoft.AspNetCore.Mvc;
using Travel.API.Contracts;

namespace Travel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        private readonly IDestinationRepository _repository;

        public DestinationController(IDestinationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var result = await _repository.GetByConditionAsync(x => x.Id == id);

            if (result is not null)
            {
                return Ok(result);
            }

            return NoContent();
        }
    }
}
