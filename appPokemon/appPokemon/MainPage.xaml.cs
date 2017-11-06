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
        PokemonRepository rep = new PokemonRepository();

        public MainPage()
        {

            InitializeComponent();

            btPokemon.Clicked += LoadingActive;

            void LoadingActive(object sender, EventArgs e)
            {
                GlobalVar.PokemonSelected = txtPokemon.Text;
                if (GlobalVar.PokemonSelected != null)
                {
                    if (!GlobalVar.PokemonSelected.StartsWith(" "))
                    {
                        lbLoading.Text = "LOADING";
                        GlobalVar.PokemonSelected = txtPokemon.Text;
                        if (rep.ObtenerPokemon(GlobalVar.PokemonSelected) != null)
                        {
                            indicator.IsRunning = true;
                            indicator.IsVisible = true;
                            Device.BeginInvokeOnMainThread(async () => {
                                await Navigation.PushAsync(new SecondaryPage());
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