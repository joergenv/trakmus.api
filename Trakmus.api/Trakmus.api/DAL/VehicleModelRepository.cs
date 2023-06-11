using System;
using System.Collections.Generic;
using Trakmus.api.DAL.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Trakmus.api.DAL
{
    public interface IVehicleModelRepository : IRepositoryBase<VehicleModel>
    {
        Task<VehicleModel> GetByIdAsync(Guid id);

        Task<List<VehicleModel>> Search(string s);

        Task<VehicleModel> CreateVehicleAsync(VehicleModel vehicleModel);

        Task<VehicleModel> UpdateVehicleAsync(VehicleModel vehicleModel);

        Task<List<VehicleModel>> GetAllVehiclesAsync();
    }


    public class VerhicleModelRepository : RepositoryBase<VehicleModel>, IVehicleModelRepository
    {

        public VerhicleModelRepository(TrakMusContext context) : base(context)
        {

        }

        public async Task<VehicleModel> GetByIdAsync(Guid id)
        {
            return await FindAll().FirstOrDefaultAsync<VehicleModel>(m => m.Id == id);
        }

        public async Task<List<VehicleModel>> GetAllVehiclesAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<List<VehicleModel>> Search(string s)
        {
            return await FindByCondition(m => m.Name.ToUpper().Contains(s.ToUpper()) || m.Manufacturer.Name.ToUpper().Contains(s.ToUpper())).ToListAsync();
        }

        public async Task<VehicleModel> CreateVehicleAsync(VehicleModel vehicleModel)
        {
            return await CreateAsync(vehicleModel);
        }

        public async Task<VehicleModel> UpdateVehicleAsync(VehicleModel vehicleModel)
        {
            return await UpdateAsync(vehicleModel);
        }
        public void DeleteVehicle(VehicleModel vehicleModel)
        {
            return;
        }
    }
}
