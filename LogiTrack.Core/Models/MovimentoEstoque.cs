using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiTrack.Core.Models
{
    public enum TipoMovimento
    {
        Entrada = 1,
        Saida = 2,
        Ajuste = 3
    }

    public class MovimentoEstoque
    {
        public int Id { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        public virtual Produto? Produto { get; set; }

        [Required]
        public TipoMovimento Tipo { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantidade deve ser maior que zero")]
        public int Quantidade { get; set; }

        [StringLength(200)]
        public string Observacao { get; set; } = string.Empty;

        public DateTime DataMovimento { get; set; } = DateTime.Now;

        [Required]
        [StringLength(100)]
        public string Usuario { get; set; } = string.Empty;
        public decimal? PrecoUnitario { get; set; }

        public decimal? ValorTotal => PrecoUnitario * Quantidade;
    }
}
