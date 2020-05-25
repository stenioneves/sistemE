using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using sistemE.Data;
using sistemE.Models;

namespace sistemE.Pages.Emprestimos
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly sistemE.Data.ApplicationDbContext _context;

        public IndexModel(sistemE.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Emprestimo> Emprestimo { get;set; }
        public IList<Beneficiario> Beneficiario {get; set;}
        public IList<Situacao> Situacao {get;set;}
        public async Task OnGetAsync()
        {
          Emprestimo= await _context.Emprestimos
                .Include(e => e.IdentityUser).ToListAsync();

           Beneficiario =await _context.Beneficiarios.ToListAsync(); 
           Situacao =await _context.Situacaos.ToListAsync();    
        
        }
                
    }
}
