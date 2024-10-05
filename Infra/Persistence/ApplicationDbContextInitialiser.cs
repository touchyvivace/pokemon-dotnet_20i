using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Pokemon.Domain.Entities;

namespace Infra.Persistence
{

    public class ApplicationDbContextInitialiser
    {
        private readonly ILogger<ApplicationDbContextInitialiser> _logger;
        private readonly IConfiguration _config;

        private readonly ApplicationDbContext _context;
        public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger,
         ApplicationDbContext context,
         IConfiguration config
         )
        {
            _logger = logger;
            _context = context;
            _config = config;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                // if (_context.Database.IsSqlServer())
                if (_context.Database.IsNpgsql())
                
                {
                    await _context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }
        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }
        public async Task TrySeedAsync()
        {
            try
            {
                string seedFile = _config["SeedFile"].ToString() ?? string.Empty;
                await SeedDataAsync<PokemonInfo>(seedFile);
            }
            catch (Exception ex)
            {
                _logger.LogError("Seed failed {ex}", ex.Message);
            }
        }
        public async Task SeedDataAsync<T>(string filePath) where T : class
        {
            try
            {
                if (!_context.Set<T>().Any())
                {

                    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HasHeaderRecord = true,
                    };

                    using var reader = new StreamReader(filePath);
                    using var csv = new CsvReader(reader, config);
                    RegisterCsvClassMap(csv);
                    var records = csv.GetRecords<T>().ToList();
                    if (records.Any())
                    {
                        try
                        {
                            await _context.Set<T>().AddRangeAsync(records);
                            await _context.SaveChangesAsync();
                        }
                        catch (Exception ex)
                        {
                            if (ex.InnerException != null)
                            {
                                Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Seed: {ex.Message}");

            }
        }

        private static void RegisterCsvClassMap(CsvReader csv)
        {
            csv.Context.RegisterClassMap<PokemonRecordMap>();
        }
    }
}