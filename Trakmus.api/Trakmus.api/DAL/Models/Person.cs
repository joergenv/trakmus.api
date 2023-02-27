using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trakmus.api.DAL.Models
{
    [Table("persons")]
    public class Person
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("firstname")]
        public string FirstName { get; set; }

        [Column("lastname")]
        public string LastName { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("note")]
        public string Note { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("user_id")]
        public Guid? UserId { get; set; }

        public virtual User? User { get; set; }
    }
}
