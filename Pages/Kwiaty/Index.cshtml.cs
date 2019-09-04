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
    public class IndexModel : PageModel
    {
        private readonly Kwiaciarnia.Data.ApplicationDbContext _context;

        public IndexModel(Kwiaciarnia.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Kwiat> Kwiat { get;set; }

        public async Task OnGetAsync()
        {
            Kwiat = await _context.Kwiat.ToListAsync();
        }
    }
}
