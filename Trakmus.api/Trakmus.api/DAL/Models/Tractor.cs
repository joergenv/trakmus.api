using System;
using System.Collections.Generic;
using System.Linq;
using Trakmus.api.Services.ViewModels;
using Trakmus.api.Shared;

namespace Trakmus.api.DAL.Models
{
    public class Tractor
    {
        public Guid Id { get; set; }

        public Guid TractorModelId { get; set; }

        public virtual VehicleModel TractorModel { get; set; }

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

        public FuelType Fuel { get; set; }
        
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

        public bool Enabled { get; set; }

        public static explicit operator TractorVm(Tractor t)
        {

            TractorVm output = new TractorVm
            {

                Id = t.Id.ToString(),
                BackTires = t.BackTires,
                Bore = t.Bore,
                CC = t.CC,
                Country = t.Country,
                Cylinders = t.Cylinders,
                Forward = t.Forward,
                FrontTires = t.FrontTires,
                HorsePower = t.HorsePower,
                LiftSystem = t.LiftSystem.ToString(),
                ModelId = t.TractorModel.Id.ToString(),
                Manufacturer = t.TractorModel.Manufacturer.Name.ToString(),
                Owner = t.Owner.FirstName + t.Owner.LastName,
                OwnerId = t.Owner.Id.ToString(),
                Reverse = t.Reverse,
                ModelName = t.TractorModel.Name,
                Stroke = t.Stroke,
                Weight = t.Weight,
                Year = t.Year,
                Fuel = t.Fuel.ToString(language.Dansk)
            };

            return output;
        }

        //public static explicit operator List<TractorVm>(List<Tractor> t)
        //{

        //    List<TractorVm> output = t.Select(model => new TractorVm()
        //    {
        //        Id = model.Id.ToString(),
        //        BackTires = model.BackTires,
        //        Bore = model.Bore,
        //        CC = model.CC,
        //        Country = model.Country,
        //        Cylinders = model.Cylinders,
        //        Forward = model.Forward,
        //        FrontTires = model.FrontTires,
        //        HorsePower = model.HorsePower,
        //        LiftSystem = model.LiftSystem.ToString(),
        //        ModelId = model.TractorModel.Id.ToString(),
        //        Manufacturer = model.TractorModel.Manufacturer.Name.ToString(),
        //        Owner = model.Owner.FirstName + model.Owner.LastName,
        //        OwnerId = model.Owner.Id.ToString(),
        //        Reverse = model.Reverse,
        //        ModelName = model.TractorModel.Name,
        //        Stroke = model.Stroke,
        //        Weight = model.Weight,
        //        Year = model.Year,
        //        Fuel = model.Fuel.ToString(language.Dansk)
        //    }).ToList();

        //    return output;
        //}


    }
}
