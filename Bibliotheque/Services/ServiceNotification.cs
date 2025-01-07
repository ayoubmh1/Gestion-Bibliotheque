using Bibliotheque.Data;
using Bibliotheque.Models;
using Microsoft.EntityFrameworkCore;

public class ServiceNotification
{
    private readonly AppDbContext _context;

    public ServiceNotification(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> CompterNotificationsAsync()
    {
        return await _context.Emprunts
            .CountAsync(e => e.DateRetourEffective == null && e.DateRetourPrevue < DateTime.Now);
    }
    public async Task<List<Emprunt>> ObtenirNotificationsAsync()
    {
        return await _context.Emprunts
            .Where(e => e.DateRetourEffective == null && e.DateRetourPrevue < DateTime.Now)
            .Include(e => e.Livre)
            .ToListAsync();
    }
}
