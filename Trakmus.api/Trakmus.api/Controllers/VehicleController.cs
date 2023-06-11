using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Trakmus.api.DAL.Models;
using Trakmus.api.Services;
using Trakmus.api.DAL;

namespace Trakmus.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _VehicleService;

        public VehicleController(IVehicleService VehicleService)
        {
            _VehicleService = VehicleService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<VehicleModel>>> GetAllVehicles()
        {
            try
            {
                var result = await _VehicleService.GetAllVehiclesAsync();

                return result;
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return null;
            }

        }

        [HttpPost("Create")]
        public async Task<ActionResult<VehicleModel>> CreateVehicle(VehicleModel vehicle)
        {
            try
            {
                return await _VehicleService.CreateVehicleAsync(vehicle);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return null;
            }

        }

        [HttpPost("Update")]
        public async Task<ActionResult<VehicleModel>> UpdateVehicle(VehicleModel vehicle)
        {
            return await _VehicleService.UpdateVehicleAsync(vehicle);
        }
    }
}
