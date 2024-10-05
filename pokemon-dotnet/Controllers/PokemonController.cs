using Pokemon.Data;
using Pokemon.Models;
using Microsoft.AspNetCore.Mvc;

namespace Pokemon.Controllers {
    [ApiController]
    [Route("api/pokemon")]
    public class PokemonController : ControllerBase {
        private readonly ApiContext _context;

        public PokemonController(ApiContext context) {
            _context = context;
        }
        
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllPokemons()
        {

            return Ok("");
        }

        [HttpGet]
        [Route("{pokemonId}")]
        public async Task<IActionResult> GetPokemonById() {
            
            return Ok();
        }
        
        [HttpPut]
        [Route("{pokemonId}")]
        public async Task<IActionResult> UpdatePokemon() {
            
            return Ok();
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<PokemonInfo>> CreatePokemon() {
            return Ok();
        }

        [HttpDelete]
        [Route("{pokemonId}")]
        public async Task<IActionResult> DeletePokemon() {
            
            return Ok();
        }
    }
}
