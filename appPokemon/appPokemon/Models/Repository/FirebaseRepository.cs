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

            if (GlobalVar.countFirebaseRepository == false)
            {
                GlobalVar.countFirebaseRepository = true;

                GlobalVar.entrenadorAmigo = new Entrenador();
                GlobalVar.entrenadorEnemigo = new Entrenador();
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

        public bool Login(string username, string password)
        {
            client = GetHttpClient("https://apppokemon-ffdfb.firebaseio.com/");

            HttpResponseMessage response = client.GetAsync(".json").Result;

            if (response.IsSuccessStatusCode)
            {
                var resultContent = response.Content.ReadAsStringAsync().Result;
                Models.User.RootObject user = JsonConvert.DeserializeObject<Models.User.RootObject>(resultContent);
                foreach (var ser in user.users)
                {
                    if (ser.name == username && ser.pass == password)
                    {
                        GlobalVar.entrenadorAmigo.user = user.users.First();

                        // Aquí habría que poner al entrenador enemigo
                        GlobalVar.entrenadorEnemigo.user = user.users.First();

                        return true;
                    }
                }
            }

            return false;
        }
    }
}
