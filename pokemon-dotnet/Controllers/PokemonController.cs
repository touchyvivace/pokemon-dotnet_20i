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
        [HttpPut("{pokemonId}")]
        public async Task<IActionResult> UpdatePokemon(int pokemonId, [FromBody] UpdatePokemonCommand updatePokemonCommand)
        {
            updatePokemonCommand.PokemonId = pokemonId;

            var result = await Mediator.Send(updatePokemonCommand);

            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<PokemonInfo>> CreatePokemon([FromBody] AddPokemonCommand addPokemonCommand)
        {
            var result = await Mediator.Send(addPokemonCommand);

            if (result == null)
            {
                return BadRequest("A Pokemon with the same name already exists.");
            }

            return CreatedAtAction(nameof(GetPokemonById), new { pokemonId = result.Id }, result);
        }

        [HttpDelete("{pokemonId}")]
        public async Task<IActionResult> DeletePokemon(int pokemonId)
        {
            var command = new DeletePokemonCommand { PokemonId = pokemonId };
            var success = await Mediator.Send(command);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
