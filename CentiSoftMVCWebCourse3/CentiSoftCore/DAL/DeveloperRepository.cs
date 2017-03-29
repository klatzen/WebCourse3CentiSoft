using CentiSoftCore.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentiSoftCore.DAL
{
    public class DeveloperRepository : BaseRepository, IDeveloperRepository
    {

        public Developer LoadDev(int id)
        {
            return dbContext.Developers.FirstOrDefault(x => x.Id == id);
        }

        public List<Developer> LoadAllDev()
        {
            return dbContext.Developers.ToList();
        }

        public void SaveDev(Developer dev)
        {
            if (dev.Id > 0)
            {
                Developer tempDev = LoadDev(dev.Id);
                tempDev.Email = dev.Email;
                tempDev.Name = dev.Name;
            }
            else
            {
                dbContext.Developers.Add(dev);
            }
            dbContext.SaveChanges();
        }

        public void DeleteDev(int id)
        {
            Developer dev = LoadDev(id);
            dbContext.Developers.Remove(dev);
            dbContext.SaveChanges();
        }
    }
}

