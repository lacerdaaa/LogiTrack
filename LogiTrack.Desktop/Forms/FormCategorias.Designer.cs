namespace LogiTrack.Desktop.Forms
{
    partial class FormCategorias
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
            pnlTop = new Panel();
            btnNova = new Button();
            btnEditar = new Button();
            btnExcluir = new Button();
            dgvCategorias = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Nome = new DataGridViewTextBoxColumn();
            Descricao = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(btnExcluir);
            pnlTop.Controls.Add(btnEditar);
            pnlTop.Controls.Add(btnNova);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(578, 50);
            pnlTop.TabIndex = 0;
            // 
            // btnNova
            // 
            btnNova.Location = new Point(39, 9);
            btnNova.Name = "btnNova";
            btnNova.Size = new Size(112, 34);
            btnNova.TabIndex = 0;
            btnNova.Text = "Nova ";
            btnNova.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(187, 9);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(112, 34);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(333, 9);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(112, 34);
            btnExcluir.TabIndex = 2;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            // 
            // dgvCategorias
            // 
            dgvCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategorias.Columns.AddRange(new DataGridViewColumn[] { ID, Nome, Descricao, Status });
            dgvCategorias.Dock = DockStyle.Fill;
            dgvCategorias.Location = new Point(0, 50);
            dgvCategorias.Name = "dgvCategorias";
            dgvCategorias.RowHeadersWidth = 62;
            dgvCategorias.Size = new Size(578, 294);
            dgvCategorias.TabIndex = 1;
            // 
            // ID
            // 
            ID.HeaderText = "id";
            ID.MinimumWidth = 8;
            ID.Name = "ID";
            ID.Width = 150;
            // 
            // Nome
            // 
            Nome.HeaderText = "Nome";
            Nome.MinimumWidth = 8;
            Nome.Name = "Nome";
            Nome.Width = 150;
            // 
            // Descricao
            // 
            Descricao.HeaderText = "Descrição";
            Descricao.MinimumWidth = 8;
            Descricao.Name = "Descricao";
            Descricao.Width = 150;
            // 
            // Status
            // 
            Status.HeaderText = "Status";
            Status.MinimumWidth = 8;
            Status.Name = "Status";
            Status.Width = 150;
            // 
            // FormCategorias
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(578, 344);
            Controls.Add(dgvCategorias);
            Controls.Add(pnlTop);
            Name = "FormCategorias";
            Text = "Categorias";
            pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Button btnExcluir;
        private Button btnEditar;
        private Button btnNova;
        private DataGridView dgvCategorias;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Nome;
        private DataGridViewTextBoxColumn Descricao;
        private DataGridViewTextBoxColumn Status;
    }
}