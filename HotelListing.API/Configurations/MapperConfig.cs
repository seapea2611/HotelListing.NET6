using AutoMapper;
using HotelListing.API.Data;
using HotelListing.API.Model.Country;
using HotelListing.API.Model.Hotels;
using HotelListing.API.Model.User;

namespace HotelListing.API.Configurations
{
    public class MapperConfig : Profile 
    {
        public MapperConfig() {
            CreateMap<Country, CreateCountryDto>().ReverseMap();
            CreateMap<Country, GetCountryDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, UpdateCountryDto>().ReverseMap();

            CreateMap<Hotel, HotelDto>().ReverseMap();
            CreateMap<Hotel, CreateHotelDto>().ReverseMap();

            CreateMap<ApiUserDto,ApiUser>().ReverseMap();

        }
    }
}
