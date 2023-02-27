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
    public interface IPersonRepository : IDisposable
    {
        IEnumerable<Person> GetOwners { get; set; }
        IEnumerable<Person> GetUsers { get; set; }
        IEnumerable<Person> GetPersons { get; set; }

        Task<Person> GetPersonByIdAsync(string id);

        Task<Person>GetPersonByEmailAsync(string email);
        void Insert(Person person);
        void Update(Person person);
        void Delete(Guid Id);

        void Save();
    }

    public class PersonRepository : IPersonRepository, IDisposable
    {
        TrakMusContext context;
        Logger<T>

        public PersonRepository (TrakMusContext context)
        {
            this.context = context;
        }

        public Task<Person> GetPersonByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new Exception(string.Format("Email er tomt."));

            var person = context.Persons.FirstOrDefaultAsync(p => p.Email.ToUpper() == email.ToUpper());

            if (person == null)
                throw new Exception(String.Format("Personen med email {0} findes ikke", email));

            return person;
        }

        public Task<Person> GetPersonByIdAsync(string id)
        {
            Guid personId;

            if (!Guid.TryParse(id, out personId))
                throw new Exception(string.Format("Id '{0}' er ikke valid id"));

            var person = context.Persons.FirstOrDefaultAsync(p => p.Id == personId);

            if (person == null)
                throw new Exception(String.Format("Personen med id {0} findes ikke", personId));

            return person;

        }

        public async Task<IEnumerable<Person>> GetOnwers()
        {
            var owners = await context.Tractors.Select(t => t.Owner).Distinct().ToListAsync();

            return owners;
        }

        public async Task<IEnumerable<Person>> GetUsers()
        {
            var users = await context.Persons.Where(p => p.UserId != null).ToListAsync();

            return users;
        }

        public Task<Person> Insert(Person person)
        {
            return Task.FromResult(new Person());
        }

        public Task<Person> Update(Person person)
        {
            return Task.FromResult(new Person());
        }

        public void Delete(Guid id)
        {

        }

    }
}
