using BIMA.Common.Core.JWTAuth;
using BIMA.Common.Core.JWTAuth.Interfaces;
using BIMA.Common.Core.JWTAuth.Models;
using BIMA.Common.EmailService;
using BIMA.Database;
using BIMA.Database.Entities;
using BIMA.Domain.Service;
using BIMA.Domain.Services;
using BIMA.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using BIMA.Domain.Repository.Interfaces;
using BIMA.Domain.Repository.Repository;
using BIMA.Common.Core.JWTAuth.Infrastructure;
using Stripe;

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
            services.AddScoped<DbContext, BIMADbContext>();
            services.AddScoped(typeof(IUnitOfWorkAsync<>), typeof(UnitOfWork<>));

            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<INewsletterService, NewsletterService>();
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IContactUsService, ContactUsService>();
            services.AddScoped<INavbarService, NavbarService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IPlanPriceService, PlanPriceService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICourseCategoryService, CourseCategoryService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICourseContentService, CourseContentService>();
            services.AddScoped<IUserCourseContentService, UserCourseContentService>();

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
            services.AddIdentity<User, Role>(opt => opt.SignIn.RequireConfirmedAccount = true)
               .AddEntityFrameworkStores<BIMADbContext>()
               .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(opt =>
            {
                // Password settings
                opt.Password.RequireDigit = true;
                opt.Password.RequiredLength = 8;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireUppercase = true;
                opt.Password.RequireNonAlphanumeric = true;

                // User settings.
                opt.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                opt.User.RequireUniqueEmail = true;

            });

            services.Configure<DataProtectionTokenProviderOptions>(options =>
                    options.TokenLifespan = TimeSpan.FromHours(2));
        }
        #endregion

        #region JWT Auth
        public static void JWTAuthConfig(this IServiceCollection services, IConfiguration Configuration)
        {
            var jwtTokenConfig = Configuration.GetSection("jwtTokenConfig").Get<JwtTokenConfig>();
            services.AddSingleton(jwtTokenConfig);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtTokenConfig.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtTokenConfig.Secret)),
                    ValidAudience = jwtTokenConfig.Audience,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)
                };
            });
            services.AddSingleton<IJwtAuthManager, JwtAuthManager>();
            services.AddHostedService<JwtRefreshTokenCache>();

        }
        #endregion

        #region JWT Auth
        [Obsolete]
        public static void StripeConfig(this IServiceCollection services, IConfiguration Configuration)
        {
            StripeConfiguration.SetApiKey(Configuration["Stripe:SecretKey"]);
        }
        #endregion

        #region CORS
        public static void CorsConfig(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
            });
        }
        #endregion

        #region swagger
        public static void SwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Service", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }

                    }
                });
            });
        }
        #endregion

    }
}
