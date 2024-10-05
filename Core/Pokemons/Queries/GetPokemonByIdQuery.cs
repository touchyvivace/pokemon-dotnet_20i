using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pokemon.Core.Common.Interfaces;
using Pokemon.Domain.Entities;

namespace Core.Pokemons.Queries
{
    public record GetPokemonByIdQuery : IRequest<PokemonInfo>
    {
        public int Id { get; set; }
    };

    public class GetPokemonByIdQueryContext : IRequestHandler<GetPokemonByIdQuery, PokemonInfo>
    {
        private readonly IApplicationDbContext _context;

        public GetPokemonByIdQueryContext(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PokemonInfo> Handle(GetPokemonByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Pokemons.Where(p => p.Id == request.Id).FirstOrDefaultAsync();
            return result;
        }
    }
}