using System;
using System.ComponentModel.DataAnnotations;

namespace ContasAPagarAPI.Models
{
    public class Conta
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(120)]
        public string Nome { get; set; }
        public double ValorOriginal { get; set; }
        public DateTime DataVencimento { get; set; }
    }
}
