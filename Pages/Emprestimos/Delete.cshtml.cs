using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sistemE.Data;
using sistemE.Models;

namespace sistemE.Pages.Emprestimos
{
    public class DeleteModel : PageModel
    {
        private readonly sistemE.Data.ApplicationDbContext _context;

        public DeleteModel(sistemE.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Emprestimo Emprestimo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Emprestimo = await _context.Emprestimos
                .Include(e => e.IdentityUser).FirstOrDefaultAsync(m => m.Id == id);

            if (Emprestimo == null)
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

            Emprestimo = await _context.Emprestimos.FindAsync(id);

            if (Emprestimo != null)
            {
                _context.Emprestimos.Remove(Emprestimo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
