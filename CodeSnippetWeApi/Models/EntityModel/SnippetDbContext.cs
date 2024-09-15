using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodeSnippetWeApi.Models.EntityModel
{
    public class SnippetDbContext : IdentityDbContext<AppUserModel, IdentityRole<int>, int>
    {
    
        public SnippetDbContext(DbContextOptions options) : base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<AppUserModel>().HasData(new AppUserModel
        //    {
        //        FullName = "Golam Salehin",
        //        UserName = "emon@emon.com",
        //        Email = "emon@emon.com",
        //        PasswordHash= "AQAAAAIAAYagAAAAEDj6mOMn8hVb1cMiTasDFe3zoPVAvCNQY9Gk3mG6SC8QlNK35gg0Yp4hRjpC6/KmQg==",
        //        ConcurrencyStamp= "14eb7163-67eb-4a67-a863-4d9c8a37ee67",
        //        SecurityStamp= "DRLQDNIWHHINMVG6UCVJZM2ZRVWNZNHC",
        //    });
        //}
        public DbSet<FrameworkModel> Framework { get; set; }
        public DbSet<LanguageModel> Language { get; set; }
        public DbSet<SnippetModel> Snippet { get; set; }
        public DbSet<TopicModel> Topic { get; set; } 

       
    }
}
