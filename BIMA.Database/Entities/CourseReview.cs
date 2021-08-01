using System;
using System.Collections.Generic;
using System.Text;

namespace BIMA.Database.Entities
{
    public class CourseReview
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ReviewContent { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int Order { get; set; }

    }
}
