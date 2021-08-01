using BIMA.Common.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace BIMA.Domain.Models.Public
{
    public class ContactUsModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public QuestionType QuestionType { get; set; }
    }
}
