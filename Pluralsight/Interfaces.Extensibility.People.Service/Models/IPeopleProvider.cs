using Interfaces.Extensibility.PersonRepository.Interface;
using System.Collections.Generic;

namespace Interfaces.Extensibility.People.Service.Models
{
    public interface IPeopleProvider
    {
        List<Person> GetPeople();
    }
}
