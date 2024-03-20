using ExampleCode.Core.Pokemon.HttpClient.Responses;
using Refit;

namespace ExampleCode.Core.Pokemon.HttpClient;

public interface IPokeApi
{
    [Get("/pokemon/{id}")]
    Task<PokeResponse> GetPokemon(int id);
}