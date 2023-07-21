using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Trakmus.api.Services.ViewModels;
using Trakmus.api.Shared;

namespace Trakmus.api.DAL.Models
{
    [Table("tractors")]
    public class Tractor
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("tractormodel_id")]
        public Guid TractorModelId { get; set; }

        public virtual VehicleModel TractorModel { get; set; }

        [Column("person_id")]
        public Guid PersonId { get; set; }

        public virtual Person Owner { get; set; }

        [Column("year")]
        public int Year { get; set; }

        [Column("horsepower")]
        public int HorsePower { get; set; }


        //fremad-gear
        [Column("forward")]
        public int Forward { get; set; }

        //bak-gear
        [Column("reverse")]
        public int Reverse { get; set; }

        [Column("cylinders")]
        public int Cylinders { get; set; }

        [Column("country")]
        public string Country { get; set; }

        [Column("fueltype")]
        public FuelType Fuel { get; set; }

        [Column("fronttires")]
        public string FrontTires { get; set; }

        [Column("backtires")]
        public string BackTires { get; set; }

        [Column("weight")]
        public int Weight { get; set; }

        [Column("cc")]
        public int CC { get; set; }

        //slaglængde
        [Column("stroke")]
        public int Stroke { get; set; }

        //boring
        [Column("bore")]
        public int Bore { get; set; }

        [Column("liftsystem")]
        public LiftSystem LiftSystem { get; set; }

        [Column("history")]
        public string History { get; set; }

        [Column("enabled")]
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
