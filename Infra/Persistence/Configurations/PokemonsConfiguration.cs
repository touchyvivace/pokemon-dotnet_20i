using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pokemon.Domain.Entities;

namespace Infra.Persistence.Configurations
{
    public class PokemonsConfiguration : IEntityTypeConfiguration<PokemonInfo>
    {
        public void Configure(EntityTypeBuilder<PokemonInfo> builder)
        {
           builder.HasIndex(p => p.PokemonType);
        }
    }
}