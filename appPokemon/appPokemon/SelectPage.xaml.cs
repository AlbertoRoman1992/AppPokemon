using appPokemon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace appPokemon
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectPage : ContentPage
    {
        public SelectPage()
        {
            InitializeComponent();

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

            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            var imagenPokemon1 = new Image();
            imagenPokemon1.Source = new UriImageSource
            {
                Uri = new Uri(GlobalVar.entrenadorAmigo.pokemons[0].sprites.front_default)
            };

            var imagenPokemon2 = new Image();
            imagenPokemon2.Source = new UriImageSource
            {
                Uri = new Uri(GlobalVar.entrenadorAmigo.pokemons[1].sprites.front_default)
            };

            var imagenPokemon3 = new Image();
            imagenPokemon3.Source = new UriImageSource
            {
                Uri = new Uri(GlobalVar.entrenadorAmigo.pokemons[2].sprites.front_default)
            };

            var imagenPokemon4 = new Image();
            imagenPokemon4.Source = new UriImageSource
            {
                Uri = new Uri(GlobalVar.entrenadorAmigo.pokemons[3].sprites.front_default)
            };

            var imagenPokemon5 = new Image();
            imagenPokemon5.Source = new UriImageSource
            {
                Uri = new Uri(GlobalVar.entrenadorAmigo.pokemons[4].sprites.front_default)
            };

            var imagenPokemon6 = new Image();
            imagenPokemon6.Source = new UriImageSource
            {
                Uri = new Uri(GlobalVar.entrenadorAmigo.pokemons[5].sprites.front_default)
            };

            grid.Children.Add(imagenPokemon1, 0, 0);
            grid.Children.Add(imagenPokemon2, 0, 1);
            grid.Children.Add(imagenPokemon3, 0, 2);
            grid.Children.Add(imagenPokemon4, 0, 3);
            grid.Children.Add(imagenPokemon5, 0, 4);
            grid.Children.Add(imagenPokemon6, 0, 5);

            var nombrePokemon1 = new Label
            {
                Text = GlobalVar.entrenadorAmigo.pokemons[0].name,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 8
            };

            var nombrePokemon2 = new Label
            {
                Text = GlobalVar.entrenadorAmigo.pokemons[1].name,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 8
            };

            var nombrePokemon3 = new Label
            {
                Text = GlobalVar.entrenadorAmigo.pokemons[2].name,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 8
            };

            var nombrePokemon4 = new Label
            {
                Text = GlobalVar.entrenadorAmigo.pokemons[3].name,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 8
            };

            var nombrePokemon5 = new Label
            {
                Text = GlobalVar.entrenadorAmigo.pokemons[4].name,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 8
            };

            var nombrePokemon6 = new Label
            {
                Text = GlobalVar.entrenadorAmigo.pokemons[5].name,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 8
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
                Text = "Te elijo a ti!",
                StyleId = "0"
            };

            var buttonPokemon2 = new Button
            {
                FontSize = 10,
                Text = "Te elijo a ti!",
                StyleId = "1"
            };

            var buttonPokemon3 = new Button
            {
                FontSize = 10,
                Text = "Te elijo a ti!",
                StyleId = "2"
            };

            var buttonPokemon4 = new Button
            {
                FontSize = 10,
                Text = "Te elijo a ti!",
                StyleId = "3"
            };

            var buttonPokemon5 = new Button
            {
                FontSize = 10,
                Text = "Te elijo a ti!",
                StyleId = "4"
            };

            var buttonPokemon6 = new Button
            {
                FontSize = 10,
                Text = "Te elijo a ti!",
                StyleId = "5"
            };

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

            grid.Children.Add(buttonPokemon1, 3, 0);
            grid.Children.Add(buttonPokemon2, 3, 1);
            grid.Children.Add(buttonPokemon3, 3, 2);
            grid.Children.Add(buttonPokemon4, 3, 3);
            grid.Children.Add(buttonPokemon5, 3, 4);
            grid.Children.Add(buttonPokemon6, 3, 5);

            return grid;
        }
    }
}