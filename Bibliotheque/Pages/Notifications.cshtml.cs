using Bibliotheque.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Bibliotheque.Models;

namespace Bibliotheque.Pages
{
    public class NotificationsModel : PageModel
    {
        private readonly ServiceEmprunt _serviceEmprunt;

        public List<Emprunt> EmpruntsEnRetard { get; set; } = new();

        public NotificationsModel(ServiceEmprunt serviceEmprunt)
        {
            _serviceEmprunt = serviceEmprunt;
        }

        public async Task OnGetAsync()
        {
            EmpruntsEnRetard = await _serviceEmprunt.ObtenirEmpruntsEnRetardAsync();
        }
    }
}
