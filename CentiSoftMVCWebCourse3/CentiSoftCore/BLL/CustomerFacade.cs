using CentiSoftCore.DAL;
using CentiSoftCore.MODELS;
using CentiSoftCore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentiSoftCore.BLL
{
    public class CustomerFacade : BaseFacade, ICustomerFacade
    {
        private ICustomerRepository customerRepository;
        private IProjectRepository projectRepository;
        private ITaskRepository taskRepository;

        public CustomerFacade(int clientId) : base(clientId)
        {

            customerRepository = StructureMapContainer.GetContainer().GetInstance<ICustomerRepository>();
            projectRepository = StructureMapContainer.GetContainer().GetInstance<IProjectRepository>();
            taskRepository = StructureMapContainer.GetContainer().GetInstance<ITaskRepository>();

        }
        
        public Customer LoadCustomer(int id)
        {
            return customerRepository.LoadCustomer(id, clientId);
        }

        public List<Customer> LoadAllCustomers()
        {
            return customerRepository.LoadAllCustomers(clientId);
        }

        public void SaveCustomer(Customer customer)
        {
            customerRepository.SaveCustomer(customer);
        }

        public void DeleteCustomer(int id) {

            Customer cus = customerRepository.LoadCustomer(id, clientId);
            if (!projectRepository.HasProjects(id)) {
                customerRepository.RemoveCustomer(id, clientId);
            }
        }

        public List<Project> FindProjectsOnCusID(int cusId) {
            return projectRepository.FindProjOnCusID(cusId, clientId);
        }

        public List<MODELS.Task> FindTasksOnProject(int id)
        {
            return taskRepository.TasksOnProj(id,clientId);
        }
    }
}
