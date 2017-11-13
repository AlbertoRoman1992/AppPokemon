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
                if (GlobalVar.friendCoach.user.pokemons.Count() >= count)
                {
                    GlobalVar.friendCoach.pokemons.Add(ObtenerPokemon(GlobalVar.friendCoach.user.pokemons[count].name));
                }

                // Agrego los pokemons del entrenador enemigo
                if (GlobalVar.enemyCoach.user.pokemons.Count() >= count)
                {
                    GlobalVar.enemyCoach.pokemons.Add(ObtenerPokemon(GlobalVar.enemyCoach.user.pokemons[count].name));
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

        public Move.RootObject ObtenerMove(string url)
        {
            client = GetHttpClient(url);

            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var resultContent = response.Content.ReadAsStringAsync().Result;
                Move.RootObject respuesta = JsonConvert.DeserializeObject<Move.RootObject>(resultContent);
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
