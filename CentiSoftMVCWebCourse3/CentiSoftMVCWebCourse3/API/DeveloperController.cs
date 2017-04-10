using CentiSoftCore.BLL;
using CentiSoftCore.MODELS;
using CentiSoftMVCWebCourse3.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CentiSoftMVCWebCourse3.API
{
    public class DeveloperController : ApiController
    {
        //Lille ændring
        [Log]
        [HttpGet]
        public List<Developer> GetAllDevelopers()
        {
            IDeveloperFacade devFacade = new DeveloperFacade();
            return devFacade.LoadAllDev();
        }

        [Log]
        [HttpGet]
        public Developer GetDeveloper(int id)
        {
            IDeveloperFacade devFacade = new DeveloperFacade();
            return devFacade.LoadDev(id);
        }

        [Log]
        [HttpPost, HttpPut]
        public void PostDeveloper([FromBody] Developer developer)
        {
            IDeveloperFacade devFacade = new DeveloperFacade();
            devFacade.SaveDev(developer);
        }

        [Log]
        [HttpDelete]
        public void DeleteDeveloper(int id)
        {
            IDeveloperFacade devFacade = new DeveloperFacade();
            devFacade.DeleteDev(id);
        }
    }
}