using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pokemon.Core.Common.Interfaces;
using Pokemon.Domain.Entities;

namespace Core.Pokemons.Queries
{
    public record AddPokemonCommand : IRequest<PokemonInfo>
    {
        [JsonIgnore]
        public int PokemonId { get; set; }
        public string PokemonName { get; set; }
        public string PokemonType { get; set; }
        public int Speed { get; set; }
        public bool Shiny { get; set; }
    };

    public class AddPokemonCommandContext : IRequestHandler<AddPokemonCommand, PokemonInfo>
    {
        private readonly IApplicationDbContext _context;

        public AddPokemonCommandContext(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PokemonInfo> Handle(AddPokemonCommand request, CancellationToken cancellationToken)
        {
            bool exists = await _context.Pokemons
      .AnyAsync(p => p.PokemonName == request.PokemonName, cancellationToken);

            if (exists)
            {
                // Return null or throw a custom exception to indicate a duplicate
                return null;
                // Alternatively, you can throw an exception:
                // throw new DuplicatePokemonException("A Pokémon with the same name already exists.");
            }
            try
            {


                var pokemonInfo = new PokemonInfo
                {
                    PokemonName = request.PokemonName,
                    PokemonType = request.PokemonType,
                    Speed = request.Speed,
                    Shiny = request.Shiny
                };
                _context.Pokemons.Add(pokemonInfo);
                await _context.SaveChangesAsync(cancellationToken);
                return pokemonInfo;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
    }
}