﻿namespace HotelListing.API.Model.User
{
    public class AuthResponseDto
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
