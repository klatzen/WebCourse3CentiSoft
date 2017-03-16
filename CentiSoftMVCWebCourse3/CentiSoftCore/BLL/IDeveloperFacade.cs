using System.Collections.Generic;
using CentiSoftCore.MODELS;

namespace CentiSoftCore.BLL
{
    public interface IDeveloperFacade
    {
        void DeleteDev(int id);
        List<Developer> LoadAllDev();
        Developer LoadDev(int id);
        List<Task> LoadTasksOnDev(int id);
        void SaveDev(Developer dev);
    }
}