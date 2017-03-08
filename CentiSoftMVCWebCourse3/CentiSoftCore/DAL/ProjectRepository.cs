using CentiSoftCore.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentiSoftCore.DAL
{
    public class ProjectRepository : BaseRepository
    {
        public Project LoadProject(int id, int clientId)
        {
            return dbContext.Projects.Include(x => x.Customer).FirstOrDefault(x => x.Id == id && x.Customer.ClientId == clientId);
        }

        public List<Project> LoadAllProject()
        {
            return dbContext.Projects.ToList();
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

        public List<Project> FindProjectOnClient(int id)
        {
            return dbContext.Projects.Include(x => x.Customer).Where(x=> x.Customer.ClientId == id).ToList();
        }
    }
}
