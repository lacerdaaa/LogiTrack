using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogiTrack.Desktop.Forms
{
    public partial class FormProdutos : Form
    {
        public FormProdutos()
        {
            InitializeComponent();
        }

        private void dgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void InitializeComponent()
        {
            pnlTop = new Panel();
            btnNovo = new Button();
            btnExcluir = new Button();
            btnEditar = new Button();
            button1 = new Button();
            txtBusca = new TextBox();
            dgvProdutos = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colNome = new DataGridViewTextBoxColumn();
            colCategoria = new DataGridViewTextBoxColumn();
            colPreco = new DataGridViewTextBoxColumn();
            colEstoque = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            pnlTop.SuspendLayout();
            ((ISupportInitialize)dgvProdutos).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(btnNovo);
            pnlTop.Controls.Add(btnExcluir);
            pnlTop.Controls.Add(btnEditar);
            pnlTop.Controls.Add(button1);
            pnlTop.Controls.Add(txtBusca);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(778, 60);
            pnlTop.TabIndex = 0;
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(363, 14);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(112, 34);
            btnNovo.TabIndex = 4;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(602, 14);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(112, 34);
            btnExcluir.TabIndex = 3;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(481, 14);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(112, 34);
            btnEditar.TabIndex = 2;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // button1
            // 
            button1.Location = new Point(245, 14);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 1;
            button1.Text = "Buscar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnBuscar_Click;
            // 
            // txtBusca
            // 
            txtBusca.Location = new Point(39, 17);
            txtBusca.Name = "txtBusca";
            txtBusca.Size = new Size(200, 31);
            txtBusca.TabIndex = 0;
            // 
            // dgvProdutos
            // 
            dgvProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProdutos.Columns.AddRange(new DataGridViewColumn[] { colId, colNome, colCategoria, colPreco, colEstoque, colStatus });
            dgvProdutos.Dock = DockStyle.Fill;
            dgvProdutos.Location = new Point(0, 60);
            dgvProdutos.Name = "dgvProdutos";
            dgvProdutos.RowHeadersWidth = 62;
            dgvProdutos.Size = new Size(778, 484);
            dgvProdutos.TabIndex = 1;
            // 
            // colId
            // 
            colId.DataPropertyName = "Id";
            colId.HeaderText = "ID";
            colId.MinimumWidth = 8;
            colId.Name = "colId";
            colId.Width = 150;
            // 
            // colNome
            // 
            colNome.DataPropertyName = "Nome";
            colNome.HeaderText = "Nome";
            colNome.MinimumWidth = 8;
            colNome.Name = "colNome";
            colNome.Width = 150;
            // 
            // colCategoria
            // 
            colCategoria.DataPropertyName = "Categoria.Nome";
            colCategoria.HeaderText = "Categoria";
            colCategoria.MinimumWidth = 8;
            colCategoria.Name = "colCategoria";
            colCategoria.Width = 150;
            // 
            // colPreco
            // 
            colPreco.DataPropertyName = "Preco";
            colPreco.HeaderText = "Preço";
            colPreco.MinimumWidth = 8;
            colPreco.Name = "colPreco";
            colPreco.Width = 150;
            // 
            // colEstoque
            // 
            colEstoque.DataPropertyName = "Estoque";
            colEstoque.HeaderText = "Estoque";
            colEstoque.MinimumWidth = 8;
            colEstoque.Name = "colEstoque";
            colEstoque.Width = 150;
            // 
            // colStatus
            // 
            colStatus.DataPropertyName = "Ativo";
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 8;
            colStatus.Name = "colStatus";
            colStatus.Width = 150;
            // 
            // FormProdutos
            // 
            ClientSize = new Size(778, 544);
            Controls.Add(dgvProdutos);
            Controls.Add(pnlTop);
            Name = "FormProdutos";
            Text = "Produtos";
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ((ISupportInitialize)dgvProdutos).EndInit();
            ResumeLayout(false);
        }
    }
}
