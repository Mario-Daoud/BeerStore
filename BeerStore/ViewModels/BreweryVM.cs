namespace BeerStore.ViewModels
{
    public class BreweryVM
    {
        public int Brouwernr { get; set; }
        public string? Naam { get; set; } 
        public string? Adres { get; set; }
        public string? Postcode { get; set; }
        public string? Gemeente { get; set; }
        public float Omzet { get; set; }
    }
}
