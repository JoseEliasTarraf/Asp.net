using ServiceContracts.DTO;

namespace ServiceContracts
{
    /// <summary>
    /// Represents business logic for manipulating
    /// country Entity
    /// </summary>
    public interface ICountriesService
    {
        /// <summary>
        /// Adds a country object to the list of countries
        /// </summary>
        /// <param name="countryAddResquest">Country object to add</param>
        /// <returns>Returns the country object after adding it
        /// (including newly generated country id)</returns>
        CountryResponse AddCountry(CountryAddResquest?
            countryAddResquest);

        /// <summary>
        /// Returns All Countries
        /// </summary>
        /// <returns>All countries from the list as List of CountryResponse</returns>
        List<CountryResponse> GetCountryList();

        /// <summary>
        /// Return Country object based on the country id
        /// </summary>
        /// <param name="id">CountryID (guid)</param>
        /// <returns>Matching country as CountryResponse</returns>
        CountryResponse? GetCountryById(Guid? id);
    }
}