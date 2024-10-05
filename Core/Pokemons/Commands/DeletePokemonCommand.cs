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
    public record DeletePokemonCommand : IRequest<bool>
    {
        public int PokemonId { get; set; }
    };

    public class DeletePokemonCommandContext : IRequestHandler<DeletePokemonCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeletePokemonCommandContext(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeletePokemonCommand request, CancellationToken cancellationToken)
        {

            var entity = await _context.Pokemons.Where(p => p.Id == request.PokemonId).FirstOrDefaultAsync();
            if (entity == null)
            {
                return false;
            }
            _context.Pokemons.Remove(entity);
            var ret = await _context.SaveChangesAsync(cancellationToken);
            return ret <= 0 ? false : true;
        }
    }
}