using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appPokemon.Models.Stat
{
    public class Language
    {
        public string url { get; set; }
        public string name { get; set; }
    }

    public class Name
    {
        public string name { get; set; }
        public Language language { get; set; }
    }

    public class Increase
    {
        public string url { get; set; }
        public string name { get; set; }
    }

    public class Decrease
    {
        public string url { get; set; }
        public string name { get; set; }
    }

    public class AffectingNatures
    {
        public List<Increase> increase { get; set; }
        public List<Decrease> decrease { get; set; }
    }

    public class Characteristic
    {
        public string url { get; set; }
    }

    public class Move
    {
        public string url { get; set; }
        public string name { get; set; }
    }

    public class Increase2
    {
        public Move move { get; set; }
        public int change { get; set; }
    }

    public class Move2
    {
        public string url { get; set; }
        public string name { get; set; }
    }

    public class Decrease2
    {
        public Move2 move { get; set; }
        public int change { get; set; }
    }

    public class AffectingMoves
    {
        public List<Increase2> increase { get; set; }
        public List<Decrease2> decrease { get; set; }
    }

    public class RootObject
    {
        public bool is_battle_only { get; set; }
        public List<Name> names { get; set; }
        public AffectingNatures affecting_natures { get; set; }
        public List<Characteristic> characteristics { get; set; }
        public AffectingMoves affecting_moves { get; set; }
        public object move_damage_class { get; set; }
        public int game_index { get; set; }
        public int id { get; set; }
        public string name { get; set; }
    }
}
