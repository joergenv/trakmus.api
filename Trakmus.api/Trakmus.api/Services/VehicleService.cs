using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trakmus.api.DAL;
using Trakmus.api.DAL.Models;

namespace Trakmus.api.Services
{
    public interface IVehicleService
    {
        Task<VehicleModel> CreateVehicleAsync(VehicleModel model);

        Task<VehicleModel> UpdateVehicleAsync(VehicleModel model);

        Task<List<VehicleModel>> GetAllVehiclesAsync();

    }

    public class VehicleService : IVehicleService
    {
        IVehicleModelRepository _vehicleModelRepository;

        public VehicleService(IVehicleModelRepository vehicleModelRepository)
        {
            _vehicleModelRepository = vehicleModelRepository;
        }

        public async Task<VehicleModel> CreateVehicleAsync(VehicleModel model)
        {
            try
            {
                return await _vehicleModelRepository.CreateVehicleAsync(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<VehicleModel> UpdateVehicleAsync(VehicleModel model)
        {
            return await _vehicleModelRepository.UpdateVehicleAsync(model);
        }

        public async Task<List<VehicleModel>> GetAllVehiclesAsync()
        {
            return await _vehicleModelRepository.GetAllVehiclesAsync();
        }

    }
}
