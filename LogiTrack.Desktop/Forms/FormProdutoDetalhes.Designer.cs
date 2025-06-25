namespace LogiTrack.Desktop.Forms
{
    partial class FormProdutoDetalhes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtNome = new TextBox();
            txtDescricao = new TextBox();
            nudPreco = new NumericUpDown();
            nudEstoque = new NumericUpDown();
            cmbCategoria = new ComboBox();
            txtCodigoBarras = new TextBox();
            chkAtivo = new CheckBox();
            btnSalvar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)nudPreco).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudEstoque).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 37);
            label1.Name = "label1";
            label1.Size = new Size(61, 25);
            label1.TabIndex = 0;
            label1.Text = "Nome";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 81);
            label2.Name = "label2";
            label2.Size = new Size(88, 25);
            label2.TabIndex = 1;
            label2.Text = "Descrição";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 125);
            label3.Name = "label3";
            label3.Size = new Size(56, 25);
            label3.TabIndex = 2;
            label3.Text = "Preço";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 169);
            label4.Name = "label4";
            label4.Size = new Size(76, 25);
            label4.TabIndex = 3;
            label4.Text = "Estoque";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 211);
            label5.Name = "label5";
            label5.Size = new Size(88, 25);
            label5.TabIndex = 4;
            label5.Text = "Categoria";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(21, 253);
            label6.Name = "label6";
            label6.Size = new Size(80, 25);
            label6.TabIndex = 5;
            label6.Text = "C. Barras";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(115, 37);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(150, 31);
            txtNome.TabIndex = 6;
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(115, 81);
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(150, 31);
            txtDescricao.TabIndex = 7;
            // 
            // nudPreco
            // 
            nudPreco.Location = new Point(115, 125);
            nudPreco.Name = "nudPreco";
            nudPreco.Size = new Size(83, 31);
            nudPreco.TabIndex = 8;
            // 
            // nudEstoque
            // 
            nudEstoque.Location = new Point(115, 167);
            nudEstoque.Name = "nudEstoque";
            nudEstoque.Size = new Size(83, 31);
            nudEstoque.TabIndex = 9;
            // 
            // cmbCategoria
            // 
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(115, 211);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(150, 33);
            cmbCategoria.TabIndex = 10;
            // 
            // txtCodigoBarras
            // 
            txtCodigoBarras.Location = new Point(115, 253);
            txtCodigoBarras.Name = "txtCodigoBarras";
            txtCodigoBarras.Size = new Size(150, 31);
            txtCodigoBarras.TabIndex = 11;
            // 
            // chkAtivo
            // 
            chkAtivo.AutoSize = true;
            chkAtivo.Location = new Point(21, 303);
            chkAtivo.Name = "chkAtivo";
            chkAtivo.Size = new Size(80, 29);
            chkAtivo.TabIndex = 12;
            chkAtivo.Text = "Ativo";
            chkAtivo.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(340, 250);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(112, 34);
            btnSalvar.TabIndex = 13;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(340, 290);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(112, 34);
            btnCancelar.TabIndex = 14;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FormProdutoDetalhes
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(478, 344);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalvar);
            Controls.Add(chkAtivo);
            Controls.Add(txtCodigoBarras);
            Controls.Add(cmbCategoria);
            Controls.Add(nudEstoque);
            Controls.Add(nudPreco);
            Controls.Add(txtDescricao);
            Controls.Add(txtNome);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormProdutoDetalhes";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Produto - Detalhes";
            ((System.ComponentModel.ISupportInitialize)nudPreco).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudEstoque).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtNome;
        private TextBox txtDescricao;
        private NumericUpDown nudPreco;
        private NumericUpDown nudEstoque;
        private ComboBox cmbCategoria;
        private TextBox txtCodigoBarras;
        private CheckBox chkAtivo;
        private Button btnSalvar;
        private Button btnCancelar;
    }
}