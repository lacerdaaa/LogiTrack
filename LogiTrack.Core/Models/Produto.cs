using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiTrack.Core.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Descrição deve ter no máximo 500 caracteres")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "Preço é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Preço deve ser maior que zero")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Quantidade é obrigatória")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantidade não pode ser negativa")]
        public int QuantidadeEstoque { get; set; }

        [Required(ErrorMessage = "Categoria é obrigatória")]
        public int CategoriaId { get; set; }

        public virtual Categoria? Categoria { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public DateTime? DataUltimaAtualizacao { get; set; }

        [StringLength(50)]
        public string CodigoBarras { get; set; } = string.Empty;

        public bool Ativo { get; set; } = true;

        public decimal ValorTotalEstoque => Preco * QuantidadeEstoque;

        public bool EstoqueBaixo => QuantidadeEstoque <= 10; 
    }
}

