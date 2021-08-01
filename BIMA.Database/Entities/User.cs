using BIMA.Common.Core.Enum;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BIMA.Database.Entities
{
    public class User : IdentityUser<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; } 
        public DateTime? ModifiedDate { get; set; }
        public string CompanyName { get; set; }
        public int Age { get; set; }
        public string CountryCode { get; set; }
        public virtual Country Country { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }
        public bool Paid { get; set; }
        public GenderEnum? Gender { get; set; }
        public string Employment { get; set; }
        public string CompanyUniqueStamp { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<UserQuestionType> UserQuestionTypes { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<UserCourseContent> UserCourseContents { get; set; }




        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + " " + FirstName;
            }
        }
    }
}
