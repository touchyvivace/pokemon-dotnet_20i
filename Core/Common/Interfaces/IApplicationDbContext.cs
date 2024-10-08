﻿using System.Data;
using Pokemon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Pokemon.Core.Common.Interfaces;

public interface IApplicationDbContext
{
         DbSet<PokemonInfo> Pokemons {get;}
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

   
}
