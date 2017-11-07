using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appPokemon.Models
{
    public class Entrenador
    {
        public User.User user { get; set; }

        public List<Pokemon.RootObject> pokemons { get; set; }
    }
}
