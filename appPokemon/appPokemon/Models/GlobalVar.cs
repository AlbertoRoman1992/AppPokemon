using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace appPokemon.Models
{
    public class GlobalVar
    {
        public GlobalVar()
        {
            pokemonAmigoHp = pokemonAmigo.stats.Where(x => x.stat.name == "hp").First().base_stat;
            pokemonEnemigoHp = pokemonEnemigo.stats.Where(x => x.stat.name == "hp").First().base_stat;

            HpBarAmigo = new ProgressBar();
            HpBarEnemigo = new ProgressBar();
            HpDatosAmigo = new Label();
            HpDatosEnemigo = new Label();
        }

        public static string pokemonID { get; set; }

        public static Pokemon.RootObject pokemonAmigo { get; set; }

        public static Pokemon.RootObject pokemonEnemigo { get; set; }

        public static double pokemonAmigoHp { get; set; }

        public static double pokemonEnemigoHp { get; set; }

        public static void golpeAmigo(int golpe)
        {
            if(pokemonAmigoHp >= golpe)
            {
                pokemonAmigoHp += -golpe;
            }
            else
            {
                pokemonAmigoHp = 0;
            }
        }

        public static void golpeEnemigo(int golpe)
        {
            if (pokemonEnemigoHp >= golpe)
            {
                pokemonEnemigoHp += -golpe;
            }
            else
            {
                pokemonEnemigoHp = 0;
            }
        }

        public static ProgressBar HpBarAmigo { get; set; }

        public static ProgressBar HpBarEnemigo { get; set; }

        public static Label HpDatosAmigo { get; set; }

        public static Label HpDatosEnemigo { get; set; }
    }
}
