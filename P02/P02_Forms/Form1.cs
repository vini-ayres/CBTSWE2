using P02_API_SDK.Dtos;
using P02_API_SDK.Services;
using System.Data;
using System.Windows.Forms;

namespace P02_Forms
{
    public partial class Form1 : Form
    {
        private readonly UsuariosService usuariosService;
        public Form1()
        {
            InitializeComponent();
            usuariosService = new UsuariosService("http://localhost:5129", new HttpClient());
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await loadDataGrid();
            createButtonsDataGrid();
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await loadDataGrid();
        }
        private void btnNovoUsuario_Click(object sender, EventArgs e)
        {
            var addUser = new AddUsuario();
            addUser.FormClosed += async (object sender, FormClosedEventArgs e) => { await loadDataGrid(); };
            addUser.ShowDialog();
        }

        private async Task loadDataGrid()
        {
            if (string.IsNullOrWhiteSpace(txtBusca.Text))
                dgUsuarios.DataSource = await usuariosService.GetAll();
            else
                dgUsuarios.DataSource = await usuariosService.GetByName(txtBusca.Text);
        }

        private void createButtonsDataGrid()
        {
            DataGridViewButtonColumn editarButtonColumn = new DataGridViewButtonColumn();
            editarButtonColumn.HeaderText = "Editar";
            editarButtonColumn.Name = "Editar";
            editarButtonColumn.Text = "Editar";
            editarButtonColumn.UseColumnTextForButtonValue = true;
            dgUsuarios.Columns.Add(editarButtonColumn);

            DataGridViewButtonColumn excluirButtonColumn = new DataGridViewButtonColumn();
            excluirButtonColumn.HeaderText = "Excluir";
            excluirButtonColumn.Name = "Excluir";
            excluirButtonColumn.Text = "Excluir";
            excluirButtonColumn.UseColumnTextForButtonValue = true;
            dgUsuarios.Columns.Add(excluirButtonColumn);
        }

        private async void dgUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int Editar = dgUsuarios.Columns["Editar"].Index;
            int Excluir = dgUsuarios.Columns["Excluir"].Index;

            var usuarios = dgUsuarios.DataSource as List<UsuarioDTO>;
            var usuario = usuarios[e.RowIndex];

            if (e.ColumnIndex == Editar && e.RowIndex >= 0)
            {
                var addUser = new AddUsuario(usuario);
                addUser.FormClosed += async (object sender, FormClosedEventArgs e) => { await loadDataGrid(); };
                addUser.ShowDialog();
            }

            if (e.ColumnIndex == Excluir && e.RowIndex >= 0)
            {
                await usuariosService.Delete(usuario.Id);
                loadDataGrid();
            }
        }
    }
}