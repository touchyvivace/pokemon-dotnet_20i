
using Pokemon.Core.Common.Interfaces;

namespace Pokemon.Infra.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
