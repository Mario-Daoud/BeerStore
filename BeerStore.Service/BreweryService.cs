using BeerStore.Repositories;
using BeerStore.Models.Entities;


namespace BeerStore.Service
{
    public class BreweryService
    {
        private BreweryDAO breweryDAO;

        public BreweryService()
        {
            breweryDAO = new BreweryDAO();
        }

        public async Task<IEnumerable<Brewery>?> GetAll()
        {
            return await breweryDAO.GetAll();
        }


    }
}