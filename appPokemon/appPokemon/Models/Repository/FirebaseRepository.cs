using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Xamarin;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;
using appPokemon.Models.User;
using System.Net.Http;
using ModernHttpClient;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace appPokemon.Models.Repository
{
    class FirebaseRepository
    {
        HttpClient client;

        public FirebaseRepository()
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

        // El método del login devuelve la lista del usuario porque guardo los datos para saber si el usuario es la primera vez que inicia o no
        public async Task<List<User.Pokemon>> Login(string username, string password)
        {

            var firebase = new FirebaseClient("https://apppokemon-ffdfb.firebaseio.com/");
            var items = await firebase
              .Child("users")
              //.WithAuth("<Authentication Token>") // <-- Add Auth token if required. Auth instructions further down in readme.
              .OrderByKey()
              .OnceAsync<User.User>();

            foreach (var item in items)
            {
                if (item.Object.name == username && item.Object.pass == password)
                {
                    GlobalVar.friendCoach.user = item.Object;

                    // Aquí habría que poner al entrenador enemigo
                    GlobalVar.enemyCoach.user = item.Object;
                    return item.Object.pokemons;
                }
            }

            return null;

            //client = GetHttpClient("https://apppokemon-ffdfb.firebaseio.com/");

            //HttpResponseMessage response = client.GetAsync(".json").Result;

            //if (response.IsSuccessStatusCode)
            //{
            //    var resultContent = response.Content.ReadAsStringAsync().Result;
            //    Models.User.RootObject user = JsonConvert.DeserializeObject<Models.User.RootObject>(resultContent);
            //    foreach (var ser in user.users)
            //    {
            //        if (ser.name == username && ser.pass == password)
            //        {
            //            GlobalVar.entrenadorAmigo.user = user.users.First();

            //            // Aquí habría que poner al entrenador enemigo
            //            GlobalVar.entrenadorEnemigo.user = user.users.First();

            //            return ser.pokemons;
            //        }
            //    }
            //}
        }
    }
}
