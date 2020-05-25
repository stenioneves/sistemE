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
    public class DeleteModel : PageModel
    {
        private readonly sistemE.Data.ApplicationDbContext _context;

        public DeleteModel(sistemE.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pagamento Pagamento { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pagamento = await _context.Pagamentos.FirstOrDefaultAsync(m => m.Id == id);

            if (Pagamento == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pagamento = await _context.Pagamentos.FindAsync(id);

            if (Pagamento != null)
            {
                _context.Pagamentos.Remove(Pagamento);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
