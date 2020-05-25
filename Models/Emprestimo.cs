using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemE.Models
{
    [Table("emprestimo")]
    public class Emprestimo
    {
        [Display(Name="Código do emprestimo")]
        [Column("Id")]
        public int Id {get; set;}
        [Required]
        [Display(Name="Valor solicitado")]
        [Column("valor")]
        [DataType(DataType.Currency)]
        public decimal ValorSolicitado {get; set;}
        [Required]
        [Display(Name="Quantidade de parcela")]
        public int qtd {get; set;}
        [Required]
        [Display(Name="Data de Solicitação")]
        [Column("dataSolic")]
        [DataType(DataType.DateTime)]
        public DateTime DataSolicitacao {get; set;}
        
        [Display(Name="Observação")]
        [Column("observacao")]
        [DataType(DataType.Text)]
        public string Observacao {get; set;}
        [ForeignKey("beneficiario")]
        [Column(Order = 1)]
        public int Solicitante {get; set;}
        public virtual Beneficiario Beneficiario {get; set;}
        [ForeignKey("situacao")]
        [Column(Order = 1)]
        public int status {get; set;}
        public  virtual Situacao Situacao {get; set;}
        [Required]
        [Display(Name="Autorizado por")]
        [ForeignKey("IdentityUser")]
        [Column(Order = 1)]
        public string Autorizado {get; set;}
        public virtual IdentityUser IdentityUser { get; set; }

    }
}