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
        public CustomerFacade(int clientId) : base(clientId)
        {

            customerRepository = new CustomerRepository();
            projectRepository = new ProjectRepository();

        }

        public Customer loadCustomer(int id)
        {
            return customerRepository.loadCustomer(id, clientId);
        }

        public List<Customer> loadAllCustomers()
        {
            return customerRepository.LoadAllCustomers(clientId);
        }

        public void saveCustomer(Customer customer)
        {
            customerRepository.saveCustomer(customer);
        }

        public void deleteCustomer(int id) {

            Customer cus = customerRepository.loadCustomer(id, clientId);
            if (!projectRepository.hasProjects(id)) {
                customerRepository.removeCustomer(id);
            }
        }

        public List<Project> findProjectsOnCusID(int cusId) {
            return projectRepository.findProjOnCusID(cusId, clientId);
        }
    }
}
