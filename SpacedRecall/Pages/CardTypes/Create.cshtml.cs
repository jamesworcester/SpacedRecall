using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SpacedRecall.Data;
using SpacedRecall.Models;

namespace SpacedRecall.Pages.CardTypes
{
    public class CreateModel : PageModel
    {
        private readonly SpacedRecall.Data.ApplicationDbContext _context;

        public CreateModel(SpacedRecall.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CardType CardType { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CardType.Add(CardType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
