using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trakmus.api.DAL;
using Trakmus.api.DAL.Models;

namespace Trakmus.api.Services
{

    public interface IPersonService
    {
        Task<List<Person>> FindAllAsync();

        Task<Person> FindById(Guid id);

        Task<Person> CreateAsync(Person person);

        Task<Person> UpdateAsync(Person person);
    }


    /// <summary>
    /// Grunden til at der bliver brugt Create i stedet for Addx er for at følge CRUD-navngivningen.
    /// </summary>
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService (IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Person> FindById(Guid id)
        {
            return await _personRepository.GetPersonByIdAsync(id);
        }


        public async Task<Person> CreateAsync(Person person)
        {
            try
            {
                ValidatePerson(person);
                return await _personRepository.CreatePersonAsync(person);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Person> UpdateAsync(Person person)
        {
            try
            {
                ValidatePerson(person);
                return await _personRepository.UpdatePersonAsync(person);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }        
        }

        public async Task<List<Person>> FindAllAsync()
        {
            return  await _personRepository.FindAll().ToListAsync();
            
        }

        //public async Task<List<Person>> SearchAsync(string s)
        //{
        //    var result = await _personRepository.GetByIdAsync().ToLis
        //    if (string.IsNullOrEmpty(s))
        //}



        private void ValidatePerson(Person person)
        {
            if (string.IsNullOrEmpty(person.Email) && person.User != null)
                throw new Exception("Personen skal have en email-adresse, for at kunne bliver oprettet som bruger");
            if (string.IsNullOrEmpty(person.FirstName))
                throw new Exception("Personen skal have et fornavn");
            if (string.IsNullOrEmpty(person.LastName))
                throw new Exception("Personen skal have et efternavn");
        }
    }
}
