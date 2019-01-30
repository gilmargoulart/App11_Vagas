using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using App11_Vagas.Modelos;
using Xamarin.Forms;

namespace App11_Vagas.Banco
{
    public class Database
    {
        private SQLiteConnection _conexao;

        public Database()
        {
            var dep = DependencyService.Get<ICaminho>();
            string caminho = dep.ObterCaminho("dbSQLAppVagas.sqlite");
            _conexao = new SQLiteConnection(caminho);
            _conexao.CreateTable<Vaga>();
        }

        public List<Vaga> Pesquisar(string palavra)
        {
            return _conexao.Table<Vaga>().Where(v => v.NomeVaga.Contains(palavra)).ToList();
        }

        public Vaga ObterVagaPorId(int Id)
        {
            return _conexao.Table<Vaga>().Where(v => v.Id == Id).FirstOrDefault();
        }

        public void Cadastro(Vaga vaga)
        {
            _conexao.Insert(vaga);
        }

        public void Atualizacao(Vaga vaga)
        {
            _conexao.Update(vaga);
        }
        public void Exclusao(Vaga vaga)
        {
            _conexao.Delete(vaga);
        }

    }
}
