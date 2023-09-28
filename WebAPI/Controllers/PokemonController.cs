using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class PokemonsController : ControllerBase
{
    private readonly ILogger<PokemonsController> _logger;

    private readonly IPokemonsSources _pokemonsSources; //à ajouter

    public PokemonsController(
        ILogger<PokemonsController> logger,
        IPokemonsSources pokemonsSources)
    {
        _logger = logger;
        _pokemonsSources = pokemonsSources;
    }


[HttpGet("{id}")]
public IActionResult GetPokemonById(int id)
{
    var pokemon = _pokemonsSources.GetAll().FirstOrDefault(pok => pok.Id == id);

    return pokemon == default
    ? NotFound()
    : Ok(pokemon);
}

    [HttpGet("All")]
    public IEnumerable<Pokemon> GetAllPokemons()
    {
        return _pokemonsSources.GetAll();
    }

[HttpPost]
public Pokemon CreatePokemon(CreatePokemonDto createPokemonDto)
{
    var pokemon = new Pokemon
    {
        Id = createPokemonDto.Id,
        Name = createPokemonDto.Name,
        Description = createPokemonDto.Description,
        PictureUrl = createPokemonDto.PictureUrl,
        Type = createPokemonDto.Type
    };

    _pokemonsSources.Add(pokemon);

    return pokemon;
}

[HttpPut("{pokemonId}")]
public IActionResult UpdatePokemon(int pokemonId, UpdatePokemonDto updatePokemonDto)
{   
    var pokemon = new Pokemon
    {   
        Id = pokemonId,
        Name = updatePokemonDto.Name,
        Description = updatePokemonDto.Description,
        PictureUrl = updatePokemonDto.PictureUrl,
        Type = updatePokemonDto.Type
    };

    return _pokemonsSources.Update(pokemonId, pokemon)==null
    ? NotFound()
    : Ok(pokemon);
}

[HttpDelete("pokemonId")]
public IActionResult DeletePokemon(int pokemonId)
{
    var pokemon = _pokemonsSources.GetAll().FirstOrDefault(pok => pok.Id == pokemonId);
    if (pokemon == null)
    {
        return BadRequest();
    }
    else{
        _pokemonsSources.Remove(pokemon);
        return Ok();
    }
    }


}