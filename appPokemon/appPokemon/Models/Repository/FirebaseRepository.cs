using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Xamarin;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;
using appPokemon.Models.User;

namespace appPokemon.Models.Repository
{
    class FirebaseRepository
    {
        public async Task<bool> Login(string user, string pass)
        {
            var firebase = new FirebaseClient("https://apppokemon-ffdfb.firebaseio.com/");
            var items = await firebase.Child("Users").OnceAsync<Models.User.User>();


              //.WithAuth("<Authentication Token>") // <-- Add Auth token if required. Auth instructions further down in readme.
              //.OrderByKey()
              //.LimitToFirst(2)
              //.OnceAsync<RootObject>();


            foreach (var item in items)
            {
                if (user == item.Object.name && pass == item.Object.pass)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
