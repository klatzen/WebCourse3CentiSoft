using System.Collections.Generic;
using CentiSoftCore.MODELS;

namespace CentiSoftCore.DAL
{
    public interface IClientRepository
    {
        void DeleteClient(int id);
        List<Client> LoadAllClient();
        Client LoadClient(int id);
        void SaveClient(Client client);
    }
}