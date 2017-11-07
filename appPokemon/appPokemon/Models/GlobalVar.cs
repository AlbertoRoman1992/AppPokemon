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
            pokemonAmigos = new List<Pokemon.RootObject>();
            pokemonEnemigos = new List<Pokemon.RootObject>();
            countAmigo = 0;
            countEnemigo = 0;
            HpBarAmigo = new List<ProgressBar>();
            HpBarEnemigo = new List<ProgressBar>();
            HpDatosAmigo = new Label();
            HpDatosEnemigo = new Label();
            XpBarAmigo = new ProgressBar();
            XpBarEnemigo = new ProgressBar();
            ImagenAmigo = new Image();
            ImagenEnemigo = new Image();

            for(int count = 0; count < 6; count++)
            {
                HpBarAmigo.Add(new ProgressBar());
                HpBarEnemigo.Add(new ProgressBar());
            }
        }

        public static string pokemonID { get; set; }

        public static List<Pokemon.RootObject> pokemonAmigos { get; set; }

        public static List<Pokemon.RootObject> pokemonEnemigos { get; set; }

        public static int countAmigo { get; set; }

        public static int countEnemigo { get; set; }

        public static double pokemonAmigoHp { get; set; }

        public static double pokemonEnemigoHp { get; set; }

        public static void golpeAmigo(int golpe)
        {
            if(pokemonAmigoHp > golpe)
            {
                pokemonAmigoHp -= golpe;
            }
            else
            {
                pokemonAmigoHp = 0;

                ImagenAmigo.RotateTo(180);
            }
        }

        public static void golpeEnemigo(int golpe)
        {
            if (pokemonEnemigoHp > golpe)
            {
                pokemonEnemigoHp -= golpe;
            }
            else
            {
                pokemonEnemigoHp = 0;

                ImagenEnemigo.RotateTo(180);
            }
        }

        public static List<ProgressBar> HpBarAmigo { get; set; }

        public static List<ProgressBar> HpBarEnemigo { get; set; }

        public static Label HpDatosAmigo { get; set; }

        public static Label HpDatosEnemigo { get; set; }

        public static ProgressBar XpBarAmigo { get; set; }

        public static ProgressBar XpBarEnemigo { get; set; }

        public static Image ImagenAmigo { get; set; }

        public static Image ImagenEnemigo { get; set; }
    }
}
