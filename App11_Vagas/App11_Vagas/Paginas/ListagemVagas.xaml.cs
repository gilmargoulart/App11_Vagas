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
	public partial class ListagemVagas : ContentPage
	{
		public ListagemVagas ()
		{
			InitializeComponent ();
		}

        private void BtnAdd_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CadastrarVaga());
        }

        private void BtnListagemVagas_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new ListagemVagas());
        }

        private void BtnMaisDetalhes_Tapped(object sender, EventArgs e)
        {
            Label lblDetalhe = (Label)sender;
            Vaga vaga = (Vaga)((TapGestureRecognizer)lblDetalhe.GestureRecognizers[0]).CommandParameter;
            Navigation.PushAsync(new DetalharVaga(vaga));
        }
    }
}