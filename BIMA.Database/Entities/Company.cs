using System;
using System.Collections.Generic;
using System.Text;

namespace BIMA.Database.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public virtual ICollection<User> Users { get; set; }

    }
}
