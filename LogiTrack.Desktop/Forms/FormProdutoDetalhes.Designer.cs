using LogiTrack.Core.Models;
using LogiTrack.Core.Services;
using LogiTrack.Core.Services.Interfaces;
using LogiTrack.Desktop.Utils;

namespace LogiTrack.Desktop.Forms
{
    public partial class FormProdutoDetalhes : Form
    {
        private readonly IProdutoService _produtoService;
        private readonly ICategoriaService _categoriaService;
        private Produto? _produtoEditado;

        public FormProdutoDetalhes(IProdutoService produtoService,
                                 ICategoriaService categoriaService)
        {
            InitializeComponent();
            _produtoService = produtoService;
            _categoriaService = categoriaService;

            ConfigurarControles();
            CarregarCategorias();
        }

        private void ConfigurarControles()
        {
            nudPreco.DecimalPlaces = 2;
            nudPreco.Minimum = 0;
            nudPreco.Maximum = 999999;

            nudEstoque.Minimum = 0;
            nudEstoque.Maximum = 9999;

            // Eventos dos botões
            btnSalvar.Click += BtnSalvar_Click;
            btnCancelar.Click += BtnCancelar_Click;
        }

        private async void CarregarCategorias()
        {
            try
            {
                var categorias = await _categoriaService.ObterTodasAsync();
                cmbCategoria.DataSource = categorias;
                cmbCategoria.DisplayMember = "Nome";
                cmbCategoria.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Erro ao carregar categorias: {ex.Message}");
            }
        }

        private async void BtnSalvar_Click(object? sender, EventArgs e)
        {
            var produto = _produtoEditado ?? new Produto();

            produto.Nome = txtNome.Text;
            produto.Descricao = txtDescricao.Text;
            produto.Preco = nudPreco.Value;
            produto.QuantidadeEstoque = (int)nudEstoque.Value;
            produto.CategoriaId = (int)cmbCategoria.SelectedValue;
            produto.CodigoBarras = txtCodigoBarras.Text;
            produto.Ativo = chkAtivo.Checked;

            if (!ValidacaoHelper.ValidateAndShowErrors(produto))
                return;

            try
            {
                if (_produtoEditado == null)
                {
                    await _produtoService.AdicionarAsync(produto);
                    MessageHelper.ShowSuccess("Produto cadastrado com sucesso!");
                }
                else
                {
                    await _produtoService.AtualizarAsync(produto);
                    MessageHelper.ShowSuccess("Produto atualizado com sucesso!");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Erro ao salvar produto: {ex.Message}");
            }
        }

        private void BtnCancelar_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtNome;
        private TextBox txtDescricao;
        private NumericUpDown nudPreco;
        private NumericUpDown nudEstoque;
        private ComboBox cmbCategoria;
        private Label label6;
        private TextBox txtCodigoBarras;
        private CheckBox chkAtivo;
        private Button btnSalvar;
        private Button btnCancelar;
    }
}