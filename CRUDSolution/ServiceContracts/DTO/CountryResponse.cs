using System;
using Entities;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// DTO class that is used as return type for most
    /// of countriesService methods
    /// </summary>
    public class CountryResponse
    {
        public Guid CountryId { get; set; }
        public string? CountryName { get; set; }
    }
    
    public static class CountryExtension
    {
        public static CountryResponse ToCoutryResponse(
            this Country country)
        {
            return new CountryResponse()
            {
                CountryId = country.CountryID,
                CountryName = country.CountryName
            };
        }
    }
}
