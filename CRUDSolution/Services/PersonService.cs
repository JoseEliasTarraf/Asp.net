using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using Services.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace Services
{
    public class PersonService : IPersonsService
    {
        private readonly List<Person> _persons;
        private readonly ICountriesService _countriesService;

        public PersonService()
        {
            _persons = new List<Person>();
            _countriesService = new CountriesService();
        }
        private PersonResponse CovertPersonToResponse(Person person)
        {
            PersonResponse personResponse = person.ToPersonResponse();
            personResponse.Country =
            _countriesService.GetCountryById(person.CountryID)?.CountryName;
            return personResponse;
        }
        public PersonResponse AddPerson(PersonAddRequest? request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            //Model Validations
            ValidationHelper.ModelValidation(request);

            Person person = request.ToPerson();

            person.PersonID = Guid.NewGuid();

            _persons.Add(person);
            return CovertPersonToResponse(person);
        }

        public List<PersonResponse> GetPersonsList()
        {
            List<PersonResponse> list = _persons.Select(c => c.ToPersonResponse()).ToList();
            return list;
        }

        public PersonResponse GetPersonByID(Guid? personID)
        {
            if(personID == null)
            {
                return null;
            }
            Person? person = _persons.FirstOrDefault(p=> p.PersonID == personID);
            if(person == null)
            {
                return null;
            }

            return person.ToPersonResponse();
        }
    }
}
