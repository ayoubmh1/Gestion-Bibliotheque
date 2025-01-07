function ouvrirModal(element) {
    const id = element.getAttribute('data-id');
    const titre = element.getAttribute('data-titre');
    const auteur = element.getAttribute('data-auteur');
    const categorie = element.getAttribute('data-categorie');
    const anneePublication = element.getAttribute('data-anneepublication');
    const prix = element.getAttribute('data-prix');
    const disponiblePourAchat = element.getAttribute('data-disponibl-epourachat') === 'true' ? "Oui" : "Non";
    const cheminImage = element.getAttribute('data-cheminimage');

    // Remplir les informations du modal
    document.getElementById('modalTitre').textContent = titre;
    document.getElementById('modalAuteur').textContent = `Auteur : ${auteur}`;
    document.getElementById('modalCategorie').textContent = `Catégorie : ${categorie}`;
    document.getElementById('modalAnneePublication').textContent = `Année de publication : ${anneePublication}`;
    document.getElementById('modalPrix').textContent = `Prix : ${prix}€`;
    document.getElementById('modalDisponiblePourAchat').textContent = `Disponible à l'achat : ${disponiblePourAchat}`;
    document.getElementById('modalImage').src = cheminImage;

    document.getElementById('livreModal').setAttribute('data-id', id);

    document.getElementById('livreModal').style.display = 'flex';
}
function fermerModal() {
    document.getElementById('livreModal').style.display = 'none';
}
