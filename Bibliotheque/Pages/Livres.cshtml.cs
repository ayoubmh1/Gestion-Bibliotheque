using Bibliotheque.Data;
using Bibliotheque.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bibliotheque.Pages
{
    public class LivresModel : PageModel
    {
        private readonly AppDbContext _context;

        public LivresModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Livre> Livres { get; set; } = new List<Livre>();

        [BindProperty]
        public int LivreId { get; set; } // Pour la suppression

        public async Task OnGetAsync()
        {
            Livres = await _context.Livres.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var livre = await _context.Livres.FindAsync(id);
            if (livre == null)
            {
                return NotFound();
            }

            _context.Livres.Remove(livre);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Le livre a été supprimé avec succès.";
            return RedirectToPage();
        }
        //public async Task<IActionResult> OnGetDetailsAsync(int id)
        //{
          //  var livre = await _context.Livres.FirstOrDefaultAsync(l => l.Id == id);
           // if (livre == null) return NotFound();

            //return Page(new { Livre = livre });
        //}

        public async Task<IActionResult> OnPostEditAsync(Livre livre)
        {
            if (!ModelState.IsValid) return Page();

            _context.Attach(livre).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Les informations du livre ont été mises à jour avec succès.";
            return RedirectToPage();
        }

    }
}
