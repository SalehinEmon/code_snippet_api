using CodeSnippetWeApi.BLL;
using CodeSnippetWeApi.DAL;
using CodeSnippetWeApi.Helper;
using CodeSnippetWeApi.Models.EntityModel;
using CodeSnippetWeApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NuGet.Configuration;

namespace CodeSnippetWeApi.ExtensionMethods
{
    public static class DependencyExtension
    {
        public static WebApplicationBuilder AddBlls(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<FramewrokBLL>();
            builder.Services.AddScoped<LanguageBLL>();
            builder.Services.AddScoped<UserBll>();
            builder.Services.AddScoped<TopicBLL>();
            builder.Services.AddScoped<SnippetBLL>();
            return builder;
        }

        public static WebApplicationBuilder AddDAOs(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<FrameworkDAO>();
            builder.Services.AddScoped<LanguageDAO>();
            builder.Services.AddScoped<SnippetDAO>();
            builder.Services.AddScoped<TopicDAO>();
            return builder;
        }

        public static WebApplicationBuilder AddOtherService(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<JWTHelper>();
            builder.Services.AddCors();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            return builder;
        }
        public static WebApplicationBuilder AddDbContext(this WebApplicationBuilder builder)
        {
            var defaultConString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<SnippetDbContext>(option => { option.UseSqlServer(defaultConString); });

            return builder;
        }

        public static WebApplicationBuilder AddAuthService(this WebApplicationBuilder builder)
        {

            var tempParameters = builder.Configuration.GetSection("JWTSettings").Get<TokenValidationParameters>();
            var securityKey = builder.Configuration["JWTSettings:securityKey"];


            builder.Services.AddAuthentication(opp =>
            {

                opp.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opp.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;


            }).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = tempParameters.ValidIssuer,
                    ValidAudience = tempParameters.ValidAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                        .GetBytes(securityKey??""))
                };
            });


            return builder;
        }

        public static WebApplicationBuilder AddIdentityService(this WebApplicationBuilder builder)
        {
            builder.Services.AddIdentity<AppUserModel, IdentityRole<int>>(option =>
            {
                option.Password.RequiredLength = 5;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireLowercase = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireDigit = false;
                //option.User.AllowedUserNameCharacters = null;
            }).AddEntityFrameworkStores<SnippetDbContext>();
            return builder;
        }

    }
}
