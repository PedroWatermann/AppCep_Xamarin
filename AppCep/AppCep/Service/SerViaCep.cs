using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using AppCep.Service.Model;
using Newtonsoft.Json;

namespace AppCep.Service
{
    public class SerViaCep
    {
        private static string enderecoUrl = "https://viacep.com.br/ws/{0}/json";

        public static ModEndereco buscarEnderecoViaCep(string cep)
        {
            string novoEnderecoUrl = string.Format(enderecoUrl, cep);

            WebClient wc = new WebClient(); // Abre um cliente para web: como se fosse um túnel para enviar requisições http na web
            string conteudo = wc.DownloadString(novoEnderecoUrl); // Baixar e armazenar todas as strings do conteúdo do site
            ModEndereco endereco = JsonConvert.DeserializeObject<ModEndereco>(conteudo); // Converte o json recebido 

            return endereco.Cep == null ? null : endereco;
        }
    }
}
