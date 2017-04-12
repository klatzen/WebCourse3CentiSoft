using CentiSoftCore.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace CentiSoftCore.DAL
{
    public class ProjectRepository : BaseRepository, IProjectRepository
    {
        public Project LoadProject(int id, int clientId)
        {
            return dbContext.Projects.Include(x=> x.Customer).FirstOrDefault(x => x.Id == id && x.Customer.ClientId == clientId);
        }

        public List<Project> LoadAllProject(int clientId)
        {
            return dbContext.Projects.Where(x => x.Customer.ClientId == clientId).ToList();
        }
        public void SaveProject(Project project)
        {
            if (project.Id > 0)
            {
                Project tempProject = LoadProject(project.Id, project.Customer.ClientId);
                tempProject.Name = project.Name;
                tempProject.DueDate = project.DueDate;
            }
            else
            {
                dbContext.Projects.Add(project);
            }
            dbContext.SaveChanges();
        }
        public void DeleteProject(int id, int clientId)
        {
            Project project = LoadProject(id, clientId);
            dbContext.Projects.Remove(project);
            dbContext.SaveChanges();
        }

        public bool HasProjects(int id)
        {
            bool hasProjects = false;
            List<Project> proj = dbContext.Projects.Where(x => x.CustomerId == id).ToList();
            if (proj != null) {
                hasProjects = true;
            }
            return hasProjects;
        }

        public List<Project> FindProjOnCusID(int cusId, int clientId)
        {
            List<Project> projList = dbContext.Projects.Where(x => x.CustomerId == cusId && x.Customer.ClientId == clientId).ToList();
            return projList;
        }

        public List<Project> FindProjectOnClient(int clientId)
        {
            return dbContext.Projects.Include(x => x.Customer).Where(x => x.Customer.ClientId == clientId).ToList();
        }
    }
}
