using BeerStore.Models.Entities;
using BeerStore.Repositories;

namespace BeerStore.Service
{
    public class BeerService
    {
        private BeerDAO beerDAO; 
        public BeerService()
        {
            beerDAO = new BeerDAO();
        }

        public async Task<IEnumerable<Beer>?> GetAll()
        {
            return await beerDAO.GetAll();
        }

        public async Task<IEnumerable<Beer>?> GetBeersByAlcohol(decimal? percentage)
        {
            return await beerDAO.GetBeersByAlcohol(percentage);
        }

        public async Task<IEnumerable<Beer>?> GetBeerWithBrewer(int? brewer)
        {
            return await beerDAO.GetBeersWithBrewer(brewer);
        }
    }
}