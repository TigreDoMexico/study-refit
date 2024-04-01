using ExampleCode.Core.Pokemon.HttpClient.Responses;

namespace ExampleCode.Core.Pokemon.Contracts;

public interface IPokemonService
{
    Task<PokeResponse> GetPokemonAsync(int number);
}