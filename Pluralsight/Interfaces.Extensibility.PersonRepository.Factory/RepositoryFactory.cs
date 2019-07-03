using Interfaces.Extensibility.PersonRepository.Interface;
using System;
using System.Configuration;

namespace Interfaces.Extensibility.PersonRepository.Factory
{
    public static class RepositoryFactory
    {
        public static IPersonRepository GetRepository()
        {
            string repositoryTypeName = ConfigurationManager.AppSettings["RepositoryType"];
            Type repositoryType = Type.GetType(repositoryTypeName);
            object repository = Activator.CreateInstance(repositoryType);
            IPersonRepository personRepository = repository as IPersonRepository;

            return personRepository;
        }
    }
}
