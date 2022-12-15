namespace BeerStore.Areas.Admin.ViewModels
{
    public class BeerAdminVM
    {
        public int Biernr { get; set; }
        public string? Naam { get; set; }
        public string? BrouwerNaam { get; set; }
        public string? SoortNaam { get; set; }
        public decimal? Alcohol { get; set; }
        public string? Image { get; set; }
    }
}
