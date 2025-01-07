using Bibliotheque.Data;
using Bibliotheque.Models;
using Microsoft.EntityFrameworkCore;

public class ServiceLivre
{
    private readonly AppDbContext _context;

    public ServiceLivre(AppDbContext context)
    {
        _context = context;
    }

    // Ajouter un livre
    public async Task AjouterLivreAsync(Livre livre)
    {
        if (livre == null) throw new ArgumentNullException(nameof(livre));

        // Image par défaut si aucune image n'est spécifiée
        if (string.IsNullOrEmpty(livre.CheminImage))
        {
            livre.CheminImage = "/images/default-book.png";
        }

        _context.Livres.Add(livre);
        await _context.SaveChangesAsync();
    }

    // Obtenir tous les livres
    public async Task<List<Livre>> ObtenirTousLesLivresAsync()
    {
        return await _context.Livres.ToListAsync();
    }

    // Obtenir un livre par ID
    public async Task<Livre?> ObtenirLivreParIdAsync(int id)
    {
        return await _context.Livres.FindAsync(id);
    }

    // Supprimer un livre
    public async Task SupprimerLivreAsync(int id)
    {
        var livre = await ObtenirLivreParIdAsync(id);
        if (livre == null) throw new KeyNotFoundException("Livre introuvable.");

        _context.Livres.Remove(livre);
        await _context.SaveChangesAsync();
    }

    // Mettre à jour la quantité disponible
    public async Task MettreAJourDisponibiliteAsync(int livreId, bool incrementer)
    {
        var livre = await _context.Livres.FindAsync(livreId);
        if (livre == null) throw new KeyNotFoundException("Livre introuvable.");

        if (incrementer)
        {
            livre.QuantiteDisponible++;
        }
        else
        {
            if (livre.QuantiteDisponible <= 0)
                throw new InvalidOperationException("La quantité disponible est déjà à zéro.");
            livre.QuantiteDisponible--;
        }

        await _context.SaveChangesAsync();
    }
}
