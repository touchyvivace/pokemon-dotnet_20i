
using Pokemon.Core.Common.Interfaces;

namespace BizViewV6Api.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
