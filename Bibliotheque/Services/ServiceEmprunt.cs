using Bibliotheque.Data;
using Bibliotheque.Models;
using Microsoft.EntityFrameworkCore;

namespace Bibliotheque.Services
{
    public class ServiceEmprunt
    {
        private readonly AppDbContext _context;
        private readonly ServiceLivre _serviceLivre;

        public ServiceEmprunt(AppDbContext context, ServiceLivre serviceLivre)
        {
            _context = context;
            _serviceLivre = serviceLivre;
        }

        // Ajouter un nouvel emprunt
        public async Task AjouterEmpruntAsync(Emprunt emprunt)
        {
            if (emprunt == null) throw new ArgumentNullException(nameof(emprunt));

            // Vérifie si le livre existe et est disponible
            var livre = await _context.Livres.FindAsync(emprunt.LivreId);
            if (livre == null) throw new KeyNotFoundException("Livre introuvable.");
            if (livre.QuantiteDisponible <= 0) throw new InvalidOperationException("Livre non disponible.");

            // Vérifie les informations du client
            if (string.IsNullOrWhiteSpace(emprunt.ClientCin))
                throw new InvalidOperationException("CIN du client obligatoire.");

            // Diminue la quantité disponible
            await _serviceLivre.MettreAJourDisponibiliteAsync(livre.Id, false);

            // Ajoute l'emprunt
            emprunt.DateEmprunt = DateTime.Now;
            emprunt.Retourne = false;
            _context.Emprunts.Add(emprunt);
            await _context.SaveChangesAsync();
        }



        // Obtenir tous les emprunts
        public async Task<List<Emprunt>> ObtenirTousLesEmpruntsAsync()
        {
            return await _context.Emprunts
                .Include(e => e.Livre) // Inclut les informations sur le livre
                .ToListAsync();
        }

        // Obtenir un emprunt par ID
        public async Task<Emprunt?> ObtenirEmpruntParIdAsync(int id)
        {
            return await _context.Emprunts
                .Include(e => e.Livre)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        // Obtenir les emprunts en retard
        public async Task<List<Emprunt>> ObtenirEmpruntsEnRetardAsync()
        {
            var aujourdHui = DateTime.Now;
            return await _context.Emprunts
                .Where(e => e.DateRetourPrevue < aujourdHui && !e.Retourne)
                .Include(e => e.Livre)
                .ToListAsync();
        }

        // Marquer un emprunt comme retourné
        public async Task RetournerEmpruntAsync(int empruntId)
        {
            var emprunt = await _context.Emprunts.FindAsync(empruntId);
            if (emprunt == null) throw new KeyNotFoundException("Emprunt introuvable.");
            if (emprunt.Retourne) throw new InvalidOperationException("Emprunt déjà retourné.");

            // Marque comme retourné
            emprunt.Retourne = true;
            emprunt.DateRetourEffective = DateTime.Now;

            // Augmente la quantité disponible pour le livre
            await _serviceLivre.MettreAJourDisponibiliteAsync(emprunt.LivreId, true);

            await _context.SaveChangesAsync();
        }

        // Supprimer un emprunt
        public async Task SupprimerEmpruntAsync(int id)
        {
            var emprunt = await _context.Emprunts.FindAsync(id);
            if (emprunt == null) throw new KeyNotFoundException("Emprunt introuvable.");

            // Si l'emprunt n'a pas été retourné, remettre la quantité du livre
            if (!emprunt.Retourne)
            {
                await _serviceLivre.MettreAJourDisponibiliteAsync(emprunt.LivreId, true);
            }

            _context.Emprunts.Remove(emprunt);
            await _context.SaveChangesAsync();
        }
    }
}
