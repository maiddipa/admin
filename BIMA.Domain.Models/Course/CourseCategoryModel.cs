using System;
using System.Collections.Generic;
using System.Text;

namespace BIMA.Domain.Models.Course
{
    public class CourseCategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public bool HasSubCategories { get; set; }
    }
}
