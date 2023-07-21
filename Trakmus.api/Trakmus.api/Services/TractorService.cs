using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualBasic;
//using Org.BouncyCastle.Asn1.IsisMtt.X509;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Trakmus.api.DAL;
using Trakmus.api.DAL.Models;
using Trakmus.api.Services.ViewModels;
using Trakmus.api.Shared;

namespace Trakmus.api.Services
{
    /// <summary>
    /// services er lagt ind som businesslogic-lag, hvor der bl.a. fejlhåndteres og mappes til viewmodels
    /// </summary>

    public interface ITractorService
    {
        Task<TractorVm> GetTractorByIdAsync(Guid id);

        Task<List<TractorVm>> GetTractorsAsync(string search);

        Task<Tractor> CreateTractorAsync(Tractor tractor);

        Task<Tractor> UpdateTractorAsync(Tractor tractor);
        Task DeleteTractorAsync(Tractor tractor);
        
    }

    /// <summary>
    /// Modellen indeholder også fabrikant.
    /// </summary>

    public class TractorService : ITractorService
    {
        private readonly ITractorRepository _tractorRepository;
        private readonly IVehicleModelRepository _vehicleModelRepository;
        private readonly IPersonRepository _personRepository;

        public TractorService(ITractorRepository tractorRepository, IVehicleModelRepository vehicleModelRepository, IPersonRepository personRepository)
        {
            _tractorRepository = tractorRepository;
            _personRepository = personRepository;
            _vehicleModelRepository = vehicleModelRepository;
        }

        public async Task<TractorVm> GetTractorByIdAsync(Guid id)
        {
            var result = _tractorRepository.GetTractorByIdAsync(id);

            var er = result.Cast<TractorVm>();

            return await er;

        }

        public List<TractorVm> GetAllTractorsAsync()
        {
            var result = _tractorRepository.GetAllTractorsAsync();

            var list = Task.Run(() => result).GetAwaiter();
            var tractors = list.GetResult();

            return tractors.Select(t => new TractorVm()
            {
                Id = t.Id.ToString(),
                BackTires = t.BackTires,
                Bore = t.Bore,
                CC = t.CC,
                Country = t.Country,
                Cylinders = t.Cylinders,
                Forward = t.Forward,
                FrontTires = t.FrontTires,
                HorsePower = t.HorsePower,
                LiftSystem = t.LiftSystem.ToString(),
                ModelId = t.TractorModel.Id.ToString(),
                Manufacturer = t.TractorModel.Manufacturer.Name.ToString(),
                Owner = t.Owner.FirstName + t.Owner.LastName,
                OwnerId = t.Owner.Id.ToString(),
                Reverse = t.Reverse,
                ModelName = t.TractorModel.Name,
                Stroke = t.Stroke,
                Weight = t.Weight,
                Year = t.Year,
                Fuel = t.Fuel.ToString(language.Dansk)
            }).ToList();

        }

        public async Task<List<TractorVm>> GetTractorsAsync(string search)
        {
             var result = _tractorRepository.FindByCondition(t => t.TractorModel.Name.ToUpper()
            .Contains(search.ToUpper()) || t.TractorModel.Manufacturer.Name.ToUpper().Contains(search.ToUpper()));

            var list = Task.Run(() => result).GetAwaiter();
            var tractors = list.GetResult();

            return await tractors.Select(t => new TractorVm()
            {
                Id = t.Id.ToString(),
                BackTires = t.BackTires,
                Bore = t.Bore,
                CC = t.CC,
                Country = t.Country,
                Cylinders = t.Cylinders,
                Forward = t.Forward,
                FrontTires = t.FrontTires,
                HorsePower = t.HorsePower,
                LiftSystem = t.LiftSystem.ToString(),
                ModelId = t.TractorModel.Id.ToString(),
                Manufacturer = t.TractorModel.Manufacturer.Name.ToString(),
                Owner = t.Owner.FirstName + t.Owner.LastName,
                OwnerId = t.Owner.Id.ToString(),
                Reverse = t.Reverse,
                ModelName = t.TractorModel.Name,
                Stroke = t.Stroke,
                Weight = t.Weight,
                Year = t.Year,
                Fuel = t.Fuel.ToString(language.Dansk)
            }).ToListAsync();

        }

        public async Task<Tractor> CreateTractorAsync(Tractor tractor)
        {
            tractor.Id = Guid.NewGuid();
            return await _tractorRepository.CreateAsync(tractor);
        }

        public async Task<Tractor> UpdateTractorAsync(Tractor tractor)
        {
            return await _tractorRepository.UpdateAsync(tractor);
        }
        
        public async Task DeleteTractorAsync(Tractor tractor)
        {
            tractor.Enabled = false;

            var t = await _tractorRepository.UpdateAsync(tractor);
            _ = Task.Run(() => t);

        }

    }
}
