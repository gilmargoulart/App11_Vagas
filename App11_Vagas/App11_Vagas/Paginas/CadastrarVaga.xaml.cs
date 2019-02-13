using App11_Vagas.Banco;
using App11_Vagas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App11_Vagas.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadastrarVaga : ContentPage
	{
		public CadastrarVaga (Vaga vaga = null)
		{
			InitializeComponent ();
            if (vaga != null)
            {

            }
		}
        
        private void ButtonSalvar_Clicked(object sender, EventArgs e)
        {
            // Obter dados
            Vaga vaga = new Vaga()
            {
                NomeVaga = txtVaga.Text,
                Quantidade = short.Parse(txtQuantidade.Text),
                Cidade = txtCidade.Text,
                Descricao = txtDescCargo.Text,
                Email = txtEmail.Text,
                Empresa = txtEmpresa.Text,
                Salario = double.Parse(txtSalario.Text),
                Telefone = txtTelefone.Text,
                TipoContratacao = txtTpContratacao.IsToggled ? "PJ" : "CLT"
            };

            // Gravar no Banco
            Database db = new Database();
            db.Cadastro(vaga);

            // Voltar
            App.Current.MainPage = new NavigationPage(new ConsultarVagas());
        }
    }
}