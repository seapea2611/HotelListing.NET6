using Microsoft.Build.Framework;


namespace HotelListing.API.Model.Hotels
{
    public abstract class BaseHotelDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public double? Rating { get; set; }
        [Required]
       
        public int CountryID { get; set; }
    }
}
