using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appPokemon.Models.User
{

    public class Move
    {
        public string url { get; set; }
    }

    public class Pokemon
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Move> moves { get; set; }
        public int level { get; set; }
        public int experience { get; set; }
        public bool sex { get; set; }
        public int hp { get; set; }
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
