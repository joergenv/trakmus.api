using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trakmus.api.DAL.Models;
using Trakmus.api.Services;

namespace Trakmus.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerService _manufacturerService;

        public ManufacturerController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Manufacturer>>> GetAllManufacturers()
        {
            try
            {
                var result = await _manufacturerService.GetAllManufactureresAsync();

                return result;
            }
            catch(Exception ex)
            {
                var s = ex.Message;
                return null;
            }
            
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Manufacturer>> CreateManufacturer(Manufacturer manufacturer)
        {
            try
            {
                return await _manufacturerService.CreateManufacturerAsync(manufacturer);
            }
            catch(Exception ex){
                var s = ex.Message;
                return null;
            }
            
        }

        [HttpPost("Update")]
        public async Task<ActionResult<Manufacturer>> UpdateManufacturer(Manufacturer manufacturer)
        {
            return await _manufacturerService.UpdateManufacturerAsync(manufacturer);
        }
    }
    
}
