using Bibliotheque.Services;
using Bibliotheque.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bibliotheque.Pages
{
    public class AjouterLivreModel : PageModel
    {
        private readonly ServiceLivre _serviceLivre;

        [BindProperty]
        public Livre Livre { get; set; }

        [BindProperty]
        public IFormFile? ImageFile { get; set; }

        public AjouterLivreModel(ServiceLivre serviceLivre)
        {
            _serviceLivre = serviceLivre;
        }

        public void OnGet()
        {
            // Aucune logique spécifique pour la requête GET
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Retourne la page si les données du formulaire ne sont pas valides
                return Page();
            }

            try
            {
                // Si une image a été uploadée, enregistrez-la
                if (ImageFile != null)
                {
                    var filePath = Path.Combine("wwwroot/images", ImageFile.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(stream);
                    }
                    Livre.CheminImage = "/images/" + ImageFile.FileName;
                }
                else
                {
                    // Utilisez une image par défaut si aucune image n'est fournie
                    Livre.CheminImage = "/images/default-book.png";
                }

                // Ajoutez le livre en base de données
                await _serviceLivre.AjouterLivreAsync(Livre);

                // Affichez un message de confirmation
                TempData["Message"] = "Livre ajouté avec succès !";

                return RedirectToPage("AjouterLivre");
            }
            catch (Exception ex)
            {
                // Gérer les erreurs et afficher un message d'erreur
                ModelState.AddModelError(string.Empty, $"Erreur : {ex.Message}");
                return Page();
            }
        }
    }
}
