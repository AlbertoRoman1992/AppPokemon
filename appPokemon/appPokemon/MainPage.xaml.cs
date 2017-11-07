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
        FirebaseRepository rep = new FirebaseRepository();

        public MainPage()
        {
            InitializeComponent();

            GlobalVar xGlobal = new GlobalVar();

            btPokemon.Clicked += LoadingActive;

            void LoadingActive(Object sender, EventArgs e)
            {
                if(rep.Login(txtUsername.Text, txtPass.Text))
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
                    lbUsername.TextColor = Color.Red;
                    lbUsername.Text = "Usuario o contraseña incorrecta";
                }
            }
        }
    }
}