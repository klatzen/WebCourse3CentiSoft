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
        public Project LoadProject(int id)
        {
            return dbContext.Projects.FirstOrDefault(x => x.Id == id);
        }

        public List<Project> LoadAllProject()
        {
            return dbContext.Projects.ToList();
        }
        public void SaveProject(Project project)
        {
            if (project.Id > 0)
            {
                Project tempProject = LoadProject(project.Id);
                tempProject.Name = project.Name;
                tempProject.DueDate = project.DueDate;
            }
            else
            {
                dbContext.Projects.Add(project);
            }
            dbContext.SaveChanges();
        }
        public void DeleteProject(int id)
        {
            Project project = LoadProject(id);
            dbContext.Projects.Remove(project);
            dbContext.SaveChanges();
        }
    }
}
