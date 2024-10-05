using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SortOrder
    {
        [EnumMember(Value = "asc")]
         [Display(Name = "Ascending Order", Description = "Sorts the results in ascending order.")]
        Ascending ,
        [EnumMember(Value = "desc")]
           [Display(Name = "Descending Order", Description = "Sorts the results in descending order.")]
        Descending
    }
}