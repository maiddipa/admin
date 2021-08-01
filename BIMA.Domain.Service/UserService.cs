using AutoMapper;
using BIMA.Database.Entities;
using BIMA.Domain.Models;
using BIMA.Domain.Repository.Interfaces;
using BIMA.Domain.Repository.Interfaces.IRepository;
using BIMA.Domain.Services.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BIMA.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper; 
        private readonly IUserRepository _userRepository;
        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;

        }
       
        public async Task<bool> UserRegistration(UserRegistrationModel userModel)
        {
            var user = _mapper.Map<User>(userModel);
            await _userRepository.AddAsync(user);

            return true;
        }
    }
}
