using MediatR;
using Microsoft.AspNetCore.Mvc;
using NoobGGApp.Application.Features.Games.Queries.GetAllDapper;

namespace NoobGGApp.WebApi.Controllers
{
    public class GamesController : ApiControllerBase
    {
        public GamesController(ISender mediator) : base(mediator)
        {
        }

        [HttpGet]               // api/games?pageNumber=3&
        // public async Task<IActionResult> GetAllAsync(string searchKeyword = "", int pageNumber = 1, int pageSize = 10, bool isAscending = true, CancellationToken cancellationToken=default)
        public async Task<IActionResult> GetAllAsync([FromQuery] GetAllGamesDapperQuery query, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }
    }
}
