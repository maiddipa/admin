using BIMA.Database;
using BIMA.Database.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BIMA.WebApi.Helpers
{
    public class UserHelper
    {
        private BIMADbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        ILogger<UserHelper> _logger;
        private readonly UserManager<User> _userManager;


        public UserHelper(BIMADbContext dbContext,
                           IHttpContextAccessor httpContextAccessor,
                           ILogger<UserHelper> logger,
                           UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            _userManager = userManager;
        }

        public int? GetLoggedInUserId()
        {
            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;

            return _userManager.FindByNameAsync(userName).Id;
        }

        public bool IsUserLoggedIn(int userId)
        {
            var loggedInUserId = GetLoggedInUserId();

            if (loggedInUserId == null || userId == null)
                return false;

            return userId == loggedInUserId;
        }

        public async Task<bool> HasUserRoleAsync(int userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var isInRole = await _userManager.IsInRoleAsync(user, role);

            return isInRole;
        }
    }
}
