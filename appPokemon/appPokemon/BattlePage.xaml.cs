using appPokemon.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using appPokemon.Models.Repository;
using System.Threading;

namespace appPokemon
{
    public partial class BattlePage : ContentPage
    {
        PokemonRepository rep;
        Java.Lang.Thread CargarPokemonsThread;

        public BattlePage()
        {
            rep = new PokemonRepository();

            if (GlobalVar.battlePageVisited == false)
            {
                GlobalVar.battlePageVisited = true;

                InitializeComponent();

                CargarPokemonsThread = new Java.Lang.Thread(rep.CargarPokemons);

                InicializarPagina();
            }

            CargarDatos();

            GlobalGrid.imageFriendImage.RotateTo(0, 0);
            GlobalGrid.imageEnemyImage.RotateTo(0, 0);

            GenerarGridPokemon(false);
            GenerarGridData(false);
            GenerarGridValues(false);
            GenerarGridHp(false);
            GenerarGridPokemon(true);
            GenerarGridData(true);
            GenerarGridValues(true);
            GenerarGridHp(true);
            GenerarGridMenu();
            GenerarGridAttack();

            Content = GlobalGrid.gridBattlePage;
        }

        public void InicializarPagina()
        {
            // Carga los pokemons iniciales
            GlobalVar.friendCoach.pokemons.Add(rep.ObtenerPokemon(GlobalVar.friendCoach.user.pokemons[0].name));
            GlobalVar.enemyCoach.pokemons.Add(rep.ObtenerPokemon(GlobalVar.enemyCoach.user.pokemons[0].name));

            // Pone a cargar el resto de pokemons de forma secundaria
            CargarPokemonsThread.Start();

            // Genero y gestiono los grids de la página
            GlobalGrid.InicializarGrids();
            GlobalGrid.DimensionarGrids();
            GlobalGrid.EstructurarGrids();
        }

        public void CargarDatos()
        {
            // Carga el Stat del pokemon amigo
            GlobalVar.friendStat = rep.ObtenerStat(GlobalVar.friendCoach.pokemons[GlobalVar.pokAmigo].stats.Where(x => x.stat.name == "hp").First().stat.url);

            // Carga los ataques del amigo
            GlobalVar.friendMoves.Clear();
            for (int count = 0; count < GlobalVar.friendCoach.user.pokemons[GlobalVar.pokAmigo].moves.Count(); count++)
            {
                GlobalVar.friendMoves.Add(rep.ObtenerMove(GlobalVar.friendCoach.user.pokemons[GlobalVar.pokAmigo].moves[count].url));
            }

            // Carga los ataques del enemigo
            GlobalVar.enemyMoves.Clear();
            for (int count = 0; count < GlobalVar.enemyCoach.user.pokemons[GlobalVar.pokEnemigo].moves.Count(); count++)
            {
                GlobalVar.enemyMoves.Add(rep.ObtenerMove(GlobalVar.enemyCoach.user.pokemons[GlobalVar.pokEnemigo].moves[count].url));
            }
        }

        public void GenerarGridPokemon(bool amigo)
        {
            if (amigo == true)
            {
                GlobalGrid.imageFriendImage.Source = new UriImageSource
                {
                    Uri = new Uri(GlobalLogic.obtenerImagen(GlobalVar.pokAmigo, amigo))
                };
            }
            else
            {
                GlobalGrid.imageEnemyImage.Source = new UriImageSource
                {
                    Uri = new Uri(GlobalLogic.obtenerImagen(GlobalVar.pokEnemigo, amigo))
                };
            }
        }

        public void GenerarGridMenu()
        {
            GlobalGrid.labelInfo.Text = "Información de la Batalla";
        }

        public void GenerarGridData(bool amigo)
        {
            if (amigo == true)
            {
                GlobalGrid.progressBarFriendXp.Progress = GlobalVar.friendCoach.user.pokemons[GlobalVar.pokAmigo].experience / GlobalLogic.experienciaMaxima(amigo);
            }
            else
            {
                GlobalGrid.progressBarEnemyXp.Progress = GlobalVar.enemyCoach.user.pokemons[GlobalVar.pokEnemigo].experience / GlobalLogic.experienciaMaxima(amigo);
            }
        }

        public void GenerarGridValues(bool amigo)
        {
            GlobalGrid.labelHpTitle.Text = GlobalVar.friendStat.names.Where(x => x.language.name == "es").First().name;

            if (amigo == true)
            {
                GlobalGrid.labelFriendName.Text = GlobalVar.friendCoach.user.pokemons[GlobalVar.pokAmigo].name;

                GlobalGrid.labelFriendLevel.Text = GlobalLogic.CalculaGenero(GlobalVar.friendCoach.user.pokemons[GlobalVar.pokAmigo].sex) + " Nv " + GlobalVar.friendCoach.user.pokemons[GlobalVar.pokAmigo].level;
            }
            else
            {
                GlobalGrid.labelEnemyName.Text = GlobalVar.enemyCoach.user.pokemons[GlobalVar.pokAmigo].name;

                GlobalGrid.labelEnemyLevel.Text = GlobalLogic.CalculaGenero(GlobalVar.enemyCoach.user.pokemons[GlobalVar.pokAmigo].sex) + " Nv " + GlobalVar.enemyCoach.user.pokemons[GlobalVar.pokAmigo].level;
            }
        }

        public void GenerarGridHp(bool amigo)
        {
            if (amigo == true)
            {
                GlobalGrid.progressBarFriendHpBar.Progress = GlobalVar.friendCoach.user.pokemons[GlobalVar.pokAmigo].hp / GlobalLogic.vidaMaxima(true);

                GlobalGrid.labelFriendHpData.Text = GlobalVar.friendCoach.user.pokemons[GlobalVar.pokAmigo].hp.ToString() + "/" + GlobalLogic.vidaMaxima(true).ToString();
            }
            else
            {
                GlobalGrid.progressBarEnemyHpBar.Progress = GlobalVar.enemyCoach.user.pokemons[GlobalVar.pokAmigo].hp / GlobalLogic.vidaMaxima(true);

                GlobalGrid.labelEnemyHpData.Text = GlobalVar.enemyCoach.user.pokemons[GlobalVar.pokAmigo].hp.ToString() + "/" + GlobalLogic.vidaMaxima(true).ToString();
            }
        }

        public void GenerarGridAttack()
        {
            for (int count = 0; count < GlobalVar.friendCoach.user.pokemons[GlobalVar.pokAmigo].moves.Count(); count++)
            {
                switch (count)
                {
                    case 0:
                        GlobalGrid.buttonAttack1.Text = GlobalVar.friendMoves[count].names.Where(x => x.language.name == "es").First().name;
                        break;
                    case 1:
                        GlobalGrid.buttonAttack2.Text = GlobalVar.friendMoves[count].names.Where(x => x.language.name == "es").First().name;
                        break;
                    case 2:
                        GlobalGrid.buttonAttack3.Text = GlobalVar.friendMoves[count].names.Where(x => x.language.name == "es").First().name;
                        break;
                    case 3:
                        GlobalGrid.buttonAttack4.Text = GlobalVar.friendMoves[count].names.Where(x => x.language.name == "es").First().name;
                        break;
                    default:
                        break;
                }
            }

            GlobalGrid.buttonAttack1.Clicked += Button_click;
            GlobalGrid.buttonAttack2.Clicked += Button_click;
            GlobalGrid.buttonAttack3.Clicked += Button_click;
            GlobalGrid.buttonAttack4.Clicked += Button_click;

            async void Button_click(Object sender, EventArgs e)
            {
                Button boton = (Button)sender;

                if (GlobalVar.friendCoach.user.pokemons[GlobalVar.pokAmigo].moves.Count() > int.Parse(boton.StyleId))
                {
                    await GlobalLogic.AtaqueAsync(int.Parse(boton.StyleId), true);

                    if (GlobalVar.enemyCoach.user.pokemons[GlobalVar.pokEnemigo].hp == 0)
                    {
                        await GlobalLogic.actualizarExperienciaAsync();
                    }
                    else
                    {
                        await GlobalLogic.AtaqueAsync(new Random(DateTime.Now.Millisecond).Next(0, GlobalVar.enemyCoach.user.pokemons[GlobalVar.pokEnemigo].moves.Count()), false);

                        if (GlobalVar.friendCoach.user.pokemons[GlobalVar.pokAmigo].hp == 0)
                        {
                            while (CargarPokemonsThread.IsAlive)
                            {
                                Java.Lang.Thread.Sleep(1);
                            }

                            Device.BeginInvokeOnMainThread(async () =>
                            {
                                await Navigation.PushAsync(new SelectPage());
                            });
                        }
                    }
                }
            }
        }
    }
}