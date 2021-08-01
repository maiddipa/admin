using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BIMA.Database.Entities
{
    public class Role : IdentityRole<long>
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }

    }
}
