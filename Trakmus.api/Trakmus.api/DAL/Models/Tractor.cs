using System;

namespace Trakmus.api.DAL.Models
{
    public class Tractor
    {
        public Guid Id { get; set; }

        public Guid TractorModelId { get; set; }

        public virtual TractorModel TractorModel { get; set; }

        public Guid PersonId { get; set; }

        public virtual Person Owner { get; set; }

        public int Year { get; set; }

        public int HorsePower { get; set; }

        //fremad-gear
        public int Forward { get; set; }

        //bak-gear
        public int Reverse { get; set; }

        public int Cylinders { get; set; }

        public string Country { get; set; }

        public FuelType FuelType { get; set; }
        
        public string FrontTires { get; set; }

        public string BackTires { get; set; }

        public int Weight { get; set; }

        public int CC { get; set; }

        //slaglængde
        public int Stroke { get; set; }

        //boring
        public int Bore { get; set; }

        public LiftSystem LiftSystem { get; set; }

        public string History { get; set; }

    }
}
