using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using System;
using System.Collections.Generic;


namespace CRUDTest
{
    public class CountriesServiceTest
    {
        private readonly ICountriesService _countriesServices;

        public CountriesServiceTest()
        {
            _countriesServices = new CountriesService();
        }
        #region AddCountry
        [Fact]
        public void AddCountry_NullCountry()
        {
            //Arrange
            CountryAddResquest? request = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            //Act
            _countriesServices.AddCountry(request));
            
        }

        [Fact]
        public void AddCountry_CountryNameIsNull()
        {
            //Arrange
            CountryAddResquest? request = new CountryAddResquest()
            {
                CountryName = null,
            };

            //Assert
            Assert.Throws<ArgumentException>(() =>
            //Act
            _countriesServices.AddCountry(request));
        }

        [Fact]
        public void AddCountry_DuplicateCountryName()
        {
            //Arrange
            CountryAddResquest? request = new CountryAddResquest()
            {
                CountryName = "USA"
            };
            CountryAddResquest? request2 = new CountryAddResquest()
            {
                CountryName = "USA"
            };

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _countriesServices.AddCountry(request);
                _countriesServices.AddCountry(request2);
            });
        }
        
        [Fact]
        public void AddCountry_ProperCountryDetails()
        {
            //Arrange
            CountryAddResquest? request = new CountryAddResquest()
            {
                CountryName = "Japan",
            };

            //Act
            CountryResponse response = _countriesServices.AddCountry(request);
            List<CountryResponse> country = _countriesServices.GetCountryList();

            //Assert
            Assert.True(response.CountryId != Guid.Empty);
            Assert.Contains(response,country);
        }
        #endregion

        #region GetCountries
        [Fact]
        public void GetAllCountrie_EmptyList()
        {
            //Acts
            List<CountryResponse> actual_response_list = _countriesServices.GetCountryList();

            //Assert
            Assert.Empty(actual_response_list);
        }

        [Fact]
        public void GetCountryList_AddFewCountries()
        {
            //Arranger
            List<CountryAddResquest> country_request = new List<CountryAddResquest>()
            {
                new CountryAddResquest() {CountryName = "USA"},
                new CountryAddResquest() {CountryName = "UK"}
            };

            //Act
            List<CountryResponse> countries_response = new List<CountryResponse>();
            foreach (var country in country_request)
            {
              countries_response.Add( _countriesServices.AddCountry(country));
            }

            List<CountryResponse> actualList = _countriesServices.GetCountryList();

            foreach (var country in actualList)
            {
                Assert.Contains(country, actualList);
            }
        }
        #endregion

        #region GetCountryByID
        [Fact]
        public void GetCountryByID_NullID()
        {
            //Arrange
            Guid? countryId = null;
            //Act
           CountryResponse? response = _countriesServices.GetCountryById(countryId);

            //Assert
            Assert.Null(response);
        }

        [Fact]
        public void GetCountryByID_ValidID()
        {
            //Arrange
            CountryAddResquest country_request = new CountryAddResquest()
            {
                CountryName = "China"
            };
            CountryResponse response = _countriesServices.AddCountry(country_request);

            //Act
            CountryResponse? response1 = _countriesServices.GetCountryById(response.CountryId);

            Assert.Equal(response, response1);
        }
        #endregion
    }
}
