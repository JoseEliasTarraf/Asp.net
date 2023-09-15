using ServiceContracts.DTO;
using System;

namespace ServiceContracts
{
    public interface IPersonsService
    {
        PersonResponse AddPerson(PersonAddRequest request);

        List<PersonResponse> GetPersonsList();
    }
}
