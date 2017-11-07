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

            GlobalVar xGlobal = new GlobalVar();

            
            //pickerColor.Items.Add("Bulbasaur");
            //pickerColor.Items.Add("mew");
            //pickerColor.Items.Add("Bulb");
            //pickerColor.Items.Add("mewtwo");
            //pickerColor.Items.Add("Bulbasaur");
            //pickerColor.Items.Add("mew");
            //pickerColor.Items.Add("Bulb");
            //pickerColor.Items.Add("mewtwo");
            //pickerColor.Items.Add("Bulbasaur");
            //pickerColor.Items.Add("mew");
            //pickerColor.Items.Add("Bulb");
            //pickerColor.Items.Add("mewtwo");
            //pickerColor.Items.Add("Bulbasaur");
            //pickerColor.Items.Add("mew");
            //pickerColor.Items.Add("Bulb");
            //pickerColor.Items.Add("mewtwo");
            //pickerColor.Items.Add("Bulbasaur");
            //pickerColor.Items.Add("mew");
            //pickerColor.Items.Add("Bulb");
            //pickerColor.Items.Add("mewtwo");
            //pickerColor.Items.Add("Bulbasaur");
            //pickerColor.Items.Add("mew");
            //pickerColor.Items.Add("Bulb");
            //pickerColor.Items.Add("mewtwo");

            btnLogin.Clicked += LoginCommand;

            void LoginCommand(Object sender, EventArgs e)
            {
                if (rep.Login(txtUsername.Text, txtPass.Text))
                {
                    lbError.TextColor = Color.Black;
                    lbError.Text = "LOADING";
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Navigation.PushAsync(new BattlePage());
                    });
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