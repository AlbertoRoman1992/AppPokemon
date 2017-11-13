using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appPokemon.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using appPokemon.Models.Repository;

namespace appPokemon
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        PokemonRepository rep;

        public ListPage()
        {
            InitializeComponent();

            rep = new PokemonRepository();

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

            List<Image> imagePokemons = new List<Image>();
            Image imagePokemon;

            for (int count = 0; count < 6; count++)
            {
                imagePokemon = new Image();

                imagePokemon.Source = new UriImageSource
                {
                    Uri = new Uri("https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/poke-ball.png")
                };

                imagePokemons.Add(imagePokemon);
            }

            grid.Children.Add(imagePokemons[0], 0, 0);
            grid.Children.Add(imagePokemons[1], 0, 1);
            grid.Children.Add(imagePokemons[2], 0, 2);
            grid.Children.Add(imagePokemons[3], 0, 3);
            grid.Children.Add(imagePokemons[4], 0, 4);
            grid.Children.Add(imagePokemons[5], 0, 5);

            List<Models.ListaPokemon.Result> listaPokemon = rep.ObtenerLista();

            List<Picker> namePokemons = new List<Picker>();
            Picker namePokemon;

            for (int count = 0; count < 6; count++)
            {
                namePokemon = new Picker
                {
                    Title = "Pokemon",
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    StyleId = count.ToString()
                };

                namePokemons.Add(namePokemon);
            }

            for (int count = 0; count < listaPokemon.Count(); count++)
            {
                for (int countPokemons = 0; countPokemons < 6; countPokemons++)
                {
                    namePokemons[countPokemons].Items.Add(listaPokemon[count].name);
                }
            }

            var buttonPokemonSelected = new Button
            {
                FontSize = 10,
                Text = "Seleccionar",
                StyleId = "0"
            };

            grid.Children.Add(namePokemons[0], 1, 0);
            grid.Children.Add(namePokemons[1], 1, 1);
            grid.Children.Add(namePokemons[2], 1, 2);
            grid.Children.Add(namePokemons[3], 1, 3);
            grid.Children.Add(namePokemons[4], 1, 4);
            grid.Children.Add(namePokemons[5], 1, 5);
            grid.Children.Add(buttonPokemonSelected, 1, 6);

            namePokemons[0].SelectedIndexChanged += changeSelectedPicker;
            namePokemons[1].SelectedIndexChanged += changeSelectedPicker;
            namePokemons[2].SelectedIndexChanged += changeSelectedPicker;
            namePokemons[3].SelectedIndexChanged += changeSelectedPicker;
            namePokemons[4].SelectedIndexChanged += changeSelectedPicker;
            namePokemons[5].SelectedIndexChanged += changeSelectedPicker;

            void changeSelectedPicker(Object sender, EventArgs e)
            {
                Picker nombrePokemon = (Picker)sender;

                if (GlobalVar.friendCoach.pokemons.Count == 0)
                {
                    for(int count = 0; count < 6; count++)
                    {
                        GlobalVar.friendCoach.pokemons.Add(new Models.Pokemon.RootObject());
                    }
                }

                Models.Pokemon.RootObject pokemon = rep.ObtenerPokemon(nombrePokemon.SelectedItem.ToString());
                GlobalVar.friendCoach.pokemons[int.Parse(nombrePokemon.StyleId)] = pokemon;

                imagePokemons[int.Parse(nombrePokemon.StyleId)].Source = GlobalLogic.obtenerImagen(int.Parse(nombrePokemon.StyleId), true, true);
            }

            return grid;
        }
    }
}
