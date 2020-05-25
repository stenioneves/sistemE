using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sistemE.Data;
using sistemE.Models;

namespace sistemE.Pages.Situacoes
{
    public class IndexModel : PageModel
    {
        private readonly sistemE.Data.ApplicationDbContext _context;

        public IndexModel(sistemE.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Situacao> Situacao { get;set; }

        public async Task OnGetAsync()
        {
            Situacao = await _context.Situacaos.ToListAsync();
        }
    }
}
