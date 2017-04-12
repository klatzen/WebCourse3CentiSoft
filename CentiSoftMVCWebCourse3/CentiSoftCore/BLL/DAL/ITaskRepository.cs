using System.Collections.Generic;
using CentiSoftCore.MODELS;

namespace CentiSoftCore.DAL
{
    public interface ITaskRepository
    {
        void DeleteTask(int id);
        bool DevHasTasks(int id);
        List<Task> LoadAllTask();
        Task LoadTask(int id);
        void SaveTask(Task task);
        List<Task> TasksOnDev(int id);
        List<Task> TasksOnProj(int id, int clientId);
    }
}