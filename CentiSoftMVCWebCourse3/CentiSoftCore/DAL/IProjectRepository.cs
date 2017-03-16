using System.Collections.Generic;
using CentiSoftCore.MODELS;

namespace CentiSoftCore.DAL
{
    public interface IProjectRepository
    {
        void DeleteProject(int id, int clientId);
        List<Project> FindProjectOnClient(int clientId);
        List<Project> FindProjOnCusID(int cusId, int clientId);
        bool HasProjects(int id);
        List<Project> LoadAllProject(int clientId);
        Project LoadProject(int id, int clientId);
        void SaveProject(Project project);
    }
}