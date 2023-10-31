using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Model.User
{
    public class ApiUserDto : LoginDto
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string FirstName {  get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string LastName { get; set; }
       
    }

    
}
