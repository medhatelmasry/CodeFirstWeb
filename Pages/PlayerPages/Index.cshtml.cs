using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CodeFirstWeb.Data;
using CodeFirstWeb.Models;

namespace CodeFirstWeb.Pages.PlayerPages
{
    public class IndexModel : PageModel
    {
        private readonly CodeFirstWeb.Data.ApplicationDbContext _context;

        public IndexModel(CodeFirstWeb.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Player> Player { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Players != null)
            {
                Player = await _context.Players
                .Include(p => p.Team).ToListAsync();
            }
        }
    }
}
