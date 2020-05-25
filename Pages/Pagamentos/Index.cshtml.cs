using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sistemE.Data;
using sistemE.Models;

namespace sistemE.Pages.Pagamentos
{
    public class IndexModel : PageModel
    {
        private readonly sistemE.Data.ApplicationDbContext _context;

        public IndexModel(sistemE.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Pagamento> Pagamento { get;set; }

        public async Task OnGetAsync()
        {
            Pagamento = await _context.Pagamentos.ToListAsync();
        }
    }
}
