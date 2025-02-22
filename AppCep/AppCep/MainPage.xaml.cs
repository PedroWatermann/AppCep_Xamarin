using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppCep.Service.Model;
using AppCep.Service;

namespace AppCep
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btnBuscar.Clicked += buscarCep;
        }

        private void buscarCep(object sender, EventArgs e)
        {
            string cep = entCep.Text.Trim();
            if (isValidCep(cep))
            {
                try
                {
                    ModEndereco endereco = SerViaCep.buscarEnderecoViaCep(cep);

                    if (endereco != null)
                    {
                        lblResultado.Text = string.Format("Endereço: {2}, {3}, {0} {1}.", endereco.Localidade, endereco.Uf, endereco.Logradouro, endereco.Bairro);
                        entCep.Text = "";
                    }
                    else
                    {
                        DisplayAlert("Erro", $"O CEP {cep} não foi encontrado!", "OK");
                        entCep.Text = "";
                    }
                }
                catch (Exception er)
                {
                    DisplayAlert("Erro Fatal", $"Erro: {er.Message}", "OK");
                }
            }
        }

        private bool isValidCep(string cep)
        {
            bool valido = true;

            if (cep.Length != 8)
            {
                DisplayAlert("Erro", "CEP inválido!\n\nO CEP deve conter 8 números", "OK");
                valido = false;
            }

            int novoCep = 0;
            if (!int.TryParse(cep, out novoCep))
            {
                DisplayAlert("Erro", "O CEP deve conter apenas números!", "OK");
                valido = false;
            }

            return valido;
        }
    }
}
