using Microsoft.AspNetCore.Mvc;

namespace Kotas.Pokemon.Domain.Filters.Common;

[BindProperties]
public class PagedFilter
{
    public int ActualPage { get; set; } = 0;
    public int QuantityByPage { get; set; } = 10;
    public string Filter { get; set; } = string.Empty;
}
