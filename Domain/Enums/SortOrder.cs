using System.Runtime.Serialization;

namespace Domain.Enums
{
    public enum SortOrder
    {
        [EnumMember(Value = "asc")]
        Ascending,
        [EnumMember(Value = "desc")]
        Descending
    }
}