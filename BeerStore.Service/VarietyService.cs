using BeerStore.Models.Entities;
using BeerStore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BeerStore.Service
{
    public class VarietyService
    {
        private VarietyDAO varietyDAO;

        public VarietyService()
        {
            varietyDAO = new VarietyDAO();
        }

        public async Task<IEnumerable<Variety>> GetAll()
        {
            return await varietyDAO.GetAll();
        }


    }
}