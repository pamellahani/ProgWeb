using Microsoft.EntityFrameworkCore;

public class PokemonsDbSources : IPokemonsDbSources
{
    private readonly PokemonContext _dbContext;

    public PokemonsDbSources(
        PokemonContext context
    )
    {
        this._dbContext = context;
    }

   public IEnumerable<Pokemon> GetAll()
{
    return this._dbContext.Pokemons
        .Include(pokemon => pokemon.Abilities)
        .ToList();
}

public IEnumerable<Ability> GetAllAbilities()
{
    return this._dbContext.Abilities
        .Include(ability => ability.Pokemons)
        .ToList();
}

public Pokemon GetByName(string name)
{
    return this._dbContext.Pokemons
        .Include(pokemon => pokemon.Abilities)
        .FirstOrDefault(pokemon => pokemon.Name.Equals(name));
}
public Pokemon Insert(CreatePokemonDto dto)
{
    var pokemon = new Pokemon
    {
        Id = dto.Id,
        Name = dto.Name,
        Description = dto.Description,
        PictureUrl = dto.PictureUrl,
        Type = dto.Type
    };

    this._dbContext.Pokemons
        .Add(pokemon);

    this._dbContext.SaveChanges();

    return pokemon;
}

/*
EF Core réalise une liaison un-à-plusieurs entre les entités Pokemons et Abilities, où un Pokemon 
peut avoir une seule Ability, mais une Ability peut être associée à plusieurs Pokemons.
*/

public Pokemon Update(int id, CreatePokemonDto dto)
{
    var pokemon = _dbContext.Pokemons.FirstOrDefault(pok=>pok.Id == id);
    pokemon.Name = dto.Name;
    pokemon.Description=dto.Description;    
    pokemon.Type = dto.Type;
    pokemon.PictureUrl=dto.PictureUrl;
    this._dbContext.Update(pokemon);
    this._dbContext.SaveChanges();
    return pokemon; 
}

public Pokemon? Delete(int id)
{
    Pokemon? pok = _dbContext.Pokemons.FirstOrDefault(pok=>pok.Id == id); 
    if (pok!=null){
        this._dbContext.Remove(pok);
        this._dbContext.SaveChanges();
    }
    return pok; 
}

}