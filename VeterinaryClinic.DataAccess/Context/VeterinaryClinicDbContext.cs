using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VeterinaryClinic.Entities;

namespace VeterinaryClinic.DataAccess.Context
{
    public class VeterinaryClinicDbContext : IdentityDbContext<User>
    {
        public VeterinaryClinicDbContext(DbContextOptions<VeterinaryClinicDbContext> options)
        : base(options)
        {
        }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<WeatherInfo> WeatherInfos { get; set; }
    }
}
