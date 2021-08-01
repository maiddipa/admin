using System;
using System.Collections.Generic;
using System.Text;

namespace BIMA.Database.Entities
{
    public class CourseSection
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CourseId { get; set; }
        public int Order { get; set; }
        public virtual ICollection<CourseContent> CourseContents { get; set; }

    }
}
