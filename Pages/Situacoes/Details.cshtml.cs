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
    public class DetailsModel : PageModel
    {
        private readonly sistemE.Data.ApplicationDbContext _context;

        public DetailsModel(sistemE.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Situacao Situacao { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Situacao = await _context.Situacaos.FirstOrDefaultAsync(m => m.Id == id);

            if (Situacao == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
