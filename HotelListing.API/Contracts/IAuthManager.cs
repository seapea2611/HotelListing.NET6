using HotelListing.API.Model.User;
using Microsoft.AspNetCore.Identity;

namespace HotelListing.API.Contracts
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Resigter(ApiUserDto userDto);
        Task<AuthResponseDto> Login(LoginDto loginDto);
        Task<String> CreateRefreshToken();
        Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request);

    }
}
