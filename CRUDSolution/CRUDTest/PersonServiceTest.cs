using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace CRUDTest
{
    public class PersonServiceTest
    {
        private readonly IPersonsService _personsService;
        private readonly ICountriesService _countriesService;
        private readonly ITestOutputHelper _outputHelper;
        

        public PersonServiceTest(ITestOutputHelper testOutuputHelper)
        {
            _personsService = new PersonService();
            _countriesService = new CountriesService();
            _outputHelper = testOutuputHelper;
        }

        #region AddPerson
        [Fact]
        public void AddPerson_NullPerson()
        {
            //Arrange
            PersonAddRequest? request = null;

            //Act
           Assert.Throws<ArgumentNullException> (
               () =>
               {
                   _personsService.AddPerson(request);
               });
        }

        [Fact]
        public void AddPerson_PersonNameNull()
        {
            PersonAddRequest request = new PersonAddRequest()
            {
                PersonName = null
            };

            Assert.Throws<ArgumentException>(() =>
            {
                _personsService.AddPerson(request);
            });
        }

        [Fact]
        public void AddPerson_ProperPerson()
        {
            CountryAddResquest country_add = new CountryAddResquest()
            {
                CountryName = "China"
            };

            CountryResponse countryResponse = _countriesService.AddCountry(country_add);

            PersonAddRequest request = new PersonAddRequest()
            {
                PersonName ="José",
                Email = "neto_jtarraf@hotmail.com",
                Address = "My Address",
                CountryID = countryResponse.CountryId,
                DateOfBirth = DateTime.Now,
                Gender = ServiceContracts.Enums.GenderOptions.Male,
                ReceiveNewsLetters = true,
            };

            //Act
            PersonResponse response = _personsService.AddPerson(request);
            List<PersonResponse> list_response = _personsService.GetPersonsList();

            Assert.True(response.PersonID != Guid.Empty);
            Assert.Contains(response, list_response);
        }
        #endregion

        #region GetPersonByID
        [Fact]
        public void GetPersonByID_NullID()
        {
            Guid? personID = null;

            PersonResponse? response = _personsService.GetPersonByID(personID);

            Assert.Null(response);
        }

        [Fact]
        public void GetPersonByID_ProperID()
        {
            CountryAddResquest country_add = new CountryAddResquest()
            {
                CountryName = "China"
            };

            CountryResponse countryResponse = _countriesService.AddCountry(country_add);

            PersonAddRequest personAddRequest = new PersonAddRequest()
            {
                Address = "Minha Casa",
                CountryID = countryResponse.CountryId,
                DateOfBirth = DateTime.Now,
                Email = "neto_jtarraf@hotmail.com",
                Gender = ServiceContracts.Enums.GenderOptions.Male,
                ReceiveNewsLetters = true,
                PersonName = "José"
            };
            PersonResponse response = _personsService.AddPerson(personAddRequest);

            PersonResponse? personResponse = _personsService.GetPersonByID(response.PersonID);

            Assert.Equal(response,personResponse);
        }
        #endregion

        #region GetAllPerson
        [Fact]
        public void GetAllPersons_EmptyList()
        {
            List<PersonResponse> personList = _personsService.GetPersonsList();

            Assert.Empty(personList);
        }
        #endregion
    }
}
