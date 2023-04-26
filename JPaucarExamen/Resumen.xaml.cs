using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JPaucarExamen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Resumen : ContentPage
    {
        public Resumen(string User, string Nombre, string TotalPagar)
        {
            InitializeComponent();
            TxtUser.Text = User;
            TxtNombre.Text = Nombre;
            TxtPagoTotal.Text = TotalPagar;
        }

        private void BtnCerrar_Clicked(object sender, System.EventArgs e)
        {
            DisplayAlert("Éxito", $"Se terminó la ejecución de la aplicación!", "Aceptar");
        }
    }
}