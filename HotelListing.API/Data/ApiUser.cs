using Microsoft.AspNetCore.Identity;

namespace HotelListing.API.Data
{
    public class ApiUser : IdentityUser
    {
        public String firstName {  get; set; }
        public String lastName { get; set; }
    }
}
