using CsvHelper.Configuration;
using Pokemon.Domain.Entities;

public class PokemonRecordMap : ClassMap<PokemonInfo>
{
    public PokemonRecordMap()
    {
        Map(m => m.PokemonName).Index(1);
        Map(m => m.PokemonType).Index(2);
        Map(m => m.Speed).Index(3);
        Map(m => m.Shiny).Index(4);
    }
}
