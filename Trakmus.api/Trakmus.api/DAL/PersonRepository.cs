using System.Collections.Generic;
using System;
using Trakmus.api.DAL.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace Trakmus.api.DAL
{
    public interface IPersonRepository : IRepositoryBase<Person>
    {
        Task<Person> GetPersonByIdAsync(Guid id);

        Task<List<Person>> GetAllPersonsAsync();

        Task<Person> CreatePersonAsync(Person person);

        Task<Person> UpdatePersonAsync(Person person);


    }


    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {

        public PersonRepository(TrakMusContext context) : base(context)
        {

        }

        public Task<Person> GetPersonByIdAsync(Guid id)
        {
            return FindAll().FirstOrDefaultAsync<Person>(m => m.Id == id);
        }

        public async Task<Person> CreatePersonAsync(Person person)
        {
            return await CreateAsync(person);
        }

        public async Task<List<Person>> GetAllPersonsAsync()
        {
            return await FindAll().ToListAsync();
        }
        public async Task<Person> UpdatePersonAsync (Person Person)
        {
            return await UpdateAsync(Person);
        }
        public void Delete(Person person)
        {
            return;
        }
    }
}
