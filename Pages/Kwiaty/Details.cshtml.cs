using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Kwiaciarnia.Data;
using Kwiaciarnia.Models;

namespace Kwiaciarnia.Pages.Kwiaty
{
    public class DetailsModel : PageModel
    {
        private readonly Kwiaciarnia.Data.ApplicationDbContext _context;

        public DetailsModel(Kwiaciarnia.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Kwiat Kwiat { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Kwiat = await _context.Kwiat.FirstOrDefaultAsync(m => m.ID == id);

            if (Kwiat == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
