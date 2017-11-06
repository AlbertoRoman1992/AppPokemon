using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

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

        public Models.Pokemon.RootObject ObtenerPokemon(string id)
        {
            client = GetHttpClient("https://pokeapi.co/api/v2/pokemon/");

            HttpResponseMessage response = client.GetAsync(id).Result;

            if (response.IsSuccessStatusCode)
            {
                var resultContent = response.Content.ReadAsStringAsync().Result;
                Models.Pokemon.RootObject pokemon = JsonConvert.DeserializeObject<Models.Pokemon.RootObject>(resultContent);
                return pokemon;
            }

            return null;
        }

        public bool ObtenerLogin(string username, string password)
        {
            client = GetHttpClient("https://apppokemon-ffdfb.firebaseio.com/");

            HttpResponseMessage response = client.GetAsync(".json").Result;

            if (response.IsSuccessStatusCode)
            {
                var resultContent = response.Content.ReadAsStringAsync().Result;
                Models.User.RootObject user = JsonConvert.DeserializeObject<Models.User.RootObject>(resultContent);
                foreach (var ser in user.users)
                {
                    if(ser.name == username && ser.pass == password)
                    {
                        return true;
                    }
                }
                return false;
            }

            return false;
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
