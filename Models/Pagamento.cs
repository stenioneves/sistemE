using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemE.Models
{
    
    [Table("pagamento")]
    public class Pagamento
    {
        [Display(Name="Código do pagamento")]
        public int Id {get; set;}
        [Required]
        [Column("numparcela")]
        [Display(Name="Número da parcela")]
        public int NumParcela {get; set;}
        [Required]
        [Display(Name="Data de Vencimento")]
        [Column("datavenc")]
        [DataType(DataType.Date)]
        public DateTime DataVenc {get; set;}
        
        [Display(Name="Data de pagamento")]
        [Column("datapag")]
        [DataType(DataType.Date)]
        public DateTime DataPag {get; set;}
        [Required]
        [Display(Name="Emprestimo")]
        [ForeignKey("emprestimo")]
        [Column(Order = 1)]
        public int Idemprestimo {get; set;}
        public virtual Emprestimo Emprestimo {get; set;}


    }
}