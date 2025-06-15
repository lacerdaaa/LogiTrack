using System.ComponentModel.DataAnnotations;

namespace LogiTrack.Web.Models
{
    public class CategoriaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(50, ErrorMessage = "Nome deve ter no máximo 50 caracteres")]
        [Display(Name = "Nome da Categoria")]
        public string Nome { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Descrição deve ter no máximo 200 caracteres")]
        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        [Display(Name = "Ativa")]
        public bool Ativa { get; set; }

        [Display(Name = "Quantidade de Produtos")]
        public int QuantidadeProdutos { get; set; }
    }
}