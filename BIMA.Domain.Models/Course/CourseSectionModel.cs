using System;
using System.Collections.Generic;
using System.Text;

namespace BIMA.Domain.Models.Course
{
    public class CourseSectionModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<CourseContentModel> CourseContents { get; set; }
    }
}
