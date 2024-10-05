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
    public record UpdatePokemonCommand : IRequest<PokemonInfo>
    {
        [JsonIgnore]
        public int PokemonId { get; set; }
        public string PokemonName { get; set; }
        public string PokemonType { get; set; }
        public int Speed { get; set; }
        public bool Shiny { get; set; }
    };

    public class UpdatePokemonCommandContext : IRequestHandler<UpdatePokemonCommand, PokemonInfo>
    {
        private readonly IApplicationDbContext _context;

        public UpdatePokemonCommandContext(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PokemonInfo> Handle(UpdatePokemonCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Pokemons.Where(p => p.Id == request.PokemonId).FirstOrDefaultAsync();
            if (entity == null)
            {
                return null;
            }
            entity.PokemonName = request.PokemonName;
            entity.PokemonType = request.PokemonType;
            entity.Speed = request.Speed;
            entity.Shiny = request.Shiny;
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}