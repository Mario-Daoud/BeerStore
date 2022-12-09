using BeerStore.Models.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace BeerStore.Repositories
{
    public class BreweryDAO
    {
        private readonly BeerDbContext _dbContext;

        public BreweryDAO()
        {
            _dbContext = new BeerDbContext();
        }

        public async Task<IEnumerable<Models.Entities.Brewery>?> GetAll()
        {
            try
            {
                return await _dbContext.Breweries.ToListAsync();
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