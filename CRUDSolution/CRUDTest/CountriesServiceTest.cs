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

            //Assert
            Assert.True(response.CountryId != Guid.Empty);
        }
    }
}
