using App11_Vagas.Modelos;
using App11_Vagas.Banco;
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
	public partial class EditarVaga : ContentPage
	{

        private Vaga _vaga;

		public EditarVaga (Vaga vaga = null)
		{
			InitializeComponent ();
            _vaga = vaga;

            txtVaga.Text = _vaga.NomeVaga;
            txtQuantidade.Text = _vaga.Quantidade.ToString();
            txtCidade.Text = _vaga.Cidade;
            txtDescCargo.Text = _vaga.Descricao;
            txtEmail.Text = _vaga.Email;
            txtEmpresa.Text = _vaga.Empresa;
            txtSalario.Text = _vaga.Salario.ToString();
            txtTelefone.Text = _vaga.Telefone;
            txtTpContratacao.IsToggled = (_vaga.TipoContratacao=="PJ" ? true : false);

        }

        private void ButtonSalvar_Clicked(object sender, EventArgs e)
        {
            // Obter dados
            _vaga.NomeVaga = txtVaga.Text;
            _vaga.Quantidade = short.Parse(txtQuantidade.Text);
            _vaga.Cidade = txtCidade.Text;
            _vaga.Descricao = txtDescCargo.Text;
            _vaga.Email = txtEmail.Text;
            _vaga.Empresa = txtEmpresa.Text;
            _vaga.Salario = double.Parse(txtSalario.Text);
            _vaga.Telefone = txtTelefone.Text;
            _vaga.TipoContratacao = txtTpContratacao.IsToggled ? "PJ" : "CLT";

            // Gravar no Banco
            Database db = new Database();
            db.Atualizacao(_vaga);

            // Redirecionar pra tela inicial
            App.Current.MainPage = new NavigationPage(new ConsultarVagas());
        }
    }
}