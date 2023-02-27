using System;
namespace Trakmus.api.DAL.Models
{
    public class TractorModel
    {
        public Guid Id { get; set; }

        public Guid ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public string Name { get; set; }

        public int IntroYear { get; set; }

        public int LastYear { get; set; }


    }
}
