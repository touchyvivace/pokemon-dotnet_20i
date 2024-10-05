using System.ComponentModel.DataAnnotations;

namespace Pokemon.Domain.Entities;
public class PokemonInfo : BaseAuditableEntity
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name field is required PokemonName!")]
    public string PokemonName { get; set; }

    [Required(ErrorMessage = "Name field is required PokemonType!")]
    public string PokemonType { get; set; }

    [Required(ErrorMessage = "Name field is required Speed!")]
    [Range(0, 9999, ErrorMessage = "Type formatting is wrong number")]
    public int Speed { get; set; }

    public bool Shiny { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
