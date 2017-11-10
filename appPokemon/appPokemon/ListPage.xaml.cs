using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appPokemon.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using appPokemon.Models.Repository;
using appPokemon.Models.User;

namespace appPokemon
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
            Entrenador ent = new Entrenador();
            Models.Pokemon.RootObject pok = new Models.Pokemon.RootObject();
            

            Content = GenerarGrid();
        }

        public Grid GenerarGrid()
        {
            var grid = new Grid();

            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            //grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            List<Image> imagenPokemon = new List<Image>();

            var imagenPokemon1 = new Image();
            imagenPokemon1.Source = new UriImageSource
            {
                Uri = new Uri("https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/poke-ball.png")
            };
            imagenPokemon.Add(imagenPokemon1);

            var imagenPokemon2 = new Image();
            imagenPokemon2.Source = new UriImageSource
            {
                Uri = new Uri("https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/poke-ball.png")
            };
            imagenPokemon.Add(imagenPokemon2);


            var imagenPokemon3 = new Image();
            imagenPokemon3.Source = new UriImageSource
            {
                Uri = new Uri("https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/poke-ball.png")
            };
            imagenPokemon.Add(imagenPokemon3);
        

            var imagenPokemon4 = new Image();
            imagenPokemon4.Source = new UriImageSource
            {
                Uri = new Uri("https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/poke-ball.png")
            };
            imagenPokemon.Add(imagenPokemon4);


            var imagenPokemon5 = new Image();
            imagenPokemon5.Source = new UriImageSource
            {
                Uri = new Uri("https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/poke-ball.png")
            };
            imagenPokemon.Add(imagenPokemon5);


            var imagenPokemon6 = new Image();
            imagenPokemon6.Source = new UriImageSource
            {
                Uri = new Uri("https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/poke-ball.png")
            };

            imagenPokemon.Add(imagenPokemon6);

            var buttonPokemonSe = new Button
            {
                FontSize = 10,
                Text = "Seleccionar",
                StyleId = "0"
            };

            grid.Children.Add(imagenPokemon[0], 0, 0);
            grid.Children.Add(imagenPokemon[1], 0, 1);
            grid.Children.Add(imagenPokemon[2], 0, 2);
            grid.Children.Add(imagenPokemon[3], 0, 3);
            grid.Children.Add(imagenPokemon[4], 0, 4);
            grid.Children.Add(imagenPokemon[5], 0, 5);
            grid.Children.Add(buttonPokemonSe, 0, 6);

            //var nombrePokemon1 = new Label
            //{
            //    Text = "Vacio",
            //    VerticalTextAlignment = TextAlignment.Center,
            //    HorizontalTextAlignment = TextAlignment.Center,
            //    FontSize = 8
            //};

            PokemonRepository rep = new PokemonRepository();
            List<Models.ListaPokemon.Result> listaPokemon = rep.ObtenerLista();

            Picker nombrePokemon1 = new Picker
            {
                Title = "Pokemon",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                StyleId = "0"
            };

            Picker nombrePokemon2 = new Picker
            {
                Title = "Pokemon",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                StyleId = "1"
            };

            Picker nombrePokemon3 = new Picker
            {
                Title = "Pokemon",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                StyleId = "2"
            };

            Picker nombrePokemon4 = new Picker
            {
                Title = "Pokemon",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                StyleId = "3"
            };

            Picker nombrePokemon5 = new Picker
            {
                Title = "Pokemon",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                StyleId = "4"
            };

            Picker nombrePokemon6 = new Picker
            {
                Title = "Pokemon",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                StyleId = "5"
            };

            for (int i = 0; i < listaPokemon.Count(); i++)
            {
                nombrePokemon1.Items.Add(listaPokemon[i].name);
                nombrePokemon2.Items.Add(listaPokemon[i].name);
                nombrePokemon3.Items.Add(listaPokemon[i].name);
                nombrePokemon4.Items.Add(listaPokemon[i].name);
                nombrePokemon5.Items.Add(listaPokemon[i].name);
                nombrePokemon6.Items.Add(listaPokemon[i].name);
            }
            
            // Create BoxView for displaying picked Color
            BoxView boxView = new BoxView
            {
                WidthRequest = 150,
                HeightRequest = 150,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            grid.Children.Add(nombrePokemon1, 1, 0);
            grid.Children.Add(nombrePokemon2, 1, 1);
            grid.Children.Add(nombrePokemon3, 1, 2);
            grid.Children.Add(nombrePokemon4, 1, 3);
            grid.Children.Add(nombrePokemon5, 1, 4);
            grid.Children.Add(nombrePokemon6, 1, 5);

            grid.Children.Add(GlobalVar.HpBarAmigo[0], 2, 0);
            grid.Children.Add(GlobalVar.HpBarAmigo[1], 2, 1);
            grid.Children.Add(GlobalVar.HpBarAmigo[2], 2, 2);
            grid.Children.Add(GlobalVar.HpBarAmigo[3], 2, 3);
            grid.Children.Add(GlobalVar.HpBarAmigo[4], 2, 4);
            grid.Children.Add(GlobalVar.HpBarAmigo[5], 2, 5);

            var buttonPokemon1 = new Button
            {
                FontSize = 10,
                Text = "Seleccionar",
                StyleId = "0"
            };

            var buttonPokemon2 = new Button
            {
                FontSize = 10,
                Text = "Seleccionar",
                StyleId = "1"
            };

            var buttonPokemon3 = new Button
            {
                FontSize = 10,
                Text = "Seleccionar",
                StyleId = "2"
            };

            var buttonPokemon4 = new Button
            {
                FontSize = 10,
                Text = "Seleccionar",
                StyleId = "3"
            };

            var buttonPokemon5 = new Button
            {
                FontSize = 10,
                Text = "Seleccionar",
                StyleId = "4"
            };

            var buttonPokemon6 = new Button
            {
                FontSize = 10,
                Text = "Seleccionar",
                StyleId = "5"
            };

            nombrePokemon1.SelectedIndexChanged += changeSelectedPicker;
            nombrePokemon2.SelectedIndexChanged += changeSelectedPicker;
            nombrePokemon3.SelectedIndexChanged += changeSelectedPicker;
            nombrePokemon4.SelectedIndexChanged += changeSelectedPicker;
            nombrePokemon5.SelectedIndexChanged += changeSelectedPicker;
            nombrePokemon6.SelectedIndexChanged += changeSelectedPicker;

            void changeSelectedPicker(Object sender, EventArgs e)
            {
                Picker nombrePokemon = (Picker)sender;
                if(GlobalVar.entrenadorAmigo.pokemons.Count == 0)
                {
                    GlobalVar.entrenadorAmigo.pokemons.Add(new Models.Pokemon.RootObject());
                    GlobalVar.entrenadorAmigo.pokemons.Add(new Models.Pokemon.RootObject());
                    GlobalVar.entrenadorAmigo.pokemons.Add(new Models.Pokemon.RootObject());
                    GlobalVar.entrenadorAmigo.pokemons.Add(new Models.Pokemon.RootObject());
                    GlobalVar.entrenadorAmigo.pokemons.Add(new Models.Pokemon.RootObject());
                    GlobalVar.entrenadorAmigo.pokemons.Add(new Models.Pokemon.RootObject());
                }
                
                Models.Pokemon.RootObject pokemon = rep.ObtenerPokemon(nombrePokemon.SelectedItem.ToString());
                GlobalVar.entrenadorAmigo.pokemons[int.Parse(nombrePokemon.StyleId)] = pokemon;

                imagenPokemon[int.Parse(nombrePokemon.StyleId)].Source = GlobalVar.entrenadorAmigo.pokemons[int.Parse(nombrePokemon.StyleId)].sprites.front_default;
                
            }

            //    nombrePokemon1.SelectedIndexChanged += (sender, args) =>
            //{
            //    if (picker.SelectedIndex == -1)
            //    {
            //        boxView.Color = Color.Default;
            //    }
            //    else
            //    {
            //        string colorName = picker.Items[picker.SelectedIndex];
            //        boxView.Color = nameToColor[colorName];
            //    }
            //};

            buttonPokemon1.Clicked += Button_click;
            buttonPokemon2.Clicked += Button_click;
            buttonPokemon3.Clicked += Button_click;
            buttonPokemon4.Clicked += Button_click;
            buttonPokemon5.Clicked += Button_click;
            buttonPokemon6.Clicked += Button_click;



            void Button_click(Object sender, EventArgs e)
            {
                Button boton = (Button)sender;

                if (GlobalVar.HpBarAmigo[int.Parse(boton.StyleId)].Progress > 0)
                {
                    GlobalVar.countAmigo = int.Parse(boton.StyleId);

                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Navigation.PushAsync(new BattlePage());
                    });
                }
            }

            //grid.Children.Add(buttonPokemon1, 3, 0);
            //grid.Children.Add(buttonPokemon2, 3, 1);
            //grid.Children.Add(buttonPokemon3, 3, 2);
            //grid.Children.Add(buttonPokemon4, 3, 3);
            //grid.Children.Add(buttonPokemon5, 3, 4);
            //grid.Children.Add(buttonPokemon6, 3, 5);

            return grid;
        }
    }
}
