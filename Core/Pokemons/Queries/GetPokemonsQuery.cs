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
    public record GetPokemonsQuery : IRequest<IEnumerable<PokemonInfo>>
    {
        public string? PokemonType { get; set; }
        public bool Sort { get; set; }
        public SortOrder SortOrder { get; set; }
    };

    public class GetPokemonsQueryContext : IRequestHandler<GetPokemonsQuery, IEnumerable<PokemonInfo>>
    {
        private readonly IApplicationDbContext _context;

        public GetPokemonsQueryContext(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PokemonInfo>> Handle(GetPokemonsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<PokemonInfo> query = _context.Pokemons.Where(p => p.PokemonType == request.PokemonType);

            if (request.Sort)
            {
                query = request.SortOrder switch
                {
                    SortOrder.Ascending => query.OrderBy(p => p.PokemonName),
                    SortOrder.Descending => query.OrderByDescending(p => p.PokemonName),
                    _ => query
                };
            }
            return await query.ToListAsync(cancellationToken);
        }
    }
}