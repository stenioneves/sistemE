using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using sistemE.Data;
using sistemE.Models;

namespace sistemE.Pages.Situacoes
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
            return Page();
        }

        [BindProperty]
        public Situacao Situacao { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Situacaos.Add(Situacao);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
