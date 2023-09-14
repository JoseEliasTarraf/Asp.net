using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using System.Collections.Specialized;
using System.Data;

namespace Services
{
    //Classe com todos os Methods referentes ao Country
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

        public CountryResponse? GetCountryById(Guid? id)
        {
            if(id == null)
            {
                return null;
            }
            Country? country = _countries.FirstOrDefault(c=> c.CountryID == id);

            if(country == null)
            {
                return null;
            }
            return country.ToCoutryResponse();
        }

        public List<CountryResponse> GetCountryList()
        {
          return _countries.Select(c=> c.ToCoutryResponse()).ToList();
        }
    }
}