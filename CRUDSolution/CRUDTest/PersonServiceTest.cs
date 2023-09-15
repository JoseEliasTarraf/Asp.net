using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace CRUDTest
{
    public class PersonServiceTest
    {
        private readonly IPersonsService _personsService;
        

        public PersonServiceTest()
        {
            _personsService = new PersonService();
            
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
            PersonAddRequest request = new PersonAddRequest()
            {
                PersonName ="José",
                Email = "neto_jtarraf@hotmail.com",
                Address = "My Address",
                CountryID = Guid.NewGuid(),
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
    }
}
