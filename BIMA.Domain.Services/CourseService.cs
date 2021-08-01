using AutoMapper;
using BIMA.Common.Core.Enum;
using BIMA.Database.Entities;
using BIMA.Domain.Models.Course;
using BIMA.Domain.Models.Public;
using BIMA.Domain.Repository.Interfaces;
using BIMA.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BIMA.Domain.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWorkAsync<Course> _unitOfWork;
        private readonly IMapper _mapper;


        public CourseService(IUnitOfWorkAsync<Course> unitOfWork,
                                  IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CourseListModel>> GetCoursesByCategoryId(int categoryId, CancellationToken cancellationToken)
        {
            var courses = await _unitOfWork.Courses.GetCoursesByCategoryId(categoryId, cancellationToken);
            return _mapper.Map<List<CourseListModel>>(courses);
        }

        public async Task<CoursePageModel> GetCourseById(int courseId, int userId, CancellationToken cancellationToken)
        {
            var courses = await _unitOfWork.Courses.GetCourseById(courseId, cancellationToken);
            var userCourseContent = await _unitOfWork.UserCourseContents.GetByUserIdAndCourseContentIds(userId, courses.Id);

            var mappedCourses = _mapper.Map<CoursePageModel>(courses);

            foreach (var courseSection in mappedCourses.CourseSections)
            {
                foreach (var courseContent in courseSection.CourseContents)
                {
                    var cc = userCourseContent.Find(x => x.CourseContentId.Equals(courseContent.Id));
                    if (cc == null)
                        continue;
                    courseContent.IsWatched = cc.IsWatched;
                    courseContent.Notes = cc.Notes;
                    courseContent.Time = cc.Time;
                }

            }

            return mappedCourses;
        }

    }
}
