using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;



namespace sistemE.Models
{
    [Table("beneficiario")]
   public class Beneficiario
   {
        [Display(Name="Código")]
        [Column("Id")]
        public int Id {get; set;}
        [Required]
        [Display(Name="Nome do solicitante")]
        [Column("Nome")]
        public string Nome {get; set;}
        [Required]
        [Display(Name="Usuario Responsável")]
        [ForeignKey("IdentityUser")]
        [Column(Order = 1)]
        public string Responsavel {get; set;}
        public virtual IdentityUser IdentityUser { get; set; }

   } 
}