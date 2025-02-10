using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kotas.Pokemon.Infra.CrossCuttings.Configuration;

public class AppConfigurations
{
    public string ConnectionString { get; set; }
    public KotasPokemon KotasPokemon { get; set; }
}
