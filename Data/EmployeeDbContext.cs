using EmployeeBackendAPI.Interface;
using EmployeeBackendAPI.Model.Area;
using EmployeeBackendAPI.Model.Department;
using EmployeeBackendAPI.Model.Employee;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EmployeeBackendAPI.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<EmployeeQualification>().ToTable("employee_qualification");
            builder.Entity<EmployeeContactDetail>().ToTable("employee_contact_details");
            builder.Entity<IdentityUser>(entity =>
            {
                entity.ToTable("User");
                entity.Property(p => p.Id).HasColumnName("UserId");
            });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("EmployeeDbConnnection");
                optionsBuilder.UseNpgsql(connectionString);
            }

            optionsBuilder
                .UseNpgsql(@"Server=localhost;Database=EmployeeAPI;User Id=postgres;Password=Raja@1234;")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        /*public DbSet<translate_api> translate_api { get; set; }
        public DbSet<hotel_master_new> hotel_master_new { get; set; }*/
        public DbSet<Employee> employee { get; set; }
        public DbSet<EmployeeQualification> employee_Qualification { get; set; }
        public DbSet<EmployeeContactDetail> employee_Contact_Details { get; set; }
        public DbSet<leaves> leaves { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<currency_master> currency_Master { get; set; }
        public DbSet<city_master> city_Master { get; set; }
        public DbSet<state_master> state_Master { get; set; }
        public DbSet<country_master> country_master { get; set; }
        public DbSet<location> location { get; set; }
        public DbSet<countries> countries { get; set; }
        public DbSet<state> state { get; set; }
        public DbSet<city> city { get; set; }
        public DbSet<job_master> job_master { get; set; }
    }
}
