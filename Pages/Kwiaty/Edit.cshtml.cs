using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kwiaciarnia.Data;
using Kwiaciarnia.Models;

namespace Kwiaciarnia.Pages.Kwiaty
{
    public class EditModel : PageModel
    {
        private readonly Kwiaciarnia.Data.ApplicationDbContext _context;

        public EditModel(Kwiaciarnia.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Kwiat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KwiatExists(Kwiat.ID))
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

        private bool KwiatExists(int id)
        {
            return _context.Kwiat.Any(e => e.ID == id);
        }
    }
}
