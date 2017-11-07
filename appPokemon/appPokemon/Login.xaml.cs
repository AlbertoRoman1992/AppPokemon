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
	public partial class Login : ContentPage
	{
        PokemonRepository rep = new PokemonRepository();
        List<string> colores = new List<string>();
        
		public Login ()
		{
			InitializeComponent ();

            btnLogin.Clicked += LoginCommand;
            pickerColor.Items.Add("Bulbasaur");
            pickerColor.Items.Add("mew");
            pickerColor.Items.Add("Bulb");
            pickerColor.Items.Add("mewtwo");
            pickerColor.Items.Add("Bulbasaur");
            pickerColor.Items.Add("mew");
            pickerColor.Items.Add("Bulb");
            pickerColor.Items.Add("mewtwo");
            pickerColor.Items.Add("Bulbasaur");
            pickerColor.Items.Add("mew");
            pickerColor.Items.Add("Bulb");
            pickerColor.Items.Add("mewtwo");
            pickerColor.Items.Add("Bulbasaur");
            pickerColor.Items.Add("mew");
            pickerColor.Items.Add("Bulb");
            pickerColor.Items.Add("mewtwo");
            pickerColor.Items.Add("Bulbasaur");
            pickerColor.Items.Add("mew");
            pickerColor.Items.Add("Bulb");
            pickerColor.Items.Add("mewtwo");
            pickerColor.Items.Add("Bulbasaur");
            pickerColor.Items.Add("mew");
            pickerColor.Items.Add("Bulb");
            pickerColor.Items.Add("mewtwo");


            void LoginCommand(Object sender, EventArgs e)
            {
                if (rep.ObtenerLogin(txtUsername.Text, txtPass.Text))
                {

                    GlobalVar.pokemonID = "1";
                    if (GlobalVar.pokemonID != null)
                    {
                        if (!GlobalVar.pokemonID.StartsWith(" "))
                        {
                            
                            
                            if (rep.ObtenerPokemon(GlobalVar.pokemonID) != null)
                            {
                               
                                Device.BeginInvokeOnMainThread(async () =>
                                {
                                    await Navigation.PushAsync(new BattlePage());
                                });
                            }
                            else
                            {
                                
                            }
                        }
                    }
                }
                else
                {
                    lbError.Text = "Usuario o contraseña incorrecta"; 
                }
            }
                
            }

            void LoadingActive(Object sender, EventArgs e)
            {

        }
            void PickerItemChanged(Object sender, System.EventArgs e)
            {
                
            }


	}
}