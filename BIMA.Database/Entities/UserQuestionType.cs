using BIMA.Common.Core.Enum;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BIMA.Database.Entities
{
    public class UserQuestionType
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; }
        public QuestionType QuestionType { get; set; }

    }
}
