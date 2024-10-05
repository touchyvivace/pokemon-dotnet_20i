using Pokemon.Models;
using Microsoft.EntityFrameworkCore;

namespace Pokemon.Data {
    public class ApiContext : DbContext {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options) {
        }

        public DbSet<PokemonInfo> Pokemon { get; set; } = null!;
    }
}