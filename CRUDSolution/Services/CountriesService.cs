using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using System.Collections.Specialized;
using System.Data;

namespace Services
{
    public class CountriesService : ICountriesService
    {
        private readonly List<Country> _countries;

        public CountriesService()
        {
            _countries = new List<Country>();
        }

        public CountryResponse AddCountry(CountryAddResquest? countryAddResquest)
        {
            //Validation
            if(countryAddResquest == null)
            {
                throw new ArgumentNullException(nameof(countryAddResquest));
            }

            if(countryAddResquest.CountryName == null) 
            {
                throw new ArgumentException(nameof (countryAddResquest.CountryName));
            }

            if(_countries.Where(c=> 
            c.CountryName == countryAddResquest.CountryName).Count() > 0)
            {
                throw new ArgumentException("CoutryName Already Exists");
            }

            Country country = countryAddResquest.ToCountry();

            country.CountryID = Guid.NewGuid();

            _countries.Add(country);

            return country.ToCoutryResponse();
        }
    }
}