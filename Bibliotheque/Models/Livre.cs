namespace Bibliotheque.Models
{
    public class Livre
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Auteur { get; set; }
        public string Categorie { get; set; }
        public int AnneePublication { get; set; }
        public double Prix { get; set; }
        public string? CheminImage { get; set; }
        public bool DisponiblePourAchat { get; set; }
        public int QuantiteDisponible { get; set; } // Quantité disponible pour emprunt ou achat
        public int QuantiteTotale { get; set; } // Quantité totale du livre
    }
}
