using CentiSoftCore.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentiSoftCore.DAL
{
    public class ClientRepository : BaseRepository
    {
        public Client LoadClient(int id)
        {
            return dbContext.Clients.FirstOrDefault(x => x.Id == id);
        }

        public List<Client> LoadAllClient()
        {
            return dbContext.Clients.ToList();
        }
        public void SaveClient(Client client)
        {
            if (client.Id > 0)
            {
                Client oldClient = LoadClient(client.Id);
                oldClient.Name = oldClient.Name;
            }
            else
            {
                dbContext.Clients.Add(client);
            }
            dbContext.SaveChanges();
        }
        public void DeleteClient(int id)
        {
            Client tempClient = LoadClient(id);
            dbContext.Clients.Remove(tempClient);
            dbContext.SaveChanges();
        }
    }
}
