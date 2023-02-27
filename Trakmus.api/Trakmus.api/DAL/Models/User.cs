using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trakmus.api.DAL.Models
{
    [Table("users")]
    public class User
    {
        public Guid Id { get; set; }
        
        public string DisplayName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

    }
}
