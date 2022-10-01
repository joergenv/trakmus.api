using System;
namespace Trakmus.api.DAL.Models
{
    public class TractorModel
    {
        public int Id { get; set; }

        public Guid GuidId { get; set; }

        public int MyProperty { get; set; }

        public int ManufacturerId { get; set; }

        public string Name { get; set; }

        public int IntroYear { get; set; }

        public int LastYear { get; set; }


    }
}
