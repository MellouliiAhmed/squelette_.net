using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure
{
    public class AMContext: DbContext
    {
        public DbSet<Activite> Activites { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Conseiller> Conseillers { get; set; }
        public DbSet<Pack> Packs { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        //public DbSet<Plane> Planes { get; set; }
        //public DbSet<Flight> Flights { get; set; }
        //public DbSet<Passenger> Passengers { get; set; }
        //public DbSet<Staff> Staff { get; set; }
        //public DbSet<Traveller> Travellers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
              Initial Catalog=MellouliAhmedDB;MultipleActiveResultSets=true;Integrated Security=true") ;
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>().HasOne(p => p.Pack)
           .WithMany(c => c.Reservations)
           .HasForeignKey(c => c.PackFK);

            modelBuilder.Entity<Reservation>().HasOne(p => p.Client)
        .WithMany(c => c.Reservations)
        .HasForeignKey(c => c.ClientFK);

            modelBuilder.Entity<Client>().HasOne(p => p.Conseiller)
        .WithMany(c => c.Clients)
        .HasForeignKey(c => c.ConseillerFK)
        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reservation>().HasKey(r => new
            {
                r.ClientFK,
                r.PackFK,
                r.DateReservation
            });
            //modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            //modelBuilder.ApplyConfiguration(new FlightConfiguration());
            //modelBuilder.ApplyConfiguration(new PassengerConfiguration());
            //modelBuilder.ApplyConfiguration(new TicketConfiguration());

            ////TPT
            //modelBuilder.Entity<Staff>().ToTable("Staff");
            //modelBuilder.Entity<Traveller>().ToTable("Travellers");

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            //    // Pre-convention model configuration goes here
            //    configurationBuilder
            //        .Properties<string>()
            //        .HaveMaxLength(50);

            //configurationBuilder
            //    .Properties<decimal>()
            //        .HavePrecision(8,3);

            //configurationBuilder
            //  .Properties<DateTime>()
            //      .HaveColumnType("date");

                configurationBuilder
                    .Properties<string>()
                    .HaveMaxLength(15);
        }



    }
}
