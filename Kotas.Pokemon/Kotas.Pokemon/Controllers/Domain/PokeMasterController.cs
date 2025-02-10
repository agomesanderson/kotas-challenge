using Kotas.Pokemon.Domain.Commands.Input.PokeMasters;
using Kotas.Pokemon.Domain.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Kotas.Pokemon.Controllers.Domain;

[ApiVersion("1.0")]
[Route("poke-masters")]
public class PokeMasterController : BaseController
{
    private readonly PokeMasterHandler _handler;

    public PokeMasterController(PokeMasterHandler handler)
    {
        _handler = handler;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var result = await _handler.Handle(id);
        return CustomResponse(new { result.Data });
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreatePokeMasterCommand command)
    {
        var result = await _handler.Handle(command);
        return CustomResponse(result);
    }
}
