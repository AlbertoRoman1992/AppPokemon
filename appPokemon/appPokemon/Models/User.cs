using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appPokemon.Models.User
{
    public class Pokemon
    {
        public int experience { get; set; }
        public int level { get; set; }
        public string name { get; set; }
        public bool sex { get; set; }
    }

    public class User
    {
        public string name { get; set; }
        public string pass { get; set; }
        public List<Pokemon> pokemons { get; set; }
    }

    public class RootObject
    {
        public List<User> users { get; set; }
    }
}
