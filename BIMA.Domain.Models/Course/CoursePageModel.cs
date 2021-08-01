using System;
using System.Collections.Generic;
using System.Text;

namespace BIMA.Domain.Models.Course
{
    public class CoursePageModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string  Description { get; set; }
        public List<CourseSectionModel> CourseSections{ get; set; }
    }
}
