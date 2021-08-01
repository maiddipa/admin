using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BIMA.Database.Entities.BaseEntity
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime LastModified { get; set; }

        public BaseEntity()
        {
            CreatedTime = DateTime.UtcNow;
            LastModified = DateTime.UtcNow;
        }
    }
}
