using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities.v1;

namespace Persistence.Context.v1
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<VehicleType> VehicleTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _VehicleConfiguration(modelBuilder.Entity<Vehicle>());
            _TownConfiguration(modelBuilder.Entity<Town>());
            _VehicleTypeConfiguration(modelBuilder.Entity<VehicleType>());

            base.OnModelCreating(modelBuilder);
        }


        private void _VehicleConfiguration(EntityTypeBuilder<Vehicle> vehicle)
        {
            vehicle
                .HasKey(x => x.Id);

            vehicle
                .Property(x => x.EngineCapacity)
                .IsRequired();

            vehicle
                .Property(x => x.VehicleAge)
                .IsRequired();

            vehicle
                .Property(x => x.Purpose)
                .IsRequired();

            vehicle
                .HasOne(x => x.Town)
                .WithMany(x => x.Vehicles)
                .HasForeignKey(x => x.TownId);

            vehicle
                .HasOne(x => x.VehicleType)
                .WithMany()
                .HasForeignKey(x => x.VehicleTypeId);
        }

        private void _TownConfiguration(EntityTypeBuilder<Town> town)
        {
            town
                .HasKey(x => x.Id);

            town
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();

            town
                .Property(x => x.Postcode)
                .IsRequired()
                .HasMaxLength(10);
        }

        private void _VehicleTypeConfiguration(EntityTypeBuilder<VehicleType> vehicleType)
        {
            vehicleType
                .HasKey(x => x.Id);

            vehicleType
                .Property(x => x.Type)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode();
        }
    }
}
