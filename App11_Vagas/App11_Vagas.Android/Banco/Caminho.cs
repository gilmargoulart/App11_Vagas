using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using App11_Vagas.Banco;
using App11_Vagas.Droid.Banco ;
using System.IO;

[assembly:Dependency(typeof(Caminho))]
namespace App11_Vagas.Droid.Banco
{
    public class Caminho : ICaminho
    {
        public string ObterCaminho(string NomeArquivoBanco)
        {
            
            var caminhoPasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string caminhoDB = Path.Combine(caminhoPasta, NomeArquivoBanco);

            return caminhoDB;
        }
    }
}