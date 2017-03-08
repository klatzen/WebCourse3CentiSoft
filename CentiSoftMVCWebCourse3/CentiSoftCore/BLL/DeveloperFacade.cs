using CentiSoftCore.DAL;
using CentiSoftCore.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentiSoftCore.BLL
{
    public class DeveloperFacade : BaseFacade
    {
        private DeveloperRepository devRep;
        private TaskRepository taskRep;

        public DeveloperFacade(int clientId) : base(clientId)
        {
            devRep = new DeveloperRepository();
            taskRep = new TaskRepository();
        }

        public Developer LoadDev(int id)
        {
           return devRep.LoadDev(id);
        }

        public void SaveDev(Developer dev)
        {
            devRep.SaveDev(dev);
        }

        public void DeleteDev(int id)
        {
            Developer developer = devRep.LoadDev(id);
            if(developer != null)
            {
                bool hasTasks = taskRep.DevHasTasks(developer.Id);
                if (!hasTasks)
                {
                    devRep.DeleteDev(id);
                }
            }
        }
    }
}
