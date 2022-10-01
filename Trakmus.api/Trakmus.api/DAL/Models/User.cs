using System;
namespace Trakmus.api.DAL.Models
{
    public class User
    {
        public int Id { get; set; }

        public Guid GuidId { get; set; }
        public string DisplayName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

    }
}
