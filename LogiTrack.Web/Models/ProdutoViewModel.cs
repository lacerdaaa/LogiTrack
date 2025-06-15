using System.ComponentModel.DataAnnotations;

namespace LogiTrack.Web.Models
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres")]
        [Display(Name = "Nome do Produto")]
        public string Nome { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Descrição deve ter no máximo 500 caracteres")]
        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Preço é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Preço deve ser maior que zero")]
        [Display(Name = "Preço")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Quantidade é obrigatória")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantidade não pode ser negativa")]
        [Display(Name = "Quantidade em Estoque")]
        public int QuantidadeEstoque { get; set; }

        [Required(ErrorMessage = "Categoria é obrigatória")]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        [Display(Name = "Categoria")]
        public string? CategoriaNome { get; set; }

        [StringLength(50, ErrorMessage = "Código de barras deve ter no máximo 50 caracteres")]
        [Display(Name = "Código de Barras")]
        public string? CodigoBarras { get; set; }

        [Display(Name = "Data de Cadastro")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = false)]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Última Atualização")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = false)]
        public DateTime? DataUltimaAtualizacao { get; set; }

        public bool Ativo { get; set; }

        // Propriedades calculadas
        [Display(Name = "Valor Total em Estoque")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal ValorTotalEstoque => Preco * QuantidadeEstoque;

        [Display(Name = "Estoque Baixo")]
        public bool EstoqueBaixo => QuantidadeEstoque <= 10;
    }
}