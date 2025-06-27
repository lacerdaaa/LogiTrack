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
    public partial class FormProdutoDetalhes : Form
    {
        public FormProdutoDetalhes()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtNome = new TextBox();
            txtDescricao = new TextBox();
            nudPreco = new NumericUpDown();
            nudEstoque = new NumericUpDown();
            cmbCategoria = new ComboBox();
            label6 = new Label();
            txtCodigoBarras = new TextBox();
            chkAtivo = new CheckBox();
            btnSalvar = new Button();
            btnCancelar = new Button();
            ((ISupportInitialize)nudPreco).BeginInit();
            ((ISupportInitialize)nudEstoque).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 32);
            label1.Name = "label1";
            label1.Size = new Size(65, 25);
            label1.TabIndex = 0;
            label1.Text = "Nome:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 72);
            label2.Name = "label2";
            label2.Size = new Size(92, 25);
            label2.TabIndex = 1;
            label2.Text = "Descrição:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 111);
            label3.Name = "label3";
            label3.Size = new Size(56, 25);
            label3.TabIndex = 2;
            label3.Text = "Preço";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(39, 148);
            label4.Name = "label4";
            label4.Size = new Size(76, 25);
            label4.TabIndex = 3;
            label4.Text = "Estoque";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(39, 189);
            label5.Name = "label5";
            label5.Size = new Size(92, 25);
            label5.TabIndex = 4;
            label5.Text = "Categoria:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(140, 26);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(150, 31);
            txtNome.TabIndex = 5;
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(140, 70);
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(150, 31);
            txtDescricao.TabIndex = 6;
            // 
            // nudPreco
            // 
            nudPreco.Location = new Point(140, 111);
            nudPreco.Name = "nudPreco";
            nudPreco.Size = new Size(64, 31);
            nudPreco.TabIndex = 7;
            // 
            // nudEstoque
            // 
            nudEstoque.Location = new Point(140, 148);
            nudEstoque.Name = "nudEstoque";
            nudEstoque.Size = new Size(64, 31);
            nudEstoque.TabIndex = 8;
            // 
            // cmbCategoria
            // 
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(140, 185);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(150, 33);
            cmbCategoria.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(39, 228);
            label6.Name = "label6";
            label6.Size = new Size(80, 25);
            label6.TabIndex = 10;
            label6.Text = "C. Barras";
            // 
            // txtCodigoBarras
            // 
            txtCodigoBarras.Location = new Point(140, 228);
            txtCodigoBarras.Name = "txtCodigoBarras";
            txtCodigoBarras.Size = new Size(150, 31);
            txtCodigoBarras.TabIndex = 11;
            // 
            // chkAtivo
            // 
            chkAtivo.AutoSize = true;
            chkAtivo.Location = new Point(39, 272);
            chkAtivo.Name = "chkAtivo";
            chkAtivo.Size = new Size(80, 29);
            chkAtivo.TabIndex = 12;
            chkAtivo.Text = "Ativo";
            chkAtivo.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(335, 226);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(112, 34);
            btnSalvar.TabIndex = 13;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += BtnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(335, 272);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(112, 34);
            btnCancelar.TabIndex = 14;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += BtnCancelar_Click;
            // 
            // FormProdutoDetalhes
            // 
            ClientSize = new Size(478, 334);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalvar);
            Controls.Add(chkAtivo);
            Controls.Add(txtCodigoBarras);
            Controls.Add(label6);
            Controls.Add(cmbCategoria);
            Controls.Add(nudEstoque);
            Controls.Add(nudPreco);
            Controls.Add(txtDescricao);
            Controls.Add(txtNome);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormProdutoDetalhes";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Adicionar Produto";
            ((ISupportInitialize)nudPreco).EndInit();
            ((ISupportInitialize)nudEstoque).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
