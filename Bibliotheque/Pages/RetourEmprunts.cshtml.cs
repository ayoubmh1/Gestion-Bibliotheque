using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Bibliotheque.Services;
using Bibliotheque.Models;

namespace Bibliotheque.Pages
{
    public class RetourEmpruntsModel : PageModel
    {
        private readonly ServiceEmprunt _serviceEmprunt;

        public RetourEmpruntsModel(ServiceEmprunt serviceEmprunt)
        {
            _serviceEmprunt = serviceEmprunt;
        }

        public List<Emprunt> Emprunts { get; set; }

        public async Task OnGetAsync()
        {
            Emprunts = await _serviceEmprunt.ObtenirTousLesEmpruntsAsync();
        }

        public async Task<IActionResult> OnPostRetournerEmpruntAsync(int id)
        {
            await _serviceEmprunt.RetournerEmpruntAsync(id);
            TempData["SuccessMessage"] = "L'emprunt a été marqué comme retourné avec succès.";
            return RedirectToPage("/RetourEmprunts");
        }
    }
}
