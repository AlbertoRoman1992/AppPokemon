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

            List<Image> imagePokemons = new List<Image>();
            Image imagePokemon;

            for (int count = 0; count < 6; count++)
            {
                imagePokemon = new Image();

                imagePokemon.Source = new UriImageSource
                {
                    Uri = new Uri(GlobalLogic.obtenerImagen(0, true, true))
                };

                imagePokemons.Add(imagePokemon);
            }

            grid.Children.Add(imagePokemons[0], 0, 0);
            grid.Children.Add(imagePokemons[1], 0, 1);
            grid.Children.Add(imagePokemons[2], 0, 2);
            grid.Children.Add(imagePokemons[3], 0, 3);
            grid.Children.Add(imagePokemons[4], 0, 4);
            grid.Children.Add(imagePokemons[5], 0, 5);

            List<Label> namePokemons = new List<Label>();
            Label namePokemon;

            for (int count = 0; count < 6; count++)
            {
                namePokemon = new Label
                {
                    Text = GlobalVar.friendCoach.user.pokemons[count].name,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    FontSize = 8
                };

                namePokemons.Add(namePokemon);
            }

            grid.Children.Add(namePokemons[0], 1, 0);
            grid.Children.Add(namePokemons[1], 1, 1);
            grid.Children.Add(namePokemons[2], 1, 2);
            grid.Children.Add(namePokemons[3], 1, 3);
            grid.Children.Add(namePokemons[4], 1, 4);
            grid.Children.Add(namePokemons[5], 1, 5);

            List<ProgressBar> hpBarPokemons = new List<ProgressBar>();
            ProgressBar hpBarPokemon = new ProgressBar();

            for(int count = 0; count < 6; count++)
            {
                // Para el cálculo de la vida máxima
                GlobalVar.pokAmigo = count;

                hpBarPokemon = new ProgressBar
                {
                    Progress = ((double)GlobalVar.friendCoach.user.pokemons[count].hp / (double)GlobalLogic.vidaMaxima(true))
                };

                hpBarPokemons.Add(hpBarPokemon);
            }

            grid.Children.Add(hpBarPokemons[0], 2, 0);
            grid.Children.Add(hpBarPokemons[1], 2, 1);
            grid.Children.Add(hpBarPokemons[2], 2, 2);
            grid.Children.Add(hpBarPokemons[3], 2, 3);
            grid.Children.Add(hpBarPokemons[4], 2, 4);
            grid.Children.Add(hpBarPokemons[5], 2, 5);

            List<Button> buttonPokemons = new List<Button>();
            Button buttonPokemon = new Button();

            for(int count = 0; count < 6; count++)
            {
                buttonPokemon = new Button
                {
                    FontSize = 10,
                    Text = "Te elijo a ti!",
                    StyleId = count.ToString()
                };

                buttonPokemons.Add(buttonPokemon);
            }

            for(int count = 0; count < 6; count++)
            {
                buttonPokemons[count].Clicked += Button_click;
            }

            void Button_click(Object sender, EventArgs e)
            {
                Button boton = (Button)sender;

                if (GlobalVar.friendCoach.user.pokemons[int.Parse(boton.StyleId)].hp > 0)
                {
                    GlobalVar.pokAmigo = int.Parse(boton.StyleId);

                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Navigation.PushAsync(new BattlePage());
                    });
                }
            }

            grid.Children.Add(buttonPokemons[0], 3, 0);
            grid.Children.Add(buttonPokemons[1], 3, 1);
            grid.Children.Add(buttonPokemons[2], 3, 2);
            grid.Children.Add(buttonPokemons[3], 3, 3);
            grid.Children.Add(buttonPokemons[4], 3, 4);
            grid.Children.Add(buttonPokemons[5], 3, 5);

            return grid;
        }
    }
}