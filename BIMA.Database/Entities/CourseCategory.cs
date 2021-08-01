using System;
using System.Collections.Generic;
using System.Text;

namespace BIMA.Database.Entities
{
    public class CourseCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public int Order { get; set; }
        public int? ParentCategoryId { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

    }
}
