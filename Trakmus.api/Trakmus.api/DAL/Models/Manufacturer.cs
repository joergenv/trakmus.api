using System;

namespace Trakmus.api.DAL.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }

        public Guid GuidId { get; set; }

        public string Name { get; set; }

        public char[] Country { get; set; }

        public string History { get; set; }
    }
}
