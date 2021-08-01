using BIMA.Database.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BIMA.Database.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CourseCategoryId { get; set; }
        public virtual CourseCategory CourseCategory { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public int SectionsCount { get; set; }
        public int CoursesCount { get; set; }
        public decimal TotalCourseTime { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int Order { get; set; }
        public string  Logo { get; set; }

        public virtual ICollection<CourseSection> CourseSections { get; set; }


    }
}
