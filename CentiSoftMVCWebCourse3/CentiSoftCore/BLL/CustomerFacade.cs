using CentiSoftCore.DAL;
using CentiSoftCore.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentiSoftCore.BLL
{
    public class CustomerFacade : BaseFacade
    {
        private CustomerRepository customerRepository;
        private ProjectRepository projectRepository;
        private TaskRepository taskRepository;
        public CustomerFacade(int clientId) : base(clientId)
        {

            customerRepository = new CustomerRepository();
            projectRepository = new ProjectRepository();

        }

        public Customer LoadCustomer(int id)
        {
            return customerRepository.loadCustomer(id, clientId);
        }

        public List<Customer> LoadAllCustomers()
        {
            return customerRepository.LoadAllCustomers(clientId);
        }

        public void SaveCustomer(Customer customer)
        {
            customerRepository.saveCustomer(customer);
        }

        public void DeleteCustomer(int id) {

            Customer cus = customerRepository.loadCustomer(id, clientId);
            if (!projectRepository.hasProjects(id)) {
                customerRepository.removeCustomer(id);
            }
        }

        public List<Project> FindProjectsOnCusID(int cusId) {
            return projectRepository.findProjOnCusID(cusId, clientId);
        }

        public List<MODELS.Task> FindTasksOnProject(int id)
        {
            return taskRepository.TasksOnProj(id,clientId);
        }
    }
}
