using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Xamarin.Forms;

namespace appPokemon.Models
{
    public static class GlobalLogic
    {
        public static async Task AtaqueAsync(int moveClicked, bool amigo)
        {
            if (amigo == true)
            {
                await GlobalGrid.imageFriendImage.TranslateTo(-50, 50, 75);
                await GlobalGrid.imageFriendImage.TranslateTo(50, -50, 35);

                await GlobalGrid.imageEnemyImage.TranslateTo(25, -25, 35);
                await GlobalGrid.imageEnemyImage.TranslateTo(0, 0, 35);

                golpe(moveClicked, amigo);
                await GlobalGrid.progressBarEnemyHpBar.ProgressTo((GlobalVar.enemyCoach.user.pokemons[GlobalVar.pokEnemigo].hp / GlobalLogic.vidaMaxima(false)), 250, Easing.Linear);
                GlobalGrid.labelEnemyHpData.Text = GlobalVar.enemyCoach.user.pokemons[GlobalVar.pokEnemigo].hp.ToString() + "/" + GlobalLogic.vidaMaxima(false).ToString();

                await GlobalGrid.imageFriendImage.TranslateTo(0, 0, 90);
            }
            else
            {
                await GlobalGrid.imageEnemyImage.TranslateTo(50, -50, 75);
                await GlobalGrid.imageEnemyImage.TranslateTo(-50, 50, 35);

                await GlobalGrid.imageFriendImage.TranslateTo(-25, 25, 35);
                await GlobalGrid.imageFriendImage.TranslateTo(0, 0, 35);

                golpe(moveClicked, amigo);
                await GlobalGrid.progressBarFriendHpBar.ProgressTo((GlobalVar.friendCoach.user.pokemons[GlobalVar.pokEnemigo].hp / GlobalLogic.vidaMaxima(false)), 250, Easing.Linear);
                GlobalGrid.labelFriendHpData.Text = GlobalVar.friendCoach.user.pokemons[GlobalVar.pokEnemigo].hp.ToString() + "/" + GlobalLogic.vidaMaxima(false).ToString();

                await GlobalGrid.imageEnemyImage.TranslateTo(0, 0, 90);
            }
        }

        public static void golpe(int moveClicked, bool amigo)
        {
            int golpe = 0;

            if (amigo == true)
            {
                golpe = GlobalVar.friendMoves[moveClicked].power;

                if (GlobalVar.enemyCoach.user.pokemons[GlobalVar.pokEnemigo].hp > golpe)
                {
                    GlobalVar.enemyCoach.user.pokemons[GlobalVar.pokEnemigo].hp -= golpe;
                }
                else
                {
                    GlobalVar.enemyCoach.user.pokemons[GlobalVar.pokEnemigo].hp = 0;

                    GlobalGrid.imageEnemyImage.RotateTo(180);
                }
            }
            else
            {
                golpe = GlobalVar.enemyMoves[moveClicked].power;

                if (GlobalVar.friendCoach.user.pokemons[GlobalVar.pokEnemigo].hp > golpe)
                {
                    GlobalVar.friendCoach.user.pokemons[GlobalVar.pokEnemigo].hp -= golpe;
                }
                else
                {
                    GlobalVar.friendCoach.user.pokemons[GlobalVar.pokEnemigo].hp = 0;

                    GlobalGrid.imageFriendImage.RotateTo(180);
                }
            }
            
        }

        public static string CalculaGenero(bool hembra)
        {
            if (hembra)
                return "♀";

            return "♂";
        }

        public static int experienciaMaxima(bool amigo)
        {
            if (amigo == true)
            {
                return GlobalVar.friendCoach.pokemons[GlobalVar.pokAmigo].base_experience * GlobalVar.friendCoach.user.pokemons[GlobalVar.pokAmigo].level;
            }
            else
            {
                return GlobalVar.enemyCoach.pokemons[GlobalVar.pokEnemigo].base_experience * GlobalVar.enemyCoach.user.pokemons[GlobalVar.pokEnemigo].level;
            }
        }

        public static async Task actualizarExperienciaAsync()
        {
            int nuevaExp = GlobalVar.friendCoach.user.pokemons[GlobalVar.pokAmigo].experience + (experienciaMaxima(false) / experienciaMaxima(true));

            bool maximo = false;

            while (nuevaExp >= (experienciaMaxima(true) - GlobalVar.friendCoach.user.pokemons[GlobalVar.pokAmigo].experience) && maximo == false)
            {
                if (GlobalVar.friendCoach.user.pokemons[GlobalVar.pokAmigo].level == 100)
                {
                    maximo = true;

                    nuevaExp = experienciaMaxima(true);

                    await GlobalGrid.progressBarEnemyXp.ProgressTo(1, 250, Easing.Linear);
                }
                else
                {
                    nuevaExp -= (experienciaMaxima(true) - GlobalVar.friendCoach.user.pokemons[GlobalVar.pokAmigo].experience);

                    GlobalVar.friendCoach.user.pokemons[GlobalVar.pokAmigo].level += 1;

                    await GlobalGrid.progressBarFriendXp.ProgressTo(1, 250, Easing.Linear);
                    GlobalGrid.progressBarFriendXp.Progress = 0;
                    GlobalGrid.labelFriendLevel.Text = CalculaGenero(GlobalVar.friendCoach.user.pokemons[GlobalVar.pokAmigo].sex) + " Nv " + GlobalVar.friendCoach.user.pokemons[GlobalVar.pokAmigo].level;
                }
            }

            GlobalVar.friendCoach.user.pokemons[GlobalVar.pokAmigo].experience = nuevaExp;

            await GlobalGrid.progressBarFriendXp.ProgressTo(((double)GlobalVar.friendCoach.user.pokemons[GlobalVar.pokAmigo].experience / (double)experienciaMaxima(true)), 250, Easing.Linear);

            // Hay que actualizar la experiencia en la BBDD
        }

        public static int vidaMaxima(bool amigo)
        {
            if (amigo == true)
            {
                return GlobalVar.friendCoach.pokemons[GlobalVar.pokAmigo].stats.Where(x => x.stat.name == "hp").First().base_stat * GlobalVar.friendCoach.user.pokemons[GlobalVar.pokAmigo].level;
            }
            else
            {
                return GlobalVar.enemyCoach.pokemons[GlobalVar.pokEnemigo].stats.Where(x => x.stat.name == "hp").First().base_stat * GlobalVar.enemyCoach.user.pokemons[GlobalVar.pokEnemigo].level;
            }
        }

        public static string obtenerImagen(int posicion, bool amigo, bool frontAmigo = false)
        {
            if (amigo == true)
            {
                if (GlobalVar.friendCoach.user.pokemons[posicion].sex == true && GlobalVar.friendCoach.pokemons[posicion].sprites.back_female != null)
                {
                    if (frontAmigo == true)
                    {
                        return GlobalVar.friendCoach.pokemons[posicion].sprites.front_female.ToString();
                    }
                    else
                    {
                        return GlobalVar.friendCoach.pokemons[posicion].sprites.back_female.ToString();
                    }
                }
                else
                {
                    if (frontAmigo == true)
                    {
                        return GlobalVar.friendCoach.pokemons[posicion].sprites.front_default;
                    }
                    else
                    {
                        return GlobalVar.friendCoach.pokemons[posicion].sprites.back_default;
                    }
                }
            }
            else
            {
                if (GlobalVar.enemyCoach.user.pokemons[posicion].sex == true && GlobalVar.enemyCoach.pokemons[posicion].sprites.back_female != null)
                {
                    return GlobalVar.enemyCoach.pokemons[posicion].sprites.front_female.ToString();
                }
                else
                {
                    return GlobalVar.enemyCoach.pokemons[posicion].sprites.front_default;
                }
            }
        }
    }
}
