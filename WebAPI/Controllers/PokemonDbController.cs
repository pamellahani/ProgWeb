using Microsoft.AspNetCore.Mvc;

namespace PokeAPIPolytech.Controllers;

[ApiController]
[Route("[controller]")]
public class PokemonsDbController : ControllerBase
{
    private readonly ILogger<PokemonsController> _logger;
    private readonly IPokemonsDbSources _pokemonsDbSources;

    public PokemonsDbController(
        ILogger<PokemonsController> logger,
        IPokemonsDbSources pokemonsDbSources)
    {
        _logger = logger;
        _pokemonsDbSources = pokemonsDbSources;
    }

    [HttpGet("Pokemons/All")]
    public IEnumerable<Pokemon> GetAllPokemons()
    {
        return _pokemonsDbSources.GetAll();
    }

    [HttpPost]
    public IActionResult AddPokemon([FromBody] CreatePokemonDto newPokemon)
    {
        if (newPokemon == null)
        {
            return BadRequest();
        }

        _pokemonsDbSources.Insert(newPokemon); 

        return Ok();
    }

    [HttpGet("{name}")]
    public IActionResult GetPokemonByName(string name)
    {
        var pokemon = _pokemonsDbSources.GetByName(name);

        if (pokemon == null)
        {
            return NotFound();
        }

        return Ok(pokemon);
    }

    [HttpGet("Abilities")]
    public IEnumerable<Ability> GetAllAbilities()
    {
        return _pokemonsDbSources.GetAllAbilities();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, CreatePokemonDto updatedPokemon)
    {
        return _pokemonsDbSources.Update(id, updatedPokemon) == null ? NotFound() : Ok(updatedPokemon); 
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        var res = _pokemonsDbSources.Delete(id); 
        return res == null ? NotFound() : Ok(res);
    }
}