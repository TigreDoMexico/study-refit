using ExampleCode.Core.Pokemon.Contracts;
using ExampleCode.Core.Pokemon.HttpClient;
using ExampleCode.Core.Pokemon.HttpClient.Responses;
using Microsoft.Extensions.Logging;

namespace ExampleCode.Core.Pokemon;

public class PokemonService : IPokemonService
{
    private readonly ILogger<PokemonService> _logger;
    private readonly IPokeApi _pokeApi;

    public PokemonService(IPokeApi pokeApi, ILogger<PokemonService> logger)
        => (_pokeApi, _logger) = (pokeApi, logger);
    
    public async Task<PokeResponse> GetPokemonAsync(int number)
    {
        try
        {
            return await _pokeApi.GetPokemon(number);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error catching data from PokeAPI: {error}", ex);
            throw;
        }
    }
}