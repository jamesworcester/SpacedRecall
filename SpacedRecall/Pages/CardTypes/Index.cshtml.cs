using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SpacedRecall.Data;
using SpacedRecall.Models;

namespace SpacedRecall.Pages.CardTypes
{
    public class IndexModel : PageModel
    {
        private readonly SpacedRecall.Data.ApplicationDbContext _context;

        public IndexModel(SpacedRecall.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CardType> CardType { get;set; } = default!;

        public async Task OnGetAsync()
        {
            CardType = await _context.CardType.ToListAsync();
        }
    }
}
