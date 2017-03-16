using System.Collections.Generic;
using CentiSoftCore.MODELS;

namespace CentiSoftCore.DAL
{
    public interface IDeveloperRepository
    {
        void DeleteDev(int id);
        List<Developer> LoadAllDev();
        Developer LoadDev(int id);
        void SaveDev(Developer dev);
    }
}