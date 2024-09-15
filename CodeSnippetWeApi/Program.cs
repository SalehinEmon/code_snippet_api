
using CodeSnippetWeApi.BLL;
using CodeSnippetWeApi.DAL;
using CodeSnippetWeApi.ExtensionMethods;
using CodeSnippetWeApi.Helper;
using CodeSnippetWeApi.Models;
using CodeSnippetWeApi.Models.EntityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CodeSnippetWeApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.AddBlls();
            builder.AddDAOs();
            builder.AddOtherService();
            builder.AddIdentityService();
            builder.AddDbContext();
            builder.AddAuthService();

            
            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

         

            app.UseRouting();

            if (app.Environment.IsDevelopment())
            {
                app.UseCors(x => x.AllowAnyHeader().
                 AllowAnyMethod().
                 WithOrigins("http://localhost:4200"));
            }

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapFallbackToFile("/index.html");


            app.MapControllers();



            app.Run();
        }
    }
}
