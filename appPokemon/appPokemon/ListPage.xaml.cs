using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appPokemon.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace appPokemon
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();

            Image imagenNull = new Image();

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
                Uri = new Uri("https://image.shutterstock.com/z/stock-vector-default-red-rubber-stamp-isolated-on-white-background-grunge-rectangular-seal-with-text-ink-513816427.jpg")
            };

            var imagenPokemon2 = new Image();
            imagenPokemon2.Source = new UriImageSource
            {
                Uri = new Uri("https://image.shutterstock.com/z/stock-vector-default-red-rubber-stamp-isolated-on-white-background-grunge-rectangular-seal-with-text-ink-513816427.jpg")
            };

            var imagenPokemon3 = new Image();
            imagenPokemon3.Source = new UriImageSource
            {
                Uri = new Uri("https://image.shutterstock.com/z/stock-vector-default-red-rubber-stamp-isolated-on-white-background-grunge-rectangular-seal-with-text-ink-513816427.jpg")
            };

            var imagenPokemon4 = new Image();
            imagenPokemon4.Source = new UriImageSource
            {
                Uri = new Uri("https://image.shutterstock.com/z/stock-vector-default-red-rubber-stamp-isolated-on-white-background-grunge-rectangular-seal-with-text-ink-513816427.jpg")
            };

            var imagenPokemon5 = new Image();
            imagenPokemon5.Source = new UriImageSource
            {
                Uri = new Uri("https://image.shutterstock.com/z/stock-vector-default-red-rubber-stamp-isolated-on-white-background-grunge-rectangular-seal-with-text-ink-513816427.jpg")
            };

            var imagenPokemon6 = new Image();
            imagenPokemon6.Source = new UriImageSource
            {
                Uri = new Uri("https://image.shutterstock.com/z/stock-vector-default-red-rubber-stamp-isolated-on-white-background-grunge-rectangular-seal-with-text-ink-513816427.jpg")
            };

            grid.Children.Add(imagenPokemon1, 0, 0);
            grid.Children.Add(imagenPokemon2, 0, 1);
            grid.Children.Add(imagenPokemon3, 0, 2);
            grid.Children.Add(imagenPokemon4, 0, 3);
            grid.Children.Add(imagenPokemon5, 0, 4);
            grid.Children.Add(imagenPokemon6, 0, 5);

            var nombrePokemon1 = new Label
            {
                Text = "Vacio",
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 8
            };

            var nombrePokemon2 = new Label
            {
                Text = "Vacio",
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 8
            };

            var nombrePokemon3 = new Label
            {
                Text = "Vacio",
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 8
            };

            var nombrePokemon4 = new Label
            {
                Text = "Vacio",
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 8
            };

            var nombrePokemon5 = new Label
            {
                Text = "Vacio",
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 8
            };

            var nombrePokemon6 = new Label
            {
                Text = "Vacio",
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
