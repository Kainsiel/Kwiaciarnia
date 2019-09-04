using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Kwiaciarnia.Data;
using Kwiaciarnia.Models;

namespace Kwiaciarnia.Pages.Kwiaty
{
    public class CreateModel : PageModel
    {
        private readonly Kwiaciarnia.Data.ApplicationDbContext _context;

        public CreateModel(Kwiaciarnia.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Kwiat Kwiat { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Kwiat.Add(Kwiat);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}