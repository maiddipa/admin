using BIMA.Database.Entities;
using BIMA.Domain.Models;
using System;
using AutoMapper;
using BIMA.Domain.Models.Public;
using System.Collections.Generic;
using BIMA.Domain.Models.Course;

namespace BIMA.Domain.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Models to Entities

            CreateMap<UserRegistrationModel, User>()
                .ForMember(d => d.UserName, a => a.MapFrom(u => u.Email));


            #endregion

            #region Entities to Models

            CreateMap<Navbar, NavbarModel>();
            CreateMap<City, CityModel>();
            CreateMap<Country, CountryModel>();
            CreateMap<CourseCategory, CourseCategoryModel>()
                .ForMember(c => c.HasSubCategories, a => a.MapFrom(u => u.ParentCategoryId.HasValue));
            CreateMap<Course, CourseListModel>();
            CreateMap<Course, CoursePageModel>();
            CreateMap<CourseSection, CourseSectionModel>();
            CreateMap<CourseContent, CourseContentModel>();                
            CreateMap<UserCourseContent, CourseContentModel>()
                .ForMember(cc => cc.IsWatched, a => a.MapFrom(ucc => ucc.IsWatched))
                .ForMember(cc => cc.Notes, a => a.MapFrom(ucc => ucc.Notes))
                .ForMember(cc => cc.Time, a => a.MapFrom(ucc => ucc.Time));

            #endregion
        }

    }
}
