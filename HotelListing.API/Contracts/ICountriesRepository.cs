﻿using HotelListing.API.Data;

namespace HotelListing.API.Contracts
{
    public interface ICountriesRepository : IGenericRepository<Country>
    {
        Task<Country> GetDetail(int id  );
    }
}
