using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SpacedRecall.Data;
using SpacedRecall.Models;

namespace SpacedRecall.Pages.Decks
{
    public class DetailsModel : PageModel
    {
        private readonly SpacedRecall.Data.ApplicationDbContext _context;

        public DetailsModel(SpacedRecall.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Deck Deck { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deck = await _context.Deck.FirstOrDefaultAsync(m => m.Id == id);

            if (deck is not null)
            {
                Deck = deck;

                return Page();
            }

            return NotFound();
        }
    }
}
