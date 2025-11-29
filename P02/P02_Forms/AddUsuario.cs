using P02_API_SDK.Dtos;
using P02_API_SDK.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P02_Forms
{
    public partial class AddUsuario : Form
    {
        private readonly UsuariosService usuariosService;
        private readonly UsuarioDTO usuario;
        private bool isEdicao = false;

        public AddUsuario(UsuarioDTO usuario = null)
        {
            this.usuariosService = new UsuariosService("http://localhost:5129", new HttpClient());
            this.usuario = usuario;
            InitializeComponent();
            init();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void init()
        {
            if (usuario == null)
            {
                lblTitle.Text = "Novo usuario";
                return;
            }

            isEdicao = true;
            lblTitle.Text = "Editar usuario";
            txtNome.Text = usuario.Nome;
            txtSenha.Text = usuario.Senha;
            txtConfirmarSenha.Text = usuario.Senha;
            rdAtivo.Checked = usuario.Ativo;
            rdInativo.Checked = !usuario.Ativo;
        }

        private UsuarioDTO getEntity()
        {
            var usuarioDto = new UsuarioDTO()
            {
                Nome = txtNome.Text,
                Senha = txtSenha.Text,
                Ativo = rdAtivo.Checked
            };

            if (isEdicao) usuarioDto.Id = usuario.Id;

            return usuarioDto;

        }

        private bool formIsValid()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Preencha o campo nome");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("Preencha o campo senha");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtConfirmarSenha.Text))
            {
                MessageBox.Show("Preencha o campo confirmar senha");
                return false;
            }

            if (txtSenha.Text != txtConfirmarSenha.Text)
            {
                MessageBox.Show("A senha e a confirmação da senha devem ser iguais");
                return false;
            }

            return true;
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!formIsValid()) return;

            var usuarioDTO = getEntity();
            if (isEdicao)
                await usuariosService.Update(usuarioDTO.Id, usuarioDTO);
            else
                await usuariosService.Create(usuarioDTO);

            this.Close();
        }
    }
}
