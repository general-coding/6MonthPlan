using Interfaces.Extensibility.PersonRepository.CSV;
using Interfaces.Extensibility.PersonRepository.Interface;
using Interfaces.Extensibility.PersonRepository.Service;
//using Interfaces.Extensibility.PersonRepository.SQL;

namespace Interfaces.Extensibility.PersonRepository.Factory
{
    public static class RepositoryFactory
    {
        public static IPersonRepository GetRepository(string repositoryType)
        {
            IPersonRepository repository = null;

            switch (repositoryType)
            {
                case "Service":
                    repository = new ServiceRepository();
                    break;

                case "CSV":
                    repository = new CSVRepository();
                    break;

                //case "SQL":
                //    repository = new SQLRepository();
                //    break;

                default:
                    break;
            }

            return repository;
        }
    }
}
