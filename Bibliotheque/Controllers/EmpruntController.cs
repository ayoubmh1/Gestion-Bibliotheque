using Bibliotheque.Models;
using Bibliotheque.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bibliotheque.Controllers
{
    public class EmpruntController : Controller
    {
        private readonly ServiceEmprunt _serviceEmprunt;
        private readonly ServiceLivre _serviceLivre;
        private readonly ServiceNotification _serviceNotification;

        public EmpruntController(ServiceEmprunt serviceEmprunt, ServiceLivre serviceLivre, ServiceNotification serviceNotification)
        {
            _serviceEmprunt = serviceEmprunt;
            _serviceLivre = serviceLivre;
            _serviceNotification = serviceNotification;
        }

        // Page des retours
        public async Task<IActionResult> RetourEmprunts()
        {
            var emprunts = await _serviceEmprunt.ObtenirTousLesEmpruntsAsync();
            return View(emprunts);
        }

        // Action pour marquer un emprunt comme retourné
        [HttpPost]
        public async Task<IActionResult> RetournerEmprunt(int id)
        {
            try
            {
                await _serviceEmprunt.RetournerEmpruntAsync(id);
                return RedirectToAction("RetourEmprunts");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("RetourEmprunts");
            }
        }
    }
}
