using Core.Pokemons.Queries;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Domain.Entities;

namespace Pokemon.Controllers
{
    public class PokemonController : ApiControllerBase
    {

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<PokemonInfo>> GetAllPokemons([FromQuery] GetPokemonsQuery pokemonsQuery)
        {
            return await Mediator.Send(pokemonsQuery);
        }
        [HttpGet("{pokemonId}")]
        public async Task<ActionResult<PokemonInfo>> GetPokemonById(int pokemonId)
        {
            var query = new GetPokemonByIdQuery { Id = pokemonId };
            var result = await Mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpPut]
        [Route("{pokemonId}")]
        public async Task<IActionResult> UpdatePokemon()
        {

            return Ok();
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<PokemonInfo>> CreatePokemon()
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{pokemonId}")]
        public async Task<IActionResult> DeletePokemon()
        {

            return Ok();
        }
    }
}
