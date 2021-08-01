using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BIMA.Database.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public virtual Country Country { get; set; }
        public string District { get; set; }
        public int Population { get; set; }

        public virtual ICollection<User> Users { get; set; }

    }
}
