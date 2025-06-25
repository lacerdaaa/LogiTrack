using LogiTrack.Desktop.Services;
using LogiTrack.Desktop.Utils;

namespace LogiTrack.Desktop.Forms
{
    public partial class FormPrincipal : Form
    {
        private readonly FormService _formService;

        public FormPrincipal(FormService formService)
        {
            InitializeComponent();
            _formService = formService;
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            lblData.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 60000;
            timer.Tick += (s, e) => lblData.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            timer.Start();
        }

        private void mnuProdutos_Click(object sender, EventArgs e)
        {
            try
            {
                _formService.ShowForm<FormProdutos>(this);
                lblStatus.Text = "Produtos aberto";
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Erro ao abrir produtos: {ex.Message}");
            }
        }

        private void mnuCategorias_Click(object sender, EventArgs e)
        {
            try
            {
                _formService.ShowForm<FormCategorias>(this);
                lblStatus.Text = "Categorias aberto";
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Erro ao abrir categorias: {ex.Message}");
            }
        }

        private void mnuSair_Click(object sender, EventArgs e)
        {
            if (MessageHelper.ShowConfirmation("Deseja realmente sair do sistema?"))
            {
                Application.Exit();
            }
        }

        private void mnuSobre_Click(object sender, EventArgs e)
        {
            MessageHelper.ShowInfo(
                "LogiTrack - Sistema de Estoque\n" +
                "Versão 1.0\n" +
                "Desenvolvido com .NET 8 e Windows Forms\n" +
                "Utilizando Entity Framework Core e MySQL",
                "Sobre o Sistema");
        }

        private MenuStrip mnuPrincipal;
        private ToolStripMenuItem Sair;
        private ToolStripMenuItem mnuProdutos;
        private ToolStripMenuItem mnuCategorias;
        private ToolStripMenuItem relatóriosToolStripMenuItem;
        private ToolStripMenuItem estoqueBaixoToolStripMenuItem;
        private ToolStripMenuItem produtosPorCategoriaToolStripMenuItem;
        private ToolStripMenuItem ajudaToolStripMenuItem;
        private ToolStripMenuItem sobreToolStripMenuItem;
        private ToolStripMenuItem mnuSair;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
        private ToolStripStatusLabel lblData;
    }
}