using LogiTrack.Core.Models;
using LogiTrack.Core.Services;
using LogiTrack.Core.Services.Interfaces;
using LogiTrack.Desktop.Services;
using LogiTrack.Desktop.Utils;

namespace LogiTrack.Desktop.Forms
{
    public partial class FormProdutos : Form
    {
        private readonly IProdutoService _produtoService;
        private readonly FormService _formService;
        private List<Produto> _produtos = new();

        public FormProdutos(IProdutoService produtoService, FormService formService)
        {
            InitializeComponent();
            _produtoService = produtoService;
            _formService = formService;
            ConfigurarGrid();
            _ = CarregarProdutosAsync();
        }

        private void ConfigurarGrid()
        {
            dgvProdutos.AutoGenerateColumns = false;
            dgvProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProdutos.MultiSelect = false;

            dgvProdutos.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", DataPropertyName = "Id", Width = 60 },
                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", DataPropertyName = "Nome", Width = 200 },
                new DataGridViewTextBoxColumn { Name = "Categoria", HeaderText = "Categoria", DataPropertyName = "Categoria.Nome", Width = 120 },
                new DataGridViewTextBoxColumn { Name = "Preco", HeaderText = "Preço", DataPropertyName = "Preco", Width = 80, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } },
                new DataGridViewTextBoxColumn { Name = "Estoque", HeaderText = "Estoque", DataPropertyName = "QuantidadeEstoque", Width = 80 },
                new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status", DataPropertyName = "Ativo", Width = 80 }
            });
        }

        private async Task CarregarProdutosAsync()
        {
            try
            {
                _produtos = (await _produtoService.ObterTodosAsync()).ToList();
                dgvProdutos.DataSource = _produtos;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Erro ao carregar produtos: {ex.Message}");
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBusca.Text))
                {
                    await CarregarProdutosAsync();
                }
                else
                {
                    _produtos = (await _produtoService.BuscarPorNomeAsync(txtBusca.Text)).ToList();
                    dgvProdutos.DataSource = _produtos;
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Erro na busca: {ex.Message}");
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            var form = _formService.CreateForm<FormProdutoDetalhes>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _ = CarregarProdutosAsync();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.SelectedRows.Count == 0)
            {
                MessageHelper.ShowWarning("Selecione um produto para editar.");
                return;
            }

            var produto = (Produto)dgvProdutos.SelectedRows[0].DataBoundItem;
            var form = _formService.CreateForm<FormProdutoDetalhes>();

            if (form.ShowDialog() == DialogResult.OK)
            {
                _ = CarregarProdutosAsync();
            }
        }

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.SelectedRows.Count == 0)
            {
                MessageHelper.ShowWarning("Selecione um produto para excluir.");
                return;
            }

            var produto = (Produto)dgvProdutos.SelectedRows[0].DataBoundItem;

            if (MessageHelper.ShowConfirmation($"Deseja realmente excluir o produto '{produto.Nome}'?"))
            {
                try
                {
                    await _produtoService.ExcluirAsync(produto.Id);
                    MessageHelper.ShowSuccess("Produto excluído com sucesso!");
                    await CarregarProdutosAsync();
                }
                catch (Exception ex)
                {
                    MessageHelper.ShowError($"Erro ao excluir produto: {ex.Message}");
                }
            }
        }

        private Panel pnlTop;
        private Button btnNovo;
        private Button btnExcluir;
        private Button btnEditar;
        private Button button1;
        private TextBox txtBusca;
        private DataGridView dgvProdutos;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNome;
        private DataGridViewTextBoxColumn colCategoria;
        private DataGridViewTextBoxColumn colPreco;
        private DataGridViewTextBoxColumn colEstoque;
        private DataGridViewTextBoxColumn colStatus;
    }
}