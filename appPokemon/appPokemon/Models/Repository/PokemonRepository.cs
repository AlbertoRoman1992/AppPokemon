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

            if (GlobalVar.countPokemonRepository == 0)
            {
                GlobalVar.countPokemonRepository += 1;

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
            for (int count = 0; count < 6; count++)
            {
                client = GetHttpClient("https://pokeapi.co/api/v2/pokemon/");

                // Agrego los pokemons del entrenador amigo
                if(GlobalVar.entrenadorAmigo.user.pokemons.Count() >= count)
                {
                    HttpResponseMessage response = client.GetAsync(GlobalVar.entrenadorAmigo.user.pokemons[count].name).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var resultContent = response.Content.ReadAsStringAsync().Result;
                        GlobalVar.entrenadorAmigo.pokemons.Add(JsonConvert.DeserializeObject<Models.Pokemon.RootObject>(resultContent));
                    }
                }

                // Agrego los pokemons del entrenador enemigo
                if (GlobalVar.entrenadorEnemigo.user.pokemons.Count() >= count)
                {
                    HttpResponseMessage response = client.GetAsync(GlobalVar.entrenadorEnemigo.user.pokemons[count].name).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var resultContent = response.Content.ReadAsStringAsync().Result;
                        GlobalVar.entrenadorEnemigo.pokemons.Add(JsonConvert.DeserializeObject<Models.Pokemon.RootObject>(resultContent));
                    }
                }
            }
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
    }
}
