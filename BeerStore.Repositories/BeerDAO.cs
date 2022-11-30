using BeerStore.Models.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace BeerStore.Repositories
{
    public class BeerDAO
    {
        private readonly BeerDbContext _dbContext;

        public BeerDAO()
        {
            _dbContext = new BeerDbContext();
        }

        public IEnumerable<Models.Entities.Beer> GetAll()
        {
            try
            {
                return _dbContext.Beers.Include(a => a.BrouwernrNavigation).Include(a => a.SoortnrNavigation).ToList();
            }
            catch (Microsoft.Data.SqlClient.SqlException ex)
            {
                Debug.WriteLine("db not found", ex.ToString());
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}