﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentiSoftCore.DAL
{
    public class TaskRepository : BaseRepository, ITaskRepository
    {
        public List<MODELS.Task> LoadAllTask()
        {
            return dbContext.Tasks.ToList();
        }
        public MODELS.Task LoadTask(int id)
        {
            return dbContext.Tasks.FirstOrDefault(x => x.Id == id);
        }
        public void SaveTask(MODELS.Task task)
        {
            if(task.Id > 0)
            {
                MODELS.Task tempTask = LoadTask(task.Id);
                tempTask.Name = task.Name;
                tempTask.Description = task.Description;
                tempTask.Duration = task.Duration;
            }
            else
            {
                dbContext.Tasks.Add(task);
            }
            dbContext.SaveChanges();
        }
        public void DeleteTask(int id)
        {
            MODELS.Task tempTask = LoadTask(id);
            dbContext.Tasks.Remove(tempTask);
            dbContext.SaveChanges();
        }

        public bool DevHasTasks(int id)
        {
            bool hasTasks = false;
            List<MODELS.Task> tasksOnDev = TasksOnDev(id);
            if(tasksOnDev != null)
            {
                hasTasks = true;
            }
            return hasTasks;
        }

        public List<MODELS.Task> TasksOnDev(int id)
        {
            return dbContext.Tasks.Where(x => x.DeveloperId == id).ToList();
        }

        public List<MODELS.Task> TasksOnProj(int id, int clientId)
        {
            return dbContext.Tasks.Where(x => x.ProjectId == id && x.Project.Customer.ClientId == clientId).ToList();
        }
    }
}
