using AutoBogus;
using ExampleCode.Core.Pokemon;
using ExampleCode.Core.Pokemon.HttpClient;
using ExampleCode.Core.Pokemon.HttpClient.Responses;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace ExampleCode.Core.Tests.Pokemon;

public class PokemonServiceTests
{
    private readonly IPokeApi _pokeApi = Substitute.For<IPokeApi>();
    private readonly ILogger<PokemonService> _logger = Substitute.For<ILogger<PokemonService>>();
    
    [Fact]
    public async Task When_GetPokemon_ShouldCallOnceRefitApi()
    {
        var apiResponse = new AutoFaker<PokeResponse>().Generate();
        var pokeId = apiResponse.Id;
        _pokeApi.GetPokemon(Arg.Any<int>()).Returns(Task.FromResult(apiResponse));

        var service = new PokemonService(_pokeApi, _logger);
        await service.GetPokemonAsync(pokeId);

        await _pokeApi.Received(1).GetPokemon(Arg.Is(pokeId));
    }
    
    [Fact]
    public async Task When_FailInRefitApi_ShouldThrowException()
    {
        var exception = new AutoFaker<Exception>().Generate();
        _pokeApi.GetPokemon(Arg.Any<int>()).ThrowsAsync(exception);

        var service = new PokemonService(_pokeApi, _logger);
        var action = async () => await service.GetPokemonAsync(10);

        await action.Should().ThrowAsync<Exception>();
    }
}