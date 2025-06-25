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
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            mnuPrincipal = new MenuStrip();
            Sair = new ToolStripMenuItem();
            mnuProdutos = new ToolStripMenuItem();
            mnuCategorias = new ToolStripMenuItem();
            mnuSair = new ToolStripMenuItem();
            relatóriosToolStripMenuItem = new ToolStripMenuItem();
            estoqueBaixoToolStripMenuItem = new ToolStripMenuItem();
            produtosPorCategoriaToolStripMenuItem = new ToolStripMenuItem();
            ajudaToolStripMenuItem = new ToolStripMenuItem();
            sobreToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            lblData = new ToolStripStatusLabel();
            mnuPrincipal.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // mnuPrincipal
            // 
            mnuPrincipal.ImageScalingSize = new Size(24, 24);
            mnuPrincipal.Items.AddRange(new ToolStripItem[] { Sair, relatóriosToolStripMenuItem, ajudaToolStripMenuItem });
            mnuPrincipal.Location = new Point(0, 0);
            mnuPrincipal.Name = "mnuPrincipal";
            mnuPrincipal.Size = new Size(1002, 33);
            mnuPrincipal.TabIndex = 1;
            mnuPrincipal.Text = "menuStrip1";
            // 
            // Sair
            // 
            Sair.DropDownItems.AddRange(new ToolStripItem[] { mnuProdutos, mnuCategorias, mnuSair });
            Sair.Name = "Sair";
            Sair.Size = new Size(107, 29);
            Sair.Text = "Cadastros";
            // 
            // mnuProdutos
            // 
            mnuProdutos.Name = "mnuProdutos";
            mnuProdutos.Size = new Size(270, 34);
            mnuProdutos.Text = "Produtos";
            mnuProdutos.Click += mnuProdutos_Click;
            // 
            // mnuCategorias
            // 
            mnuCategorias.Name = "mnuCategorias";
            mnuCategorias.Size = new Size(270, 34);
            mnuCategorias.Text = "Categorias";
            mnuCategorias.Click += mnuCategorias_Click;
            // 
            // mnuSair
            // 
            mnuSair.Name = "mnuSair";
            mnuSair.Size = new Size(270, 34);
            mnuSair.Text = "Sair";
            mnuSair.Click += mnuSair_Click;
            // 
            // relatóriosToolStripMenuItem
            // 
            relatóriosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { estoqueBaixoToolStripMenuItem, produtosPorCategoriaToolStripMenuItem });
            relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
            relatóriosToolStripMenuItem.Size = new Size(106, 29);
            relatóriosToolStripMenuItem.Text = "Relatórios";
            relatóriosToolStripMenuItem.Click += relatóriosToolStripMenuItem_Click;
            // 
            // estoqueBaixoToolStripMenuItem
            // 
            estoqueBaixoToolStripMenuItem.Name = "estoqueBaixoToolStripMenuItem";
            estoqueBaixoToolStripMenuItem.Size = new Size(301, 34);
            estoqueBaixoToolStripMenuItem.Text = "Estoque Baixo";
            // 
            // produtosPorCategoriaToolStripMenuItem
            // 
            produtosPorCategoriaToolStripMenuItem.Name = "produtosPorCategoriaToolStripMenuItem";
            produtosPorCategoriaToolStripMenuItem.Size = new Size(301, 34);
            produtosPorCategoriaToolStripMenuItem.Text = "Produtos por Categoria";
            // 
            // ajudaToolStripMenuItem
            // 
            ajudaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sobreToolStripMenuItem });
            ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            ajudaToolStripMenuItem.Size = new Size(74, 29);
            ajudaToolStripMenuItem.Text = "Ajuda";
            // 
            // sobreToolStripMenuItem
            // 
            sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            sobreToolStripMenuItem.Size = new Size(270, 34);
            sobreToolStripMenuItem.Text = "Sobre";
            sobreToolStripMenuItem.Click += mnuSobre_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus, lblData });
            statusStrip1.Location = new Point(0, 680);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1002, 32);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(60, 25);
            lblStatus.Text = "Status";
            lblStatus.Click += toolStripStatusLabel1_Click;
            // 
            // lblData
            // 
            lblData.Name = "lblData";
            lblData.Size = new Size(0, 25);
            // 
            // FormPrincipal
            // 
            ClientSize = new Size(1002, 712);
            Controls.Add(statusStrip1);
            Controls.Add(mnuPrincipal);
            IsMdiContainer = true;
            MainMenuStrip = mnuPrincipal;
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Logitrack - Seu gerenciador de Estoque";
            WindowState = FormWindowState.Maximized;
            mnuPrincipal.ResumeLayout(false);
            mnuPrincipal.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void relatóriosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
