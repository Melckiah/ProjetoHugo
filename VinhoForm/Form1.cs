using Applications.Services;
using Applications.Services.Servico;
using Domain.Model.Entity;
using Domain.Model.Repository;
using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VinhoDados.Repositorio;
using Applications.Services;


namespace VinhoForm
{

    public partial class Form1 : Form
    {
        private List<Domain.Model.Entity.Vinho> _vinhos;
        private VinhoAplicacao _aplicacao = new VinhoAplicacao(new VinhoRepositorio());
        private TwitterAplicacao _twitterapp = new TwitterAplicacao();
        private int _indice;

        public Form1()
        {
            InitializeComponent();

            IniciarDados();
        }
        public void IniciarDados()
        {
            _indice = 0;

            _vinhos = _aplicacao.RetornarTodos();

            btAnterior.Enabled = false;
            if (_vinhos.Count < 2)
                btProximo.Enabled = false;

            if (_vinhos.Count > 0)
            {
                CarregarDados();
            }
            else
            {
                txtNome.Text = "";
                txtDescricao.Text = "";
                txtTeor.Text = "";
                txtColoracao.Text = "";
                
                btSalvar.Enabled = false;
                btExcluir.Enabled = false;
            }
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            var vinho = _vinhos.ElementAt(_indice);

            vinho.Nome = txtNome.Text;
            vinho.Descricao = txtDescricao.Text;
            vinho.Coloracao = txtColoracao.Text;
            vinho.Graduacao = txtTeor.Text;

            _aplicacao.Atualizar(vinho);
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            var vinho = _vinhos.ElementAt(_indice);

            _aplicacao.Deletar(vinho);

            IniciarDados();
        }

        private void CarregarDados()
        {
            var vinho = _vinhos.ElementAt(_indice);
            txtNome.Text = vinho.Nome;
            txtDescricao.Text = vinho.Descricao;
            txtTeor.Text = vinho.Graduacao;
            txtColoracao.Text = vinho.Coloracao;
            
        }

        private void btProximo_Click(object sender, EventArgs e)
        {
            if (_indice == 0)
                btAnterior.Enabled = true;

            _indice++;
            CarregarDados();

            if (_indice == _vinhos.Count - 1)
                btProximo.Enabled = false;
        }

        private void btAnterior_Click(object sender, EventArgs e)
        {
            if (_indice == _vinhos.Count - 1)
                btProximo.Enabled = true;

            _indice--;
            CarregarDados();

            if (_indice == 0)
                btAnterior.Enabled = false;
        }

        private void btCriar_Click(object sender, EventArgs e)
        {
            var vinho = new Domain.Model.Entity.Vinho();

            vinho.Nome = txtNome.Text;
            vinho.Descricao = txtDescricao.Text;
            vinho.Coloracao = txtColoracao.Text;
            vinho.Graduacao = txtTeor.Text;
            
            btAnterior.Enabled = true;
            btExcluir.Enabled = true;
            btProximo.Enabled = true;
            btSalvar.Enabled = true;

            _aplicacao.Criar(vinho);


            _twitterapp.Criar();

            




            IniciarDados();
        }
    }
}
