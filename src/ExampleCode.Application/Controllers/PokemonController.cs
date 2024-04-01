using ExampleCode.Application.Dto;
using ExampleCode.Core.Pokemon.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ExampleCode.Application.Controllers;
    
[ApiController]
[Route("api/pokemon")]
public class PokemonController : ControllerBase
{
    private readonly ILogger<PokemonController> _logger;
    private readonly IPokemonService _pokemonService;

    public PokemonController(IPokemonService pokemonService, ILogger<PokemonController> logger)
        => (_pokemonService, _logger) = (pokemonService, logger);

    [HttpGet("{id}")]
    public async Task<PokemonDto> Get(int id)
    {
        var pokemonResponse = await _pokemonService.GetPokemonAsync(id);
        return new(pokemonResponse.Id.ToString(), pokemonResponse.Name);
    }
}
