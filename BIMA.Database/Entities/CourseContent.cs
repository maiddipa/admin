using System;
using System.Collections.Generic;
using System.Text;

namespace BIMA.Database.Entities
{
    public class CourseContent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CourseSectionId { get; set; }
        public string ResourceLocation { get; set; }
        public double Duration { get; set; }
        public int Order { get; set; }
        public virtual UserCourseContent UserCourseContent { get; set; }


    }
}
