using System.Net.Mail;
using BackendData.Domain.Model;
using BackendData.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace BackendData.Persistence
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;
       
        public  DbSet<Record> Records { get; set; }
       public AppDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Record>().ToTable("Records");
            builder.Entity<Record>().HasKey(p => p._id);
            builder.Entity<Record>().Property(p => p._id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Record>().Property(p => p.year).IsRequired();
            builder.Entity<Record>().Property(p => p.area).IsRequired().HasMaxLength(50);
            builder.Entity<Record>().Property(p => p.rank).IsRequired().HasMaxLength(50);
            builder.Entity<Record>().Property(p => p.domestic_exports).IsRequired().HasMaxLength(50);
          

           // builder.UseSnakeCaseNamingConvention();
        }
    }
}

