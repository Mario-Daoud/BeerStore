using BeerStore.Repositories;

namespace BeerStore.Service
{
    public class BeerService
    {
        private BeerDAO BeerDAO { get; set; }

        public BeerService()
        {
            BeerDAO = new BeerDAO();
        }

        public IEnumerable<Models.Entities.Beer>? GetAll()
        {
            return BeerDAO.GetAll();
        }
    }
}