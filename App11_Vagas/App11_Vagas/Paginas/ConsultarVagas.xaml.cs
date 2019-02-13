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
    public partial class ConsultarVagas : ContentPage
    {
        List<Vaga> Lista { get; set; }
        
        public ConsultarVagas()
        {
            InitializeComponent();
            AtualizarLista();
        }

        private void AtualizarLista()
        {
            Database db = new Database();
            Lista = db.Pesquisar("");
            ListaVagas.ItemsSource = Lista;
            lblCount.Text = string.Format("{0} registros encontrados", Lista.Count.ToString());
        }

        private void BtnEditar_Tapped(object sender, EventArgs e)
        {
            Label lblEditar = (Label)sender;
            Vaga vaga = (Vaga)((TapGestureRecognizer)lblEditar.GestureRecognizers[0]).CommandParameter;
            Navigation.PushAsync(new EditarVaga(vaga));
        }

        private void BtnExcluir_Tapped(object sender, EventArgs e)
        {
            Label lblExcluir = (Label)sender;
            Vaga vaga = (Vaga)((TapGestureRecognizer)lblExcluir.GestureRecognizers[0]).CommandParameter;

            Database db = new Database();
            db.Exclusao(vaga);

            AtualizarLista();
        }

        private void BtnAdd_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CadastrarVaga());
        }

        private void BtnListagemVagas_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListagemVagas());
        }

        private void BtnMaisDetalhes_Tapped(object sender, EventArgs e)
        {
            Label lblDetalhe = (Label)sender;
            Vaga vaga = (Vaga)((TapGestureRecognizer)lblDetalhe.GestureRecognizers[0]).CommandParameter;
            Navigation.PushAsync(new DetalharVaga(vaga));
        }
        
        private void Pesquisar_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListaVagas.ItemsSource = Lista.Where(a => a.NomeVaga.Contains(e.NewTextValue)).ToList();
        }
    }
}