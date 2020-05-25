using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using sistemE.Data;
using sistemE.Models;

namespace sistemE.Pages.Emprestimos
{
    public class CreateModel : PageModel
    {
        private readonly sistemE.Data.ApplicationDbContext _context;

        public CreateModel(sistemE.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Autorizado"] = new SelectList(_context.Users, "Id", "Id");
        ViewData["Solicitante"]= new SelectList(_context.Beneficiarios,"Id","Nome");
        ViewData["Situacao"]= new SelectList(_context.Situacaos,"Id","Descricao");
            return Page();
        }

        [BindProperty]
        public Emprestimo Emprestimo { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Emprestimos.Add(Emprestimo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
