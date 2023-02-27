using System;

namespace Trakmus.api.DAL.Models
{
    public class Manufacturer
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string History { get; set; }
    }
}
