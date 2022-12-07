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
    }
}
