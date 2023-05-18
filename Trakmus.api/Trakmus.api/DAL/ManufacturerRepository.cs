using System;
using System.Collections.Generic;
using Trakmus.api.DAL.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Trakmus.api.DAL
{
    public interface IManufacturerRepository : IRepositoryBase<Manufacturer>
    {
        Task<Manufacturer> GetManufacturerByIdAsync(Guid id);

        Task<List<Manufacturer>> GetAllManufacturersAsync();

        Task<Manufacturer> CreateManufacturerAsync(Manufacturer manufacturer);

        Task<Manufacturer> UpdateManufacturerAsync(Manufacturer manufacturer);
        
    }


    public class ManufacturerRepository : RepositoryBase<Manufacturer>, IManufacturerRepository
    {

        public ManufacturerRepository(TrakMusContext context) : base(context)
        {
            
        }

        public async Task<List<Manufacturer>> GetAllManufacturersAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Manufacturer> GetManufacturerByIdAsync(Guid id)
        {
            return await FindAll().FirstOrDefaultAsync<Manufacturer>(m => m.Id == id);
        }

        public async Task<Manufacturer> CreateManufacturerAsync(Manufacturer manufacturer)
        {
            return await CreateAsync(manufacturer);
        }
        public async Task<Manufacturer> UpdateManufacturerAsync(Manufacturer manufacturer)
        {
            return await UpdateAsync(manufacturer);
        }
        public void Delete(Guid id)
        {
            return;
        }
    }
}
