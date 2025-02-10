using Kotas.Pokemon.Domain.Filters.Common;
using Microsoft.AspNetCore.Mvc;

namespace Kotas.Pokemon.Domain.Filters;

[BindProperties]
public class PokemonFilter : PagedFilter
{
    
}
