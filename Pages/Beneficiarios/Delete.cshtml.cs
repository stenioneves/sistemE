using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sistemE.Data;
using sistemE.Models;

namespace sistemE.Pages.Beneficiarios
{
    public class DeleteModel : PageModel
    {
        private readonly sistemE.Data.ApplicationDbContext _context;

        public DeleteModel(sistemE.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Beneficiario Beneficiario { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Beneficiario = await _context.Beneficiarios
                .Include(b => b.IdentityUser).FirstOrDefaultAsync(m => m.Id == id);

            if (Beneficiario == null)
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

            Beneficiario = await _context.Beneficiarios.FindAsync(id);

            if (Beneficiario != null)
            {
                _context.Beneficiarios.Remove(Beneficiario);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
