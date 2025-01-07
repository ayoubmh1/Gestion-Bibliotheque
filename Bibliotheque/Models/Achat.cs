namespace Bibliotheque.Models
{
    public class Achat
    {
        public int Id { get; set; }
        public int LivreId { get; set; }
        public Livre Livre { get; set; }
        public DateTime DateAchat { get; set; }
        public double Montant { get; set; }
    }
}
