using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JPaucarExamen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private const string User = "estudiante2023";
        private const string Pass = "uisrael2023";
        public Login()
        {
            InitializeComponent();
        }

        private void BtnIngresar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtUsuario.Text) || !string.IsNullOrEmpty(TxtUsuario.Text))
            {
                if (TxtUsuario.Text.Equals(User) && TxtPass.Text.Equals(Pass))
                    Navigation.PushAsync(new Registro(User));
                else
                    DisplayAlert("Error de ingreso", "El usuario y/o contraseña son incorrectos, por favor intente de nuevo", "Aceptar");

                Limpiar();
            }
            else
                DisplayAlert("Error de validación", "No puede dejar campos vacíos, por favor intente de nuevo", "Aceptar");
        }

        private void Limpiar()
        {
            TxtUsuario.Text = string.Empty;
            TxtPass.Text = string.Empty;
        }
    }
}