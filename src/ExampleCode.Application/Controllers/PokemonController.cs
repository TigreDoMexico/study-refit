using ExampleCode.Application.Dto;
using ExampleCode.Core.Pokemon.HttpClient;
using Microsoft.AspNetCore.Mvc;

namespace ExampleCode.Application.Controllers;
    
[ApiController]
[Route("api/pokemon")]
public class PokemonController : ControllerBase
{
    private readonly ILogger<PokemonController> _logger;
    private readonly IPokeApi _pokeApi;

    public PokemonController(IPokeApi pokeApi, ILogger<PokemonController> logger)
        => (_pokeApi, _logger) = (pokeApi, logger);

    [HttpGet("{id}")]
    public async Task<PokemonDto> Get(int id)
    {
        var pokemonResponse = await _pokeApi.GetPokemon(id);
        return new(pokemonResponse.Id.ToString(), pokemonResponse.Name);
    }
}
