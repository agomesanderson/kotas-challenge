namespace Kotas.Pokemon.Infra.Dtos.Pokemons;

public class PokemonDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int BaseExperience { get; set; }
    public int Height { get; set; }
    public bool IsDefault { get; set; }
    public int Order { get; set; }
    public int Weight { get; set; }
    public SpriteDto Sprites { get; set; }
}

public class PokemonSpeciesResponse
{
    public EvolutionChain EvolutionChain { get; set; }
}

public class EvolutionChain
{
    public string Url { get; set; }
}

public class EvolutionChainResponse
{
    public EvolutionChainData Chain { get; set; }
}

public class EvolutionChainData
{
    public Species Species { get; set; }
    public List<EvolutionChainData> EvolvesTo { get; set; }
}

public class Species
{
    public int Id { get; set; }
}

public class Evolution
{
    public int Id { get; set; }
}

public class SpriteDto
{
    public string BackDefault { get; set; }
    public string BackShiny { get; set; }
    public string FrontDefault { get; set; }
    public string FrontShiny { get; set; }
    public OtherSpriteDto Other { get; set; }
}

public class OtherSpriteDto
{
    public DreamWorldSpriteDto DreamWorld { get; set; }
    public HomeSpriteDto Home { get; set; }
    public OfficialArtworkSpriteDto OfficialArtwork { get; set; }
    public ShowdownSpriteDto Showdown { get; set; }
}

public class DreamWorldSpriteDto
{
    public string FrontDefault { get; set; }
    public string FrontFemale { get; set; }
}

public class HomeSpriteDto
{
    public string FrontDefault { get; set; }
    public string FrontShiny { get; set; }
}

public class OfficialArtworkSpriteDto
{
    public string FrontDefault { get; set; }
    public string FrontShiny { get; set; }
}

public class ShowdownSpriteDto
{
    public string FrontDefault { get; set; }
    public string FrontShiny { get; set; }
    public string BackDefault { get; set; }
    public string BackShiny { get; set; }
}