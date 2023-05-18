using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trakmus.api.DAL;
using Trakmus.api.DAL.Models;

namespace Trakmus.api.Services
{
    interface IManufacturerService
    {
        Task<Manufacturer> CreateManufacturerAsync(Manufacturer manufacturer);

        Task<Manufacturer> UpdateManufacturerAsync(Manufacturer manufacturer);

        Task<List<Manufacturer>> GetAllManufactureresAsync();


    }

    public class ManufacturerService : IManufacturerService
    {
        IManufacturerRepository _manufacturerReposistory;
        public ManufacturerService(IManufacturerRepository manufacturerRepository)
        {
            _manufacturerReposistory = manufacturerRepository;
        }

        public async Task<Manufacturer> CreateManufacturerAsync(Manufacturer manufacturer)
        {
            try
            {
                return await _manufacturerReposistory.CreateManufacturerAsync(manufacturer);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Manufacturer> UpdateManufacturerAsync(Manufacturer manufacturer)
        {
            return await _manufacturerReposistory.UpdateManufacturerAsync(manufacturer);
        }

        public async Task<List<Manufacturer>> GetAllManufactureresAsync()
        {
            return await _manufacturerReposistory.GetAllManufacturersAsync();
        }
    }
}
