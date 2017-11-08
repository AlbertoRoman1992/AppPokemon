using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace appPokemon.Models
{
    public class GlobalLogic
    {
        public GlobalLogic()
        {

        }

        public static int experienciaMaxima(bool amigo)
        {
            if(amigo == true)
            {
                return GlobalVar.entrenadorAmigo.pokemons[GlobalVar.countAmigo].base_experience * GlobalVar.entrenadorAmigo.user.pokemons[GlobalVar.countAmigo].level;
            }
            else
            {
                return GlobalVar.entrenadorEnemigo.pokemons[GlobalVar.countEnemigo].base_experience * GlobalVar.entrenadorEnemigo.user.pokemons[GlobalVar.countEnemigo].level;
            }
        }

        public static void actualizarExperiencia()
        {
            int nuevaExp = GlobalVar.entrenadorAmigo.user.pokemons[GlobalVar.countAmigo].experience + (experienciaMaxima(false) / experienciaMaxima(true));

            while(nuevaExp >= (experienciaMaxima(true) - GlobalVar.entrenadorAmigo.user.pokemons[GlobalVar.countAmigo].experience))
            {
                if(GlobalVar.entrenadorAmigo.user.pokemons[GlobalVar.countAmigo].level == 100)
                {
                    nuevaExp = experienciaMaxima(true);
                }
                else
                {
                    nuevaExp -= (experienciaMaxima(true) - GlobalVar.entrenadorAmigo.user.pokemons[GlobalVar.countAmigo].experience);

                    GlobalVar.entrenadorAmigo.user.pokemons[GlobalVar.countAmigo].level += 1;
                }
            }

            GlobalVar.entrenadorAmigo.user.pokemons[GlobalVar.countAmigo].experience = nuevaExp;
            
            GlobalVar.XpBarAmigo.ProgressTo((GlobalVar.entrenadorEnemigo.user.pokemons[GlobalVar.countEnemigo].experience / GlobalLogic.experienciaMaxima(true)), 250, Easing.Linear);

            // Hay que actualizar la experiencia en la BBDD
        }
    }
}
