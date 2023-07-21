using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trakmus.api.DAL.Models
{

    [Table("vehiclemodels")]
    public class VehicleModel
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("manufacturer_id")]        
        public Guid ManufacturerId { get; set; }

        [ForeignKey("ManufacturerId")]
        public virtual Manufacturer Manufacturer { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("introyear")]
        public int IntroYear { get; set; }

        [Column("lastyear")]
        public int LastYear { get; set; }

        [Column("country")]
        public string Country { get; set; }

        [Column("history")]
        public string History { get; set; }



    }
}
