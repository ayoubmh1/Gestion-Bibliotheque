using Bibliotheque.Models;
using Bibliotheque.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bibliotheque.Pages.Emprunts
{
    public class NouveauEmpruntModel : PageModel
    {
        private readonly ServiceEmprunt _serviceEmprunt;

        [BindProperty]
        public string NomClient { get; set; } = string.Empty;

        [BindProperty]
        public string CinClient { get; set; } = string.Empty;

        [BindProperty]
        public DateTime DateRetourPrevue { get; set; }

        [BindProperty(SupportsGet = true)]
        public int LivreId { get; set; }

        // Propri�t� pour stocker le message de succ�s
        public string? SuccessMessage { get; set; }

        public NouveauEmpruntModel(ServiceEmprunt serviceEmprunt)
        {
            _serviceEmprunt = serviceEmprunt;
            DateRetourPrevue = DateTime.Now.AddDays(1);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Cr�ation d'un nouvel emprunt
            var emprunt = new Emprunt
            {
                LivreId = LivreId,
                ClientCin = CinClient,
                ClientNom = NomClient,
                DateEmprunt = DateTime.Now,
                DateRetourPrevue = DateRetourPrevue,
                Retourne = false
            };

            // Ajout dans la base de donn�es via le service
            await _serviceEmprunt.AjouterEmpruntAsync(emprunt);

            // D�finir le message de succ�s
            SuccessMessage = "Emprunt ajout� avec succ�s !";

            // Rendre la m�me page
            return Page();
        }
    }
}
