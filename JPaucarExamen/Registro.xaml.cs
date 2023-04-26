using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JPaucarExamen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private const double CostoCurso = 3000;
        private const int Cuotas = 3;
        private const double Interes = 0.05;
        private string UserName = string.Empty;

        public Registro(string User)
        {
            InitializeComponent();
            UserName = User;
            LblUser.Text += User;
        }

        private void BtnCalcularTotal_Clicked(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtNombre.Text) || !string.IsNullOrEmpty(TxtMonto.Text))
            {
                if (Convert.ToDouble(TxtMonto.Text) >= CostoCurso)
                {
                    DisplayAlert("Error de validación", $"Debe ingresar un valor menor al costo del curso: {CostoCurso}", "Aceptar");
                    TxtMonto.Text = string.Empty;
                }
                else
                {
                    double recargo = CostoCurso * Interes;
                    double valorDiferido = CostoCurso - Convert.ToDouble(TxtMonto.Text);
                    double cuota = (valorDiferido / Cuotas) + recargo;
                    TxtPagoMensual.Text = Convert.ToString(Math.Round(cuota, 2));
                }
            }
            else
                DisplayAlert("Error de validación", $"No puede dejar campos en blanco!", "Aceptar");
        }

        private void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtPagoMensual.Text) || string.IsNullOrEmpty(TxtNombre.Text) || string.IsNullOrEmpty(TxtMonto.Text))
                DisplayAlert("Error de validación", $"No puede guardar si no ha realizado el cálculo del pago mensual previamente", "Aceptar");
            else
            {
                DisplayAlert("Éxito!", $"Elemento guardado con éxito", "Aceptar");
                string totalPagar = Convert.ToString(Math.Round(Convert.ToDouble(TxtPagoMensual.Text) * Cuotas + Convert.ToDouble(TxtMonto.Text), 2));
                Navigation.PushAsync(new Resumen(UserName, TxtNombre.Text, totalPagar));
            }
        }
    }
}