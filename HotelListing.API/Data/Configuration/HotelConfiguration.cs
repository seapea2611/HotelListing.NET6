using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.API.Data.Configuration
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
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
