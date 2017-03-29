using CentiSoftCore.BLL;
using CentiSoftCore.DAL;
using StructureMap;

namespace CentiSoftCore.Utils
{
    public class StructureMapContainer : Registry
    {
        private static Container instance;
        static StructureMapContainer()
        {
            instance = new Container(x =>
            {
                x.For<IClientFacade>().Use<ClientFacade>();
                x.For<ICustomerFacade>().Use<CustomerFacade>();
                x.For<IDeveloperFacade>().Use<DeveloperFacade>();
                x.For<IClientRepository>().Use<ClientRepository>();
                x.For<ICustomerRepository>().Use<CustomerRepository>();
                x.For<IDeveloperRepository>().Use<DeveloperRepository>();
                x.For<IProjectRepository>().Use<ProjectRepository>();
                x.For<ITaskRepository>().Use<TaskRepository>();
            });
        }

        public static Container GetContainer()
        {
            return instance;
        }
    }
}
