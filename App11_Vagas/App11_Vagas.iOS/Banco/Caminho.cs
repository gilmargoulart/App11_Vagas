using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foundation;
using UIKit;

using App11_Vagas.Banco;
using Xamarin.Forms;
using System.IO;
using App11_Vagas.iOS.Banco;

[assembly:Dependency(typeof(Caminho))]
namespace App11_Vagas.iOS.Banco
{
    public class Caminho : ICaminho
    {
        public string ObterCaminho(string NomeArquivoBanco)
        {
            var caminhoPasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);


            string caminhoDaBiblioteca = Path.Combine(caminhoPasta, "..", "Library");
            string caminhoDB = Path.Combine(caminhoDaBiblioteca, NomeArquivoBanco);

            return caminhoDB;
        }
    }
}