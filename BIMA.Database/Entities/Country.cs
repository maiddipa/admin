using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BIMA.Database.Entities
{
    public class Country
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public string Region { get; set; }
        public float SurfaceArea { get; set; }
        public int IndepYear { get; set; }
        public int Population { get; set; }
        public float LifeExpectancy { get; set; }
        public float GNP { get; set; }
        public float GNPOld { get; set; }
        public string LocalName { get; set; }
        public string GovernmentForm { get; set; }
        public string HeadOfState { get; set; }
        public string Capital { get; set; }
        public string Code2 { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
