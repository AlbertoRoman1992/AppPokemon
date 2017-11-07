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

            GlobalVar xGlobal = new GlobalVar();

            GlobalVar.pokemonAmigos.Add(rep.ObtenerPokemon(GlobalVar.pokemonID));
            GlobalVar.pokemonAmigos.Add(rep.ObtenerPokemon(new Random(DateTime.Now.Millisecond).Next(1, 803).ToString()));
            GlobalVar.pokemonAmigos.Add(rep.ObtenerPokemon(new Random(DateTime.Now.Millisecond).Next(1, 803).ToString()));
            GlobalVar.pokemonAmigos.Add(rep.ObtenerPokemon(new Random(DateTime.Now.Millisecond).Next(1, 803).ToString()));
            GlobalVar.pokemonAmigos.Add(rep.ObtenerPokemon(new Random(DateTime.Now.Millisecond).Next(1, 803).ToString()));
            GlobalVar.pokemonAmigos.Add(rep.ObtenerPokemon(new Random(DateTime.Now.Millisecond).Next(1, 803).ToString()));
            GlobalVar.pokemonAmigoHp = GlobalVar.pokemonAmigos[GlobalVar.countAmigo].stats.Where(x => x.stat.name == "hp").First().base_stat;

            GlobalVar.pokemonEnemigos.Add(rep.ObtenerPokemon(new Random(DateTime.Now.Millisecond).Next(1, 803).ToString()));
            GlobalVar.pokemonEnemigos.Add(rep.ObtenerPokemon(new Random(DateTime.Now.Millisecond).Next(1, 803).ToString()));
            GlobalVar.pokemonEnemigos.Add(rep.ObtenerPokemon(new Random(DateTime.Now.Millisecond).Next(1, 803).ToString()));
            GlobalVar.pokemonEnemigos.Add(rep.ObtenerPokemon(new Random(DateTime.Now.Millisecond).Next(1, 803).ToString()));
            GlobalVar.pokemonEnemigos.Add(rep.ObtenerPokemon(new Random(DateTime.Now.Millisecond).Next(1, 803).ToString()));
            GlobalVar.pokemonEnemigos.Add(rep.ObtenerPokemon(new Random(DateTime.Now.Millisecond).Next(1, 803).ToString()));
            GlobalVar.pokemonEnemigoHp = GlobalVar.pokemonEnemigos[GlobalVar.countEnemigo].stats.Where(x => x.stat.name == "hp").First().base_stat;

            InicializarVariables();

            Content = GenerarGrid();
        }

        public BattlePage(int count)
        {
            rep = new PokemonRepository();

            GlobalVar.pokemonAmigoHp = GlobalVar.pokemonAmigos[GlobalVar.countAmigo].stats.Where(x => x.stat.name == "hp").First().base_stat;

            GlobalVar.pokemonEnemigoHp = GlobalVar.pokemonEnemigos[GlobalVar.countEnemigo].stats.Where(x => x.stat.name == "hp").First().base_stat;

            GlobalVar.ImagenAmigo.RotateTo(0, 0);

            Content = GenerarGrid();
        }

        public void InicializarVariables()
        {
            for (int count = 0; count < 6; count++)
            {
                GlobalVar.HpBarAmigo[count].Progress = 1;
                GlobalVar.HpBarEnemigo[count].Progress = 1;
            }
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

                GlobalVar.ImagenAmigo.Source = new UriImageSource
                {
                    Uri = new Uri(GlobalVar.pokemonAmigos[GlobalVar.countAmigo].sprites.back_default)
                };

                grid.Children.Add(GlobalVar.ImagenAmigo, 0, 0);
                grid.Children.Add(GenerarGridDatos(amigo), 1, 0);
            }
            else
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });

                GlobalVar.ImagenEnemigo.Source = new UriImageSource
                {
                    Uri = new Uri(GlobalVar.pokemonEnemigos[GlobalVar.countEnemigo].sprites.front_default)
                };

                grid.Children.Add(GenerarGridDatos(amigo), 0, 0);
                grid.Children.Add(GlobalVar.ImagenEnemigo, 1, 0);
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
                BackgroundColor = Color.Gray
            };

            gridMenu.Children.Add(info, 0, 0);
            gridMenu.Children.Add(GenerarGridControles(), 1, 0);

            return gridMenu;
        }

        public string CalculaGenero(bool hembra)
        {
            if (new Random(DateTime.Now.Millisecond).Next(1) == 0 || hembra)
                return "♀";

            return "♂";
        }

        public string CalculaNivel()
        {
            return new Random(DateTime.Now.Millisecond).Next(1, 101).ToString();
        }

        public Grid GenerarGridDatos(bool amigo)
        {
            var gridDatos = new Grid();

            if (amigo == true)
            {
                gridDatos.RowDefinitions.Add(new RowDefinition { Height = new GridLength(3, GridUnitType.Star) });
                gridDatos.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
                gridDatos.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

                GlobalVar.XpBarAmigo.Progress = GlobalVar.pokemonAmigos[GlobalVar.countAmigo].base_experience / GlobalVar.pokemonAmigos[GlobalVar.countAmigo].base_experience;

                gridDatos.Children.Add(GenerarGridValores(amigo), 0, 1);
                gridDatos.Children.Add(GlobalVar.XpBarAmigo, 0, 2);
            }
            else
            {
                gridDatos.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
                gridDatos.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                gridDatos.RowDefinitions.Add(new RowDefinition { Height = new GridLength(3, GridUnitType.Star) });

                GlobalVar.XpBarEnemigo.Progress = GlobalVar.pokemonEnemigos[GlobalVar.countEnemigo].base_experience / GlobalVar.pokemonEnemigos[GlobalVar.countEnemigo].base_experience;

                gridDatos.Children.Add(GenerarGridValores(amigo), 0, 0);
                gridDatos.Children.Add(GlobalVar.XpBarEnemigo, 0, 1);
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
                FontSize = 8
            };

            var Hp = new Label
            {
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalTextAlignment = TextAlignment.End,
                FontSize = 8
            };

            var Nivel = new Label
            {
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 8
            };

            if (amigo == true)
            {
                Nombre.Text = GlobalVar.pokemonAmigos[GlobalVar.countAmigo].name;
                Hp.Text = rep.ObtenerStat(GlobalVar.pokemonAmigos[GlobalVar.countAmigo].stats.Where(x => x.stat.name == "hp").First().stat.url).names.Where(x => x.language.name == "es").First().name;
                Nivel.Text = CalculaGenero(GlobalVar.pokemonAmigos[GlobalVar.countAmigo].sprites.front_female != null) + " Nv " + CalculaNivel();
            }
            else
            {
                Nombre.Text = GlobalVar.pokemonEnemigos[GlobalVar.countEnemigo].name;
                Hp.Text = rep.ObtenerStat(GlobalVar.pokemonEnemigos[GlobalVar.countEnemigo].stats.Where(x => x.stat.name == "hp").First().stat.url).names.Where(x => x.language.name == "es").First().name;
                Nivel.Text = CalculaGenero(GlobalVar.pokemonEnemigos[GlobalVar.countEnemigo].sprites.front_female != null) + " Nv " + CalculaNivel();
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
                GlobalVar.HpBarAmigo[GlobalVar.countAmigo].Progress = GlobalVar.pokemonAmigoHp / GlobalVar.pokemonAmigos[GlobalVar.countAmigo].stats.Where(x => x.stat.name == "hp").First().base_stat;

                GlobalVar.HpDatosAmigo.Text = GlobalVar.pokemonAmigoHp.ToString() + "/" + GlobalVar.pokemonAmigos[GlobalVar.countAmigo].stats.Where(x => x.stat.name == "hp").First().base_stat.ToString();
                GlobalVar.HpDatosAmigo.VerticalTextAlignment = TextAlignment.Start;
                GlobalVar.HpDatosAmigo.HorizontalTextAlignment = TextAlignment.Center;
                GlobalVar.HpDatosAmigo.FontSize = 8;

                gridPs.Children.Add(GlobalVar.HpBarAmigo[GlobalVar.countAmigo], 0, 0);
                gridPs.Children.Add(GlobalVar.HpDatosAmigo, 0, 1);
            }
            else
            {
                GlobalVar.HpBarEnemigo[GlobalVar.countEnemigo].Progress = GlobalVar.pokemonEnemigoHp / GlobalVar.pokemonEnemigos[GlobalVar.countEnemigo].stats.Where(x => x.stat.name == "hp").First().base_stat;

                GlobalVar.HpDatosEnemigo.Text = GlobalVar.pokemonEnemigoHp.ToString() + "/" + GlobalVar.pokemonEnemigos[GlobalVar.countEnemigo].stats.Where(x => x.stat.name == "hp").First().base_stat.ToString();
                GlobalVar.HpDatosEnemigo.VerticalTextAlignment = TextAlignment.Start;
                GlobalVar.HpDatosEnemigo.HorizontalTextAlignment = TextAlignment.Center;
                GlobalVar.HpDatosEnemigo.FontSize = 8;

                gridPs.Children.Add(GlobalVar.HpBarEnemigo[GlobalVar.countEnemigo], 0, 0);
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
                FontSize = 10,
                Text = "Null",
                StyleId = "0"
            };

            var ataque2 = new Button
            {
                FontSize = 10,
                Text = "Null",
                StyleId = "1"
            };

            var ataque3 = new Button
            {
                FontSize = 10,
                Text = "Null",
                StyleId = "2"
            };

            var ataque4 = new Button
            {
                FontSize = 10,
                Text = "Null",
                StyleId = "3"
            };

            string text;

            for(int count = 0; count < GlobalVar.pokemonAmigos[GlobalVar.countAmigo].abilities.Count(); count++)
            {
                text = rep.ObtenerAbility(GlobalVar.pokemonAmigos[GlobalVar.countAmigo].abilities[count].ability.url).names.Where(x => x.language.name == "es").First().name;

                switch (count)
                {
                    case 0:
                        ataque1.Text = text;
                        break;
                    case 1:
                        ataque2.Text = text;
                        break;
                    case 2:
                        ataque3.Text = text;
                        break;
                    case 3:
                        ataque4.Text = text;
                        break;
                    default:
                        break;
                }
            }

            ataque1.Clicked += Button_click;
            ataque2.Clicked += Button_click;
            ataque3.Clicked += Button_click;
            ataque4.Clicked += Button_click;

            void Button_click(Object sender, EventArgs e)
            {
                Button boton = (Button)sender;

                if (GlobalVar.pokemonAmigos[GlobalVar.countAmigo].abilities.Count() > int.Parse(boton.StyleId))
                {
                    AtaqueAmigoAsync(GlobalVar.pokemonAmigos[GlobalVar.countAmigo].abilities[int.Parse(boton.StyleId)].slot).ConfigureAwait(true);
                }
            }

            //void Button_click(Button sender)
            //{
            //    AtaqueAmigoAsync(GlobalVar.pokemonAmigos[GlobalVar.countAmigo].abilities[int.Parse(sender.StyleId)].slot).ConfigureAwait(true);
            //}

            //if (GlobalVar.pokemonAmigos[GlobalVar.countAmigo].abilities.Count() > 0)
            //{
            //    ataque1.Text = rep.ObtenerAbility(GlobalVar.pokemonAmigos[GlobalVar.countAmigo].abilities[0].ability.url).names.Where(x => x.language.name == "es").First().name;

            //    ataque1.Clicked += (sender, ea) =>
            //    {
            //        AtaqueAmigoAsync(GlobalVar.pokemonAmigos[GlobalVar.countAmigo].abilities[0].slot).ConfigureAwait(true);
            //    };
            //}

            //var ataque2 = new Button
            //{
            //    FontSize = 10,
            //    Text = "Null"
            //};

            //if (GlobalVar.pokemonAmigos[GlobalVar.countAmigo].abilities.Count() > 1)
            //{
            //    ataque2.Text = rep.ObtenerAbility(GlobalVar.pokemonAmigos[GlobalVar.countAmigo].abilities[1].ability.url).names.Where(x => x.language.name == "es").First().name;

            //    ataque2.Clicked += (sender, ea) =>
            //    {
            //        AtaqueAmigoAsync(GlobalVar.pokemonAmigos[GlobalVar.countAmigo].abilities[1].slot).ConfigureAwait(true);
            //    };
            //}

            //var ataque3 = new Button
            //{
            //    FontSize = 10,
            //    Text = "Null"
            //};

            //if (GlobalVar.pokemonAmigos[GlobalVar.countAmigo].abilities.Count() > 2)
            //{
            //    ataque3.Text = rep.ObtenerAbility(GlobalVar.pokemonAmigos[GlobalVar.countAmigo].abilities[2].ability.url).names.Where(x => x.language.name == "es").First().name;

            //    ataque3.Clicked += (sender, ea) =>
            //    {
            //        AtaqueAmigoAsync(GlobalVar.pokemonAmigos[GlobalVar.countAmigo].abilities[2].slot).ConfigureAwait(true);
            //    };
            //}

            //var ataque4 = new Button
            //{
            //    FontSize = 10,
            //    Text = "Null"
            //};

            //if (GlobalVar.pokemonAmigos[GlobalVar.countAmigo].abilities.Count() > 3)
            //{
            //    ataque4.Text = rep.ObtenerAbility(GlobalVar.pokemonAmigos[GlobalVar.countAmigo].abilities[3].ability.url).names.Where(x => x.language.name == "es").First().name;

            //    ataque4.Clicked += (sender, ea) =>
            //    {
            //        AtaqueAmigoAsync(GlobalVar.pokemonAmigos[GlobalVar.countAmigo].abilities[3].slot).ConfigureAwait(true);
            //    };
            //}

            gridControles.Children.Add(ataque1, 0, 0);
            gridControles.Children.Add(ataque2, 1, 0);
            gridControles.Children.Add(ataque3, 0, 1);
            gridControles.Children.Add(ataque4, 1, 1);

            return gridControles;
        }

        public async Task AtaqueAmigoAsync(int golpe)
        {
            await GlobalVar.ImagenAmigo.TranslateTo(-50, 50, 75);
            await GlobalVar.ImagenAmigo.TranslateTo(50, -50, 35);

            await GlobalVar.ImagenEnemigo.TranslateTo(25, -25, 35);
            await GlobalVar.ImagenEnemigo.TranslateTo(0, 0, 35);

            GlobalVar.golpeEnemigo(golpe);
            await GlobalVar.HpBarEnemigo[GlobalVar.countEnemigo].ProgressTo((GlobalVar.pokemonEnemigoHp / GlobalVar.pokemonEnemigos[GlobalVar.countEnemigo].stats.Where(x => x.stat.name == "hp").First().base_stat), 250, Easing.Linear);
            GlobalVar.HpDatosEnemigo.Text = GlobalVar.pokemonEnemigoHp.ToString() + "/" + GlobalVar.pokemonEnemigos[GlobalVar.countEnemigo].stats.Where(x => x.stat.name == "hp").First().base_stat.ToString();

            await GlobalVar.ImagenAmigo.TranslateTo(0, 0, 90);

            await AtaqueEnemigoAsync();
        }

        public async Task AtaqueEnemigoAsync()
        {
            await GlobalVar.ImagenEnemigo.TranslateTo(50, -50, 75);
            await GlobalVar.ImagenEnemigo.TranslateTo(-50, 50, 35);

            await GlobalVar.ImagenAmigo.TranslateTo(-25, 25, 35);
            await GlobalVar.ImagenAmigo.TranslateTo(0, 0, 35);

            GlobalVar.golpeAmigo(GlobalVar.pokemonAmigos[GlobalVar.countAmigo].abilities[new Random(DateTime.Now.Millisecond).Next(GlobalVar.pokemonAmigos[GlobalVar.countAmigo].abilities.Count())].slot);
            await GlobalVar.HpBarAmigo[GlobalVar.countAmigo].ProgressTo((GlobalVar.pokemonAmigoHp / GlobalVar.pokemonAmigos[GlobalVar.countAmigo].stats.Where(x => x.stat.name == "hp").First().base_stat), 250, Easing.Linear);
            GlobalVar.HpDatosAmigo.Text = GlobalVar.pokemonAmigoHp.ToString() + "/" + GlobalVar.pokemonAmigos[GlobalVar.countAmigo].stats.Where(x => x.stat.name == "hp").First().base_stat.ToString();

            await GlobalVar.ImagenEnemigo.TranslateTo(0, 0, 90);

            if (GlobalVar.pokemonAmigoHp == 0)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PushAsync(new SelectPage());
                });
            }
        }
    }
}