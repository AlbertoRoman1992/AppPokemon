using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appPokemon.Models.User
{
    public class User
        {
            public string level { get; set; }
            public string name { get; set; }
            public string pass { get; set; }
            public string pokemon { get; set; }
        }

        public class RootObject
        {
            public List<User> users { get; set; }
        }
}
