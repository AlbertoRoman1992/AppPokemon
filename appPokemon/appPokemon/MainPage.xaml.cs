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
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
            buscarPokemon.Clicked += BuscarPokemonClicked;
        }

        public void BuscarPokemonClicked(object sender, EventArgs e)
        {
            loading.IsVisible = true;
            loading.IsRunning = true;

            GlobalVar.pokemonID = pokemonID.Text;

            Navigation.PushAsync(new BattlePage()).ConfigureAwait(false);
        }
    }
}