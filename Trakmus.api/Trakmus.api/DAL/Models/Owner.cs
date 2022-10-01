using System;
namespace Trakmus.api.DAL.Models
{
    public class Owner
    {
        public int Id { get; set; }

        public Guid GuidId { get; set; }

        public string Name { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
