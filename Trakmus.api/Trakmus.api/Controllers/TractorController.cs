﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Trakmus.api.DAL.Models;
using Trakmus.api.Services;
using Trakmus.api.Services.ViewModels;

namespace Trakmus.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TractorController : ControllerBase
    {        
        private readonly ITractorService _tractorService;
        
        public TractorController(ITractorService tractorService)
        {
            _tractorService = tractorService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<TractorVm>>> GetAllTractors()
        {
            try
            {
                var result = await _tractorService.GetTractorsAsync("");

                return result;
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return null;
            }

        }

        [HttpPost("Create")]
        public async Task<ActionResult<Tractor>> CreateTractor(Tractor tractor)
        {
            try
            {
                return await _tractorService.CreateTractorAsync(tractor);
                    
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return null;
            }

        }

        [HttpPost("Update")]
        public async Task<ActionResult<Tractor>> UpdateTractor(Tractor tractor)
        {
            return await _tractorService.UpdateTractorAsync(tractor);
        }

    }
}
