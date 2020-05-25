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

namespace sistemE.Pages.Emprestimos
{
    public class EditModel : PageModel
    {
        private readonly sistemE.Data.ApplicationDbContext _context;

        public EditModel(sistemE.Data.ApplicationDbContext context)
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
           ViewData["Autorizado"] = new SelectList(_context.Users, "Id", "Id");
           ViewData["Solicitante"]= new SelectList(_context.Beneficiarios,"Id","Nome");
            ViewData["Situacao"]= new SelectList(_context.Situacaos,"Id","Descricao");
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

            _context.Attach(Emprestimo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmprestimoExists(Emprestimo.Id))
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

        private bool EmprestimoExists(int id)
        {
            return _context.Emprestimos.Any(e => e.Id == id);
        }
    }
}
