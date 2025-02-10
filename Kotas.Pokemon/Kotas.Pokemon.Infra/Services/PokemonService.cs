using Kotas.Pokemon.Infra.Dtos.Pokemons;
using Kotas.Pokemon.Infra.Interfaces;
using Newtonsoft.Json;

namespace Kotas.Pokemon.Infra.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly HttpClient _httpClient;

        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PokemonDto> GetPokemon(int pokemon)
        {
            var response = await _httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon/{pokemon}");

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error ao obter os dados do pokemon {pokemon}. Status Code: {response.StatusCode}");

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var pokemonData = JsonConvert.DeserializeObject<PokemonDto>(jsonResponse);

            return pokemonData;
        }

        public async Task<List<PokemonDto>> GetEvolutions(int pokemon)
        {
            var response = await _httpClient.GetStringAsync($"https://pokeapi.co/api/v2/pokemon-species/{pokemon}/");
            var species = JsonConvert.DeserializeObject<PokemonSpeciesResponse>(response);

            var evolutions = new List<PokemonDto>();

            if (species.EvolutionChain != null)
            {
                var evolutionResponse = await _httpClient.GetStringAsync(species.EvolutionChain.Url);
                var evolutionChain = JsonConvert.DeserializeObject<EvolutionChainResponse>(evolutionResponse);

                var evolutionList = ExtractEvolutions(evolutionChain);
                foreach (var evolution in evolutionList)
                {
                    evolutions.Add(await GetPokemon(evolution.Id));
                }
            }

            return evolutions;
        }

        private List<Evolution> ExtractEvolutions(EvolutionChainResponse chain)
        {
            var evolutions = new List<Evolution>();
            var current = chain.Chain;

            while (current != null)
            {
                evolutions.Add(new Evolution { Id = current.Species.Id });
                current = current.EvolvesTo?.FirstOrDefault();
            }

            return evolutions;
        }
    }
}
