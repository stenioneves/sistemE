using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace sistemE.Models
{
    [Table("situacao")]
    public class Situacao
    {
       
        
        public int Id {get; set;}
        [Required]
        [Display(Name="Nome")]
        [Column("descricao")]
        public string Descricao {get; set;}
    }
}