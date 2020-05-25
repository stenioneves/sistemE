using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using sistemE.Data;
using sistemE.Models;

namespace sistemE.Pages.Beneficiarios
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
        ViewData["Responsavel"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Beneficiario Beneficiario { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Beneficiarios.Add(Beneficiario);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
