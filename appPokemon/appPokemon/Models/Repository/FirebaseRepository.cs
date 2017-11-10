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



        public async Task<bool> CrearUser(string user, string password)
        {
            if (await UserExist(user, password))
            {
                return false;
            }
            else
            {
                var firebase = new FirebaseClient("https://apppokemon-ffdfb.firebaseio.com/");

                User.User u = new User.User();
                List<User.Pokemon> listP = new List<User.Pokemon>();
                User.Pokemon pok = new User.Pokemon();
                pok.id = 1;
                pok.name = "1";
                pok.level = 1;
                pok.experience = 1;
                pok.hp = 1;
                pok.sex = false;
                pok.moves = new List<User.Move>();

                User.Move move = new User.Move();

                for (int i = 0; i < 4; i++)
                {
                    pok.moves.Add(move);
                    pok.moves[i].url = "null";
                }

                u.name = user;
                u.pass = password;
                u.pokemons = new List<User.Pokemon>();
                for (int i = 0; i < 6; i++)
                {
                    u.pokemons.Add(pok);
                }
                // add new item to list of data 
                var item = await firebase
                  .Child("users")
                  //.WithAuth("<Authentication Token>") // <-- Add Auth token if required. Auth instructions further down in readme.
                  .PostAsync(u);

                return true;
            }
        }

        public async Task<bool> UserExist(string username, string password)
        {

            var firebase = new FirebaseClient("https://apppokemon-ffdfb.firebaseio.com/");
            var items = await firebase
              .Child("users")
              //.WithAuth("<Authentication Token>") // <-- Add Auth token if required. Auth instructions further down in readme.
              .OrderByKey()
              .OnceAsync<User.User>();

            foreach (var item in items)
            {
                if (item.Object.name == username)
                {
                    return true;
                }
            }

            return false;
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
                if(item.Object.name == username && item.Object.pass == password)
                {
                    GlobalVar.entrenadorAmigo.user = item.Object;

                    // Aquí habría que poner al entrenador enemigo
                    GlobalVar.entrenadorEnemigo.user = item.Object;
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

        

        //public async Task<bool> postListPok(string usuario, List<Models.Pokemon.RootObject> listaP)
        //{
        //    var firebase = new FirebaseClient("https://apppokemon-ffdfb.firebaseio.com/");

        //    // add new item to list of data 
        //    var item = await firebase
        //      .Child("yourentity")
        //      //.WithAuth("<Authentication Token>") // <-- Add Auth token if required. Auth instructions further down in readme.
        //      .PostAsync(new YourObject());

        //    // note that there is another overload for the PostAsync method which delegates the new key generation to the client

        //    Console.WriteLine($"Key for the new item: {item.Key}");

        //    // add new item directly to the specified location (this will overwrite whatever data already exists at that location)
        //    var item = await firebase
        //      .Child("yourentity")
        //      .Child("Ricardo")
        //      //.WithAuth("<Authentication Token>") // <-- Add Auth token if required. Auth instructions further down in readme.
        //      .PutAsync(new YourObject());


        //    return false;
        //}
    }
}
