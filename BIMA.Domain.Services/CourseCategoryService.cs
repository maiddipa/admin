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
    public class CourseCategoryService : ICourseCategoryService
    {
        private readonly IUnitOfWorkAsync<CourseCategory> _unitOfWork;
        private readonly IMapper _mapper;


        public CourseCategoryService(IUnitOfWorkAsync<CourseCategory> unitOfWork,
                                  IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CourseCategoryModel>> GetCourseCategories(CancellationToken cancellationToken) 
        {
            var courseCategories =  await _unitOfWork.CourseCategories.GetCourseCategories(cancellationToken);
            return _mapper.Map<List<CourseCategoryModel>>(courseCategories);
        }

        public async Task<List<CourseCategoryModel>> GetSubCourseCategories(int courseCategoryId, CancellationToken cancellationToken)
        {
            var subCourseCategories = await _unitOfWork.CourseCategories.GetCourseCategoriesByParentCategoryId(courseCategoryId, cancellationToken);
            return _mapper.Map<List<CourseCategoryModel>>(subCourseCategories);
        }

    }
}
