using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class PokemonsTypeController : ControllerBase
{
    private readonly ILogger<PokemonsTypeController> _logger;

    private IEnumerable<Pokemon> PokemonsType = new List<Pokemon>
    {
        new Pokemon{
            Id = 1,
            Name = "Bulbasaur",
            Description = "A strange seed was planted on its back at birth. The plant sprouts and grows with this POKéMON.",
            Type = PokemonType.Grass,
            PictureUrl = "https://img.pokemondb.net/artwork/large/bulbasaur.jpg"
        },
        new Pokemon{
                Id = 4,
                Name = "Charmander",
                Description = "Obviously prefers hot places. When it rains, steam is said to spout from the tip of its tail.",
                Type = PokemonType.Fire,
                PictureUrl = "https://img.pokemondb.net/artwork/large/charmander.jpg"
        },
        new Pokemon{
                Id = 7,
                Name = "Squirtle",
                Description = "After birth, its back swells and hardens into a shell. Powerfully sprays foam from its mouth.",
                Type = PokemonType.Water,
                PictureUrl = "https://img.pokemondb.net/artwork/large/squirtle.jpg"
        }
    };

    public PokemonsTypeController(ILogger<PokemonsTypeController> logger)
    {
        _logger = logger;
    }
[HttpGet("{type}")]
public IActionResult GetPokemonByType(PokemonType type)
{
    var pokemon = PokemonsType.FirstOrDefault(pok => pok.Type == type);

    return pokemon == default
    ? NotFound()
    : Ok(pokemon);
}

}