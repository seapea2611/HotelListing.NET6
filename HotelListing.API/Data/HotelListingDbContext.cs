using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Data
{
    public class HotelListingDbContext : DbContext
    {
        public HotelListingDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Jamaica", ShortName = "JM" },
                new Country { Id = 2, Name = "VietNam", ShortName = "VN" }
                );
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Hotel A",
                    Address = "123 Main St",
                    Rating = 4.5,
                    CountryID = 1
                },
        new Hotel
        {
            Id = 2,
            Name = "Hotel B",
            Address = "456 Main St",
            Rating = 3.8,
            CountryID = 2
        },
        new Hotel
        {
            Id = 3,
            Name = "Hotel C",
            Address = "789 Main St",
            Rating = 4.0,
            CountryID = 1
        }
            );
            }
        }
    }


