using appPokemon.Models;
using appPokemon.Models.Repository;
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
        PokemonRepository rep = new PokemonRepository();

        public MainPage()
        {

            InitializeComponent();

            btPokemon.Clicked += LoadingActive;

            void LoadingActive(object sender, EventArgs e)
            {
                GlobalVar.pokemonID = txtPokemon.Text;
                if (GlobalVar.pokemonID != null)
                {
                    if (!GlobalVar.pokemonID.StartsWith(" "))
                    {
                        lbLoading.Text = "LOADING";
                        GlobalVar.pokemonID = txtPokemon.Text;
                        if (rep.ObtenerPokemon(GlobalVar.pokemonID) != null)
                        {
                            indicator.IsRunning = true;
                            indicator.IsVisible = true;
                            Device.BeginInvokeOnMainThread(async () => {
                                await Navigation.PushAsync(new BattlePage());
                            });
                        }
                        else
                        {
                            indicator.IsRunning = false;
                            indicator.IsVisible = false;
                            lbLoading.Text = "El pokemon introducido no existe";
                        }
                    }
                }
            }
        }
    }
}