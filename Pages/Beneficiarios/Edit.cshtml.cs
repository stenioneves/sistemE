using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sistemE.Data;
using sistemE.Models;

namespace sistemE.Pages.Beneficiarios
{
    public class EditModel : PageModel
    {
        private readonly sistemE.Data.ApplicationDbContext _context;

        public EditModel(sistemE.Data.ApplicationDbContext context)
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
           ViewData["Responsavel"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Beneficiario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeneficiarioExists(Beneficiario.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BeneficiarioExists(int id)
        {
            return _context.Beneficiarios.Any(e => e.Id == id);
        }
    }
}
