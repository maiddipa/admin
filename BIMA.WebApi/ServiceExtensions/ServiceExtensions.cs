using BIMA.Common.EmailService;
using BIMA.Database;
using BIMA.Database.Entities;
using BIMA.Domain.Service;
using BIMA.Domain.Services;
using BIMA.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIMA.WebApi.ServiceExtensions
{
    public static class ServiceExtensions
    {
        #region Email Configuration
        public static void EmailConfiguration(this IServiceCollection service, IConfiguration Configuration)
        {
            var emailConfig = Configuration.GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
            service.AddSingleton(emailConfig);
        }
        #endregion

        #region Register Services
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<INewsletterService, NewsletterService>();
            services.AddScoped<IUserService, UserService>();
        }
        #endregion

        #region Configure Form Options
        public static void ConfigureFormOptions(this IServiceCollection services)
        {
            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
        }
        #endregion

        #region Identity Configuration
        public static void IdentityConfiguration(this IServiceCollection services)
        {
            services.AddIdentity<User, Role>()
               .AddEntityFrameworkStores<BIMADbContext>()
               .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 8;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireUppercase = true;
                opt.Password.RequireDigit = true;

                opt.User.RequireUniqueEmail = true;
            });
        }
        #endregion
    }
}
