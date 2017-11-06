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
        FirebaseRepository frep = new FirebaseRepository();

        public MainPage()
        {

            InitializeComponent();

            btPokemon.Clicked += LoadingActive;

            void LoadingActive(Object sender, EventArgs e)
            {
                
                if(rep.ObtenerLogin(txtUsername.Text, txtPass.Text))
                {

                    GlobalVar.pokemonID = txtPokemon.Text;
                    if (GlobalVar.pokemonID != null)
                    {
                        if (!GlobalVar.pokemonID.StartsWith(" "))
                        {
                            GlobalVar.pokemonID = txtPokemon.Text;
                            if (rep.ObtenerPokemon(GlobalVar.pokemonID) != null)
                            {
                                lbLoading.Text = "LOADING";
                                indicator.IsRunning = true;
                                indicator.IsVisible = true;
                                Device.BeginInvokeOnMainThread(async () =>
                                {
                                    await Navigation.PushAsync(new BattlePage());
                                });
                            }
                            else
                            {
                                lbPokemon.TextColor = Color.Red;
                                lbPokemon.Text = "El pokemon introducido no existe";
                            }
                        }
                        else
                        {
                            lbPokemon.TextColor = Color.Red;
                            lbPokemon.Text = "El pokemon introducido no existe";
                        }
                    }
                    else
                    {
                        lbPokemon.TextColor = Color.Red;
                        lbPokemon.Text = "El pokemon introducido no existe";
                    }
                }
                else
                {
                    lbUsername.TextColor = Color.Red;
                    lbUsername.Text = "Usuario o contraseña incorrecta";
                }
            }

            //void LoadingActive(object sender, EventArgs e)
            //{
            //    GlobalVar.pokemonID = txtPokemon.Text;
            //    if (GlobalVar.pokemonID != null)
            //    {
            //        if (!GlobalVar.pokemonID.StartsWith(" "))
            //        {
            //            lbLoading.Text = "LOADING";
            //            GlobalVar.pokemonID = txtPokemon.Text;
            //            if (rep.ObtenerPokemon(GlobalVar.pokemonID) != null)
            //            {
            //                indicator.IsRunning = true;
            //                indicator.IsVisible = true;
            //                Device.BeginInvokeOnMainThread(async () => {
            //                    await Navigation.PushAsync(new BattlePage());
            //                });
            //            }
            //            else
            //            {
            //                indicator.IsRunning = false;
            //                indicator.IsVisible = false;
            //                lbLoading.Text = "El pokemon introducido no existe";
            //            }
            //        }
            //    }
            //}
        }
    }
}