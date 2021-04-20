namespace CourseWork_Samolevich.EF {
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ServiceStationEntities : DbContext {
        public ServiceStationEntities()
            : base("name=ServiceStationEntities") {
        }

        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<CarsDefects> CarsDefects { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Defects> Defects { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Owners> Owners { get; set; }
        public virtual DbSet<Servicess> Servicess { get; set; }
        public virtual DbSet<Specialty> Specialty { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Cars>()
                .HasMany(e => e.Clients)
                .WithRequired(e => e.Cars)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Defects>()
                .HasMany(e => e.CarsDefects)
                .WithOptional(e => e.Defects)
                .HasForeignKey(e => e.idDefect);

            modelBuilder.Entity<Orders>()
                .Property(e => e.TotalPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Owners>()
                .HasMany(e => e.Cars)
                .WithRequired(e => e.Owners)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Servicess>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Servicess>()
                .HasMany(e => e.Defects)
                .WithRequired(e => e.Servicess)
                .WillCascadeOnDelete(false);
        }
    }
}
