using appPokemon.Models.Repository;
using System;
using appPokemon.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace appPokemon
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        FirebaseRepository rep = new FirebaseRepository();
        //List<string> colores = new List<string>();

        public LoginPage()
        {
            InitializeComponent();

            GlobalVar.InicializarVariables();

            List<appPokemon.Models.User.Pokemon> lista;

            btnLogin.Clicked += LoginCommand;

            async void LoginCommand(Object sender, EventArgs e)
            {
                lista = await rep.Login(txtUsername.Text, txtPass.Text);

                if (lista != null)
                {
                    lbError.TextColor = Color.Black;
                    lbError.Text = "LOADING";

                    if (lista[0].name == "1")
                    {
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            await Navigation.PushAsync(new ListPage());
                        });
                    }
                    else
                    {
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            await Navigation.PushAsync(new BattlePage());
                        });
                    }
                }
                else
                {
                    lbError.TextColor = Color.Red;
                    lbError.Text = "Usuario o contraseña incorrecta";
                }
            }
        }
    }
}