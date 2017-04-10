using System.Collections.Generic;
using CentiSoftCore.MODELS;

namespace CentiSoftCore.BLL
{
    public interface IClientFacade
    {
        void DeleteClient(int id);
        List<Project> FindAllProjectsOnClient();
        List<Client> LoadAllClient();
        Client LoadClient(int id);
        Client LoadClient(string token);
        void SaveClient(Client client);
    }
}