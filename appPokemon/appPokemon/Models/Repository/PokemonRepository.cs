using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using appPokemon.Models;

namespace appPokemon.Models.Repository
{
    class PokemonRepository
    {
        HttpClient client;

        public PokemonRepository()
        {
            client = new HttpClient();

            if (GlobalVar.countPokemonRepository == false)
            {
                GlobalVar.countPokemonRepository = true;

                GlobalVar.entrenadorAmigo.pokemons = new List<Pokemon.RootObject>();
                GlobalVar.entrenadorEnemigo.pokemons = new List<Pokemon.RootObject>();
            }
        }

        private HttpClient GetHttpClient(string url)
        {
            var httpClient = new HttpClient(new NativeMessageHandler())
            {
                BaseAddress = new Uri(url)
            };

            httpClient.DefaultRequestHeaders.Accept.Clear();

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }

        public void CargarPokemons()
        {
            for (int count = 1; count < 6; count++)
            {
                
                // Agrego los pokemons del entrenador amigo
                if (GlobalVar.entrenadorAmigo.user.pokemons.Count() >= count)
                {
                    GlobalVar.entrenadorAmigo.pokemons.Add(ObtenerPokemon(GlobalVar.entrenadorAmigo.user.pokemons[count].name));
                }

                // Agrego los pokemons del entrenador enemigo
                if (GlobalVar.entrenadorEnemigo.user.pokemons.Count() >= count)
                {
                    GlobalVar.entrenadorEnemigo.pokemons.Add(ObtenerPokemon(GlobalVar.entrenadorEnemigo.user.pokemons[count].name));
                }
            }
        }

        public Models.Pokemon.RootObject ObtenerPokemon(string id)
        {
            client = GetHttpClient("https://pokeapi.co/api/v2/pokemon/");

            HttpResponseMessage response = client.GetAsync(id).Result;

            if (response.IsSuccessStatusCode)
            {
                var resultContent = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Models.Pokemon.RootObject>(resultContent);
            }

            return null;
        }

        public Stat.RootObject ObtenerStat(string url)
        {
            client = GetHttpClient(url);

            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var resultContent = response.Content.ReadAsStringAsync().Result;
                Stat.RootObject respuesta = JsonConvert.DeserializeObject<Stat.RootObject>(resultContent);
                return respuesta;
            }

            return null;
        }

        public Ability.RootObject ObtenerAbility(string url)
        {
            client = GetHttpClient(url);

            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var resultContent = response.Content.ReadAsStringAsync().Result;
                Ability.RootObject respuesta = JsonConvert.DeserializeObject<Ability.RootObject>(resultContent);
                return respuesta;
            }

            return null;
        }

        public List<Models.ListaPokemon.Result> ObtenerLista()
        {
            string url = "https://pokeapi.co/api/v2/pokemon/?limit=802";
            client = GetHttpClient(url);

            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var resultContent = response.Content.ReadAsStringAsync().Result;
                Models.ListaPokemon.RootObject respuesta = JsonConvert.DeserializeObject<Models.ListaPokemon.RootObject>(resultContent);
                return respuesta.results;
            }
            return null;
        }
    }
}
