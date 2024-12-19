using MediatR;
using Microsoft.AspNetCore.Mvc;
using NoobGGApp.Application.Features.GameRegions.Queries.GetAll;

namespace NoobGGApp.WebApi.Controllers
{
    [Route("api/gameregions")]
    [ApiController]
    public class GameRegionsController : ControllerBase
    {
        private readonly ISender _mediatr;

        public GameRegionsController(ISender mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<ActionResult<List<GameRegionGetAllDto>>> GetAllAsync(long gameId, string? name, string? code, CancellationToken cancellationToken)
        {
            return Ok(await _mediatr.Send(new GetAllGameRegionsQuery(gameId, name, code), cancellationToken));
        }
    }
}
