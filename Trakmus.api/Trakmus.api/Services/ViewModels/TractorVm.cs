using System;
using Trakmus.api.DAL.Models;
using Trakmus.api.DAL;
using System.Threading.Tasks;
using System.Data;

namespace Trakmus.api.Services.ViewModels
{
    public class TractorVm : EntityVm
    {
        public string Manufacturer { get; set; }

        public string ModelId { get; set; }
        public string ModelName { get; set; }

        public string OwnerId { get; set; }

        public string Owner { get; set; }

        public int Year { get; set; }

        public int HorsePower { get; set; }

        //fremad-gear
        public int Forward { get; set; }

        //bak-gear
        public int Reverse { get; set; }

        public int Cylinders { get; set; }

        public string Country { get; set; }

        public string Fuel { get; set; }

        public string FrontTires { get; set; }

        public string BackTires { get; set; }

        public int Weight { get; set; }

        public int CC { get; set; }

        //slaglængde
        public int Stroke { get; set; }

        //boring
        public int Bore { get; set; }

        public string LiftSystem { get; set; }

        public string History { get; set; }

    }
    
}
