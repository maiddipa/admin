using System;
using System.Collections.Generic;
using System.Text;

namespace BIMA.Domain.Models.Course
{
    public class CourseContentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ResourceLocation { get; set; }
        public int Duration { get; set; }
        public string Notes { get; set; }
        public bool IsWatched { get; set; }
        public int Time { get; set; }
    }
}
