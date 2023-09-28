public interface IPokemonsDbSources
{
    IEnumerable<Pokemon> GetAll();
    public Pokemon Insert(CreatePokemonDto dto);
    public Pokemon GetByName(string name); 
    public IEnumerable<Ability> GetAllAbilities();
    public Pokemon Update(int id, CreatePokemonDto dto);
    public Pokemon? Delete(int id);  
}