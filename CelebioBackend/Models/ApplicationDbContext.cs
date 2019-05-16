using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CelebioBackend;

namespace Celebio
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        { }

        public DbSet<User> user { get; set; }
        public DbSet<Trip> trip { get; set; }
        public DbSet<Traveller> traveller { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            //modelBuilder.Entity<User>().HasIndex(a => a.username);
            modelBuilder.Entity<User>().HasData(
            new User {
                username = "mrtmr",
                name = "murat emir",
                surname = "cabarolu",
                email = "murat@gmail.com",
                password = 123456,
            },
            new User
            {
                username = "edac",
                name = "eda",
                surname = "cicekli",
                email = "murat@gmail.com",
                password = 123456,
            }
            );

            modelBuilder.Entity<Trip>().HasData(new Trip
            {
                tripID = 1,
                creatorID = "mrtmr",
                from = "istanbul",
                to = "izmir",
                vehicle = "otostop",
                time = DateTime.Now,

            });

            modelBuilder.Entity<Traveller>().HasData(new Traveller
            {
                travellerID = 1,
                appliedUser = "mrtmr",
                appliedTripID= 1,

            });


        }



    }




}
