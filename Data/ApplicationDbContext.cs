using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using sistemE.Models;

namespace sistemE.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Beneficiario>Beneficiarios {get; set;}
        
        public DbSet<Emprestimo>Emprestimos {get; set;}
        
        public DbSet<Situacao>Situacaos {get; set;}

        public DbSet<Pagamento>Pagamentos{get;set;}
    }
}
