using Kotas.Pokemon.Domain.Commands.Input.Pokemons;
using Kotas.Pokemon.Domain.Filters;
using Kotas.Pokemon.Domain.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Kotas.Pokemon.Controllers.Domain;

[ApiVersion("1.0")]
[Route("pokemons")]
public class PokemonController : BaseController
{
    private readonly PokemonHandler _handler;

    public PokemonController(PokemonHandler handler)
    {
        _handler = handler;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var result = await _handler.Handle(id);
        return CustomResponse(new { result.Data });
    }

    [HttpGet("random")]
    public async Task<IActionResult> GetRandom()
    {
        var result = await _handler.Handle();
        return CustomResponse(new { result.Data });
    }

    [HttpGet("all-catch")]
    public async Task<IActionResult> GetAll([FromQuery] PokemonFilter pokemonFilter)
    {
        var result = await _handler.Handle(pokemonFilter);
        return CustomResponse(new { result.Data });
    }

    [HttpPost("catched")]
    public async Task<IActionResult> Post(CreateCatchPokemonCommand command)
    {
        var result = await _handler.Handle(command);
        return CustomResponse(result);
    }
}
