using Bibliotheque.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace Bibliotheque.Pages
{
    public class AccueilModel : PageModel
    {
        private readonly ServiceLivre _serviceLivre;
        private readonly ServiceNotification _serviceNotification;

        public List<Livre> Livres { get; set; } = new();
        public List<Emprunt> EmpruntsEnRetard { get; set; } = new();
        public int NombreNotifications => EmpruntsEnRetard.Count;
        public string SearchTerm { get; set; }

        public AccueilModel(ServiceLivre serviceLivre, ServiceNotification serviceNotification)
        {
            _serviceLivre = serviceLivre;
            _serviceNotification = serviceNotification;
        }

        public async Task OnGetAsync(string searchTerm)
        {
            SearchTerm = searchTerm;
            var livres = await _serviceLivre.ObtenirTousLesLivresAsync();

            if (!string.IsNullOrEmpty(SearchTerm))
            {
                Livres = livres.Where(l => l.Titre.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                                           l.Auteur.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                                           l.Categorie.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                Livres = livres;
            }

            EmpruntsEnRetard = await _serviceNotification.ObtenirNotificationsAsync();
        }
    }
}