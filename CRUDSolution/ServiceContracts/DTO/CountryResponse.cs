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
        //Modelo usado para passar a Resposta pro Client
        public Guid CountryId { get; set; }
        public string? CountryName { get; set; }

        public override bool Equals(object? obj)
        {
           if(obj == null)
           {
                return false;
           }

           if(obj.GetType() != typeof(CountryResponse))
           {
                return false;
           }

           CountryResponse country_compare =(CountryResponse)obj;

            return CountryId == country_compare.CountryId &&
            CountryName == country_compare.CountryName;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
    
    //Coversor do Modelo de Dominio para o de Resposta
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
