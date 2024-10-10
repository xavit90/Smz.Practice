using System.Text.Json;

namespace Smz.Practice.TestHost;

interface ITest
{
    void Run(string message);
    Task InvokeEndpointAsync(EndpointType endpointType);
}

class Test(HttpClient client) : ITest
{
    private readonly HttpClient client = client;

    public async Task InvokeEndpointAsync(EndpointType endpointType)
    {
        string endpoint = endpointType switch {
            EndpointType.Pokemon => "api/v2/pokemon/72",
            EndpointType.Species => "api/v2/pokemon-species/17",
            EndpointType.Ability => "api/v2/ability/10",
            _ => "unknown"
        };

        var result = await client.GetAsync(endpoint);
        Pokemon pokemon = JsonSerializer.Deserialize<Pokemon>(await result.Content.ReadAsStringAsync()) ?? new(0,string.Empty);
        Console.WriteLine($"Id: {pokemon.id}\nName: {pokemon.name}");
        // var (id, name) = pokemon;
        // Console.WriteLine($"Id: {id}\nName: {name}");
    }

    public void Run(string message)
    {
        Console.WriteLine(message);
    }
}

record Pokemon(int id, string name);

enum EndpointType 
{
    Pokemon,
    Species,
    Ability
}