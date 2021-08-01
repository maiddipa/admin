using System;
using System.Collections.Generic;
using System.Text;

namespace BIMA.Database.Entities
{
    public class UserCourseContent
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public int CourseContentId { get; set; }
        public int CourseId { get; set; }
        public string Notes { get; set; }
        public bool IsWatched { get; set; }
        public int Time { get; set; }

        public virtual CourseContent CourseContent { get; set; }
    }
}
