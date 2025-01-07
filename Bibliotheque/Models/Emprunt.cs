namespace Bibliotheque.Models
{
    public class Emprunt
    {
        public int Id { get; set; }
        public int LivreId { get; set; }
        public Livre Livre { get; set; }
        public DateTime DateEmprunt { get; set; }
        public DateTime DateRetourPrevue { get; set; }
        public DateTime? DateRetourEffective { get; set; }
        public bool Retourne { get; set; } // Indique si le livre est retourné
        public string ClientCin { get; set; } // Assurez-vous que cette propriété est présente
        public string ClientNom { get; set; } // (facultatif) Nom du client
    }
}
