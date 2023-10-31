using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Model.User
{
    public class LoginDto
    {
        [System.ComponentModel.DataAnnotations.Required]
        [EmailAddress]
        public string Email { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [StringLength(15, ErrorMessage = "Your password is limited to {2} to {1} character", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
