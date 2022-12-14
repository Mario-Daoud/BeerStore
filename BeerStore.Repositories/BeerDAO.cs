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

        public async Task<IEnumerable<Models.Entities.Beer>?> GetAll()
        {
            try
            {
                return await _dbContext.Beers.Include(a => a.BrouwernrNavigation).Include(a => a.SoortnrNavigation).ToListAsync();
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

        public async Task<IEnumerable<Models.Entities.Beer>?> GetBeersByAlcohol(decimal? percentage)
        {
            try
            {
                return _dbContext.Beers.Where(a => a.Alcohol >= percentage).Include(a => a.BrouwernrNavigation).Include(a => a.SoortnrNavigation).ToList();
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

        public async Task<IEnumerable<Models.Entities.Beer>?> GetBeersWithBrewer(string? brewer)
        {
            //SQL "select * from Adult"

            try
            {
                return await _dbContext.Beers.Where(a => a.BrouwernrNavigation.Naam == brewer).Include(b => b.BrouwernrNavigation).Include(b => b.SoortnrNavigation).ToListAsync(); ;
            }
            catch (Microsoft.Data.SqlClient.SqlException ex)
            {
                Debug.WriteLine("Didn't found db", ex.ToString());
                return null;
            }

            catch (Exception ex)
            {
                return null;
            }
        }
    }
}