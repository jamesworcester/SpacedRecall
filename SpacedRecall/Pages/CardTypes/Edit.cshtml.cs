using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpacedRecall.Data;
using SpacedRecall.Models;

namespace SpacedRecall.Pages.CardTypes
{
    public class EditModel : PageModel
    {
        private readonly SpacedRecall.Data.ApplicationDbContext _context;

        public EditModel(SpacedRecall.Data.ApplicationDbContext context)
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

            var cardtype =  await _context.CardType.FirstOrDefaultAsync(m => m.Id == id);
            if (cardtype == null)
            {
                return NotFound();
            }
            CardType = cardtype;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CardType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardTypeExists(CardType.Id))
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

        private bool CardTypeExists(int id)
        {
            return _context.CardType.Any(e => e.Id == id);
        }
    }
}
