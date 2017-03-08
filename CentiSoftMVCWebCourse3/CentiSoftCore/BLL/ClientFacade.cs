using CentiSoftCore.DAL;
using CentiSoftCore.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentiSoftCore.BLL
{
    public class ClientFacade : BaseFacade
    {
        private ClientRepository clientRepo;
        private CustomerRepository customerRepo;
        private ProjectRepository projectRepo;
        public ClientFacade(int clientId) : base(clientId)
        {
            clientRepo = new ClientRepository();
            customerRepo = new CustomerRepository();
            projectRepo = new ProjectRepository();            
        }
        public Client LoadClient(int id)
        {
            return clientRepo.LoadClient(id);
        }
        public List<Client> LoadAllClient()
        {
            return clientRepo.LoadAllClient();
        }
        public void SaveClient(Client client)
        {
            clientRepo.SaveClient(client);
        }
        public void DeleteClient(int id)
        {
            Client tempClient = LoadClient(id);
            if(tempClient != null)
            {
                Customer customer = customerRepo.CustomersOnClient(tempClient.Id);
                if (customer == null)
                {
                    clientRepo.DeleteClient(id);
                }
            }           
        }
        public List<Customer> FindCustomersOnClient(int id)
        {
            return customerRepo.FindCustomersOnClient(id);
        }
        public List<Project> FindProjectsOnClient(int id)
        {
            return projectRepo.FindProjectOnClient(id);
        }
    }
}
