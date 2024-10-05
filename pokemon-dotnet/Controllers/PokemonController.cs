using Core.Pokemons.Queries;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Domain.Entities;

namespace Pokemon.Controllers {
    public class PokemonController : ApiControllerBase {

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<PokemonInfo>> GetAllPokemons([FromQuery] GetPokemonsQuery pokemonsQuery) 
        {
            return await Mediator.Send(pokemonsQuery);
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
