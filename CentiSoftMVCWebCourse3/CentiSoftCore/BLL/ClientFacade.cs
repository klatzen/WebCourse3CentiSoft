﻿using CentiSoftCore.DAL;
using CentiSoftCore.MODELS;
using CentiSoftCore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentiSoftCore.BLL
{
    public class ClientFacade : IClientFacade
    {
        private IClientRepository clientRepo;
        private ICustomerRepository customerRepo;
        private IProjectRepository projectRepo;
        public ClientFacade()
        {
            this.clientRepo = StructureMapContainer.GetContainer().GetInstance<IClientRepository>();
            this.customerRepo = StructureMapContainer.GetContainer().GetInstance<ICustomerRepository>();
            this.projectRepo = StructureMapContainer.GetContainer().GetInstance<IProjectRepository>();

        }
        public Client LoadClient(int id)
        {
            return clientRepo.LoadClient(id);
        }

        public Client LoadClient(string token)
        {
            return clientRepo.LoadClient(token);
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

        public List<Project> FindAllProjectsOnClient() {
            return null;
                //projectRepo.LoadAllProject(clientId);
        }
    }
}
