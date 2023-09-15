using Entities;
using ServiceContracts.DTO;

public static class PersonExtensionsHelpers
{
    public static PersonResponse ToPersonResponse(this Person person)
    {
        return new PersonResponse()
        {
            PersonID = person.PersonID,
            PersonName = person.PersonName,
            Email = person.Email,
            DateOfBirth = person.DateOfBirth,
            Gender = person.Gender,
            Address = person.Address,
            ReceiveNewsLetters = person.ReceiveNewsLetters,
            CountryID = person.CountryID,
            Age = (person.DateOfBirth != null) ? Math.Round((DateTime.Now -
        person.DateOfBirth.Value).TotalDays / 365.25) : null
        };
    }
}