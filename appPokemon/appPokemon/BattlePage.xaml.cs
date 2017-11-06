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

namespace appPokemon
{
    public partial class BattlePage : ContentPage
    {
        PokemonRepository rep;

        public BattlePage()
        {
            InitializeComponent();

            rep = new PokemonRepository();

            GlobalVar.pokemonAmigo = rep.ObtenerPokemon(GlobalVar.pokemonID);
            GlobalVar.pokemonEnemigo = rep.ObtenerPokemon("bulbasaur");

            GlobalVar x = new GlobalVar();

            Content = GenerarGrid();
        }

        public Grid GenerarGrid()
        {
            var gridGeneral = new Grid();

            gridGeneral.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2.5, GridUnitType.Star) });
            gridGeneral.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gridGeneral.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2.5, GridUnitType.Star) });
            gridGeneral.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1.5, GridUnitType.Star) });

            gridGeneral.Children.Add(GenerarGridPokemon(false), 0, 0);
            gridGeneral.Children.Add(GenerarGridBatalla(), 0, 1);
            gridGeneral.Children.Add(GenerarGridPokemon(true), 0, 2);
            gridGeneral.Children.Add(GenerarGridMenu(), 0, 3);

            return gridGeneral;
        }

        public Grid GenerarGridPokemon(bool amigo)
        {
            var grid = new Grid();

            if (amigo == true)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }
            else
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
            }

            var Imagen = new Image
            {
                BackgroundColor = Color.Blue
            };

            if (amigo == true)
            {
                Imagen.Source = new UriImageSource
                {
                    Uri = new Uri(GlobalVar.pokemonAmigo.sprites.back_default)
                };

                grid.Children.Add(Imagen, 0, 0);
                grid.Children.Add(GenerarGridDatos(amigo), 1, 0);
            }
            else
            {
                Imagen.Source = new UriImageSource
                {
                    Uri = new Uri(GlobalVar.pokemonEnemigo.sprites.front_default)
                };

                grid.Children.Add(GenerarGridDatos(amigo), 0, 0);
                grid.Children.Add(Imagen, 1, 0);
            }

            return grid;
        }

        public Grid GenerarGridBatalla()
        {
            var gridBatalla = new Grid();

            return gridBatalla;
        }

        public Grid GenerarGridMenu()
        {
            var gridMenu = new Grid();

            gridMenu.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            gridMenu.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            var info = new Label
            {
                Text = "Información de la Batalla",
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalTextAlignment = TextAlignment.Center,
                BackgroundColor = Color.Green
            };

            gridMenu.Children.Add(info, 0, 0);
            gridMenu.Children.Add(GenerarGridControles(), 1, 0);

            return gridMenu;
        }

        public string CalculaGenero(Models.Pokemon.RootObject pokemon)
        {
            if (new Random(DateTime.Now.Millisecond).Next(1) == 0 || pokemon.sprites.front_female != null)
                return "♀";

            return "♂";
        }

        public string CalculaNivel()
        {
            return new Random(DateTime.Now.Millisecond).Next(100).ToString();
        }

        public Grid GenerarGridDatos(bool amigo)
        {
            var gridDatos = new Grid();

            var XpBar = new ProgressBar
            {
                BackgroundColor = Color.Red
            };

            if (amigo == true)
            {
                gridDatos.RowDefinitions.Add(new RowDefinition { Height = new GridLength(3, GridUnitType.Star) });
                gridDatos.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
                gridDatos.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

                XpBar.Progress = GlobalVar.pokemonAmigo.base_experience / GlobalVar.pokemonAmigo.base_experience;

                gridDatos.Children.Add(GenerarGridValores(amigo), 0, 1);
                gridDatos.Children.Add(XpBar, 0, 2);
            }
            else
            {
                gridDatos.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
                gridDatos.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                gridDatos.RowDefinitions.Add(new RowDefinition { Height = new GridLength(3, GridUnitType.Star) });

                XpBar.Progress = GlobalVar.pokemonEnemigo.base_experience / GlobalVar.pokemonEnemigo.base_experience;

                gridDatos.Children.Add(GenerarGridValores(amigo), 0, 0);
                gridDatos.Children.Add(XpBar, 0, 1);
            }

            return gridDatos;
        }

        public Grid GenerarGridValores(bool amigo)
        {
            var gridValores = new Grid();

            gridValores.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gridValores.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gridValores.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            gridValores.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            
            var Nombre = new Label
            {
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalTextAlignment = TextAlignment.Center,
                BackgroundColor = Color.Red,
                FontSize = 8
            };

            var Hp = new Label
            {
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalTextAlignment = TextAlignment.Center,
                BackgroundColor = Color.Red,
                FontSize = 8
            };

            var Nivel = new Label
            {
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalTextAlignment = TextAlignment.Center,
                BackgroundColor = Color.Red,
                FontSize = 8
            };

            if (amigo == true)
            {
                Nombre.Text = GlobalVar.pokemonAmigo.name;
                Hp.Text = rep.ObtenerStat(GlobalVar.pokemonAmigo.stats.Where(x => x.stat.name == "hp").First().stat.url).names.Where(x => x.language.name == "es").First().name;
                Nivel.Text = CalculaGenero(GlobalVar.pokemonAmigo) + " Nv " + CalculaNivel();
            }
            else
            {
                Nombre.Text = GlobalVar.pokemonEnemigo.name;
                Hp.Text = rep.ObtenerStat(GlobalVar.pokemonEnemigo.stats.Where(x => x.stat.name == "hp").First().stat.url).names.Where(x => x.language.name == "es").First().name;
                Nivel.Text = CalculaGenero(GlobalVar.pokemonEnemigo) + " Nv " + CalculaNivel();
            }

            gridValores.Children.Add(Nombre, 0, 0);
            gridValores.Children.Add(Hp, 0, 1);
            gridValores.Children.Add(Nivel, 1, 0);
            gridValores.Children.Add(GenerarGridPs(amigo), 1, 1);

            return gridValores;
        }

        public Grid GenerarGridPs(bool amigo)
        {
            var gridPs = new Grid();

            gridPs.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gridPs.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            if (amigo == true)
            {
                GlobalVar.HpBarAmigo.BackgroundColor = Color.Red;
                GlobalVar.HpBarAmigo.Progress = GlobalVar.pokemonAmigoHp / GlobalVar.pokemonAmigo.stats.Where(x => x.stat.name == "hp").First().base_stat;

                GlobalVar.HpDatosAmigo.Text = GlobalVar.pokemonAmigoHp.ToString() + "/" + GlobalVar.pokemonAmigo.stats.Where(x => x.stat.name == "hp").First().base_stat.ToString();
                GlobalVar.HpDatosAmigo.VerticalTextAlignment = TextAlignment.Start;
                GlobalVar.HpDatosAmigo.HorizontalTextAlignment = TextAlignment.Center;
                GlobalVar.HpDatosAmigo.BackgroundColor = Color.Red;
                GlobalVar.HpDatosAmigo.FontSize = 8;

                gridPs.Children.Add(GlobalVar.HpBarAmigo, 0, 0);
                gridPs.Children.Add(GlobalVar.HpDatosAmigo, 0, 1);
            }
            else
            {
                GlobalVar.HpBarEnemigo.BackgroundColor = Color.Red;
                GlobalVar.HpBarEnemigo.Progress = GlobalVar.pokemonEnemigoHp / GlobalVar.pokemonEnemigo.stats.Where(x => x.stat.name == "hp").First().base_stat;

                GlobalVar.HpDatosEnemigo.Text = GlobalVar.pokemonEnemigoHp.ToString() + "/" + GlobalVar.pokemonEnemigo.stats.Where(x => x.stat.name == "hp").First().base_stat.ToString();
                GlobalVar.HpDatosEnemigo.VerticalTextAlignment = TextAlignment.Start;
                GlobalVar.HpDatosEnemigo.HorizontalTextAlignment = TextAlignment.Center;
                GlobalVar.HpDatosEnemigo.BackgroundColor = Color.Red;
                GlobalVar.HpDatosEnemigo.FontSize = 8;

                gridPs.Children.Add(GlobalVar.HpBarEnemigo, 0, 0);
                gridPs.Children.Add(GlobalVar.HpDatosEnemigo, 0, 1);
            }

            return gridPs;
        }

        public Grid GenerarGridControles()
        {
            var gridControles = new Grid();

            gridControles.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gridControles.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gridControles.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            gridControles.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            var ataque1 = new Button
            {
                FontSize = 10
            };

            if (GlobalVar.pokemonAmigo.abilities.Count() > 0)
            {
                ataque1.Text = GlobalVar.pokemonAmigo.abilities[0].ability.name;

                ataque1.Clicked += (sender, ea) =>
                {
                    GlobalVar.golpeEnemigo(GlobalVar.pokemonAmigo.abilities[0].slot);
                    GlobalVar.HpBarEnemigo.ProgressTo((GlobalVar.pokemonEnemigoHp / GlobalVar.pokemonEnemigo.stats.Where(x => x.stat.name == "hp").First().base_stat), 250, Easing.Linear);
                    GlobalVar.HpDatosEnemigo.Text = GlobalVar.pokemonEnemigoHp.ToString() + "/" + GlobalVar.pokemonEnemigo.stats.Where(x => x.stat.name == "hp").First().base_stat.ToString();
                };
            }
            else
            {
                ataque1.Text = "Null";
            }

            var ataque2 = new Button
            {
                FontSize = 10
            };

            if (GlobalVar.pokemonAmigo.abilities.Count() > 1)
            {
                ataque2.Text = GlobalVar.pokemonAmigo.abilities[1].ability.name;

                ataque2.Clicked += (sender, ea) =>
                {
                    GlobalVar.golpeEnemigo(GlobalVar.pokemonAmigo.abilities[1].slot);
                    GlobalVar.HpBarEnemigo.ProgressTo((GlobalVar.pokemonEnemigoHp / GlobalVar.pokemonEnemigo.stats.Where(x => x.stat.name == "hp").First().base_stat), 250, Easing.Linear);
                    GlobalVar.HpDatosEnemigo.Text = GlobalVar.pokemonEnemigoHp.ToString() + "/" + GlobalVar.pokemonEnemigo.stats.Where(x => x.stat.name == "hp").First().base_stat.ToString();
                };
            }
            else
            {
                ataque2.Text = "Null";
            }

            var ataque3 = new Button
            {
                FontSize = 10
            };

            if (GlobalVar.pokemonAmigo.abilities.Count() > 2)
            {
                ataque3.Text = GlobalVar.pokemonAmigo.abilities[2].ability.name;

                ataque3.Clicked += (sender, ea) =>
                {
                    GlobalVar.golpeEnemigo(GlobalVar.pokemonAmigo.abilities[2].slot);
                    GlobalVar.HpBarEnemigo.ProgressTo((GlobalVar.pokemonEnemigoHp / GlobalVar.pokemonEnemigo.stats.Where(x => x.stat.name == "hp").First().base_stat), 250, Easing.Linear);
                    GlobalVar.HpDatosEnemigo.Text = GlobalVar.pokemonEnemigoHp.ToString() + "/" + GlobalVar.pokemonEnemigo.stats.Where(x => x.stat.name == "hp").First().base_stat.ToString();
                };
            }
            else
            {
                ataque3.Text = "Null";
            } 

            var ataque4 = new Button
            {
                FontSize = 10
            };

            if (GlobalVar.pokemonAmigo.abilities.Count() > 3)
            {
                ataque4.Text = GlobalVar.pokemonAmigo.abilities[3].ability.name;

                ataque4.Clicked += (sender, ea) =>
                {
                    GlobalVar.golpeEnemigo(GlobalVar.pokemonAmigo.abilities[3].slot);
                    GlobalVar.HpBarEnemigo.ProgressTo((GlobalVar.pokemonEnemigoHp / GlobalVar.pokemonEnemigo.stats.Where(x => x.stat.name == "hp").First().base_stat), 250, Easing.Linear);
                    GlobalVar.HpDatosEnemigo.Text = GlobalVar.pokemonEnemigoHp.ToString() + "/" + GlobalVar.pokemonEnemigo.stats.Where(x => x.stat.name == "hp").First().base_stat.ToString();
                };
            }
            else
            {
                ataque4.Text = "Null";
            }

            gridControles.Children.Add(ataque1, 0, 0);
            gridControles.Children.Add(ataque2, 1, 0);
            gridControles.Children.Add(ataque3, 0, 1);
            gridControles.Children.Add(ataque4, 1, 1);

            return gridControles;
        }
    }
}