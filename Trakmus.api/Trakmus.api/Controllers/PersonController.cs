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
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController (IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Person>>> GetAllPersons()
        {
            try
            {
                var result = await _personService.FindAllAsync();
                return result;
            }
            catch(Exception ex)
            {
                var s = ex.Message;
                return null;
            }
        }

        [HttpPost("Create")]
        public async Task<Person> CreatePerson(Person person)
        {
            try
            {
                var result = await _personService.CreateAsync(person);
                return result;
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return null;
            }
        }

        [HttpPost("Update")]
        public async Task<Person> UpdatePerson(Person person)
        {
            try
            {
                var result = await _personService.UpdateAsync(person);
                return result;
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return null;
            }
        }
    }
}
