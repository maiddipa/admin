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
    public class CourseContentService : ICourseContentService
    {
        private readonly IUnitOfWorkAsync<CourseContent> _unitOfWork;
        private readonly IMapper _mapper;


        public CourseContentService(IUnitOfWorkAsync<CourseContent> unitOfWork,
                                  IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<List<CourseContentModel>> GetCourseContentByCourseSectionId(int courseId, CancellationToken cancellationToken)

        {
            var courses = await _unitOfWork.CourseContents.GetCourseContentByCourseSectionId(courseId, cancellationToken);
            return _mapper.Map<List<CourseContentModel>>(courses);
        }
    }
}
