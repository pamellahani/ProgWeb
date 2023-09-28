public interface IPokemonsSources 
{
    IEnumerable<Pokemon> GetAll();

    Pokemon Add(Pokemon pokemon);

    Pokemon Remove(Pokemon pokemon);

    Pokemon? Update(int id, Pokemon pokemon);
}