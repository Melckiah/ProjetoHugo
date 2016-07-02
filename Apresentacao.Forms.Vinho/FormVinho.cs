using Applications.Services.Servico;
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

namespace Apresentacao.Forms.Vinho
{
    public partial class FormVinho : Form
    {
        private List<Domain.Model.Entity.Vinho> _vinhos;
        private VinhoAplicacao _aplicacao = new VinhoAplicacao(new VinhoRepositorio());

        private int _indice;

        public Vinho()
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
                txtEspecie.Text = "";
                txtLevel.Text = "";
                txtNome.Text = "";
                txtTipo1.Text = "";
                txtTipo2.Text = "";

                btSalvar.Enabled = false;
                btExcluir.Enabled = false;
            }
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            var vinho = _vinhos.ElementAt(_indice);

            vinho.Nome = txtNome.Text;
            vinho.Level = txtLevel.Text;
            vinho.Tipo1 = txtTipo1.Text;
            vinho.Tipo2 = txtTipo2.Text;
            vinho.Especie = txtEspecie.Text;

            _aplicacao.Atualizar(vinho);
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
            var vinho = new Dominio.Entidade.Vinho();

            vinho.Nome = txtNome.Text;
            vinho.Level = txtLevel.Text;
            vinho.Tipo1 = txtTipo1.Text;
            vinho.Tipo2 = txtTipo2.Text;
            vinho.Especie = txtEspecie.Text;

            btAnterior.Enabled = true;
            btExcluir.Enabled = true;
            btProximo.Enabled = true;
            btSalvar.Enabled = true;

            _aplicacao.Criar(vinho);

            IniciarDados();
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

        private void CarregarDados()
        {
            var vinho = _vinhos.ElementAt(_indice);
            txtTipo1.Text = vinho.Tipo1;
            txtTipo2.Text = vinho.Tipo2;
            txtNome.Text = vinho.Nome;
            txtLevel.Text = vinho.Level;
            txtEspecie.Text = vinho.Especie;
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            var vinho = _vinhos.ElementAt(_indice);

            _aplicacao.Deletar(vinho);

            IniciarDados();
        }
    }
}