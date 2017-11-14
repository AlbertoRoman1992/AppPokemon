using appPokemon.Models.Realm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace appPokemon.Models
{
    public static class GlobalVar
    {
        public static bool battlePageVisited { get; set; }

        public static int pokAmigo { get; set; }
        public static int pokEnemigo { get; set; }

        public static Entrenador friendCoach { get; set; }
        public static Entrenador enemyCoach { get; set; }

        public static StatRealm friendStat { get; set; }

        public static List<MoveRealm> friendMoves { get; set; }
        public static List<MoveRealm> enemyMoves { get; set; }

        public static void InicializarVariables()
        {
            // Se inicializa a false la comprobación de que sea la primera vez que se entra en dicha página
            battlePageVisited = false;

            // Se inicializa en 0 el índice en la lista del pokemon que está actualmente en batalla
            pokAmigo = 0;
            pokEnemigo = 0;

            // Se inicializan los entrenadores
            friendCoach = new Entrenador();
            enemyCoach = new Entrenador();

            // Se inicializan las listas de los ataques del amigo y del enemigo
            friendMoves = new List<MoveRealm>();
            enemyMoves = new List<MoveRealm>();
        }
    }
}
