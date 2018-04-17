using Xamarin.Forms;
using System;
using System.Text.RegularExpressions;

namespace Comp_dni
{
    public partial class Comp_dniPage : ContentPage
    {
        private const string CORRESPONDENCIA = "TRWAGMYFPDXBNJZSQVHLCKET";

        public Comp_dniPage()
        {
            InitializeComponent();
        }

        private void BtnCheck_Clicked(object sender, EventArgs eventArgs)
        {

            if (CheckDNI(txtDNI.Text)) DisplayAlert("Validación Correcta", "El DNI (" + txtDNI.Text + ") es correcto", "Aceptar");
            else DisplayAlert("Error", "El DNI no es correcto", "Aceptar");

        }

        private Boolean CheckDNI(String dni)
        {
           
            //Se comprueba que el string DNI no sea nulo ni este vacío.
            if (!string.IsNullOrEmpty(dni))
            {

                //Se comprueba que el DNI tenga 9 caracteres.
                if (dni.Length != 9) return false;

                //Se comprueba que los 8 primeros caracteres sean números.
                Match match = new Regex(@"\b(\d{8})\b").Match(dni.Substring(0, dni.Length - 1));
                if (!match.Success) return false;

                //Se comprueba que la letra del DNI corresponda con la que se calcula con el resultado de (número de DNI % 23).
                if (!CORRESPONDENCIA[int.Parse(dni.Substring(0, dni.Length - 1)) % 23].ToString().Equals(dni.Substring(dni.Length - 1, 1).ToUpper()))
                    return false;

            }
            else return false;

            return true;
        }
    }
}
