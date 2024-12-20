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
    public class DeleteModel : PageModel
    {
        private readonly SpacedRecall.Data.ApplicationDbContext _context;

        public DeleteModel(SpacedRecall.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CardType CardType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardtype = await _context.CardType.FirstOrDefaultAsync(m => m.Id == id);

            if (cardtype is not null)
            {
                CardType = cardtype;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardtype = await _context.CardType.FindAsync(id);
            if (cardtype != null)
            {
                CardType = cardtype;
                _context.CardType.Remove(CardType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
