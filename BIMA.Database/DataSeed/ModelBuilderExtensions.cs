using BIMA.Common.Core.Enum;
using BIMA.Database.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BIMA.Database.DataSeed
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User 
                {  
                    Id = 1, 
                    FirstName = "Amir", 
                    LastName = "Sivic",
                    UserName = "amir@digitalbim.academy",
                    NormalizedUserName = "AMIR@DIGITALBIM.ACADEMY",
                    Email = "amir@digitalbim.academy", 
                    NormalizedEmail = "AMIR@DIGITALBIM.ACADEMY",
                    PasswordHash = "AQAAAAEAACcQAAAAEJc6xurcAX/U6mpwBvPz0nVd9vbGIoxHnHLkS1Wm9ypvrfwaoZCENVDMB5WUnVe2Vw==", //B!mAcad3my
                    EmailConfirmed = true,
                    CreatedDate = new DateTime(2021, 1, 1),
                    ConcurrencyStamp = "3478806a-694d-4797-bfcd-69e01d961f6d",
                    LockoutEnabled = false,
                    SecurityStamp = "DMX6IN2LBO4XQWH3TJDFNF7JHRKJFGYY",
                    Gender = GenderEnum.Male,
                    Employment = "Founder",
                    LanguageId = 1,
                    CityId = 201,
                    CountryCode = "BIH"
                },
                new User
                {
                    Id = 2,
                    FirstName = "Edin",
                    LastName = "Cekic",
                    UserName = "edince@yopmail.com",
                    NormalizedUserName = "EDINCE@YOPMAIL.COM",
                    Email = "edince@yopmail.com",
                    NormalizedEmail = "EDINCE@YOPMAIL.COM",
                    PasswordHash = "AQAAAAEAACcQAAAAEN2WKAeKr1ZcOfZu6fvZK9HZKny7m98AMaPocHSYrrsOMtE6bbhXTsqU2PJqGt6PAw==", //B!mAcad3my
                    EmailConfirmed = true,
                    CreatedDate = new DateTime(2021 - 1 - 1),
                    ConcurrencyStamp = "a5b45156-8e17-41d9-8a1e-a0b873e61d05",
                    LockoutEnabled = false,
                    SecurityStamp = "SHB5H7M27HEOFYXXR4OBYLK3UNQEXFEK",
                    Gender = GenderEnum.Male,
                    Employment = "Developer",
                    LanguageId = 1,
                    CityId = 201,
                    CountryCode = "BIH"
                },
                new User
                {
                    Id = 3,
                    FirstName = "Anes",
                    LastName = "Sjivo",
                    UserName = "anessljivo@gmail.com",
                    NormalizedUserName = "ANESSLJIVO@GMAIL.COM",
                    Email = "anessljivo@gmail.com",
                    NormalizedEmail = "ANESSLJIVO@GMAIL.COM",
                    PasswordHash = "AQAAAAEAACcQAAAAEC3HvaDc3IXfP+Lsq/iX1exwUoBEAnESEL40NSe0YmmoCY/IQDoFS67q05iG/a4h8w==", //B!mAcad3my
                    EmailConfirmed = true,
                    CreatedDate = new DateTime(2021 - 1 - 1),
                    ConcurrencyStamp = "0fb1a022-2065-49d1-9669-c683628b8cca",
                    LockoutEnabled = false,
                    SecurityStamp = "LSXORV2CHYZQI5US6JHEYB7IJALWABS3",
                    Gender = GenderEnum.Male,
                    Employment = "Developer",
                    LanguageId = 1,
                    CityId = 201,
                    CountryCode = "BIH"
                }
                );

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "admin", NormalizedName = "ADMIN", ConcurrencyStamp = "df811e72-95fa-4d06-9c3d-0fa7016b1dde" },
                new Role { Id = 2, Name = "teacher", NormalizedName = "TEACHER", ConcurrencyStamp = "7d575d43-f590-475a-8785-5b88e1776944" },
                new Role { Id = 3, Name = "company", NormalizedName = "COMPANY", ConcurrencyStamp = "6236fa2c-c5cd-46ed-905f-ced532e5d0de" },
                new Role { Id = 4, Name = "member", NormalizedName = "MEMBER", ConcurrencyStamp = "72d2f4e3-08e7-4d26-9c62-0f52b0a8fa63" }
                );

            modelBuilder.Entity<IdentityUserRole<long>>().HasData(
                new IdentityUserRole<long> { RoleId = 1, UserId = 1 },
                new IdentityUserRole<long> { RoleId = 2, UserId = 1 },
                new IdentityUserRole<long> { RoleId = 1, UserId = 2 },
                new IdentityUserRole<long> { RoleId = 2, UserId = 2 }
                );

            modelBuilder.Entity<UserQuestionType>().HasData(
                new UserQuestionType { Id = 1, UserId = 1, QuestionType = QuestionType.General }, 
                new UserQuestionType { Id = 2, UserId = 1, QuestionType = QuestionType.Membership },
                new UserQuestionType { Id = 3, UserId = 1, QuestionType = QuestionType.Enterprise },
                new UserQuestionType { Id = 4, UserId = 1, QuestionType = QuestionType.Master },
                new UserQuestionType { Id = 5, UserId = 2, QuestionType = QuestionType.General },
                new UserQuestionType { Id = 6, UserId = 2, QuestionType = QuestionType.Membership },
                new UserQuestionType { Id = 7, UserId = 2, QuestionType = QuestionType.Enterprise },
                new UserQuestionType { Id = 8, UserId = 2, QuestionType = QuestionType.Master }
                );

            modelBuilder.Entity<Language>().HasData(
                new Language { Id = 1, Name = "German", Code = "DE" },
                new Language { Id = 2, Name = "English", Code = "ENG" }
                );

            modelBuilder.Entity<Navbar>().HasData(
               new Navbar { Id = 1, Name = "home", Label = "Home", LanguageId = 1, Order = 1 },
               new Navbar { Id = 2, Name = "courses", Label = "Kurse", LanguageId = 1, Order = 2 },
               new Navbar { Id = 3, Name = "prices", Label = "Preise", LanguageId = 1, Order = 3 },
               new Navbar { Id = 4, Name = "community", Label = "Gemeinschaft", LanguageId = 1, Order = 4 },
               new Navbar { Id = 5, Name = "about", Label = "Team", LanguageId = 1, Order = 5 },
               new Navbar { Id = 6, Name = "contact", Label = "Kontakt", LanguageId = 1, Order = 6 }
               );

            modelBuilder.Entity<PlanPrice>().HasData(
                new PlanPrice { Id = 1, Label = "MEMBERSHIP", Name = "membership", Price = 98000, Currency = "chf" },
                new PlanPrice { Id = 2, Label = "ENTERPRISE", Name = "enterprise", Price = 890000, Currency = "chf" },
                new PlanPrice { Id = 3, Label = "BIM 5D MASTER", Name = "bimMaster", Price = 980000, Currency = "chf" }
                );

        }
    }
}
