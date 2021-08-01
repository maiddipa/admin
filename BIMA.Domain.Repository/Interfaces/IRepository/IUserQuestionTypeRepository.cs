using BIMA.Common.Core.Enum;
using BIMA.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BIMA.Domain.Repository.Interfaces.IRepository
{
    public interface IUserQuestionTypeRepository : IRepositoryAsync<UserQuestionType>
    {
        Task<List<UserQuestionType>> GetUserByQuestionType(QuestionType type);
    }
}
