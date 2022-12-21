using BeerStore.Models.Data;
using BeerStore.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerStore.Repositories
{
    public class VarietyDAO
    {
        private readonly BeerDbContext _dbContext;

        public VarietyDAO()
        {
            _dbContext = new BeerDbContext();
        }

        public async Task<IEnumerable<Variety>?> GetAll()
        {
            try
            {
                return await _dbContext.Varieties.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
