using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trakmus.api.DAL.Models
{
    [Table("manufacturers")]
    public class Manufacturer
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("country")]
        public string Country { get; set; }

        [Column("history")]
        public string History { get; set; }
    }
}
